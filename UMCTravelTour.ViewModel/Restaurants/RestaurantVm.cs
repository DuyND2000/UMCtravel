using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.Restaurants
{
    public class RestaurantVm
    {
        [Key]
        public int RestaurantId { get; set; }
        [Required(ErrorMessage  = "Không được để trống")]
        [Display(Name ="Tên nhà hàng")]

        [MaxLength(200)]
        public string RestaurantName { get; set; }

        [Display(Name = "Tên địa điểm")]
        public int LocationId { get; set; }

        [Display(Name = "Ảnh")]
        public string ImageLink { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [MaxLength(12)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
        public string UrlSlug { get; set; }

    }
}
