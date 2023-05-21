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
    public class TourRestaurantMappingRepository : GenericRepository<TourRestaurantMapping>, ITourRestaurantMappingRepository
    {
        public TourRestaurantMappingRepository(UMCTravelContext context) : base(context)
        {
        }
    }
}
