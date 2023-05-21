using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UMCTravelTour.Core.Models
{
    public class Hotel : BaseEntity
    {
        public Hotel()
        {
            Rooms = new List<Room>();
            Tours = new List<Tour>();
        }

        [Key]
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Tên khách sạn không được để trống")]
        [MaxLength(100)]
        [Display(Name ="Tên khách sạn")]
        public string HotelName { get; set; }
        [Display(Name = "Tên địa điểm")]
        public int LocationId { get; set; }
        [MaxLength(12)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        public string ImageLink { get; set; }
        public string ShortDescription { get; set; }
        [MaxLength(5000)]
        public string Description { get; set; }
        public string Status { get; set; }
        public string UrlSlug { get; set; }

        public string RoomPrice { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
