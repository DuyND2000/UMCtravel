using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Service.Bookings;
using UMCTravelTour.Service.Customers;
using UMCTravelTour.Service.Tours;
using UMCTravelTour.ViewModel.Bookings;
using System.Threading.Tasks;
using UMCTravelTour.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using UMCTravelTour.Service.Locations;
using UMCTravelTour.Service.Hotels;
using UMCTravelTour.Service.Restaurants;
using UMCTravelTour.Web.Services;
using UMCTravelTour.Service.Rooms;
using UMCTravelTour.ViewModel.EmailTemplates;
using UMCTravelTour.Service.EmailTemplates;
using UMCTravelTour.Service.Comments;
using System.Linq;
using System;

namespace UMCTravelTour.Web.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IBookingService _bookingService;
        private readonly ICustomerService _customerService;
        private readonly ILocationService _locationService;
        private readonly IHotelService _hotelService;
        private readonly IRestaurantService _restaurantService;
        private readonly ITourDesignService _tourDesignService;
        private readonly IRoomService _roomService;
        private readonly IEmailTemplateSerice _emailTemplateSerice;

        public TourController(ITourService tourService, IBookingService bookingService,
            ICustomerService customerService, ILocationService locationService,
            IHotelService hotelService, IRestaurantService restaurantService,
            ITourDesignService tourDesignService, IRoomService roomService,
            IEmailTemplateSerice emailTemplateSerice)
        {
            _tourService = tourService;
            _bookingService = bookingService;
            _customerService = customerService;
            _locationService = locationService;
            _hotelService = hotelService;
            _restaurantService = restaurantService;
            _tourDesignService = tourDesignService;
            _roomService = roomService;
            _emailTemplateSerice = emailTemplateSerice;
        }

        public IActionResult Index(int showMore = 6)
        {
            var activeTours = _tourService.GetTourActiveAsync().Result.Take(showMore).AsEnumerable();

            ViewBag.TotalTour = _tourService.GetTourActiveAsync().Result.Count();
            return View(activeTours);
        }
        public JsonResult GetCustomerByPhoneAndEmail(string phone, string email)
        {
            var customer = _customerService.GetByPhoneAndEmail(phone, email);
            return Json(customer);
        }
        public async Task<ActionResult> TourDetail(int id, int showComment = 5)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Tour = await _tourService.GetByIdAsync(id);
            TempData["Duration"] = _tourService.GetByIdAsync(id).Result.Duration;
            if (showComment >= 5)
            {
                ViewBag.showComment = showComment;
            }
            else
            {
                ViewBag.showComment = 5;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookTour(BookingVm booking)
        {
            // booking.IsValidBooking = "false";
            ViewBag.isValidBooking = "false";
            booking.Status = Constant.StatusBooking.Pending;
            booking.Deposit = booking.ExpectedPrice * Constant.ServicePricePercentage;
            int day = 0;
            var duration = _tourService.GetByIdAsync(booking.TourId).Result.Duration;
            if (int.TryParse(duration.ToString().Substring(0,1), out day))
            {
                booking.EndDate = booking.StartDate.AddDays(day);
            }
            else if (int.TryParse(TempData["Duration"].ToString().Substring(0, 2), out day))
            {
                booking.EndDate = booking.StartDate.AddDays(day);
            }
            
            if (ModelState.IsValid)
            {
                var response = await _bookingService.AddAsync(booking);
                if (response.IsSuccess)
                {
                    //booking.IsValidBooking = "";
                    ViewBag.isValidBooking = "";
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
                else
                {
                    ModelState.AddModelError(string.Empty, response.ErrorMessage);
                }
            }
            ViewBag.Tour = await _tourService.GetByIdAsync(booking.TourId);
            return PartialView("_BookingPartial", booking);
        }
        public IActionResult TourDesign()
        {
            ViewBag.LocationList = new SelectList(_locationService.GetAll(), "LocationId", "LocationName");
            ViewBag.HotelList = _hotelService.GetAll();
            ViewBag.RestaurantList = _restaurantService.GetAll();
            ViewBag.RoomList = _roomService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult TourDesign(TourDesignViewModel tourDesign)
        {
            ViewBag.LocationList = new SelectList(_locationService.GetAll(), "LocationId", "LocationName");
            ViewBag.HotelList = _hotelService.GetAll();
            ViewBag.RestaurantList = _restaurantService.GetAll();
            ViewBag.RoomList = _roomService.GetAll();

            if (ModelState.IsValid)
            {
                if (tourDesign.EndDate.CompareTo(tourDesign.StartDate)<=0)
                {
                    TempData["DesignError"] = "An unexpected error has occurred";
                    return View(tourDesign);
                }    
                    if (_tourDesignService.ParseTourDesign(tourDesign))
                {

                    // gưi email cho khách hàng
                    var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.PendingTour);
                    var mailContent = new EmailTemplateVm();
                    mailContent.To = tourDesign.Email;
                    mailContent.CC = emailTemplate.CC;
                    mailContent.BCC = emailTemplate.BCC;
                    mailContent.Object = emailTemplate.Object;


                    var body = emailTemplate.Body;
                    body = body.Replace("##UserName##", tourDesign.CustomerName);
                    body = body.Replace("##Phone##", tourDesign.Phone);
                    body = body.Replace("##Email##", tourDesign.Email);
                    mailContent.Body = body;
                    var sendMailService = _emailTemplateSerice.SendGmail(mailContent);

                    //đặt thành công
                    TempData["DesignSuccess"] = "Tour designed successfully";
                    return View();

                }
                else
                {
                    TempData["DesignError"] = "An unexpected error has occurred";
                    return View(tourDesign);
                }
            }
            TempData["DesignError"] = "An unexpected error has occurred";
            return View(tourDesign);
        }
    }
}
