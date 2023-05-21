using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.Hotels
{
    public class HotelCard
    {
        public int HotelId { get; set; }
      
        [Display(Name = "Tên khách sạn")]
        public string HotelName { get; set; }

        [Display(Name = "Ảnh")]
        public string ImageLink { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Loại phòng")]
        public string RoomPrice { get; set; }
        [Display(Name = "Mô tả")]
        public string ShortDescription { get; set; }
    }
}
