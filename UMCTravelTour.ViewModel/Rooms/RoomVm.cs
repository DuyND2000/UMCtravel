using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.Rooms
{
    public class RoomVm
    {
        [Display(Name = "Tên khách sạn")]
        public int HotelId { get; set; }

        [Display(Name = "Phòng")]
        public int RoomId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Loại phòng")]
        public string RoomName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Gía phải lớn hơn 0")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [MaxLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Ảnh")]
        public string ImageLink { get; set; }
        public string UrlSlug { get; set; }
    }
}
