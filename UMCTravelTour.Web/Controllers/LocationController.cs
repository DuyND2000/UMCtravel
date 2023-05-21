using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Core.Models;
using UMCTravelTour.Service.Hotels;
using UMCTravelTour.Service.Locations;
using UMCTravelTour.Service.Restaurants;
using UMCTravelTour.ViewModel.Hotels;
using UMCTravelTour.ViewModel.Locations;
using UMCTravelTour.ViewModel.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMCTravelTour.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IHotelService _hotelService;
        private readonly IRestaurantService _restaurantService;

        public LocationController(ILocationService locationService, IHotelService hotelService, IRestaurantService restaurantService)
        {
            _locationService = locationService;
            _hotelService = hotelService;
            _restaurantService = restaurantService;
        }

        public IActionResult Index()
        {
            var locations = _locationService.GetAll();
            return View(locations.ToList());
        }
        public async Task<IActionResult> Detail(int locationId)
        {
            var location = await _locationService.GetByIdAsync(locationId);
            ViewBag.Location = location.LocationName;

            #region Lottery
            var locations = _locationService.GetAll().ToList();
            var hotels = _hotelService.GetAll().ToList();
            var restaurants = _restaurantService.GetAll().ToList();
            List<LocationVm> locationVms = new List<LocationVm>();
            List<HotelVm> hotelVms = new List<HotelVm>();
            List<RestaurantVm> restaurantVms = new List<RestaurantVm>();

            Random rd = new Random();
            for(int i = 0; i< 2; i++)
            {
                locationVms.Add(locations[rd.Next(0, locations.Count())]);
            }
            for (int i = 0; i < 2; i++)
            {
                hotelVms.Add(hotels[rd.Next(0, hotels.Count())]);
            }
            for (int i = 0; i < 2; i++)
            {
                restaurantVms.Add(restaurants[rd.Next(0, restaurants.Count())]);
            }

            ViewBag.LocationList = locationVms;
            ViewBag.HotelList = hotelVms;
            ViewBag.RestaurantList = restaurantVms;
            #endregion

            return View(location);
        }
    }
}
