using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UMCTravelTour.Web.Models;
using System.Diagnostics;

namespace UMCTravelTour.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string returnUrl, string waitingVerify)
        {
            if (waitingVerify != null)
            {
                TempData["verifyMsg"] = "Register successfully, please verify your email to login";
            }
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
