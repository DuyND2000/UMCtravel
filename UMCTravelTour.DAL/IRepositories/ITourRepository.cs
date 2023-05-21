using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.IRepositories
{
    public interface ITourRepository : IGenericRepository<Tour>
    {
        public Task<IEnumerable<Tour>> GetTourActiveAsync();
        public double GetPriceById(int tourId);
        public Task<IEnumerable<Tour>> GetRelateToursAsync(int tourId);
        public double GetAvgRatePointByTourId(int tourId);
    }
}
