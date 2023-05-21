using AutoMapper;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
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
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseResult<BookingVm>> AddAsync(BookingVm bookingVm)
        {
            try
            {
                var booking = _mapper.Map<Booking>(bookingVm);
                if (string.IsNullOrEmpty(booking.Customer.IdentityCardNumber))
                {
                    booking.Customer.IdentityCardNumber = "0";
                }

                    // cập nhật thông tin khách hàng
                if (booking.Customer.CustomerId != 0)
                {
                    var customer = _mapper.Map<Customer>(booking.Customer);
                   // booking.CustomerId = customer.CustomerId;
                    _unitOfWork.CustomerRepository.Update(customer);
                }
                else
                {
                    if (_unitOfWork.CustomerRepository.CheckPhoneExisted(booking.Customer.Phone))
                    {
                        return new ResponseResult<BookingVm>("Phone is existed");
                    }
                    if (_unitOfWork.CustomerRepository.CheckEmailExisted(booking.Customer.Email))
                    {
                        return new ResponseResult<BookingVm>("Email is existed");
                    }
                }
                // tính lại tổng tiền dự định của 1 tour
                double price = _unitOfWork.TourRepository.GetPriceById(booking.TourId);
                booking.ExpectedPrice = (decimal)price*booking.TourParticipantCount;
                // identity off
                booking.Tour = _unitOfWork.TourRepository.GetById(booking.TourId);
                _unitOfWork.BookingRepository.Add(booking);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<BookingVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<BookingVm>(ex.Message);
            }
        }
        public async Task<ResponseResult<BookingVm>> DeleteAsync(int id)
        {
            try
            {
                _unitOfWork.BookingRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<BookingVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<BookingVm>(ex.Message);
            }
        }
        public async Task<ResponseResult<BookingVm>> UpdateAsync(BookingVm bookingVm)
        {
            try
            {
                var booking = _mapper.Map<Booking>(bookingVm);
                _unitOfWork.BookingRepository.Update(booking);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<BookingVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<BookingVm>(ex.Message);
            }
        }

        public async Task<IEnumerable<BookingVm>> GetAllAsync()
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllAsync();
            var bookingVms = _mapper.Map<IEnumerable<BookingVm>>(bookings);
            return bookingVms;
        }

        public async Task<BookingVm> GetByIdAsync(int id)
        {
            var booking = await _unitOfWork.BookingRepository.GetByIdAsync(id);
            var bookingVm = _mapper.Map<BookingVm>(booking);
            return bookingVm;
        }

        public PagedVm<BookingVm> GetPaging(FilterPaging filterPaging)
        {
            Func<Booking, bool> filter = null;
            if (!string.IsNullOrEmpty(filterPaging.Keyword))
            {
                filter = x => x.BookingId.ToString().Contains(filterPaging.Keyword.ToLower());
            }
            PagedVm<Booking> Bookings = _unitOfWork.BookingRepository.GetPaging(null, filter, null, filterPaging.PageSize, filterPaging.PageIndex);
            IEnumerable<BookingVm> bookingVms = this._mapper.Map<IEnumerable<BookingVm>>(Bookings.Data.AsEnumerable());
            return new PagedVm<BookingVm>(bookingVms, filterPaging.PageIndex, filterPaging.PageSize, Bookings.TotalPage);
        }
        public PagedVm<BookingVm> GetByStatus(FilterPaging filterPaging, string status)
        {
            Func<Booking, bool> filter = null;
            if (!string.IsNullOrEmpty(status))
            {
                filter = x => x.Status.Equals(status);
            }
            PagedVm<Booking> Bookings = _unitOfWork.BookingRepository.GetPaging(null, filter, null, filterPaging.PageSize, filterPaging.PageIndex);
            IEnumerable<BookingVm> bookingVms = this._mapper.Map<IEnumerable<BookingVm>>(Bookings.Data.AsEnumerable());
            return new PagedVm<BookingVm>(bookingVms, filterPaging.PageIndex, filterPaging.PageSize, Bookings.TotalPage);
        }
        public IEnumerable<BookingVm> GetAll()
        {
            var bookings = _unitOfWork.BookingRepository.GetAll();
            var bookingVms = _mapper.Map<IEnumerable<BookingVm>>(bookings);
            return bookingVms;
        }
        public async Task<ResponseResult<BookingVm>> ChangeStatus(int idBooking, string status)
        {
            try
            {
                var booking = _unitOfWork.BookingRepository.GetById(idBooking);               
                booking.Status = status;
                await _unitOfWork.SaveChangesAsync();
                var bookingVm = _mapper.Map<BookingVm>(booking);
                return new ResponseResult<BookingVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<BookingVm>(ex.Message);
            }
        }
        public int Count()
        {
            var bookings = _unitOfWork.BookingRepository.Count();
            return bookings;
        }

        public int CountByStatus(string status)
        {
            var count = _unitOfWork.BookingRepository.GetByStatus(status).Count();
            return count;
        }

        public async Task<IEnumerable<BookingVm>> GetByCustomerId(int customerId)
        {
            var bookings = await _unitOfWork.BookingRepository.GetByCustomer(customerId);
            var bookingVms = _mapper.Map<IEnumerable<BookingVm>>(bookings);
            return bookingVms;
        }
    }
}
