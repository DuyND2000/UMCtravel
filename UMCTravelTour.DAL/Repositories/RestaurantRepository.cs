using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.DAL.IRepositories;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.ViewModel.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Repositories
{
    internal class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(UMCTravelContext context) : base(context)
        {
        }
        public IEnumerable<Restaurant> FindByLocationId(int LocationId, int size)
        {
            return DbSet.Where(res => res.LocationId.Equals(LocationId)).Take(size);
        }

        public IEnumerable<RestaurantWithTourId> GetRestaurantsByTourId(int tourId)
        {
            var data = from r in Context.Restaurants
                       join t in Context.TourRestaurantMappings on r.RestaurantId equals t.RestaurantId
                       where t.TourId == tourId
                       select new RestaurantWithTourId
                       {
                           Id = r.RestaurantId,
                           Name = r.RestaurantName,
                       };
            return data;
        }
    }
}
