using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.Service.Bookings;
using UMCTravelTour.Service.Customers;
using UMCTravelTour.Service.EmailTemplates;
using UMCTravelTour.Service.Rooms;
using UMCTravelTour.Service.Tours;
using UMCTravelTour.ViewModel.Bookings;
using UMCTravelTour.ViewModel.EmailTemplates;
using UMCTravelTour.ViewModel.Pages;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    public class BookingsController : BaseController
    {
        private readonly IBookingService _bookingService;
        private readonly ICustomerService _customerService;
        private readonly ITourService _tourService;
        private readonly IEmailTemplateSerice _emailTemplateSerice;
        private readonly IRoomService _roomService;

        public BookingsController(IBookingService bookingService, ITourService tourService, ICustomerService customerService, IEmailTemplateSerice emailTemplateSerice, IRoomService roomService)
        {
            _bookingService = bookingService;
            _customerService = customerService;
            _tourService = tourService;
            _emailTemplateSerice = emailTemplateSerice;
            _roomService = roomService;
        }

        // GET: Admin/Bookings
        public IActionResult Index(FilterPaging filterPaging)
        {
            ViewBag.FilterPaging = filterPaging;
            /*ViewBag.countPending = _bookingService.GetAllAsync();
            ViewBag.countUnpaid = _bookingService.GetByStatus(filterPaging, Constant.StatusBooking.Unpaid).Data.Count();
            ViewBag.countActive = _bookingService.GetByStatus(filterPaging, Constant.StatusBooking.Active).Data.Count();
            ViewBag.countCancalled = _bookingService.GetByStatus(filterPaging, Constant.StatusBooking.Cancelled).Data.Count();
            ViewBag.countOverdue = _bookingService.GetByStatus(filterPaging, Constant.StatusBooking.Overdue).Data.Count();*/
            var data = _bookingService.GetPaging(filterPaging);
            /*ViewBag.count = data.Data.Count();*/
            return View(data);
        }
        public IActionResult GetByStatus(string status, FilterPaging filterPaging)
        {
            ViewBag.FilterPaging = filterPaging;
            var data = _bookingService.GetByStatus(filterPaging, status);
            return View("Index", data);
        }
        // GET: Admin/Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var booking = await _bookingService.GetByIdAsync(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Admin/Bookings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_customerService.GetAll(), "CustomerId", "CustomerName");
            ViewData["TourId"] = new SelectList(_tourService.GetAll(), "TourId", "TourName");
            ViewData["RoomId"] = new SelectList(_roomService.GetAll(), "RoomId", "RoomName");
            return View();
        }


        // POST: Admin/Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingVm booking)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (booking.RoomId == 0 || _roomService.GetAll()
                        .FirstOrDefault(x => x.HotelId == _tourService.GetById(booking.TourId).HotelId && x.RoomId == booking.RoomId) == null)
                        return View(booking);
                    var price = booking.TourParticipantCount
                    * _roomService.GetAll()
                        .FirstOrDefault(x => x.HotelId == _tourService.GetById(booking.TourId).HotelId && x.RoomId == booking.RoomId)
                        .Price
                    * booking.EndDate.Subtract(booking.StartDate).Days;
                    booking.ExpectedPrice = price * (1 + Constant.ServicePricePercentage);
                    booking.Deposit = price * Constant.ServicePricePercentage;
                }
                catch
                {
                    return View(booking);
                }
                booking.Status = Constant.StatusBooking.Pending;
                await _bookingService.AddAsync(booking);
                // gưi email cho khách hàng
                var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.PendingTour);
                var mailContent = new EmailTemplateVm();
                mailContent.To = booking.Customer.Email;
                mailContent.CC = emailTemplate.CC;
                mailContent.BCC = emailTemplate.BCC;
                mailContent.Object = emailTemplate.Object;


                var body = emailTemplate.Body;
                body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                body = body.Replace("##UserName##", booking.Customer.CustomerName);
                mailContent.Body = body;
                var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
                return RedirectToAction(nameof(Index));
            }


            ViewData["CustomerId"] = new SelectList(_customerService.GetAll(), "CustomerId", "Address", booking.CustomerId);
            ViewData["TourId"] = new SelectList(_tourService.GetAll(), "TourId", "TourName", booking.TourId);
            ViewData["RoomId"] = new SelectList(_roomService.GetAll(), "RoomId", "RoomName", booking.RoomId);
            return View(booking);
        }

        // GET: Admin/Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _bookingService.GetByIdAsync(id.Value);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_customerService.GetAll(), "CustomerId", "CustomerName", booking.CustomerId);
            ViewData["TourId"] = new SelectList(_tourService.GetAll(), "TourId", "TourName", booking.TourId);
            ViewData["RoomId"] = new SelectList(_roomService.GetAll(), "RoomId", "RoomName", booking.RoomId);
            return View(booking);
        }


        // POST: Admin/Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookingVm booking)
        {
            //if (id != booking.BookingId)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {
                try
                {
                    if (booking.RoomId == 0 || _roomService.GetAll()
                        .FirstOrDefault(x => x.HotelId == _tourService.GetById(booking.TourId).HotelId && x.RoomId == booking.RoomId) == null)
                        return View(booking);
                    var price = booking.TourParticipantCount
                    * _roomService.GetAll()
                        .FirstOrDefault(x => x.HotelId == _tourService.GetById(booking.TourId).HotelId && x.RoomId == booking.RoomId)
                        .Price
                    * booking.EndDate.Subtract(booking.StartDate).Days;
                    booking.ExpectedPrice = price * (1 + Constant.ServicePricePercentage);
                    booking.Deposit = price * Constant.ServicePricePercentage;
                    await _bookingService.UpdateAsync(booking);
                }
                catch
                {
                    return View(booking);
                }

                if (booking.Status == Constant.StatusBooking.Approved)
                {
                    // gưi email cho khách hàng
                    var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.BookingSuccess);
                    var mailContent = new EmailTemplateVm();
                    mailContent.To = booking.Customer.Email;
                    mailContent.CC = emailTemplate.CC;
                    mailContent.BCC = emailTemplate.BCC;
                    mailContent.Object = emailTemplate.Object;

                    var body = emailTemplate.Body;
                    body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    body = body.Replace("##UserName##", booking.Customer.CustomerName);
                    body = body.Replace("##Matracuu##", booking.BookingId.ToString());
                    body = body.Replace("##StartTour##", booking.StartDate.ToString("dd/MM/yyyy"));
                    body = body.Replace("##EndTour##", booking.EndDate.ToString("dd/MM/yyyy"));
                    body = body.Replace("##Giatien##", "$" + booking.ExpectedPrice.ToString());


                    mailContent.Body = body;
                    var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
                }
                if (booking.Status == Constant.StatusBooking.Completed)
                {
                    // gưi email cho khách hàng
                    var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.ThankYou);
                    var mailContent = new EmailTemplateVm();
                    mailContent.To = booking.Customer.Email;
                    mailContent.CC = emailTemplate.CC;
                    mailContent.BCC = emailTemplate.BCC;
                    mailContent.Object = emailTemplate.Object;
                    var body = emailTemplate.Body;
                    body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    body = body.Replace("##UserName##", booking.Customer.CustomerName);
                    mailContent.Body = body;
                    var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
                }
                if (booking.Status == Constant.StatusBooking.Cancelled)
                {

                    // gưi email cho khách hàng
                    var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.TourCancel);
                    var mailContent = new EmailTemplateVm();
                    mailContent.To = booking.Customer.Email;
                    mailContent.CC = emailTemplate.CC;
                    mailContent.BCC = emailTemplate.BCC;
                    mailContent.Object = emailTemplate.Object;


                    var body = emailTemplate.Body;
                    body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    body = body.Replace("##UserName##", booking.Customer.CustomerName);

                    mailContent.Body = body;
                    var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
                }
                if (booking.Status == Constant.StatusBooking.Deposited)
                {
                    // gưi email cho khách hàng
                    var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.PaymentSuccess);
                    var mailContent = new EmailTemplateVm();
                    mailContent.To = booking.Customer.Email;
                    mailContent.CC = emailTemplate.CC;
                    mailContent.BCC = emailTemplate.BCC;
                    mailContent.Object = emailTemplate.Object;


                    var body = emailTemplate.Body;
                    body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    body = body.Replace("##UserName##", booking.Customer.CustomerName);
                    body = body.Replace("##MaThanhToan##", booking.BookingId.ToString());
                    body = body.Replace("##TongTien##", "$" + booking.Deposit.ToString());
                    mailContent.Body = body;
                    var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
                }
                if (booking.Status == Constant.StatusBooking.Pending)
                {
                    // gưi email cho khách hàng
                    var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.PendingTour);
                    var mailContent = new EmailTemplateVm();
                    mailContent.To = booking.Customer.Email;
                    mailContent.CC = emailTemplate.CC;
                    mailContent.BCC = emailTemplate.BCC;
                    mailContent.Object = emailTemplate.Object;


                    var body = emailTemplate.Body;
                    body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    body = body.Replace("##UserName##", booking.Customer.CustomerName);
                    mailContent.Body = body;
                    var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
                }

                return RedirectToAction(nameof(Index));
            }


            ViewData["CustomerId"] = new SelectList(_customerService.GetAll(), "CustomerId", "CustomerName", booking.CustomerId);
            ViewData["TourId"] = new SelectList(_tourService.GetAll(), "TourId", "TourId", booking.TourId);
            ViewData["RoomId"] = new SelectList(_roomService.GetAll(), "RoomId", "RoomName", booking.RoomId);
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            await _bookingService.ChangeStatus(id, status);

            var booking = await _bookingService.GetByIdAsync(id);


            var customer = await _customerService.GetByIdAsync(booking.CustomerId);

            if (booking.Status == Constant.StatusBooking.Approved)
            {
                // gưi email cho khách hàng
                var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.BookingSuccess);
                var mailContent = new EmailTemplateVm();
                mailContent.To = customer.Email;
                mailContent.CC = emailTemplate.CC;
                mailContent.BCC = emailTemplate.BCC;
                mailContent.Object = emailTemplate.Object;

                var body = emailTemplate.Body;
                body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                body = body.Replace("##UserName## ", customer.CustomerName);
                body = body.Replace("##Matracuu##", booking.BookingId.ToString());
                body = body.Replace("##StartTour##", booking.StartDate.ToString("dd/MM/yyyy"));
                body = body.Replace("##EndTour##", booking.EndDate.ToString("dd/MM/yyyy"));
                body = body.Replace("##Giatien##", "$" + booking.ExpectedPrice.ToString());


                mailContent.Body = body;
                var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
            }
            if (booking.Status == Constant.StatusBooking.Completed)
            {
                // gưi email cho khách hàng
                var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.ThankYou);
                var mailContent = new EmailTemplateVm();
                mailContent.To = customer.Email;
                mailContent.CC = emailTemplate.CC;
                mailContent.BCC = emailTemplate.BCC;
                mailContent.Object = emailTemplate.Object;
                var body = emailTemplate.Body;
                body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                body = body.Replace("##UserName##", customer.CustomerName);
                mailContent.Body = body;
                var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
            }
            if (booking.Status == Constant.StatusBooking.Cancelled)
            {

                // gưi email cho khách hàng
                var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.TourCancel);
                var mailContent = new EmailTemplateVm();
                mailContent.To = customer.Email;
                mailContent.CC = emailTemplate.CC;
                mailContent.BCC = emailTemplate.BCC;
                mailContent.Object = emailTemplate.Object;


                var body = emailTemplate.Body;
                body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                body = body.Replace("##UserName##", customer.CustomerName);

                mailContent.Body = body;
                var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
            }


            if (booking.Status == Constant.StatusBooking.Deposited)
            {
                // gưi email cho khách hàng
                var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.PaymentSuccess);
                var mailContent = new EmailTemplateVm();
                mailContent.To = customer.Email;
                mailContent.CC = emailTemplate.CC;
                mailContent.BCC = emailTemplate.BCC;
                mailContent.Object = emailTemplate.Object;


                var body = emailTemplate.Body;
                body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                body = body.Replace("##UserName##", customer.CustomerName);
                body = body.Replace("##MaThanhToan##", booking.BookingId.ToString());
                body = body.Replace("##TongTien##", "$" + booking.Deposit.ToString());
                mailContent.Body = body;
                var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
            }
            if (booking.Status == Constant.StatusBooking.Pending)
            {
                // gưi email cho khách hàng
                var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.PendingTour);
                var mailContent = new EmailTemplateVm();
                mailContent.To = customer.Email;
                mailContent.CC = emailTemplate.CC;
                mailContent.BCC = emailTemplate.BCC;
                mailContent.Object = emailTemplate.Object;


                var body = emailTemplate.Body;
                body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                body = body.Replace("##UserName##", customer.CustomerName);
                mailContent.Body = body;
                var sendMailService = _emailTemplateSerice.SendGmail(mailContent);


            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = Constant.Role.Administrator)]
        // GET: Admin/Bookings/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
