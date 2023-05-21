using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Service.Hotels;
using UMCTravelTour.ViewModel.Pages;
using System.Threading.Tasks;

namespace UMCTravelTour.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public IActionResult Index(string keyword = "", decimal minPrice = 0, decimal maxPrice = 0,int pageIndex = 1)
        {
            if (keyword == null) keyword = "";
            var data = _hotelService.GetPaging(keyword, minPrice, maxPrice, pageIndex);
            ViewBag.Keyword = keyword;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            return View(data);
        }

        public async Task<IActionResult> Detail(int hotelId)
        {
            var data = await _hotelService.GetByIdAsync(hotelId);
            ViewBag.HotelName = data.HotelName;
            return View(data);
        }
    }
}
