using System.ComponentModel.DataAnnotations;

namespace UMCTravelTour.Web.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(255, ErrorMessage = "Tên không được phép quá 255 ký tự")]
        [Display(Name = "Tên")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Họ đệm không được để trống")]
        [StringLength(255, ErrorMessage = "Họ đệm không được phép quá 255 ký tự")]
        [Display(Name = "Họ đệm")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string SignUpEmail { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string SignUpPassword { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Compare("SignUpPassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        public bool AcceptAgreement { get; set; }
        public string RegistrationValid { get; set; }
    }
}
