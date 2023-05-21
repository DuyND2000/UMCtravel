using UMCTravelTour.ViewModel.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.Tours
{
    public class TourVm
    {
        [Key]
        public int BookingId { get; set; }
        public int TourId { get; set; }
        [Required(ErrorMessage ="Không được để trống")]
        [MaxLength(200)]
        [Display(Name = "Tên chuyến đi")]
        public string TourName { get; set; }
        [Display(Name = "Ảnh")]
        public string ImageLink { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Nhà hàng")]
        public int HotelId { get; set; }
        /*[Display(Name = "Restaurant name")]
        public int RestaurantId { get; set; }*/
        [Display(Name = "Thời gian kéo dài")]
        public string Duration { get; set; }
        //Abundant save to reduce server load
        [Display(Name = "Tổng tiền")]
        public decimal TotalPrice { get; set; }
        [MaxLength(50000)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [MaxLength(500)]
        [Display(Name ="Mô tả vắn tắt")]
        public string ShortDescription { get; set; }
        [Display(Name = "Thời gian biểu")]
        public string Schedule { get; set; }
        [Display(Name = "Đánh giá")]
        public double avgRatePoint { get; set; }
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Phương tiện")]
        public string Transport { get; set; }
        [Display(Name = "Average rating")]
        [Range(0d, 10d, ErrorMessage = "Average rating must be between 0 and 10")]
        public decimal Rating { get; set; } = 0;
        //Rated by how many people, used for rating/feedback
        /* [Display(Name = "Rated by")]
         [Range(0, int.MaxValue)]
         public int RatedBy { get; set; } = 0;*/
        [Display(Name = "Đường dẫn")]
        public string UrlSlug { get; set; }
        public List<int> restaurantId { get; set; }
    }
}
