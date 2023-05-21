using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Core.Models
{
    public class Comment : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public int TourId { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(1,5, ErrorMessage = "Đánh giá trong khoảng từ một đến 5 sao")]
        [Display(Name = "Điểm đánh giá")]
        public int RatePoint { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        public Customer Customer { get; set; }
        public Tour Tour { get; set; }
    }
}
