using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.ViewModel.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Rooms
{
    public interface IRoomService
    {
         IEnumerable<RoomVm> GetAll();
         Task<IEnumerable<RoomVm>> GetAllAsync();
         Task<ResponseResult<RoomVm>> AddAsync(RoomVm roomVm);
         Task<ResponseResult<RoomVm>> UpdateAsync(RoomVm roomVm);
         Task<ResponseResult<RoomVm>> DeleteAsync(int id, int id2);
         Task<RoomVm> GetByIdAsync(int id, int id2);
        public Task<IEnumerable<RoomVm>> GetRoomByHotelIdAsync(int hotelId);
        public PagedVm<RoomVm> GetPaging(FilterPaging filterPaging);
        public bool CheckRoomIdInHotel(int hotelId, int roomId);
    }
}
