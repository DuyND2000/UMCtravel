using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Service.Restaurants;
using UMCTravelTour.ViewModel.Pages;
using System.Linq;
using System.Threading.Tasks;

namespace UMCTravelTour.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        public async Task<IActionResult> Index(int showMore=6)
        {
            /*var data = _restaurantService.GetPaging(filterPaging);*/
            var data = _restaurantService.GetAllAsync().Result.Take(showMore).AsEnumerable();

            ViewBag.TotalRestaurant = _restaurantService.GetAll().Count();
            return View(data);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var data = await _restaurantService.GetByIdAsync(id);
            ViewBag.RestaurantName = data.RestaurantName;
            ViewBag.relateRestaurants = _restaurantService.FindByLocationId(data.LocationId, 3);
            return View(data);
        }
    }
}
