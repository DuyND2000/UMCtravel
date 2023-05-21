using AutoMapper;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.DAL.IRepositories;
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
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseResult<LocationVm>> AddAsync(LocationVm locationVm)
        {
            try { 
                var location = _mapper.Map<Location>(locationVm);
                _unitOfWork.LocationRepository.Add(location);
                await  _unitOfWork.SaveChangesAsync();
                return new ResponseResult<LocationVm>();
            }catch(Exception ex) {
                return new ResponseResult<LocationVm>(ex.Message);
            }
        }

        public async Task<ResponseResult<LocationVm>> DeleteAsync(int id)
        {
            try
            {
                _unitOfWork.LocationRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<LocationVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<LocationVm>(ex.Message);
            }
        }

        public IEnumerable<LocationVm> GetAll()
        {
            var locations =  _unitOfWork.LocationRepository.GetAll();
            var locationVms = _mapper.Map<IEnumerable<LocationVm>>(locations);
            return locationVms;
        }

        public async Task<IEnumerable<LocationVm>> GetAllAsync()
        {
            var locations = await _unitOfWork.LocationRepository.GetAllAsync();
            var locationVms = _mapper.Map<IEnumerable<LocationVm>>(locations);
            return locationVms;
        }

        public async Task<LocationVm> GetByIdAsync(int id)
        {
            var location = await _unitOfWork.LocationRepository.GetByIdAsync(id);
            var locationVm = _mapper.Map<LocationVm>(location);
            return locationVm;
        }

        public async Task<ResponseResult<LocationVm>> UpdateAsync(LocationVm locationVm)
        {
            try
            {
                var location = _mapper.Map<Location>(locationVm);
                _unitOfWork.LocationRepository.Update(location);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<LocationVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<LocationVm>(ex.Message);
            }
        }

        public PagedVm<LocationVm> GetPaging(FilterPaging filterPaging)
        {
            Func<IEnumerable<Location>, IOrderedEnumerable<Location>> predicate = null;
            if (filterPaging.TypeOfSort == Constant.Sort.ASC)
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderBy(x => x.LocationName);
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
                    predicate = x => x.OrderByDescending(x => x.LocationName);
                }
                else
                {
                    predicate = x => x.OrderByDescending(x => x.LastModifiedOn);
                }
            }
            Func<Location, bool> filter = null;
            if (!string.IsNullOrEmpty(filterPaging.Keyword))
            {
                filter = x => x.LocationName.ToLower().Contains(filterPaging.Keyword.ToLower());
            }
            PagedVm<Location> locations = _unitOfWork.LocationRepository.GetPaging(null, filter, predicate, filterPaging.PageSize, filterPaging.PageIndex);
            IEnumerable<LocationVm> locationVms = this._mapper.Map<IEnumerable<LocationVm>>(locations.Data.AsEnumerable());
            return new PagedVm<LocationVm>(locationVms, filterPaging.PageIndex, filterPaging.PageSize, locations.TotalPage);
        }

        public LocationVm GetLocationWithHotelAndRestaurant(int locationId)
        {
            var location = _mapper.Map<LocationVm>(_unitOfWork.LocationRepository.GetLocationHR(locationId));
            return location;
        }
    }
}
