using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.ViewModel.Hotels;
using UMCTravelTour.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.IRepositories
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        PagedVm<HotelCard> GetPaging(string search, decimal minPrice, decimal maxPrice, int pageIndex);
        Task<IEnumerable<Hotel>> GetByLocationIdAsync(int hotelId,int locationId,int size);
    }
}
