using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
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
    public class HotelService : IHotelService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseResult<HotelVm>> AddAsync(HotelVm hotelVm)
        {
            try
            {
                var hotel = _mapper.Map<Hotel>(hotelVm);
                _unitOfWork.HotelRepository.Add(hotel);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<HotelVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<HotelVm>(ex.Message);
            }
        }

        public async Task<ResponseResult<int>> DeleteAsync(int id)
        {
            try
            {
                _unitOfWork.HotelRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<int>();
            }
            catch (DbUpdateException)
            {
                return new ResponseResult<int> ("table tour use this hotel so you can't delete this hotel");
            }catch(Exception ex)
            {
                return new ResponseResult<int>(ex.Message);
            }
        }

        public async Task<IEnumerable<HotelVm>> GetAllAsync()
        {
            var hotels = await _unitOfWork.HotelRepository.GetAllAsync();
            var hotelVms = _mapper.Map<IEnumerable<HotelVm>>(hotels);
            return hotelVms;
        }

        public async Task<HotelVm> GetByIdAsync(int id)
        {
            var hotel = await _unitOfWork.HotelRepository.GetByIdAsync(id);
            var hotelVm = _mapper.Map<HotelVm>(hotel);
            return hotelVm;
        }

        public async Task<ResponseResult<HotelVm>> UpdateAsync(HotelVm hotelVm)
        {
            try
            {
                var hotel = _mapper.Map<Hotel>(hotelVm);
                _unitOfWork.HotelRepository.Update(hotel);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<HotelVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<HotelVm>(ex.Message);
            }
        }
        public PagedVm<HotelVm> GetPaging(FilterPaging filterPaging)
        {
            Func<IEnumerable<Hotel>, IOrderedEnumerable<Hotel>> predicate = null;
            if (filterPaging.TypeOfSort == Constant.Sort.ASC)
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderBy(x => x.HotelName);
                }
                else
                {
                    predicate = x => x.OrderBy(x => x.HotelName);
                }
            }
            else
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderByDescending(x => x.HotelName);
                }
                else
                {
                    predicate = x => x.OrderByDescending(x => x.LastModifiedBy);
                }
            }
            Func<Hotel, bool> filter = null;
            if (!string.IsNullOrEmpty(filterPaging.Keyword))
            {
                filter = x => x.HotelName.ToLower().Contains(filterPaging.Keyword.ToLower());
            }
            PagedVm<Hotel> Hotels = _unitOfWork.HotelRepository.GetPaging(null,filter, predicate, filterPaging.PageSize, filterPaging.PageIndex);
            IEnumerable<HotelVm> hotelVms = this._mapper.Map<IEnumerable<HotelVm>>(Hotels.Data.AsEnumerable());
            return new PagedVm<HotelVm>(hotelVms, filterPaging.PageIndex, filterPaging.PageSize,Hotels.TotalPage);
        }

        public IEnumerable<HotelVm> GetAll()
        {
            var hotels = _unitOfWork.HotelRepository.GetAll();
            var hotelVms = _mapper.Map<IEnumerable<HotelVm>>(hotels);
            return hotelVms;
        }

        public PagedVm<HotelCard> GetPaging(string search, decimal minPrice, decimal maxPrice, int pageIndex)
        {
            var hotelCards = _unitOfWork.HotelRepository.GetPaging(search, minPrice, maxPrice, pageIndex);
            return hotelCards;

        }
        // size: lấy top các bản ghi
        public async Task<IEnumerable<HotelCard>> GetByLocationIdAsync(int hotelId, int locationId, int size)
        {
            var hotels = await _unitOfWork.HotelRepository.GetByLocationIdAsync(hotelId,locationId, size);
            var hotelCards = _mapper.Map<IEnumerable<HotelCard>>(hotels);
            return hotelCards;
        }

        public HotelVm GetById(int hotelId)
        {
            var hotel =  _unitOfWork.HotelRepository.GetById(hotelId);
            var hotelVm = _mapper.Map<HotelVm>(hotel);
            return hotelVm;
        }
    }
}
