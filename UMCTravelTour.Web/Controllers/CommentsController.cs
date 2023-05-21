using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.Service.Comments;
using UMCTravelTour.ViewModel.Comments;

namespace UMCTravelTour.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        { 
            _commentService = commentService;
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommentVm commentVm, int tourId)
        {
            var comments = _commentService.GetAll().Where(c => c.TourId == tourId);
            if(comments.Any(c => c.CustomerId == commentVm.CustomerId))
            {
                commentVm.RatePoint = comments.FirstOrDefault(c => c.CustomerId == commentVm.CustomerId).RatePoint;
            }

            if (ModelState.IsValid)
            {
                await _commentService.AddAsync(commentVm);
            }
            return RedirectToAction("TourDetail", "Tour", new { id = tourId });
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CommentVm commentVm, int tourId)
        {
            if (id != commentVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _commentService.UpdateAsync(commentVm);
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }
            }
            return RedirectToAction("TourDetail", "Tour", new { id = tourId });
        }

        // POST: Comments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int tourId)
        {
            await _commentService.DeleteAsync(id);
            return RedirectToAction("TourDetail", "Tour", new { id = tourId });
        }
    }
}
