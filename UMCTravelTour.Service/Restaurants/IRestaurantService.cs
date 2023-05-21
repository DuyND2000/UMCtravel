using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.ViewModel.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Restaurants
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<RestaurantVm>> GetAllAsync();
        public Task<ResponseResult<RestaurantVm>> AddAsync(RestaurantVm restaurantVm);
        public Task<ResponseResult<RestaurantVm>> UpdateAsync(RestaurantVm restaurantVm);
        public Task<ResponseResult<RestaurantVm>> DeleteAsync(int id);
        public Task<RestaurantVm> GetByIdAsync(int id);
        public IEnumerable<RestaurantVm> GetAll();
        public PagedVm<RestaurantVm> GetPaging(FilterPaging filterPaging);
        public IEnumerable<RestaurantVm> FindByLocationId(int LocationId, int size);
        public IEnumerable<RestaurantWithTourId> GetRestaurantsByTourId(int tourId);
    }
}
