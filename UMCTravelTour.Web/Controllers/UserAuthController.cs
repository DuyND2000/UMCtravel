using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core;
using UMCTravelTour.Core.CustomIdentity;
using UMCTravelTour.Service.Customers;
using UMCTravelTour.Service.EmailTemplates;
using UMCTravelTour.ViewModel.Customers;
using UMCTravelTour.ViewModel.EmailTemplates;
using UMCTravelTour.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UMCTravelTour.Web.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly UMCTravelContext _context;
        private readonly UserManager<DreamTourUser> _userManager;
        private readonly SignInManager<DreamTourUser> _signInManager;
        private readonly IEmailTemplateSerice _emailTemplateSerice;
        private readonly ICustomerService _customerService;

        public UserAuthController(UMCTravelContext context,
                                UserManager<DreamTourUser> userManager,
                                SignInManager<DreamTourUser> signInManager,
                                IEmailTemplateSerice emailTemplateSerice,
                                ICustomerService customerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailTemplateSerice = emailTemplateSerice;
            _customerService = customerService;
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            loginModel.LoginValid = "false";

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Email không tồi tại!");
                    return PartialView("_UserLoginPartial", loginModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (TempData["returnUrl"] != null)
                    {
                        loginModel.LoginValid = TempData["returnUrl"].ToString();
                    }
                    else
                    {
                        loginModel.LoginValid = "";
                    }
                }
                else
                {
                    if (!user.EmailConfirmed)
                    {
                        ModelState.AddModelError(string.Empty, "Hãy kiểm tra và xác minh email của bạn !");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Không thể đăng nhập");
                    }
                }
            }

            return PartialView("_UserLoginPartial", loginModel);
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationModel registrationModel)
        {
            registrationModel.RegistrationValid = "false";

            if (ModelState.IsValid)
            {
                string userName = registrationModel.FirstName + "@" + Guid.NewGuid().ToString().Substring(0, 4);
                DreamTourUser user = new DreamTourUser()
                {
                    UserName = userName,
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    PhoneNumber = registrationModel.PhoneNumber,
                    Email = registrationModel.SignUpEmail
                };

                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError(string.Empty, "Tài khoản đã tồn tại");
                    return PartialView("_UserRegistrationPartial", registrationModel);
                }

                if (_context.Users.Any(u => u.PhoneNumber == user.PhoneNumber))
                {
                    ModelState.AddModelError(string.Empty, "Số điện thoại đã được sử dụng");
                    return PartialView("_UserRegistrationPartial", registrationModel);
                }

                var result = await _userManager.CreateAsync(user, registrationModel.SignUpPassword);

                if (result.Succeeded)
                {
                    registrationModel.RegistrationValid = "";

                    var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.ConfirmRegister);
                    var mailContent = new EmailTemplateVm();
                    mailContent.To = user.Email;
                    mailContent.CC = emailTemplate.CC;
                    mailContent.BCC = emailTemplate.BCC;
                    mailContent.Object = emailTemplate.Object;

                    var body = emailTemplate.Body;
                    body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    body = body.Replace("##UserName##", user.FirstName + " " + user.LastName);
                    body = body.Replace("##Email##", user.Email);
                    mailContent.Body = body;
                    var sendMailService = _emailTemplateSerice.SendGmail(mailContent);

                    return PartialView("_UserRegistrationPartial", registrationModel);
                }
                else if(result.Errors.Any()) 
                {
                    if (result.Errors.FirstOrDefault(x=>x.Code == "DuplicateUserName") != null)
                    {
                        ModelState.AddModelError(string.Empty, "Tên đăng nhập đã được sử dụng!");
                    }
                }
                
            }

            return PartialView("_UserRegistrationPartial", registrationModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (!user.EmailConfirmed)
            {
                user.EmailConfirmed = true;

                var customerVm = new CustomerVm()
                {
                    CustomerName = $"{user.FirstName} {user.LastName}",
                    Phone = user.PhoneNumber,
                    Address = "",
                    Email = user.Email,
                    IdentityCardNumber = null
                };

                await _customerService.AddAsync(customerVm);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }
        static string storedPassword = "";
        public async Task<IActionResult> ResetPassword(string email)
        {
            if (email == "admin@umctravel.com")
            {
                return BadRequest();
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                storedPassword = GenerateNewPassword();
                //send email
                TempData["verifyMsg"] = "Chúng tôi đã gửi mật khẩu mới, vui lòng kiểm tra mail của bạn !";

                var emailTemplate = _emailTemplateSerice.GetByTilte(Constant.EmailTitleTemplate.ForgetPassword);
                var mailContent = new EmailTemplateVm();
                mailContent.To = user.Email;
                mailContent.CC = emailTemplate.CC;
                mailContent.BCC = emailTemplate.BCC;
                mailContent.Object = emailTemplate.Object;

                var body = emailTemplate.Body;
                body = body.Replace("##Datetime##", DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                body = body.Replace("##UserName##", user.FirstName + " " + user.LastName);
                body = body.Replace("##NewPassword##", storedPassword);
                body = body.Replace("##Email##", user.Email);
                mailContent.Body = body;
                var sendMailService = _emailTemplateSerice.SendGmail(mailContent);
            }
            else
            {
                TempData["verifyMsg"] = "Email này chưa được đăng ký!";
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ConfirmResetPassword(string email)
        {
            if (!string.IsNullOrEmpty(storedPassword))
            {
                var user = await _userManager.FindByEmailAsync(email);
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, storedPassword);

                if (result.Succeeded)
                {
                    //send email
                    TempData["verifyMsg"] = "Mật khẩu của bạn đã được thay đổi !";
                    storedPassword = "";
                }
                else
                {
                    TempData["verifyMsg"] = "Thay đổi mật khẩu không thành công !";
                }
            }
            else
            {
                TempData["verifyMsg"] = "Có lỗi xảy ra ! Vui lòng thử lại sau";
            }
            return RedirectToAction("Index", "Home");
        }

        private string GenerateNewPassword()
        {
            string uniqueChars = "!,@,#,$,%,&,?";
            string numericChars = "1,2,3,4,5,6,7,8,9,0";
            string lowerChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            string upperChars = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";

            char[] sep = { ',' };
            string[] arr1 = uniqueChars.Split(sep);
            string[] arr2 = numericChars.Split(sep);
            string[] arr3 = lowerChars.Split(sep);
            string[] arr4 = upperChars.Split(sep);

            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < 2; i++)
            {
                temp = arr1[rand.Next(0, arr1.Length)] +
                    arr2[rand.Next(0, arr2.Length)] +
                    arr3[rand.Next(0, arr3.Length)] +
                    arr4[rand.Next(0, arr4.Length)];
                passwordString += temp;
            }

            return passwordString;
        }
    }
}
