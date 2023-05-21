using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.ViewModel.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.IRepositories
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
        public IEnumerable<Restaurant> FindByLocationId(int LocationId, int size);
        public IEnumerable<RestaurantWithTourId> GetRestaurantsByTourId(int tourId);
    }
    
}
