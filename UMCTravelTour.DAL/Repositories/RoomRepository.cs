using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Repositories
{
    internal class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(UMCTravelContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Room>> GetRoomByHotelIdAsync(int hotelId)
        {
           return await DbSet.Include(x=>x.Hotel).Where(x=>x.HotelId == hotelId).ToListAsync();
        }
    }
}
