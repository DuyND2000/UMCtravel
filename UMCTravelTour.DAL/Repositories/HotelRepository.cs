using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.DAL.IRepositories;
using UMCTravelTour.ViewModel.Hotels;
using UMCTravelTour.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(UMCTravelContext context) : base(context)
        {
        }

        // trang thái status = active: hotel đang hoạt động và liên kết với công ty
        public async Task<IEnumerable<Hotel>> GetByLocationIdAsync(int hotelId,int locationId, int size)
        {
            return await DbSet.Where(x => x.LocationId == locationId && x.HotelId != hotelId&& x.Status == Constant.StatusTour.Active).Take(size).ToListAsync();
        }

        //lấy danh sách hotel hiện đang liên kết với công ty
        public PagedVm<HotelCard> GetPaging(string search, decimal minPrice, decimal maxPrice, int pageIndex)
        {
            var data = (from h in Context.Hotels
                       join l in Context.Locations on h.LocationId equals l.LocationId
                       join r in Context.Rooms on h.HotelId equals r.HotelId into lf
                       from r in lf.DefaultIfEmpty()
                       where l.LocationName.ToUpper().Contains(search.ToUpper())
                       || h.HotelName.ToUpper().Contains(search.ToUpper()) && h.Status == Constant.StatusTour.Active
                       select new HotelCard
                       {
                           HotelId = h.HotelId,
                           HotelName = h.HotelName,
                           Address = h.Address,
                           RoomPrice = h.RoomPrice,
                           ShortDescription = h.ShortDescription,
                           ImageLink = h.ImageLink
                       }).Distinct();
          
            var totalRows = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalRows / Constant.PageSize);
            data = data.Skip((pageIndex - 1) * Constant.PageSize).Take(Constant.PageSize);
            return new PagedVm<HotelCard>(data, pageIndex, Constant.PageSize, totalPages);
        }
    }
}
