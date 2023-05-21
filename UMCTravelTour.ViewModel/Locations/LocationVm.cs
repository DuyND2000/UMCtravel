using UMCTravelTour.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.Locations
{
    public class LocationVm
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Tên địa điểm")]
        public string LocationName { get; set; }

        [Display(Name = "Ảnh")]
        public string ImageLink { get; set; }
        [MaxLength(500000)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Link tới")]
        public string UrlSlug { get; set; }
        [Display(Name = "Sửa bởi")]
        public string LastModifiedBy { get; set; }
        [Display(Name = "Sửa ngày")]
        public DateTime LastModifiedOn { get; set; } = DateTime.Now;
        [Display(Name = "Khách sạn")]
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
        [Display(Name = "Nhà Hàng")]
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
