using AutoMapper;
using UMCTravelTour.Core.Models;
using UMCTravelTour.ViewModel.Bookings;
using UMCTravelTour.ViewModel.Comments;
using UMCTravelTour.ViewModel.Customers;
using UMCTravelTour.ViewModel.EmailTemplates;
using UMCTravelTour.ViewModel.Hotels;
using UMCTravelTour.ViewModel.Locations;
using UMCTravelTour.ViewModel.Restaurants;
using UMCTravelTour.ViewModel.Rooms;
using UMCTravelTour.ViewModel.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationVm>().ReverseMap();
            CreateMap<Booking, BookingVm>().ReverseMap();
            CreateMap<Customer, CustomerVm>().ReverseMap();
            CreateMap<Hotel, HotelVm>().ReverseMap();
            CreateMap<Hotel, HotelCard>().ReverseMap();
            CreateMap<Restaurant, RestaurantVm>().ReverseMap();
            CreateMap<Room, RoomVm>().ReverseMap();
            CreateMap<Tour, TourVm>().ReverseMap();
            CreateMap<EmailTemplate, EmailTemplateVm>().ReverseMap();
            CreateMap<Comment, CommentVm>().ReverseMap();
        }
    }
}
