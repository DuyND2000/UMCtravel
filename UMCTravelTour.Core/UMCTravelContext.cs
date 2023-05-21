using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Core.CustomIdentity.Configuration;
using UMCTravelTour.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Core
{
    public class UMCTravelContext : IdentityDbContext
    {
        public UMCTravelContext()
        {

        }

        public UMCTravelContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourRestaurantMapping> TourRestaurantMappings { get; set; }
        public DbSet<StaticContent> StaticContents { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
            {
                // Thay đổi tùy theo máy
                optionsBuilder.UseSqlServer("Server= DUY\\SQLEXPRESS01;Database=DreamTour;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Room>(entity => entity.HasKey(room => new { room.HotelId, room.RoomId }));

            /*builder.Entity<Tour>(tour =>
                tour.HasOne(t => t.Restaurant)
                .WithMany(r => r.Tours)
                .OnDelete(DeleteBehavior.NoAction));*/
            builder.Entity<TourRestaurantMapping>(e => e.HasKey(map => new { map.TourId, map.RestaurantId }));

            builder.Entity<Tour>(tour =>
                tour.HasOne(t => t.Hotel)
                .WithMany(h => h.Tours)
                .OnDelete(DeleteBehavior.NoAction));

            builder.Entity<Tour>().Property(t => t.Description).HasColumnType("ntext").HasMaxLength(int.MaxValue);
            builder.Entity<Tour>().Property(t => t.Schedule).HasColumnType("ntext").HasMaxLength(int.MaxValue);
            builder.Entity<Hotel>().Property(h => h.Description).HasColumnType("ntext").HasMaxLength(int.MaxValue);
            builder.Entity<Location>().Property(l => l.Description).HasColumnType("ntext");
            builder.Entity<Restaurant>().Property(r => r.Description).HasColumnType("ntext");
            builder.Entity<EmailTemplate>().Property(r => r.Body).HasColumnType("ntext");
            builder.Entity<Comment>(comment =>
            {
                comment.HasKey(c => c.Id);
                comment.Property(c => c.Content).HasColumnType("ntext").IsRequired(false);

                comment.HasOne(c => c.Customer)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

                comment.HasOne(c => c.Tour)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TourId)
                .OnDelete(DeleteBehavior.Cascade);
            });


            foreach (var entityTyppe in builder.Model.GetEntityTypes())
            {
                var tableName = entityTyppe.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityTyppe.SetTableName(tableName.Substring(6));
                }
            }

            builder.ApplyConfiguration(new DreamTourUserIdentityConfiguration());
            builder.ApplyConfiguration(new DreamTourRoleIdentityConfiguration());
        }
    }
}
