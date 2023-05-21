using AutoMapper;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.ViewModel.Restaurants;
using UMCTravelTour.ViewModel.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseResult<RoomVm>> AddAsync(RoomVm roomVm)
        {
            try
            {
                var room = _mapper.Map<Room>(roomVm);
                _unitOfWork.RoomRepository.Add(room);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<RoomVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<RoomVm>(ex.Message);
            }
        }

       

        public async Task<ResponseResult<RoomVm>> DeleteAsync(int id, int id2)
        {
            try
            {
                _unitOfWork.RoomRepository.Delete(id,id2);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<RoomVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<RoomVm>(ex.Message);
            }
        }

        public IEnumerable<RoomVm> GetAll()
        {
            var rooms =  _unitOfWork.RoomRepository.GetAll();
            var roomVms = _mapper.Map<IEnumerable<RoomVm>>(rooms);
            return roomVms;
        }

        public async Task<IEnumerable<RoomVm>> GetAllAsync()
        {
            var rooms = await _unitOfWork.RoomRepository.GetAllAsync();
            var roomVms = _mapper.Map<IEnumerable<RoomVm>>(rooms);
            return roomVms;
        }


        public PagedVm<RoomVm> GetPaging(FilterPaging filterPaging)
        {
            Func<IEnumerable<Room>, IOrderedEnumerable<Room>> predicate = null;
            if (filterPaging.TypeOfSort == Constant.Sort.ASC)
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderBy(x => x.RoomName);
                }
                else
                {
                    predicate = x => x.OrderBy(x => x.RoomName);
                }
            }
            else
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderByDescending(x => x.RoomName);
                }

            }
            Func<Room, bool> filter = null;
            if (!string.IsNullOrEmpty(filterPaging.Keyword))
            {
                filter = x => x.RoomName.ToLower().Contains(filterPaging.Keyword.ToLower());
            }
            PagedVm<Room> rooms = _unitOfWork.RoomRepository.GetPaging(null, filter, predicate, filterPaging.PageSize, filterPaging.PageIndex);
            IEnumerable<RoomVm> roomVms = this._mapper.Map<IEnumerable<RoomVm>>(rooms.Data.AsEnumerable());
            return new PagedVm<RoomVm>(roomVms, filterPaging.PageIndex, filterPaging.PageSize, rooms.TotalPage);
        }
        public async Task<RoomVm> GetByIdAsync(int id, int id2)
        {
            var room = await _unitOfWork.RoomRepository.GetByIdAsync(id,id2);
            var roomVm = _mapper.Map<RoomVm>(room);
            return roomVm;
        }

        public async Task<IEnumerable<RoomVm>> GetRoomByHotelIdAsync(int hotelId)
        {
            var rooms = await _unitOfWork.RoomRepository.GetRoomByHotelIdAsync(hotelId);
            var roomVms = _mapper.Map<IEnumerable<RoomVm>>(rooms);
            return roomVms;
        }
        public async Task<ResponseResult<RoomVm>> UpdateAsync(RoomVm roomVm)
        {
            try
            {
                var room = _mapper.Map<Room>(roomVm);
                _unitOfWork.RoomRepository.Update(room);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<RoomVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<RoomVm>(ex.Message);
            }
        }

        public bool CheckRoomIdInHotel(int hotelId, int roomId)
        {
            var rooms = _unitOfWork.RoomRepository.GetAll();
            foreach (var item in rooms)
            {
                if (item.HotelId == hotelId && item.RoomId == roomId)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
