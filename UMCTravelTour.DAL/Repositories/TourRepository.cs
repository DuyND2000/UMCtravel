using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Common.Constants;
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
    public class TourRepository : GenericRepository<Tour>, ITourRepository
    {
        public TourRepository(UMCTravelContext context) : base(context)
        {
        }

        public double GetAvgRatePointByTourId(int tourId)
        {
            List<int> ratePoints = (from c in Context.Comments
                                       join t in Context.Tours on c.TourId equals t.TourId
                                       where c.TourId == tourId
                                       select c.RatePoint).ToList();
            double avgRatePoint = 0;
            if(ratePoints.Count > 0)
            {
                for (int i = 0; i < ratePoints.Count(); i++)
                {
                    avgRatePoint += ratePoints[i];
                }
                avgRatePoint = Math.Ceiling(avgRatePoint / ratePoints.Count());
            }
            return avgRatePoint;
        }

        public double GetPriceById(int tourId)
        {
            return Convert.ToDouble(DbSet.FirstOrDefault(x=>x.TourId == tourId).TotalPrice);
        }

        public async Task<IEnumerable<Tour>> GetRelateToursAsync(int tourId)
        {
            var price = DbSet.FirstOrDefault(x => x.TourId == tourId).TotalPrice;
            var data = await DbSet.Where(x => x.TotalPrice >= price - price / 10 && x.TotalPrice <= price + price / 10 && x.Status == Constant.StatusTour.Active && x.TourId != tourId).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<Tour>> GetTourActiveAsync()
        {

            var data = await DbSet.Where(x => x.Status == Constant.StatusTour.Active).ToListAsync();
            return data;
        }
    }
}
