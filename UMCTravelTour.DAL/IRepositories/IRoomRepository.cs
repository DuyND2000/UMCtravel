using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.IRepositories
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        public Task<IEnumerable<Room>> GetRoomByHotelIdAsync(int hotelId);
        public Task<Room> GetRoomById(int hotelId);
    }
}
