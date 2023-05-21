using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.IRepositories;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Infrastructures
{
    public interface IUnitOfWork
    {
        UMCTravelContext Context { get;}
        IBookingRepository BookingRepository { get; }
        ILocationRepository LocationRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IHotelRepository HotelRepository { get; }
        IRoomRepository RoomRepository { get; } 
        ITourRepository TourRepository { get; }
        IRestaurantRepository RestaurantRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        ICommentRepository CommentRepository { get; }
        IStaticContentRepository StaticContentRepository { get; }
        ITourRestaurantMappingRepository TourRestaurantMappingRepository { get; }

        IEmailTemplateRepository EmailTemplateRepository { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}