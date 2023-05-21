using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UMCTravelTour.Core.Models
{
    public class Restaurant : BaseEntity
    {
        public Restaurant()
        {
            //Tours = new List<Tour>();
            TourRestaurantMappings = new List<TourRestaurantMapping>();
        }

        [Key]
        public int RestaurantId { get; set; }
        [Required]
        [Display(Name ="Restaurant name")]
        public string RestaurantName { get; set; }
        [Display(Name = "Location name")]
        public int LocationId { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        [MaxLength(12)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        public string Status { get; set; }
        public string UrlSlug { get; set; }

        public virtual Location Location { get; set; }
        //public virtual ICollection<Tour> Tours { get; set; }
        public virtual ICollection<TourRestaurantMapping> TourRestaurantMappings { get; set; }
    }
}
