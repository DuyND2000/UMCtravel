using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.Customers
{
    public class CustomerVm
    {
        [Key]
        public int CustomerId { get; set; }
        
        [Required(ErrorMessage ="Bạn phải nhập tên")]
        [MaxLength(100)]
        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        [MaxLength(12)]
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        [MaxLength(200)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập email")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Display(Name = "Số căn cước")]
        [MaxLength(20)]
        public string IdentityCardNumber { get; set; }
    }
}
