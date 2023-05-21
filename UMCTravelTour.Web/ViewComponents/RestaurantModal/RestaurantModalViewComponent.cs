using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Service.Restaurants;
using System.Linq;
using System.Threading.Tasks;

namespace UMCTravelTour.Web.ViewComponents.RestaurantModal
{
    public class RestaurantModalViewComponent : ViewComponent
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantModalViewComponent(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int locationId)
        {
            var restaurantList = _restaurantService.GetAll().Where(r => r.LocationId == locationId).ToList();
            return View(restaurantList);
        }
    }
}
