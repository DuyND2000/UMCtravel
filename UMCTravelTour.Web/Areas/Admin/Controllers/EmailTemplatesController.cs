using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.Service.EmailTemplates;
using UMCTravelTour.ViewModel.EmailTemplates;
using UMCTravelTour.ViewModel.Pages;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Constant.Role.Administrator + ", " + Constant.Role.Manager)]
    public class EmailTemplatesController : BaseController
    {
        private readonly IEmailTemplateSerice _emailTemplateSerice;

        public EmailTemplatesController(IEmailTemplateSerice emailTemplateSerice, IWebHostEnvironment webHostEnvironment)
        : base(webHostEnvironment)
        {
            _emailTemplateSerice = emailTemplateSerice;
        }

        // GET: Admin/EmailTemplates
        public  IActionResult Index(FilterPaging filterPaging)
        {
            ViewBag.FilterPaging = filterPaging;
            var data = _emailTemplateSerice.GetPaging(filterPaging);
            return View(data);
        }

        // GET: Admin/EmailTemplates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _emailTemplateSerice.GetByIdAsync(id.Value);

            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // GET: Admin/EmailTemplates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/EmailTemplates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmailTemplateVm emailTemplateVm)
        {
            if (ModelState.IsValid)
            {
               
                await _emailTemplateSerice.AddAsync(emailTemplateVm);
                return RedirectToAction(nameof(Index));
            }

            return View(emailTemplateVm);
        }

        // GET: Admin/EmailTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _emailTemplateSerice.GetByIdAsync(id.Value);
            if (email == null)
            {
                return NotFound();
            }
            return View(email);
        }

        // POST: Admin/EmailTemplates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmailTemplateVm emailTemplateVm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _emailTemplateSerice.UpdateAsync(emailTemplateVm);
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));

            }
            return View(emailTemplateVm);
        }

        [Authorize(Roles = Constant.Role.Administrator)]
            [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            await _emailTemplateSerice.DeleteAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }

      


    }
}
