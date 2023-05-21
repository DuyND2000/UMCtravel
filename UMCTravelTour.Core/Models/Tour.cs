using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UMCTravelTour.Core.Models
{
    public class Tour : BaseEntity
    {
        public Tour()
        {
            Bookings = new List<Booking>();
            TourRestaurantMappings = new List<TourRestaurantMapping>();
        }

        [Key]
        public int TourId { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name ="Tour name")]
        public string TourName { get; set; }

        public string ImageLink { get; set; }

        [Required]
        [Display(Name = "Hotel name")]
        public int HotelId { get; set; }

        /*[Display(Name = "Restaurant name")]
        public int RestaurantId { get; set; }*/
        public string Duration { get; set; }

        //Abundant save to reduce server load
        [Display(Name ="Total price")]
        public decimal TotalPrice { get; set; }

        public string Description { get; set; }

        [MaxLength(500)]
        [Display(Name = "Short description")]
        public string ShortDescription { get; set; }

        public string Schedule { get; set; }

        public string Status { get; set; }

        [Display(Name ="Created on")]
        public DateTime CreatedDate { get; set; }

        [Display(Name ="Average rating")]
        [Range(0d,10d,ErrorMessage = "Average rating must be between 0 and 10")]
        public decimal Rating { get; set; } = 0;

        //Rated by how many people, used for rating/feedback
        [Display(Name ="Rated by")]
        [Range(0,int.MaxValue)]
        public int RatedBy { get; set; } = 0;

        public string UrlSlug { get; set; }

        [Range(0,double.MaxValue)]
        public double Price { get; set; }

        public string Transport { get; set; }

        public virtual Hotel Hotel { get; set; }
        //public virtual Restaurant Restaurant { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<TourRestaurantMapping> TourRestaurantMappings { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
    }
}
