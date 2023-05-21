using System.ComponentModel.DataAnnotations;
using System;

namespace UMCTravelTour.Web.ViewModels
{
    public class TourDesignViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        //Tour
        [MaxLength(200)]
        [Display(Name = "Tên chuyến đi")]
        public string TourName { get; set; }
        [Required]
        [Display(Name = "Tên khách sạn")]
        public int HotelId { get; set; }
        //Booking
        [Range(1, 50, ErrorMessage = "Số lượng người tham gia phải trong khoảng từ 1 đến 50")]
        [Display(Name = "Số hành khách")]
        public int TourParticipantCount { get; set; }
        [Display(Name = "Ngày khởi hành")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public string Status { get; set; }
        //Restaurantjson
        public string jsonRestaurant { get; set; }
    }
}
