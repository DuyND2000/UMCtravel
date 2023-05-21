using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMCTravelTour.Core.Models
{
    public class Room : BaseEntity
    {
        //Composite key, set using Fluent API
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name ="Room type")]
        public string RoomName { get; set; }
        [Range(0,double.MaxValue,ErrorMessage ="Price must be greater or equal to 0")]
        public decimal Price { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string UrlSlug { get; set; }

        public virtual Hotel Hotel { get; set; }
     
    }
}
