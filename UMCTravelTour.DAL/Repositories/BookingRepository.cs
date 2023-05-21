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
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(UMCTravelContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetByCustomer(int customerId)
        {
            return await this.Context.Bookings.Where(b => b.CustomerId == customerId).ToListAsync();
        }

        public IEnumerable<Booking> GetByStatus(string status)
        {
           return this.Context.Bookings.Where(b => b.Status == status).ToList();
        }
    }
}
