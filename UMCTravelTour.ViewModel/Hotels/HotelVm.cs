using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.Hotels
{
    public class HotelVm
    {
        [Key]
        [Display(Name = "Mã khách sạn")]
        public int HotelId { get; set; }
        [Required(ErrorMessage = "You must {0} ")]
        [MaxLength(100)]
        [Display(Name = "Tên")]
        public string HotelName { get; set; }

        [Display(Name ="Mã địa điểm")]
        public int LocationId { get; set; }
        [Display(Name = "Tên địa điểm")]
        public string LocationName { get; set; }
        [MaxLength(12)]
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }

        [Display(Name = "Ảnh")]
        public string ImageLink { get; set; }

        [Display(Name = "Mô tả")]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Display(Name = "Đường dẫn")]
        public string UrlSlug { get; set; }

        [Display(Name = "Gía phòng")]
        public string RoomPrice { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Mô tả vắn tắt")]
        public string ShortDescription { get; set; }

        [Display(Name = "Người sửa")]
        public string LastModifiedBy { get; set; }

        [Display(Name = "Ngày sửa")]
        public DateTime LastModifiedOn { get; set; } = DateTime.Now;
    }
}
