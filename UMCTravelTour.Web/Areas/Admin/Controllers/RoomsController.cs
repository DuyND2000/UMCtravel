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
using UMCTravelTour.Service.Rooms;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.ViewModel.Rooms;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Constant.Role.Administrator + ", " + Constant.Role.Manager)]
    public class RoomsController : BaseController
    {
        private readonly IRoomService _roomService;
        private readonly IHotelService _hotelService;

        public RoomsController(IRoomService roomService, IHotelService hotelService, IWebHostEnvironment webHostEnvironment)
        : base(webHostEnvironment)
        {
            _roomService = roomService;
            _hotelService = hotelService;
        }

        // GET: Admin/Rooms
        public IActionResult Index(FilterPaging filterPaging)
        {
            ViewBag.FilterPaging = filterPaging;
            var data = _roomService.GetPaging(filterPaging);
            return View(data);
        }

        public async Task<IActionResult> Filter(string name)
        {

            var listRooms = await _roomService.GetAllAsync();

            listRooms = listRooms.Where(x => x.RoomName.Contains(name));

            return View("Index", listRooms);
        }

        // GET: Admin/Rooms/Details/5
        public async Task<IActionResult> Details(int? id, int? id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _roomService.GetByIdAsync(id.Value, id2.Value);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Admin/Rooms/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_hotelService.GetAll(), "HotelId", "HotelName");
            return View();
        }

        // POST: Admin/Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomVm roomVm, IFormFile image)
        {
            ViewBag.Error = "";
            if (ModelState.IsValid)
            {
                if (!_roomService.CheckRoomIdInHotel(roomVm.HotelId, roomVm.RoomId))
                {
                    ViewBag.Error = "Oops! Room ID is existed";
                }
                else
                {
                    if (image != null)
                    {
                        roomVm.ImageLink = GetUrl(image, ImageFolderSystem.RoomImageFolder(roomVm.HotelId, roomVm.RoomId));
                    }
                    await _roomService.AddAsync(roomVm);
                    return RedirectToAction(nameof(Index));
                }       
            }
            ViewData["HotelId"] = new SelectList(_hotelService.GetAll(), "HotelId", "HotelName", roomVm.HotelId);

            return View(roomVm);
        }

        // GET: Admin/Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id, int? id2)
        {
            if (id == null && id2 == null)
            {
                return NotFound();
            }

            var room = await _roomService.GetByIdAsync(id.Value, id2.Value);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_hotelService.GetAll(), "HotelId", "HotelName", room.HotelId);
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int id2, RoomVm roomVm, IFormFile image)
        {
            //if (id != roomVm.HotelId && id2 != roomVm.RoomId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null)
                    {
                        roomVm.ImageLink = GetUrl(image, ImageFolderSystem.RoomImageFolder(roomVm.HotelId, roomVm.RoomId));
                    }
                    await _roomService.UpdateAsync(roomVm);
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_hotelService.GetAll(), "HotelId", "HotelName", roomVm.HotelId);
            return View(roomVm);
        }

        // GET: Admin/Rooms/Delete/5
        [HttpPost]
        [Authorize(Roles = Constant.Role.Administrator)]
        public async Task<IActionResult> Delete(int? id, int? id2)
        {
            await _roomService.DeleteAsync(id.Value, id2.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
