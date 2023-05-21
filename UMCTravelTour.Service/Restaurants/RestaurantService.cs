using AutoMapper;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
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
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RestaurantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseResult<RestaurantVm>> AddAsync(RestaurantVm restaurantVm)
        {
            try
            {
                var restaurant = _mapper.Map<Restaurant>(restaurantVm);
                _unitOfWork.RestaurantRepository.Add(restaurant);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<RestaurantVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<RestaurantVm>(ex.Message);
            }
        }

        public async Task<ResponseResult<RestaurantVm>> DeleteAsync(int id)
        {
            try
            {
                _unitOfWork.RestaurantRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<RestaurantVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<RestaurantVm>(ex.Message);
            }
        }

        public IEnumerable<RestaurantVm> GetAll()
        {
            var restaurants = _unitOfWork.RestaurantRepository.GetAll();
            var restaurantVms = _mapper.Map<IEnumerable<RestaurantVm>>(restaurants);
            return restaurantVms;
        }

        public async Task<IEnumerable<RestaurantVm>> GetAllAsync()
        {
            var restaurants = await _unitOfWork.RestaurantRepository.GetAllAsync();
            var restaurantVms = _mapper.Map<IEnumerable<RestaurantVm>>(restaurants);
            return restaurantVms;
        }

        public async Task<RestaurantVm> GetByIdAsync(int id)
        {
            var restaurant = await _unitOfWork.RestaurantRepository.GetByIdAsync(id);
            var restaurantVm = _mapper.Map<RestaurantVm>(restaurant);
            return restaurantVm;
        }

        public async Task<ResponseResult<RestaurantVm>> UpdateAsync(RestaurantVm restaurantVm)
        {
            try
            {
                var restaurant = _mapper.Map<Restaurant>(restaurantVm);
                _unitOfWork.RestaurantRepository.Update(restaurant);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<RestaurantVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<RestaurantVm>(ex.Message);
            }
        }
        public PagedVm<RestaurantVm> GetPaging(FilterPaging filterPaging)
        {
            Func<IEnumerable<Restaurant>, IOrderedEnumerable<Restaurant>> predicate = null;
            if (filterPaging.TypeOfSort == Constant.Sort.ASC)
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderBy(x => x.RestaurantName);
                }
                else
                {
                    predicate = x => x.OrderBy(x => x.RestaurantName);
                }
            }
            else
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderByDescending(x => x.RestaurantName);
                }
            }
            Func<Restaurant, bool> filter = null;
            if (!string.IsNullOrEmpty(filterPaging.Keyword))
            {
                filter = x => x.RestaurantName.ToLower().Contains(filterPaging.Keyword.ToLower());
            }
            PagedVm<Restaurant> Restaurants = _unitOfWork.RestaurantRepository.GetPaging(null, filter, predicate, filterPaging.PageSize, filterPaging.PageIndex);
            IEnumerable<RestaurantVm> restaurantVms = this._mapper.Map<IEnumerable<RestaurantVm>>(Restaurants.Data.AsEnumerable());
            return new PagedVm<RestaurantVm>(restaurantVms, filterPaging.PageIndex, filterPaging.PageSize, Restaurants.TotalPage);
        }
        public IEnumerable<RestaurantVm> FindByLocationId(int LocationId, int size)
        {
            var restaurants = _unitOfWork.RestaurantRepository.FindByLocationId(LocationId, size);
            var restaurantVms = _mapper.Map<IEnumerable<RestaurantVm>>(restaurants);
            return restaurantVms;
        }
        public IEnumerable<RestaurantWithTourId> GetRestaurantsByTourId(int tourId)
        {
            return  _unitOfWork.RestaurantRepository.GetRestaurantsByTourId(tourId);
        }
    }
}
