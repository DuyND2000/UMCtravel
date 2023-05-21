using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UMCTravelTour.Core.Models
{
    public class Booking : BaseEntity
    {
        [Key]
        [Display(Name = "Mã booking")]
        public int BookingId { get; set; }

        [Display(Name = "Tour")]
        public int TourId { get; set; }
        [Display(Name ="Ngày bắt đầu")]
        public DateTime StartDate { get; set; }
        [Display(Name ="Ngày kết thúc")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Khách hành")]
        public int CustomerId { get; set; }
        [Range(1,50,ErrorMessage = "Số người trong khoảng từ 1 đến 50 người")]
        [Display(Name ="Số khách")]
        public int TourParticipantCount { get; set; }
        public decimal ExpectedPrice { get; set; } = 0;

        [Display(Name = "Đặt cọc")]
        public decimal Deposit { get; set; } = 0;

        [Display(Name = "Tổng tiền")]
        public decimal TotalPrice { get; set; } = 0;

        [Display(Name = "Phòng")]
        public int RoomId { get; set; }

        [MaxLength(150)]
        public string Note { get; set; }

        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
