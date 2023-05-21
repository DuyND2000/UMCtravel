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
using UMCTravelTour.Service.Locations;
using UMCTravelTour.ViewModel.Locations;
using UMCTravelTour.ViewModel.Pages;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    public class LocationController : BaseController
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService, IWebHostEnvironment webHostEnvironment) : base(webHostEnvironment)
        {
            _locationService = locationService;
        }

        // GET: Admin/Locations
        public IActionResult Index(FilterPaging filterPaging)
        {
            ViewBag.FilterPaging = filterPaging;
            var data = _locationService.GetPaging(filterPaging);
            return View(data);
        }

        // GET: Admin/Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _locationService.GetByIdAsync(id.Value);

            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Admin/Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LocationVm location,IFormFile ImageLink)
        {
            if (ModelState.IsValid)
            {
                if(ImageLink != null)
                {
                    // Nhớ truyền vào không có / ở đầu với cuối
                    location.ImageLink = GetUrl(ImageLink, ImageFolderSystem.LocationImageFolder(location.LocationId));
                }    
                await _locationService.AddAsync(location);
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Admin/Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _locationService.GetByIdAsync(id.Value);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Admin/Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LocationVm location, IFormFile ImageLink)
        {
            //if (id != location.LocationId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    if (ImageLink != null)
                    {
                        location.ImageLink = GetUrl(ImageLink, ImageFolderSystem.LocationImageFolder(location.LocationId));
                    }
                    await _locationService.UpdateAsync(location);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // POST: Admin/Locations/Delete/5
        [HttpPost]
        [Authorize(Roles = Constant.Role.Administrator)]
        public async Task<IActionResult> Delete(int id)
        {
            await _locationService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
