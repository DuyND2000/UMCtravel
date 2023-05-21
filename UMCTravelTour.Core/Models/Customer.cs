using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UMCTravelTour.Core.Models
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Bookings = new List<Booking>();
        }

        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Họ tên không được để trống")]
        [MaxLength(100)]
        [Display(Name ="Họ và tên khách hàng")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Điện thoại không được để trống")]
        [MaxLength(12)]
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [Display(Name = "Địa chỉ")]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        [Display(Name = "Số chứng minh thư")]
        public string IdentityCardNumber { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
