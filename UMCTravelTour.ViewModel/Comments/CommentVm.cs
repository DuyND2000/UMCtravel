using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.Comments
{
    public class CommentVm
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Khách hàng")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Đánh giá")]
        public int TourId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Đánh giá từ 1 đến 5 sao")]
        [Display(Name = "Đánh giá")]
        public int RatePoint { get; set; }

        public string Content { get; set; }

        public DateTime LastModifiedOn { get; set; } = DateTime.Now;
    }
}
