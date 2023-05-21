using UMCTravelTour.Web.ViewModels;

namespace UMCTravelTour.Web.Services
{
    public interface ITourDesignService
    {
        bool ParseTourDesign(TourDesignViewModel tourDesign);
    }
}