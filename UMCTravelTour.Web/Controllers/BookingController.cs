﻿using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Service.Bookings;
using UMCTravelTour.Service.Customers;
using UMCTravelTour.ViewModel.Bookings;
using UMCTravelTour.ViewModel.Customers;
using System.Threading.Tasks;

namespace UMCTravelTour.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ICustomerService _customerService;
        public BookingController(IBookingService bookingService, ICustomerService customerService)
        {
            _bookingService = bookingService;
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            CustomerVm currentUser = null;
            if (HttpContext.User.Identity.Name != null)
            {
                currentUser = await _customerService.GetByUserNameAsync(HttpContext.User.Identity.Name);
            }
            if(currentUser != null)
            {
                var data = await _bookingService.GetByCustomerId(currentUser.CustomerId);
                return View(data);
            }
            return View("You dont have any booking! Let Book now");
        }
        public async Task<IActionResult> Tracking(int bookingId)
        {
            var data = await _bookingService.GetByIdAsync(bookingId);
            return View(data);
        }
    }
}
