using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Locations;
using UMCTravelTour.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Locations
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationVm>> GetAllAsync();
        public IEnumerable<LocationVm> GetAll();
        public Task<ResponseResult<LocationVm>> AddAsync(LocationVm locationVm);
        public Task<ResponseResult<LocationVm>> UpdateAsync(LocationVm locationVm);
        public Task<ResponseResult<LocationVm>> DeleteAsync(int id);
        public Task<LocationVm> GetByIdAsync(int id);
        public PagedVm<LocationVm> GetPaging(FilterPaging filterPaging);
        public LocationVm GetLocationWithHotelAndRestaurant(int locationId);
    }
}
