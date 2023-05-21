using System;
using System.Collections.Generic;
using System.IO;
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
using UMCTravelTour.Service.Locations;
using UMCTravelTour.Service.Restaurants;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.ViewModel.Restaurants;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Constant.Role.Administrator + ", " + Constant.Role.Manager)]
    public class RestaurantsController : BaseController
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ILocationService _locationService;

        public RestaurantsController(IRestaurantService restaurantService, IWebHostEnvironment webHostEnvironment, ILocationService locationService) : base(webHostEnvironment)
        {
            _restaurantService = restaurantService;
            _locationService = locationService;
        }

        // GET: Admin/Restaurants
        public IActionResult Index(FilterPaging filterPaging)
        {
            ViewBag.FilterPaging = filterPaging;

            var data = _restaurantService.GetPaging(filterPaging);
            return View(data);
        }

        // GET: Admin/Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetByIdAsync(id.Value);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Admin/Restaurants/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_locationService.GetAll(), "LocationId", "LocationName");
            return View();
        }

        // POST: Admin/Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( RestaurantVm restaurant, IFormFile restaurantImage)
        {
            if (ModelState.IsValid)
            {
                if (restaurantImage != null)
                {
                    restaurant.ImageLink = GetUrl(restaurantImage,ImageFolderSystem.RestaurantImageFolder(restaurant.RestaurantId));
                }
                await _restaurantService.AddAsync(restaurant);
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_locationService.GetAll(), "LocationId", "LocationName", restaurant.LocationId);
            return View(restaurant);
        }

        // GET: Admin/Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetByIdAsync(id.Value);
            if (restaurant == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_locationService.GetAll(), "LocationId", "LocationName", restaurant.LocationId);
            return View(restaurant);
        }

        // POST: Admin/Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RestaurantVm restaurant, IFormFile restaurantImage)
        {
            //if (id != restaurant.RestaurantId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    if (restaurantImage != null)
                    {
                        restaurant.ImageLink = GetUrl(restaurantImage, ImageFolderSystem.RestaurantImageFolder(restaurant.RestaurantId));
                    }
                    await _restaurantService.UpdateAsync(restaurant);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_locationService.GetAll(), "LocationId", "LocationName", restaurant.LocationId);
            return View(restaurant);
        }

        // GET: Admin/Restaurants/Delete/5


        [HttpPost]
        [Authorize(Roles = Constant.Role.Administrator)]
        public async Task<IActionResult> Delete(int id)
        {
            await _restaurantService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
