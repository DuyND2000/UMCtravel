using Microsoft.AspNetCore.Mvc;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
