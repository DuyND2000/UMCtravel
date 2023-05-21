using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.IRepositories;
using UMCTravelTour.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UMCTravelContext _context;
        private IBookingRepository _bookingRepository;
        private ICustomerRepository _customerRepository;
        private IHotelRepository _hotelRepository;
        private ILocationRepository _locationRepository;
        private IRestaurantRepository _restaurantRepository;
        private IRoomRepository _roomRepository;
        private ITourRepository _tourRepository;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IStaticContentRepository _staticContentRepository;
        private ITourRestaurantMappingRepository _tourRestaurantMappingRepository;
        private IEmailTemplateRepository _emailTemplateRepository;
        private ICommentRepository _commentRepository;
        public UnitOfWork(UMCTravelContext context)
        {
            _context = context;
        }
        public UMCTravelContext Context => _context;

        public IBookingRepository BookingRepository => _bookingRepository ?? (_bookingRepository = new BookingRepository(_context));

        public ILocationRepository LocationRepository => _locationRepository ?? (_locationRepository = new LocationRepository(_context));

        public ICustomerRepository CustomerRepository => _customerRepository ?? (_customerRepository = new CustomerRepository(_context));

        public IHotelRepository HotelRepository => _hotelRepository ?? (_hotelRepository = new HotelRepository(_context));

        public IRoomRepository RoomRepository => _roomRepository ?? (_roomRepository = new RoomRepository(_context));

        public ITourRepository TourRepository => _tourRepository ?? (_tourRepository = new TourRepository(_context));

        public IRestaurantRepository RestaurantRepository => _restaurantRepository ?? (_restaurantRepository = new RestaurantRepository(_context));

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_context));

        public IRoleRepository RoleRepository => _roleRepository ?? (_roleRepository = new RoleRepository(_context));

        public IStaticContentRepository StaticContentRepository => _staticContentRepository ?? (_staticContentRepository = new StaticContentRepository(_context));

        public ITourRestaurantMappingRepository TourRestaurantMappingRepository => _tourRestaurantMappingRepository ?? (_tourRestaurantMappingRepository = new TourRestaurantMappingRepository(_context));

        public IEmailTemplateRepository EmailTemplateRepository => _emailTemplateRepository ?? (_emailTemplateRepository = new EmailTemplateRepository(_context));

        public ICommentRepository CommentRepository => _commentRepository ?? (_commentRepository = new CommentRepository(_context));

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
