using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.Service.Hotels;
using UMCTravelTour.Service.Locations;
using UMCTravelTour.Service.Restaurants;
using UMCTravelTour.Service.Tours;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.ViewModel.Restaurants;
using UMCTravelTour.ViewModel.Tours;
using Newtonsoft.Json;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Constant.Role.Administrator + ", " + Constant.Role.Manager)]
    public class ToursController : BaseController
    {
        private readonly ITourService _tourService;
        private readonly IHotelService _hotelService;
        private readonly IRestaurantService _restaurantService;
        private readonly ILocationService _locationService;

        public ToursController(ITourService tourService, IHotelService hotelService, IRestaurantService restaurantService, ILocationService locationService, IWebHostEnvironment webHostEnvironment) : base(webHostEnvironment)
        {
            _tourService = tourService;
            _hotelService = hotelService;
            _restaurantService = restaurantService;
            _locationService = locationService;
        }

        // GET: Admin/Tours
        public IActionResult Index(FilterPaging filterPaging)
        {
            ViewBag.FilterPaging = filterPaging;
            var data = _tourService.GetPaging(filterPaging);
            return View(data);
        }

        // GET: Admin/Tours/Create/3
        public IActionResult Create(int locationId)
        {
            if(locationId != 0)
            {
                ViewBag.locationId = locationId;
                ViewBag.locationName = _locationService.GetByIdAsync(locationId).Result.LocationName;
                return View();
            }
            return RedirectToAction("Index", "Location");
        }

        // POST: Admin/Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TourVm tour, IFormFile tourImage)
        {
            if(tour.restaurantId == null ||tour.HotelId == 0 || tour.restaurantId.Count < 1)
            {
                ViewData["HotelId"] = new SelectList(_hotelService.GetAll(), "HotelId", "HotelName", tour.HotelId);
                ModelState.AddModelError(nameof(tour.restaurantId),"Hotels or restaurants cannot be empty");
                return View(tour);
            }

            if (ModelState.IsValid)
            {
                if (tourImage != null)
                {
                    tour.ImageLink = GetUrl(tourImage,ImageFolderSystem.TourImageFolder(tour.TourId));
                }
                await _tourService.AddAsync(tour);
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_hotelService.GetAll(), "HotelId", "HotelName", tour.HotelId);
            //ViewData["RestaurantId"] = new SelectList(_restaurantService.GetAll(), "RestaurantId", "RestaurantName", tour.RestaurantId);
            return View(tour);
        }

        // GET: Admin/Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tour = await _tourService.GetByIdAsync(id.Value);

            var locationId = _locationService.GetByIdAsync(_hotelService.GetByIdAsync(tour.HotelId).Result.LocationId).Result.LocationId;
            if (locationId != 0)
            {
                ViewBag.locationId = locationId;
                ViewBag.locationName = _locationService.GetByIdAsync(locationId).Result.LocationName;
            }
            ViewBag.restaurants =JsonConvert.SerializeObject(_restaurantService.GetRestaurantsByTourId(id.Value).ToList());

            if (tour == null)
            {
                return NotFound();
            }
         //  ViewData["HotelId"] = new SelectList(_hotelService.GetAll(), "HotelId", "HotelName", tour.HotelId);
            return View(tour);
        }

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TourVm tour, IFormFile tourImage)
        {
            //if (id != tour.TourId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    if (tourImage != null)
                    {
                        tour.ImageLink = GetUrl(tourImage, ImageFolderSystem.TourImageFolder(tour.TourId));
                    }
                    await _tourService.UpdateAsync(tour);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["HotelId"] = new SelectList(_hotelService.GetAll(), "HotelId", "HotelName", tour.HotelId);*/
            //ViewData["RestaurantId"] = new SelectList(_restaurantService.GetAll(), "RestaurantId", "RestaurantName", tour.RestaurantId);
            return View(tour);
        }

        // POST: Admin/Tours/Delete/5
        [HttpPost]
        [Authorize(Roles = Constant.Role.Administrator)]
        public async Task<IActionResult> Delete(int id)
        {
            await _tourService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
