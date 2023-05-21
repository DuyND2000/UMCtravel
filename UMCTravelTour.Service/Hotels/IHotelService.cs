using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Hotels;
using UMCTravelTour.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Hotels
{
    public interface IHotelService
    {
        public PagedVm<HotelVm> GetPaging(FilterPaging filterPaging);
        Task<ResponseResult<HotelVm>> AddAsync(HotelVm hotelVm);
        Task<ResponseResult<int>> DeleteAsync(int id);
        Task<IEnumerable<HotelVm>> GetAllAsync();
        Task<HotelVm> GetByIdAsync(int id);
        Task<ResponseResult<HotelVm>> UpdateAsync(HotelVm hotelVm);
        IEnumerable<HotelVm> GetAll();
        public PagedVm<HotelCard> GetPaging(string search, decimal minPrice, decimal maxPrice, int pageIndex);
        public Task<IEnumerable<HotelCard>> GetByLocationIdAsync(int hotelId, int locationId, int size);
        public HotelVm GetById(int hotelId);
    }
}
