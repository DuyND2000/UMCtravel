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
using UMCTravelTour.Common.Constants;
namespace UMCTravelTour.DAL.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(UMCTravelContext context) : base(context)
        {
        }

        public Location GetLocationHR(int locationId)
        {
            return DbSet.Include(l => l.Hotels.Where(x=>x.Status == Constant.StatusTour.Active)).Include(l => l.Restaurants).FirstOrDefault(x => x.LocationId == locationId);
        }
    }
}
