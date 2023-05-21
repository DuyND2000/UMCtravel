using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Bookings;
using UMCTravelTour.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Bookings
{
    public interface IBookingService
    {
        public Task<IEnumerable<BookingVm>> GetAllAsync();
        public Task<ResponseResult<BookingVm>> AddAsync(BookingVm bookingVm);
        public Task<ResponseResult<BookingVm>> UpdateAsync(BookingVm bookingVm);
        public Task<ResponseResult<BookingVm>> DeleteAsync(int id);
        public Task<BookingVm> GetByIdAsync(int id);
        public PagedVm<BookingVm> GetByStatus(FilterPaging filterPaging, string status);
        public PagedVm<BookingVm> GetPaging(FilterPaging filterPaging);
        public IEnumerable<BookingVm> GetAll();
        public Task<IEnumerable<BookingVm>> GetByCustomerId(int customerId);
        public Task<ResponseResult<BookingVm>> ChangeStatus(int idBooking, string status);
        public int CountByStatus(string status);
        public int Count();
    }
}
