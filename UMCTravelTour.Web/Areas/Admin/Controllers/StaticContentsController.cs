using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Constant.Role.Administrator + ", " + Constant.Role.Manager)]
    public class StaticContentsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaticContentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/StaticContents
        public async Task<IActionResult> Index(string id = "en")
        {
            return View(_unitOfWork.StaticContentRepository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("LanguageCode,NavigationHome,NavigationExplore,NavigationTour,NavigationTourDesign,NavigationHotel,NavigationDestination,NavigationRestaurant,NavigationAbout,NavigationAboutTermsAndConditions,NavigationAboutPrivacyPolicy,NavigationContact,NavigationLogin,NavigationFacebookLink,NavigationTwitterLink,GreatWord,DynamicWord1,DynamicWord2,DynamicWord3,Quote,QuoteAuthor,FooterDescriptionTitle,FooterDescription,FooterLink,FooterLinkText,FooterTermsAndConditions,FooterPrivacyPolicy,FooterTool1Link,FooterTool1Text,FooterTool2Link,FooterTool2Text,FooterTool3Link,FooterTool3Text,FooterAffiliate1Link,FooterAffiliate1Text,FooterAffiliate2Link,FooterAffiliate2Text,FooterAffiliate3Link,FooterAffiliate3Text,FooterCopyright")] StaticContent staticContent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.StaticContentRepository.Update(staticContent);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(staticContent);
        }

        // GET: Admin/StaticContents/Details/5
        /*public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticContent = await _context.StaticContents
                .FirstOrDefaultAsync(m => m.LanguageCode == id);
            if (staticContent == null)
            {
                return NotFound();
            }

            return View(staticContent);
        }

        // GET: Admin/StaticContents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/StaticContents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LanguageCode,NavigationHome,NavigationExplore,NavigationTour,NavigationTourDesign,NavigationHotel,NavigationDestination,NavigationRestaurant,NavigationAbout,NavigationAboutTermsAndConditions,NavigationAboutPrivacyPolicy,NavigationContact,NavigationLogin,NavigationFacebookLink,NavigationTwitterLink,FooterDescriptionTitle,FooterDescription,FooterLink,FooterLinkText,FooterTermsAndConditions,FooterPrivacyPolicy,FooterTool1Link,FooterTool1Text,FooterTool2Link,FooterTool2Text,FooterTool3Link,FooterTool3Text,FooterAffiliate1Link,FooterAffiliate1Text,FooterAffiliate2Link,FooterAffiliate2Text,FooterAffiliate3Link,FooterAffiliate3Text,FooterCopyright")] StaticContent staticContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staticContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staticContent);
        }

        // GET: Admin/StaticContents/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticContent = await _context.StaticContents.FindAsync(id);
            if (staticContent == null)
            {
                return NotFound();
            }
            return View(staticContent);
        }

        // POST: Admin/StaticContents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LanguageCode,NavigationHome,NavigationExplore,NavigationTour,NavigationTourDesign,NavigationHotel,NavigationDestination,NavigationRestaurant,NavigationAbout,NavigationAboutTermsAndConditions,NavigationAboutPrivacyPolicy,NavigationContact,NavigationLogin,NavigationFacebookLink,NavigationTwitterLink,FooterDescriptionTitle,FooterDescription,FooterLink,FooterLinkText,FooterTermsAndConditions,FooterPrivacyPolicy,FooterTool1Link,FooterTool1Text,FooterTool2Link,FooterTool2Text,FooterTool3Link,FooterTool3Text,FooterAffiliate1Link,FooterAffiliate1Text,FooterAffiliate2Link,FooterAffiliate2Text,FooterAffiliate3Link,FooterAffiliate3Text,FooterCopyright")] StaticContent staticContent)
        {
            if (id != staticContent.LanguageCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staticContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaticContentExists(staticContent.LanguageCode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(staticContent);
        }

        // GET: Admin/StaticContents/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticContent = await _context.StaticContents
                .FirstOrDefaultAsync(m => m.LanguageCode == id);
            if (staticContent == null)
            {
                return NotFound();
            }

            return View(staticContent);
        }

        // POST: Admin/StaticContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var staticContent = await _context.StaticContents.FindAsync(id);
            _context.StaticContents.Remove(staticContent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaticContentExists(string id)
        {
            return _context.StaticContents.Any(e => e.LanguageCode == id);
        }*/
    }
}
