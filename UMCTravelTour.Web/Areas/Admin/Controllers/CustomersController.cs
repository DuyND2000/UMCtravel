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
using UMCTravelTour.Service.Customers;
using UMCTravelTour.Service.EmailTemplates;
using UMCTravelTour.ViewModel.Customers;
using UMCTravelTour.ViewModel.EmailTemplates;
using UMCTravelTour.ViewModel.Pages;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Constant.Role.Administrator + ", " + Constant.Role.Manager)]
    public class CustomersController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IEmailTemplateSerice _emailTemplateSerice;

        public CustomersController(ICustomerService customerService, IEmailTemplateSerice emailTemplateSerice)
        {
            _customerService = customerService;
            _emailTemplateSerice = emailTemplateSerice;
        }

        // GET: Admin/Customers
        public IActionResult Index(FilterPaging filterPaging)
        {
            ViewBag.FilterPaging = filterPaging;

            var data = _customerService.GetPaging(filterPaging);
            return View(data);
        }

        // GET: Admin/Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        /*
        // GET: Admin/Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,Phone,Address,Email,IdentityCardNumber,LastModifiedBy,LastModifiedOn")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        */
        // GET: Admin/Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            // Gửi mail khi edit customer 
            var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.CustomerSucess);
            var mailContent = new EmailTemplateVm();
            mailContent.To = customer.Email;
            mailContent.CC = emailTemplate.CC;
            mailContent.BCC = emailTemplate.BCC;
            mailContent.Object = emailTemplate.Object;

            var body = emailTemplate.Body;
            body = body.Replace("##TenKhachHang##", customer.CustomerName);
            body = body.Replace("##Phone##", customer.Phone);
            body = body.Replace("##Email##", customer.Email);
            body = body.Replace("##DateUpdate##", DateTime.Now.ToShortDateString());

            mailContent.Body = body;
            var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
            return View(customer);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerVm customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _customerService.UpdateAsync(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }
        /*
        // GET: Admin/Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }*/

        // POST: Admin/Customers/Delete/5
        [Authorize(Roles = Constant.Role.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _customerService.GetByIdAsync(id) != null;
        }
    }
}
