using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Service.Locations;
using UMCTravelTour.ViewModel.Locations;
using System.Threading.Tasks;

namespace UMCTravelTour.Web.ViewComponents.TourLocation
{
    public class TourLocation : ViewComponent
    {
        private readonly ILocationService _locationService;
        public TourLocation(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int locationId)
        {
            if (locationId != 0)
            {
                var location = _locationService.GetLocationWithHotelAndRestaurant(locationId);
                return await Task.FromResult((IViewComponentResult)View("Default", location));
            }
            else
            {
                return await Task.FromResult((IViewComponentResult)View("Default", new LocationVm()));
            }
        }
    }
}
