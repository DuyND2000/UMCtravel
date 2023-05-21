using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UMCTravelTour.Core.Models
{
    public class Location : BaseEntity
    {
        public Location()
        {
            Hotels = new List<Hotel>();
            Restaurants = new List<Restaurant>();
        }

        [Key]
        public int LocationId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Location name")]
        public string LocationName { get; set; }
        public string ImageLink { get; set; }
        [MaxLength(50000)]
        public string Description { get; set; }
        public string UrlSlug { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
