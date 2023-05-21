using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using UMCTravelTour.Common.Constants;

namespace UMCTravelTour.Web.Services
{
    public class TourDesignService : ITourDesignService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TourDesignService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ParseTourDesign(TourDesignViewModel tourDesign)
        {
            if (_unitOfWork.RoomRepository.GetAll()
                    .FirstOrDefault(x => x.HotelId == tourDesign.HotelId && x.RoomId == tourDesign.RoomId) == null)
                return false;
            var customer = new Core.Models.Customer()
            {
                CustomerName = tourDesign.CustomerName,
                Address = tourDesign.Address,
                Phone = tourDesign.Phone,
                Email = tourDesign.Email,
            };
            _unitOfWork.CustomerRepository.Add(customer);
            var tour = new Core.Models.Tour()
            {
                TourName = tourDesign.TourName,
                HotelId = tourDesign.HotelId,
            };
            _unitOfWork.TourRepository.Add(tour);
            _unitOfWork.SaveChanges();
            var price = tourDesign.TourParticipantCount
                * _unitOfWork.RoomRepository.GetAll()
                    .FirstOrDefault(x => x.HotelId == tourDesign.HotelId && x.RoomId == tourDesign.RoomId)
                    .Price
                * tourDesign.EndDate.Subtract(tourDesign.StartDate).Days;
            var booking = new Core.Models.Booking()
            {
                TourParticipantCount = tourDesign.TourParticipantCount,
                StartDate = tourDesign.StartDate,
                EndDate = tourDesign.EndDate,
                TourId = tour.TourId,
                CustomerId = customer.CustomerId,
                RoomId = tourDesign.RoomId,
                Status = Constant.StatusBooking.Pending,
                //soos người * số phòng * số ngày * 1.05(phí dịch vụ 5%)
                ExpectedPrice = price * (1 + Constant.ServicePricePercentage),
                Deposit = price * Constant.ServicePricePercentage
            };
            _unitOfWork.BookingRepository.Add(booking);
            int[] restaurantList = parseJson(tourDesign.jsonRestaurant);
            foreach(int item in restaurantList)
            {
                _unitOfWork.TourRestaurantMappingRepository.Add(new Core.Models.TourRestaurantMapping()
                {
                    TourId = tour.TourId,
                    RestaurantId = item
                });
            }
            _unitOfWork.SaveChanges();
            return true;
        }

        public int[] parseJson(string json)
        {
            List<int> list = new List<int>();
            char reading = '[';
            int i = 1;
            int currentNumber = 0;
            while(i<json.Length && (reading=json[i])!=']')
            {
                if(char.IsDigit(reading))
                {
                    //'0' = 48 ascii
                    currentNumber = currentNumber * 10 + Convert.ToInt32(reading)-48;
                }
                else
                {
                    list.Add(currentNumber);
                    currentNumber = 0;
                }
                i++;
            }
            if(currentNumber!=0)list.Add(currentNumber);
            return list.ToArray();
        }
    }
}
