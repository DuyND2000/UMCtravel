using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.IRepositories
{
    public interface IBookingRepository: IGenericRepository<Booking>
    {
        public IEnumerable<Booking> GetByStatus(string status);
        public Task<IEnumerable<Booking>> GetByCustomer(int customerId);
    }
}
