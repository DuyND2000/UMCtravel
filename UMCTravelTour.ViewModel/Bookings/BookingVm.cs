using UMCTravelTour.ViewModel.Customers;
using UMCTravelTour.ViewModel.Tours;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.Bookings
{
    public class BookingVm {
        public BookingVm()
        {

        }
        [Required]

        [Display(Name = "Mã booking")]
        public int BookingId { get; set; }

        [Display(Name = "Khách hàng")]
        public int CustomerId { get; set; }
        [Display(Name = "Mã chuyến đi")]
        public int TourId { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập ngày khởi hành")]
        [Display(Name = "Ngày khởi hành")]
        [StartDate(ErrorMessage = "Ngày khởi hành phải lớn hơn ngày hiện tại 7 ngày")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Display(Name = "Tổng giá tiền")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public DateTime EndDate { get; set; }

        [Required]
        public CustomerVm Customer { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số người tham gia")]
        [Range(1, 50, ErrorMessage = "Số lượng trong khoảng từ 1 đến 50 người")]
        [Display(Name = "Số người tham gia")]
        public int TourParticipantCount { get; set; }

        [Display(Name = "Phòng")]
        public int RoomId { get; set; }
        [Display(Name = "Khách Sạn")]
        public int HotelId { get; set; }
        [Display(Name = "Tạm tính")]
        public decimal ExpectedPrice { get; set; } 
        [MaxLength(150)]

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
        public string IsValidBooking { get; set; }

        [Display(Name = "Đặt cọc")]
        public decimal Deposit { get; set; } = 0;
    }
    public class StartDateAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);
            if (date > DateTime.Now.AddDays(7))
                return ValidationResult.Success;
            return new ValidationResult(ErrorMessage);
        }
    }
}
