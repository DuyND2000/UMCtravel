using System.ComponentModel.DataAnnotations;

namespace UMCTravelTour.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Nhớ mật khẩu")]
        public bool RememberMe { get; set; }
        public string LoginValid { get; set; }
    }
}
