using AutoMapper;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.ViewModel.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Tours
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseResult<TourVm>> AddAsync(TourVm tourVm)
        {
            try
            {
                var tourRestaurantMappings = new List<TourRestaurantMapping>();
                foreach(var restaurantId in tourVm.restaurantId)
                {
                    var tourRestaurantMapping = new TourRestaurantMapping()
                    {
                        RestaurantId = restaurantId,
                    };
                    tourRestaurantMappings.Add(tourRestaurantMapping);

                }
                var tour = _mapper.Map<Tour>(tourVm);
                tour.TourRestaurantMappings = tourRestaurantMappings;
                _unitOfWork.TourRepository.Add(tour);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<TourVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TourVm>(ex.Message);
            }
        }
        /// <summary>
        /// Before delete all record with id tour in TourRestaurantMapping entity, after delete tour wwith id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseResult<TourVm>> DeleteAsync(int id)
        {
            try
            {
                Func<TourRestaurantMapping, bool> predicate = x => x.TourId == id;
                _unitOfWork.TourRestaurantMappingRepository.DeleteByCondition(predicate);
                _unitOfWork.TourRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<TourVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TourVm>(ex.Message);
            }
        }

        public async Task<IEnumerable<TourVm>> GetAllAsync()
        {
            var tours = await _unitOfWork.TourRepository.GetAllAsync();
            var TourVms = _mapper.Map<IEnumerable<TourVm>>(tours);
            return TourVms;
        }

        public async Task<TourVm> GetByIdAsync(int id)
        {
            var tour = await _unitOfWork.TourRepository.GetByIdAsync(id);
            var tourVm = _mapper.Map<TourVm>(tour);
            tourVm.avgRatePoint = _unitOfWork.TourRepository.GetAvgRatePointByTourId(id);
            return tourVm;
        }

        public PagedVm<TourVm> GetPaging(FilterPaging filterPaging)
        {
            Func<IEnumerable<Tour>, IOrderedEnumerable<Tour>> predicate = null;
            if (filterPaging.TypeOfSort == Constant.Sort.ASC)
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderBy(x => x.TourName);
                }
                else
                {
                    predicate = x => x.OrderBy(x => x.LastModifiedOn);
                }
            }
            else
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderByDescending(x => x.TourName);
                }
                else
                {
                    predicate = x => x.OrderByDescending(x => x.LastModifiedOn);
                }
            }
            Func<Tour, bool> filter = null;
            if (!string.IsNullOrEmpty(filterPaging.Keyword))
            {
                filter = x => x.TourName.ToLower().Contains(filterPaging.Keyword.ToLower());
            }
            PagedVm<Tour> Tours = _unitOfWork.TourRepository.GetPaging(null, filter, predicate, filterPaging.PageSize, filterPaging.PageIndex);
            IEnumerable<TourVm> tourVms = this._mapper.Map<IEnumerable<TourVm>>(Tours.Data.AsEnumerable());
            return new PagedVm<TourVm>(tourVms, filterPaging.PageIndex, filterPaging.PageSize, Tours.TotalPage);
        }

        public async Task<IEnumerable<TourVm>> GetTourActiveAsync()
        {
            var tours = await _unitOfWork.TourRepository.GetTourActiveAsync();
            var tourVms = _mapper.Map<IEnumerable<TourVm>>(tours);
            foreach(var tour in tourVms)
            {
                tour.avgRatePoint = _unitOfWork.TourRepository.GetAvgRatePointByTourId(tour.TourId);
            }
            return tourVms;
        }

        public async Task<ResponseResult<TourVm>> UpdateAsync(TourVm tourVm)
        {
            try
            {
                Func<TourRestaurantMapping, bool> predicate = x => x.TourId == tourVm.TourId;
                _unitOfWork.TourRestaurantMappingRepository.DeleteByCondition(predicate);
                var tourRestaurantMappings = new List<TourRestaurantMapping>();
                foreach (var restaurantId in tourVm.restaurantId)
                {
                    var tourRestaurantMapping = new TourRestaurantMapping()
                    {
                        RestaurantId = restaurantId,
                    };
                    tourRestaurantMappings.Add(tourRestaurantMapping);

                }
                var tour = _mapper.Map<Tour>(tourVm);
                tour.TourRestaurantMappings = tourRestaurantMappings;
                _unitOfWork.TourRepository.Update(tour);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<TourVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TourVm>(ex.Message);
            }
        }
        public IEnumerable<TourVm> GetAll()
        {
            var tours = _unitOfWork.TourRepository.GetAll();
            var tourVms = _mapper.Map<IEnumerable<TourVm>>(tours);
            return tourVms;
        }
        public TourVm GetById(int id)
        {
            var tour = _unitOfWork.TourRepository.GetById(id);
            var tourVm = _mapper.Map<TourVm>(tour);
            tourVm.avgRatePoint = _unitOfWork.TourRepository.GetAvgRatePointByTourId(id);
            return tourVm;
        }

        public double GetPriceByTourId(int id)
        {
            return _unitOfWork.TourRepository.GetPriceById(id);
        }

        public async Task<IEnumerable<TourVm>> GetRelateToursAsync(int tourId)
        {
            var tours = await _unitOfWork.TourRepository.GetRelateToursAsync(tourId);
            var tourVms = _mapper.Map<IEnumerable<TourVm>>(tours);
            return tourVms;
        }
    }
}
