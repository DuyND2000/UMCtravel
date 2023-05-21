using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.Service.Hotels;
using UMCTravelTour.Service.Locations;
using UMCTravelTour.ViewModel.Hotels;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Constant.Role.Administrator + ", " + Constant.Role.Manager)]
    public class HotelController : BaseController
    {
        private readonly IHotelService _hotelService;
        private readonly ILocationService _locationService;

        public HotelController(IHotelService hotelService, ILocationService locationService, IWebHostEnvironment webHostEnvironment)
        :base(webHostEnvironment)
        {
            _hotelService = hotelService;
            _locationService = locationService;
        }

        // GET: Admin/Hotel
        public IActionResult Index(FilterPaging filterPaging)
        {

            ViewBag.FilterPaging = filterPaging;
            
            var data = _hotelService.GetPaging(filterPaging);
            return View(data);
        }

        // GET: Admin/Hotel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _hotelService.GetByIdAsync(id.Value);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Admin/Hotel/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_locationService.GetAll(), "LocationId", "LocationName");
            return View();
        }

        // POST: Admin/Hotel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelVm hotel, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    // Nhớ truyền vào không có / ở đầu với cuối
                    hotel.ImageLink = GetUrl(image,ImageFolderSystem.HotelImageFolder(hotel.HotelId));
                }
                await _hotelService.AddAsync(hotel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_locationService.GetAll(), "LocationId", "LocationName", hotel.LocationId);
            return View(hotel);
        }

        // GET: Admin/Hotel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _hotelService.GetByIdAsync(id.Value);
            if (hotel == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_locationService.GetAll(), "LocationId", "LocationName", hotel.LocationId);
            return View(hotel);
        }

        // POST: Admin/Hotel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HotelVm hotel, IFormFile image)
        {
            //if (id != hotel.HotelId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null)
                    {
                        hotel.ImageLink = GetUrl(image, ImageFolderSystem.HotelImageFolder(hotel.HotelId));
                    }
                    await _hotelService.UpdateAsync(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_locationService.GetAll(), "LocationId", "LocationName", hotel.LocationId);
            return View(hotel);
        }


        // POST: Admin/Hotel/Delete/5
        [HttpPost]
        [Authorize(Roles = Constant.Role.Administrator)]
        public async Task<IActionResult> Delete(int id)
        { 
            var response = await _hotelService.DeleteAsync(id);
            if (response.IsSuccess)
            {
                TempData["DeleteSuccess"] = Constant.DeletedMessage.DeleteSuccess;
            }
            else
            {
                TempData["DeleteError"] = response.ErrorMessage;
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
