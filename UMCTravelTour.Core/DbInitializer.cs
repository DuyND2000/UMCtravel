using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core.CustomIdentity;
using UMCTravelTour.Core.Models;
namespace UMCTravelTour.Core
{
    public class DbInitializer
    {
        private readonly UMCTravelContext _context;

        public DbInitializer(UMCTravelContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            SeedRolesAndAccounts();
            SeedLocation();
            SeedTour();
            SeedTourRestaurantMap();
            SeedEnglishStaticContent();
            SeedEmailTemplate();
            _context.SaveChanges();
            AssignRoles();
        }
        private void AssignRoles()
        {
            if (!_context.UserRoles.Any())
            {
                var admin = _context.Users.FirstOrDefault(u => u.Email == "admin@umctravel.com");
                var employee1 = _context.Users.FirstOrDefault(u => u.Email == "employee1@gmail.com");
                var employee2 = _context.Users.FirstOrDefault(u => u.Email == "employee2@gmail.com");
                var roleAdministratorId = _context.Roles.FirstOrDefault(r => r.Name == Constant.Role.Administrator).Id;
                var roleManagerId = _context.Roles.FirstOrDefault(r => r.Name == Constant.Role.Manager).Id;
                var roleEmployeeId = _context.Roles.FirstOrDefault(r => r.Name == Constant.Role.Employee).Id;
                _context.UserRoles.AddRange(
                    new IdentityUserRole<string>()
                    {
                        RoleId = roleAdministratorId,
                        UserId = admin.Id
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = roleManagerId,
                        UserId = employee1.Id
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = roleEmployeeId,
                        UserId = employee2.Id
                    }
                );
                _context.SaveChanges();
            }
        }
        private void SeedRolesAndAccounts()
        {
            string[] roles = new[] { Constant.Role.Administrator, Constant.Role.Manager, Constant.Role.Employee };

            foreach (string role in roles)
            {
                var roleStore = _context.Roles;

                if (!_context.Roles.Any(r => r.Name == role))
                {
                    if (role == Constant.Role.Administrator)
                    {
                        roleStore.Add(new DreamTourRole() { Name = Constant.Role.Administrator, NormalizedName = Constant.Role.Administrator.ToUpper(), Description = "This is the most powerful role" });
                    }
                    else if (role == Constant.Role.Manager)
                    {
                        roleStore.Add(new DreamTourRole() { Name = Constant.Role.Manager, NormalizedName = Constant.Role.Manager.ToUpper(), Description = "This is the half powerful role" });
                    }
                    else if (role == Constant.Role.Employee)
                    {
                        roleStore.Add(new DreamTourRole() { Name = Constant.Role.Employee, NormalizedName = Constant.Role.Employee.ToUpper(), Description = "Nothing to say" });
                    }
                }
            }
            #region Admin Accounts
            var user = new DreamTourUser()
            {
                FirstName = "Quan tri",
                LastName = "vien",
                Email = "admin@umctravel.com",
                NormalizedEmail = ("admin@umctravel.com").ToUpper(),
                UserName = "Quantrivien",
                NormalizedUserName = ("Quantrivien").ToUpper(),
                PhoneNumber = "0988888888",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (_context.Users.FirstOrDefault(u => u.Email == "admin@umctravel.com") == null)
            {
                var password = new PasswordHasher<DreamTourUser>();
                var hashed = password.HashPassword(user, "Admin@123");
                user.PasswordHash = hashed;

                _context.Users.Add(user);
                //var userStore = new UserStore<DreamTourUser>(_context);
                //var result = userStore.CreateAsync(user);
            }
            #endregion
            #region Employee Accounts
            var emp1 = new DreamTourUser()
            {
                FirstName = "Employee",
                LastName = "Number1",
                Email = "employee1@gmail.com",
                NormalizedEmail = ("employee1@gmail.com").ToUpper(),
                UserName = "Employee@a001",
                NormalizedUserName = ("Employee@a001").ToUpper(),
                PhoneNumber = "0342000789",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (_context.Users.FirstOrDefault(u => u.Email == "employee1@gmail.com") == null)
            {
                var password = new PasswordHasher<DreamTourUser>();
                var hashed = password.HashPassword(emp1, "Abc@123");
                emp1.PasswordHash = hashed;

                _context.Users.Add(emp1);
            }
            var emp2 = new DreamTourUser()
            {
                FirstName = "Employee",
                LastName = "Number2",
                Email = "employee2@gmail.com",
                NormalizedEmail = ("employee2@gmail.com").ToUpper(),
                UserName = "Employee@b002",
                NormalizedUserName = ("Employee@b002").ToUpper(),
                PhoneNumber = "0975675891",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (_context.Users.FirstOrDefault(u => u.Email == "employee2@gmail.com") == null)
            {
                var password = new PasswordHasher<DreamTourUser>();
                var hashed = password.HashPassword(emp2, "Abc@123");
                emp2.PasswordHash = hashed;

                _context.Users.Add(emp2);
            }
            #endregion
            #region Customer Accounts
            var user1 = new DreamTourUser()
            {
                FirstName = "Duy",
                LastName = "Nguyen Duc",
                Email = "ndd@gmail.com",
                NormalizedEmail = ("ndd@gmail.com").ToUpper(),
                UserName = "Duy@123",
                NormalizedUserName = ("Duy@123").ToUpper(),
                PhoneNumber = "0344356436",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (_context.Users.FirstOrDefault(u => u.Email == "ndd@gmail.com") == null)
            {
                var password = new PasswordHasher<DreamTourUser>();
                var hashed = password.HashPassword(user1, "Abc@123");
                user1.PasswordHash = hashed;

                _context.Users.Add(user1);
            }
            var user2 = new DreamTourUser()
            {
                FirstName = "David",
                LastName = "Beckam",
                Email = "davidbeckham@gmail.com",
                NormalizedEmail = ("davidbeckham@gmail.com").ToUpper(),
                UserName = "David@696r",
                NormalizedUserName = ("David@696r").ToUpper(),
                PhoneNumber = "0988668866",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (_context.Users.FirstOrDefault(u => u.Email == "davidbeckham@gmail.com") == null)
            {
                var password = new PasswordHasher<DreamTourUser>();
                var hashed = password.HashPassword(user2, "Abc@123");
                user2.PasswordHash = hashed;

                _context.Users.Add(user2);
            }
            #endregion
        }
        private void SeedEmailTemplate()
        {
            if (_context.EmailTemplates.Any())
                return;
            _context.EmailTemplates.AddRange(
                new EmailTemplate()
                {
                    EmailTilte = "confirm-register-success",
                    CC = "",
                    BCC = "",
                    Object = "Xác nhận địa chỉ mail của bạn",
                    Body = @"<div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_heading_2"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 100%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 70px;"">                                                                <strong>Đăng nhập</strong>                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_heading_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 190%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 35px;"">                                                                Xác nhận địa chỉ mail của bạn                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>                    <div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ddf2fe;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_text_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 18px; line-height: 32.4px; font-family: 'trebuchet ms', geneva;"">##Datetime##</span></p>                                                                <p style=""line-height: 180%; font-size: 14px;""><br /><span style=""font-size: 20px; line-height: 36px; font-family: 'trebuchet ms', geneva;"">##UserName## thân mến, </span><br /><span style=""font-family: 'trebuchet ms', geneva; font-size: 14px; line-height: 25.2px;""><span style=""font-size: 16px; line-height: 28.8px;"">Cảm ơn đã ghé thăm chúng tôi!</span></span>                                                                </p>                                                                <p style=""font-size: 14px; line-height: 180%;""><br /><span style=""font-size: 16px; line-height: 28.8px; font-family: 'trebuchet ms', geneva;"">Để hoàn tất đăng ký, vui lòng xác nhận địa chỉ email của bạn. Điều này đảm bảo chúng tôi có đúng email trong trường hợp chúng tôi cần liên hệ với bạn.</span></p>                                                                <p style=""font-size: 14px; line-height: 180%;"">&nbsp;</p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align"" align=""center"">                                                                <a href=""https://localhost:44390/UserAuth/ConfirmEmail?email=##Email##"" target=""_blank"" style=""box-sizing: border-box;display: inline-block;font-family:arial,helvetica,sans-serif;text-decoration: none;-webkit-text-size-adjust: none;text-align: center;color: #bfedd2; background-color: #169179; border-radius: 4px;-webkit-border-radius: 4px; -moz-border-radius: 4px; width:auto; max-width:100%; overflow-wrap: break-word; word-break: break-word; word-wrap:break-word; mso-border-alt: none;"">                                                                    <span class=""v-line-height"" style=""display:block;padding:10px 20px;line-height:120%;""><span style=""font-size: 14px; line-height: 16.8px;"">CONFIRM</span></span>                                                                </a>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_text_4"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 55px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><strong>Thân gửi,</strong><br />UMC Travel</p>                                                                <p style=""font-size: 14px; line-height: 180%;"">&nbsp;</p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>"
                },
                new EmailTemplate()
                {
                    EmailTilte = "forget-password",
                    CC = "",
                    BCC = "",
                    Object = "Cài lại mật khẩu",
                    Body = @"<div class=""u - row - container"" style=""padding: 0px; background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_heading_2"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 100%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 70px;"">                                                                <strong>Thay đổi mật khẩu</strong>                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_heading_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 190%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 35px;"">                                                                Mật khẩu mới                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>                    <div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ddf2fe;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_text_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 18px; line-height: 32.4px; font-family: 'trebuchet ms', geneva;"">##Datetime##</span></p>                                                                <p style=""line-height: 180%; font-size: 14px;""><br /><span style=""font-size: 20px; line-height: 36px; font-family: 'trebuchet ms', geneva;"">##UserName## thân mến, </span><br /><span style=""font-family: 'trebuchet ms', geneva; font-size: 14px; line-height: 25.2px;""><span style=""font-size: 16px; line-height: 28.8px;"">Nếu bạn mất mật khẩu hoặc muốn đặt lại mật khẩu, hãy nhấp vào nút để xác nhận thay đổi đối với mật khẩu mới của bạn, đây là mật khẩu của bạn: </span></span>                                                                </p>                                                                <p>                                                                    <div class=""v-text-align"" align=""center""><span style=""font-weight: bold;"">##NewPassword##</span></div>                                                                </p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align"" align=""center"">                                                                <a href=""https://localhost:44390/UserAuth/ConfirmResetPassword?email=##Email##"" target=""_blank"" style=""box-sizing: border-box;display: inline-block;font-family:arial,helvetica,sans-serif;text-decoration: none;-webkit-text-size-adjust: none;text-align: center;color: #bfedd2; background-color: #169179; border-radius: 4px;-webkit-border-radius: 4px; -moz-border-radius: 4px; width:auto; max-width:100%; overflow-wrap: break-word; word-break: break-word; word-wrap:break-word; mso-border-alt: none;"">                                                                    <span class=""v-line-height"" style=""display:block;padding:10px 20px;line-height:120%;""><span style=""font-size: 14px; line-height: 16.8px;"">CONFIRM</span></span>                                                                </a>                                                            </div>                                                        </td>                                                    </tr>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:0px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 10px; line-height: 180%; font-style: italic; color: crimson;""><br /><span style=""font-size: 14px; line-height: 28.8px; font-family: 'trebuchet ms', geneva;"">If you do not send this request, please safely ignore this email. Only a person with access to your email can reset your account password.</span></p>                                                                <p style=""font-size: 14px; line-height: 180%;"">&nbsp;</p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_text_4"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 55px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><strong>Thân gửi,</strong><br />UMC Travel</p>                                                                <p style=""font-size: 14px; line-height: 180%;"">&nbsp;</p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>"
                },
                new EmailTemplate()
                {

                    EmailTilte = "booking-success",
                    CC = "",
                    BCC = "",
                    Object = "Trạng thái chuyến đi",
                    Body = @"<div class=""u - row - container"" style=""padding: 0px; background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_heading_2"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 100%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 70px;"">                                                                <strong>Đặt chỗ</strong>                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_heading_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 190%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 35px;"">                                                                Đặt chuyến thành công                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>                    <div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ddf2fe;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_text_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 18px; line-height: 32.4px; font-family: 'trebuchet ms', geneva;"">##Datetime##</span></p>                                                                <p style=""line-height: 180%; font-size: 14px;""><br /><span style=""font-size: 20px; line-height: 36px; font-family: 'trebuchet ms', geneva;"">##UserName## thân mến, </span><br /><span style=""font-family: 'trebuchet ms', geneva; font-size: 14px; line-height: 25.2px;""><span style=""font-size: 16px; line-height: 28.8px;"">Cảm ơn đã lựa chọn UMC Travel cho kế hoạch của bạn</span></span>                                                                </p>                                                                <p><span style=""font-size: 16px; line-height: 28.8px;"">Yêu cầu đặt vé của bạn đã được duyệt, chúng tôi sẽ liên hệ với bạn để hoàn tất mọi thủ tục trong thời gian sớm nhất.</span>                                                                </p>                                                            </div>                                                            <table border=""1"" id=""u_content_text_1"" style=""font-family:arial,helvetica,sans-serif; border: 1px solid #6d7985;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"">                                                                <tbody>                                                                    <tr>                                                                        <td colspan=""2"" class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:0px;font-family:arial,helvetica,sans-serif; background-color: #489066;"" align=""center"">                                                                            <div class=""v-text-align v-line-height"" style=""color: #343b42; line-height: 100%; word-wrap: break-word;"">                                                                                <h3>                                                                                    Booking information                                                                                </h3>                                                                            </div>                                                                        </td>                                                                    </tr>                                                                    <tr>                                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                                Booking ID:                                                                            </div>                                                                        </td>                                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                                ##Matracuu##                                                                            </div>                                                                        </td>                                                                    </tr>                                                                    <tr>                                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                                Start time:                                                                            </div>                                                                        </td>                                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                                ##StartTour##                                                                            </div>                                                                        </td>                                                                    </tr>                                                                    <tr>                                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                                End time:                                                                            </div>                                                                        </td>                                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                                ##EndTour##                                                                            </div>                                                                        </td>                                                                    </tr>                                                                    <tr>                                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                                Total money:                                                                            </div>                                                                        </td>                                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                                ##Giatien##                                                                            </div>                                                                        </td>                                                                    </tr>                                                                </tbody>                                                            </table>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_text_4"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 55px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><strong>Thân gửi,</strong><br />UMC Travel</p>                                                                <p style=""font-size: 14px; line-height: 180%;"">&nbsp;</p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>"
                },
                new EmailTemplate()
                {

                    EmailTilte = "payment-success",
                    CC = "",
                    BCC = "",
                    Object = "Đặt cọc cho chuyến đi",
                    Body = @"<div class=""u - row - container"" style=""padding: 0px; background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_heading_2"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 100%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 70px;"">                                                                <strong>Chuyến đi</strong>                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_heading_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 190%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 35px;"">                                                                Bạn vừa đặt cọc thành công                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>                    <div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ddf2fe;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_text_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 18px; line-height: 32.4px; font-family: 'trebuchet ms', geneva;"">##Datetime##</span></p>                                                                <p style=""line-height: 180%; font-size: 14px;""><br /><span style=""font-size: 20px; line-height: 36px; font-family: 'trebuchet ms', geneva;"">##UserName## thân mến, </span><br /><span style=""font-family: 'trebuchet ms', geneva; font-size: 14px; line-height: 25.2px;""><span style=""font-size: 16px; line-height: 28.8px;"">Cảm ơn đã đặt cọc !</span></span>                                                                </p>                                                                <p style=""line-height: 180%; font-size: 14px;""><span style=""font-family: 'trebuchet ms', geneva; font-size: 14px; line-height: 25.2px;""><span style=""font-size: 16px; line-height: 28.8px;"">Mã thanh toán:  ##MaThanhToan## <br/>  Tổng tiền:  ##TongTien##</span></span>                                                                </p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_text_4"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 55px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><strong>Thân gửi,</strong><br />UMC Travel</p>                                                                <p style=""font-size: 14px; line-height: 180%;"">&nbsp;</p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>"
                }
                ,
                new EmailTemplate()
                {

                    EmailTilte = "tour-cancel",
                    CC = "",
                    BCC = "",
                    Object = "Trạng thái chuyến đi",
                    Body = @"<div class=""u - row - container"" style=""padding: 0px; background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_heading_2"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 100%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 70px;"">                                                                <strong>Chuyến đi</strong>                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_heading_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 190%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 35px;"">                                                                Chuyến đi đã bị huỷ                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>                    <div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ddf2fe;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_text_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 18px; line-height: 32.4px; font-family: 'trebuchet ms', geneva;"">##Datetime##</span></p>                                                                <p style=""line-height: 180%; font-size: 14px;""><br /><span style=""font-size: 20px; line-height: 36px; font-family: 'trebuchet ms', geneva;"">##UserName## thân mến, </span><br /><span style=""font-family: 'trebuchet ms', geneva; font-size: 14px; line-height: 25.2px;""><span style=""font-size: 16px; line-height: 28.8px;"">Thật tiếc vì không thể đồng hành cùng bạn, nhưng cảm ơn vì đã ghé thăm trang web của chúng tôi. Chúng tôi hy vọng bạn có thể chọn một chuyến tham quan khác cho kỳ nghỉ của mình trên UMC Travel trong tương lai.</span></span>                                                                </p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_text_4"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 55px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><strong>Thân gửi,</strong><br />UMC Travel</p>                                                                <p style=""font-size: 14px; line-height: 180%;"">&nbsp;</p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>"
                },
                new EmailTemplate()
                {

                    EmailTilte = "thank-you",
                    CC = "",
                    BCC = "",
                    Object = "Cảm ơn",
                    Body = @"<div class=""u - row - container"" style=""padding: 0px; background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_heading_2"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 100%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 70px;"">                                                                <strong>Chuyến đi</strong>                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_heading_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 190%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 35px;"">                                                                Chuyến đi vừa hoàn tất                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>                    <div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ddf2fe;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_text_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 18px; line-height: 32.4px; font-family: 'trebuchet ms', geneva;"">##Datetime##</span></p>                                                                <p style=""line-height: 180%; font-size: 14px;""><br /><span style=""font-size: 20px; line-height: 36px; font-family: 'trebuchet ms', geneva;"">##UserName## thân mến, </span><br /><span style=""font-family: 'trebuchet ms', geneva; font-size: 14px; line-height: 25.2px;""><span style=""font-size: 16px; line-height: 28.8px;"">Cảm ơn bạn đã chọn UMC Travel, bạn vừa kết thúc chuyến tham quan của mình, chuyến đi của bạn như thế nào? Chỉ cần dành một phút để hoàn thành khảo sát của chúng tôi để cải thiện dịch vụ của chúng tôi trong tương lai!</span></span>                                                                    <br>                                                                    <span>Điền vào khảo sát của chúng tôi : <a href=""https://forms.gle/Z5AM5hYB4TzSGrS67"">https://forms.gle/Z5AM5hYB4TzSGrS67</a></span>                                                                </p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_text_4"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 55px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><strong>Thân gửi,</strong><br />UMC Travel</p>                                                                <p style=""font-size: 14px; line-height: 180%;"">&nbsp;</p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>"
                },
                 new EmailTemplate()
                 {

                     EmailTilte = "customer-sucess",
                     CC = "",
                     BCC = "",
                     Object = "Thay đổi thông tin ngời dùng",
                     Body = @"<div class=""u - row - container"" style=""padding: 0px; background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_heading_2"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 100%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 70px;"">                                                                <strong>Khách hàng</strong>                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_heading_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 190%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 35px;"">                                                                Thông tin của bạn vừa thay đổi                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>                    <div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ddf2fe;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_text_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 18px; line-height: 32.4px; font-family: 'trebuchet ms', geneva;"">##Datetime##</span></p>                                                                <p style=""line-height: 180%; font-size: 14px;""><br /><span style=""font-size: 20px; line-height: 36px; font-family: 'trebuchet ms', geneva;"">##UserName## thân mến, </span><br /><span style=""font-family: 'trebuchet ms', geneva; font-size: 14px; line-height: 25.2px;""><span style=""font-size: 16px; line-height: 28.8px;"">Thông tin của bạn đã được cập nhật do đặt phòng mới nhất tại trang web của chúng tôi</span></span>                                                                </p>                                                                <p style=""line-height: 180%; font-size: 14px;""><span style=""font-family: 'trebuchet ms', geneva; font-size: 14px; line-height: 25.2px;""><span style=""font-size: 16px; line-height: 28.8px;"">Tên khách hàng : ##TenKhachHang## <br/> Số điện thoại : ##Phone## <br/> Địa chỉ mail : ##Email##</span></span>                                                                </p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_text_4"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 55px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><strong>Thân gửi,</strong><br />UMC Travel</p>                                                                <p style=""font-size: 14px; line-height: 180%;"">&nbsp;</p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>"
                 },
                  new EmailTemplate()
                  {

                      EmailTilte = "pending-tour",
                      CC = "",
                      BCC = "",
                      Object = "Trạng thái chuyến đi",
                      Body = @"<div class=""u - row - container"" style=""padding: 0px; background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_heading_2"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 100%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 70px;"">                                                                <strong>Chuyến đi</strong>                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_heading_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 40px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #2f3448; line-height: 190%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: 'Montserrat',sans-serif; font-size: 35px;"">                                                                Đặt chuyến của bạn đang chờ xử lý                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>                    <div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ddf2fe;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_text_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px 55px 0px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 18px; line-height: 32.4px; font-family: 'trebuchet ms', geneva;"">##Datetime##</span></p>                                                                <p style=""line-height: 180%; font-size: 14px;""><br /><span style=""font-size: 20px; line-height: 36px; font-family: 'trebuchet ms', geneva;"">##UserName## thân mến, </span><br /><span style=""font-family: 'trebuchet ms', geneva; font-size: 14px; line-height: 25.2px;""><span style=""font-size: 16px; line-height: 28.8px;"">Cảm ơn bạn đã chọn UMC Travel cho kế hoạch du lịch của mình!</span></span>                                                                </p>                                                                <p><span style=""font-size: 16px; line-height: 28.8px;"">Chúng tôi đã nhận được yêu cầu của bạn và sẽ sớm liên hệ với bạn để thảo luận và cung cấp thêm thông tin chi tiết.</span>                                                                </p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table id=""u_content_text_4"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 55px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div class=""v-text-align v-line-height"" style=""color: #536475; line-height: 180%; text-align: left; word-wrap: break-word;"">                                                                <p style=""font-size: 14px; line-height: 180%;""><strong>Thân gửi,</strong><br />UMC Travel</p>                                                                <p style=""font-size: 14px; line-height: 180%;"">&nbsp;</p>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>"
                  }


            );

        }
        private void SeedEnglishStaticContent()
        {
            //Everything is set to english by default, add anything that need to be changed in the object initializer
            if (_context.StaticContents.Any())
                return;
            _context.StaticContents.Add(new StaticContent()
            {
                LanguageCode = "en"
            });
        }
        private void SeedTourRestaurantMap()
        {
            if (_context.TourRestaurantMappings.Any())
                return;
            _context.TourRestaurantMappings.AddRange(
                new TourRestaurantMapping()
                {
                    TourId = 1,
                    RestaurantId = 1
                },
                new TourRestaurantMapping()
                {
                    TourId = 1,
                    RestaurantId = 2
                },
                new TourRestaurantMapping()
                {
                    TourId = 1,
                    RestaurantId = 3
                },
                new TourRestaurantMapping()
                {
                    TourId = 2,
                    RestaurantId = 1
                },
                new TourRestaurantMapping()
                {
                    TourId = 2,
                    RestaurantId = 3
                },
                new TourRestaurantMapping()
                {
                    TourId = 3,
                    RestaurantId = 2
                });
        }
        private void SeedTour()
        {
            if (_context.Tours.Any())
                return;
            _context.Tours.AddRange(
                new Tour()
                {
                    TourName = "Let's go to England",
                    HotelId = 1,
                    //RestaurantId = 1,
                    ShortDescription = "Delve deep into the history and culture of three inspiring, influential cities.",
                    Schedule = @"<p>	<strong>Overnight Flight</strong></p><p>	1 night</p><p>	<strong>Day 1: Travel&nbsp;day</strong></p><p>	Board your overnight flight to London today.</p><p>	<strong>London </strong>|<strong> 3 nights</strong></p><p>	<strong>Day 2: Arrival in London</strong></p><p>	Included meal: Welcome dinner</p><p>	Welcome to England! Meet your fellow travelers at tonight&rsquo;s welcome dinner.</p><p>	<strong>Day 3: Sightseeing&nbsp;tour of London</strong></p><p>	Included meal: Breakfast</p><p>	Take a guided tour of the regal landmarks of the English capital with a local expert leading the way.</p><ul>	<li>		Pass the grand Trafalgar Square and Baroque-style St. Paul&rsquo;s Cathedral, perched atop Ludgate Hill	</li>	<li>		See Westminster Abbey, the setting for royal coronations, weddings, and funerals	</li>	<li>		View icons like Big Ben, the London Eye, and the Tower of London	</li>	<li>		Stop by Buckingham Palace, where you may catch the Changing of the Guard	</li></ul><p>	Enjoy a free afternoon in London or add an excursion.</p><p>	<img src=""https://img2.storyblok.com/1534x920/smart/f/53624/600x490/7dc9dfb8f9/windsor-castle-opwig.jpg""></p><p>	Windsor Castle</p><p>	From $115 per person</p><p>	<strong>Day 4: Free&nbsp;day&nbsp;in London</strong></p><p>	Included meal: Breakfast</p><p>	Spend a free day in London or add excursions.</p><p>	&nbsp;</p>",
                    TotalPrice = 3220000,
                    Description = "<h2>	Delve deep into the history and culture of three inspiring, influential cities.</h2><p>	Perhaps no cities have influenced the world more over the last 2,000 years than London, Paris, and Rome. On this guided tour, iconic sights like Big Ben, the Eiffel Tower, and the Colosseum are just the beginning of what you&#39;ll see. Take it all in as you embark on this sweeping trip through England, France, and Italy.</p><p>	Your tour package includes</p><ul>	<li>		3 nights in handpicked hotels	</li>	<li>		3 breakfasts	</li>	<li>		1 dinners with beer or wine	</li>	<li>		1 sightseeing tours	</li>	<li>		Expert Tour Director &amp; local guides	</li></ul><p>	Included highlights</p><ul>	<li>		Trafalgar Square	</li>	<li>		Buckingham Palace	</li>	<li>		Eurostar train ride	</li>	<li>		Eiffel Tower photo stop	</li>	<li>		Place de la Concorde	</li></ul><p>	&nbsp;</p>",
                    Status = "Active",
                    Duration = "3 days",
                    CreatedDate = new DateTime(2022, 3, 13),
                    UrlSlug = "lets-go-to-england",
                    ImageLink = "assets/images/Tour/1/england-gog.jpg"
                },
                new Tour()
                {
                    TourName = "Let's go to France",
                    HotelId = 1,
                    //RestaurantId = 2,
                    TotalPrice = 4315000,
                    Duration = "5 days",
                    ShortDescription = "Discover the many sides of France.",
                    Schedule = @"<p>	<strong>Overnight Flight</strong></p><p>	1 night</p><p>	<strong>Day 1: Travel day</strong></p><p>	Board your overnight flight to Lyon today.</p><p>	<strong>Lyon | 2 nights</strong></p><p>	<strong>Day 2: Arrival in Lyon</strong></p><p>	Included meal: Welcome dinner</p><p>	Welcome to France! Meet your Tour Director and fellow travelers at a welcome dinner this evening.</p><p>	<strong>Day 3: Sightseeing tour of Lyon</strong></p><p>	Included meal: Breakfast</p><p>	A local guide introduces you to France&rsquo;s culinary capital on a tour through Lyon&rsquo;s UNESCO-recognized city center.</p><ul>	<li>		Take in the Gothic and Renaissance architecture as you pass by the Basilica of Notre-Dame de Fourvi&egrave;re	</li>	<li>		Step inside Lyon Cathedral and walk through centuries-old&nbsp;<em>traboules,</em>&nbsp;or underground passages	</li></ul><p>	Enjoy a free afternoon in Lyon or add an excursion.</p><p>	<img src=""https://img2.storyblok.com/1534x920/smart/f/53624/600x490/c2ac2f68cd/medieval-village-of-perouges-oplysg4.jpg""></p><p>	Medieval Village of P&eacute;rouges</p><p>	From $59 per person</p><p>	<strong>Nice | 2 nights</strong></p><p>	<strong>Day 4: Nice via Avignon</strong></p><p>	Included meal: Breakfast</p><p>	Travel through the countryside toward the French Riviera, stopping to explore the historic Proven&ccedil;al city of Avignon en route to Nice.</p><ul>	<li>		See the famous Pont Saint-B&eacute;n&eacute;zet, the bridge that inspired the French folk tune &quot;On the Bridge of Avignon&quot;	</li>	<li>		Pass by the magnificent Papal Palace, a UNESCO World Heritage site	</li>	<li>		Stroll through the historic town center, which is surrounded by the city&rsquo;s original medieval walls	</li></ul><p>	Spend a free evening in Nice or add an excursion.</p><p>	<img src=""https://img2.storyblok.com/1534x920/smart/f/53624/600x490/42cd0098c4/evening-in-monaco-opmog.jpg""></p><p>	Evening in Monaco</p><p>	From $125 per person</p><p>	<strong>Day 5: Sightseeing tour of Nice</strong></p><p>	Included meal: Breakfast</p><p>	Get to know Nice&rsquo;s many charms on a guided sightseeing tour.</p><ul>	<li>		Drive along the Promenade des Anglais	</li>	<li>		Discover the narrow streets of the Old Town	</li>	<li>		Explore the Roman amphitheater	</li>	<li>		Wander around the gardens of the Franciscan Monastery in Cimiez	</li></ul><p>	Enjoy a free afternoon in Nice or add an excursion.</p><p>	&nbsp;</p>",
                    Description = "<h2>	Discover the many sides of France.</h2><p>	Travel from the culinary capital of Lyon to the iconic city of Paris, and through the plethora of charming medieval villages and coastal Riviera towns in-between. This grand tour is your chance to eat, drink, and sightsee your way through this dynamic country.</p><p>	Your tour package includes</p><ul>	<li>		5 nights in handpicked hotels	</li>	<li>		5 breakfasts	</li>	<li>		2 dinners with beer or wine	</li>	<li>		2 sightseeing tours	</li>	<li>		Expert Tour Director &amp; local guides	</li></ul><p>	Included highlights</p><ul>	<li>		Basilica of Notre-Dame de Fourvi&egrave;re	</li>	<li>		Arles	</li>	<li>		Carcassone	</li>	<li>		Bordeaux	</li>	<li>		Ch&acirc;teau country	</li></ul><p>	&nbsp;</p>",
                    Status = "Active",
                    CreatedDate = new DateTime(2022, 3, 14),
                    UrlSlug = "lets-go-to-france",
                    ImageLink = "assets/images/Tour/2/fran ce gogo.jpg"
                },
                new Tour()
                {
                    TourName = "Let's go to Italy",
                    HotelId = 5,
                    //RestaurantId = 5,
                    TotalPrice = 5890000,
                    Duration = "7 days",
                    ShortDescription = "Feel the pulse of Italy&#39;s vibrant culture.",
                    Schedule = @"<p>	<strong>Overnight Flight | 1 night</strong></p><p>	<strong>Day 1: Travel day</strong></p><p>	Board your overnight flight to Venice today.</p><p>	<strong>Venice | 2 nights</strong></p><p>	<strong>Day 2: Arrival in Venice</strong></p><p>	Included meal: Dinner</p><p>	Welcome to Italy! Transfer to your hotel and get settled in. Later, meet your fellow travelers at tonight&rsquo;s welcome dinner.</p><p>	<strong>Day 3: Sightseeing tour of Venice</strong></p><p>	Included meal: Breakfast</p><p>	Admire historic churches, winding canals, and picture-perfect piazzas on a guided tour of the city known as the Queen of the Adriatic.</p><ul>	<li>		Step into the iconic St. Mark&#39;s Square and enter St. Mark&#39;s Basilica	</li>	<li>		View the stately Doge&#39;s Palace, built in the Venetian Gothic style in 1340	</li>	<li>		Marvel at the Bridge of Sighs, the link between Doge&#39;s Palace and the New Prison	</li>	<li>		See a glassblowing demonstration to learn about the city&#39;s most celebrated art	</li></ul><p>	Enjoy a free afternoon in Venice or add an excursion.</p><p>	<img src=""https://img2.storyblok.com/1534x920/smart/f/53624/818x668/aea20b4463/gondola-ride-venice-canal-cruise-opgong.jpg""></p><p>	Gondola Ride: Venice Canal Cruise</p><p>	From $75 per person</p><p>	<img src=""https://img2.storyblok.com/1534x920/smart/f/53624/818x668/f1fbfca9cd/private-gondola-ride-canal-cruise-for-two-opgref.jpg""></p><p>	Private Gondola Ride: Canal Cruise for Two</p><p>	From $159 per person</p><p>	<strong>Florence | 2 nights</strong></p><p>	<strong>Day 4: Transfer to Florence &amp; sightseeing tour</strong></p><p>	Included meals: Breakfast, Dinner</p><p>	Cross through the Apennine Mountains as you make your way to Florence. Once you arrive, get to know the city with a local guide.</p><ul>	<li>		View the legendary Florence Cathedral, known as the Duomo	</li>	<li>		Pass Giotto&rsquo;s Campanile, a masterpiece of Gothic architecture	</li>	<li>		Walk past Piazza della Repubblica to the medieval Ponte Vecchio	</li>	<li>		Stroll along the Arno River and through the courtyard of the Uffizi Gallery to Piazza della Signoria, center of Florentine life Sit down for an included dinner this evening.	</li></ul><p>	<strong>Day 5: Free day in Florence</strong></p><p>	Included meal: Breakfast</p><p>	Enjoy a free day in Florence or add an excursion.</p><p>	<img src=""https://img2.storyblok.com/1534x920/smart/f/53624/600x490/cc2e927124/san-gimignano-medieval-sights-and-tuscan-flavors-opsig.jpg""></p><p>	San Gimignano: Medieval Sights &amp; Tuscan Flavors</p><p>	From $105 per person</p><p>	<strong>Rome | 3 nights</strong></p><p>	<strong>Day 6: Transfer to Rome &amp; sightseeing tour</strong></p><p>	Included meal: Breakfast</p><p>	Depart Florence for Rome, where you&rsquo;ll follow in the footsteps of the ancient Romans on a guided tour of the Eternal City.</p><ul>	<li>		Soak up over 2,000 years of history in Imperial Rome, viewing the Arch of Constantine and the Arch of Titus	</li>	<li>		Enter the Colosseum, the largest amphitheater of the Roman Empire	</li>	<li>		Stop at the ruins of the Forum, once the setting of parades, elections, and trials	</li>	<li>		Pass by Palatine Hill to see Circus Maximus, the stadium where ancient Romans raced chariots, and the Baths of Caracalla	</li></ul><p>	<strong>Day 7: Free day in Rome</strong></p><p>	Included meal: Breakfast</p><p>	Enjoy a free day in Rome or add excursions.&nbsp;</p><p>	<em>Please note: Iconic Sights: Vatican City excursion may be offered on day 8, depending on the day of the week. Please call for more information.</em></p><p>	<img src=""https://img2.storyblok.com/1534x920/smart/f/53624/600x490/d6b4ed45d8/iconic-sights-vatican-city-oprvsg.jpg""></p><p>	Iconic Sights: Vatican City</p><p>	From $109 per person</p><p>	<img src=""https://img2.storyblok.com/1534x920/smart/f/53624/600x490/d9b5717958/rome-cooking-class-and-dinner-opcttg72.jpg""></p><p>	Rome Cooking Class &amp; Dinner</p><p>	From $109 per person</p><p>	<strong>Day 8: Free day in Rome</strong></p><p>	Included meals: Breakfast, Farewell dinner</p><p>	Enjoy another free day to explore Rome or add an excursion. Then, join your group at tonight&rsquo;s farewell dinner. Tonight, as you dine, you&#39;ll be treated to a multi-course traditional Italian meal with a live musical entertainment.</p><p>	<em>Please note: Ancient Rome: St. Paul&#39;s Basilica &amp; the Catacombs excursion may be offered on day 7, depending on the day of the week.</em></p><p>	<img src=""https://img2.storyblok.com/1534x920/smart/f/53624/600x490/9293fdde4d/family-sightseeing-the-papal-basilica-of-st-paul-and-the-catacombs-opctgf.jpg""></p><p>	Ancient Rome: St. Paul&rsquo;s Basilica &amp; the Catacombs</p><p>	From $75 per person</p><p>	<strong>Flight Home</strong></p><p>	<strong>Day 9: Departure</strong></p><p>	Included meal: Breakfast (excluding early morning departures)</p><p>	Transfer to the airport for your flight home, or extend your stay to visit the Sorrento peninsula.</p>",
                    Description = "<h2>	Feel the pulse of Italy&#39;s vibrant culture.</h2><p>	We&#39;ve picked three iconic cities at the pulse of Italy&#39;s vibrant culture, both past and present. Venice brings romance to the forefront, with sprawling Baroque palaces and meandering, gondola-dotted canals. The Renaissance is tangible in Florence, where the presence of the world&#39;s greatest artists can still be felt. And in Rome, history is ever-present, from the crumbling Colosseum to the Forum. The people, the food, the way of life&mdash;experience what Italy is all about as you make your way from one city to the next.</p><p>	Your tour package includes</p><ul>	<li>		7 nights in handpicked hotels	</li>	<li>		7 breakfasts	</li>	<li>		3 dinners with beer or wine	</li>	<li>		3 sightseeing tours	</li>	<li>		Expert Tour Director &amp; local guides	</li></ul><p>	Included highlights</p><ul>	<li>		St. Mark&rsquo;s Basilica	</li>	<li>		Florence Duomo	</li>	<li>		Ponte Vecchio	</li>	<li>		Piazza della Repubblica	</li>	<li>		world-famous Italian cuisine	</li></ul><p>	&nbsp;</p>",
                    Status = "Active",
                    CreatedDate = new DateTime(2022, 3, 14),
                    UrlSlug = "lets-go-to-italy",
                    ImageLink = "assets/images/Tour/3/italy gogo.jpg"
                });
            SeedBooking();
            SeedComment();
        }
        private void SeedComment()
        {
            if (_context.Comments.Any())
                return;
            _context.Comments.AddRange(
                new Comment()
                {
                    TourId = 3,
                    CustomerId = 3,
                    RatePoint = 4,
                    Content = "Amazing tour, you guys should pick it for your holidays",
                },
                new Comment()
                {
                    TourId = 3,
                    CustomerId = 3,
                    RatePoint = 4,
                    Content = "I can't wait to travel that place once more time",
                });
        }
        private void SeedBooking()
        {
            if (_context.Bookings.Any())
                return;
            SeedCustomer();
            _context.Bookings.AddRange(
                new Booking()
                {
                    TourId = 1,
                    StartDate = new DateTime(2022, 3, 16),
                    EndDate = new DateTime(2022, 3, 19),
                    CustomerId = 1,
                    TourParticipantCount = 16,
                    Note = "16 participants, casual tourist",
                    Status = "Pending"
                },
                new Booking()
                {
                    TourId = 2,
                    StartDate = new DateTime(2022, 3, 19),
                    EndDate = new DateTime(2022, 3, 24),
                    CustomerId = 2,
                    TourParticipantCount = 14,
                    Note = "on budget",
                    Status = "Approved"
                },
                new Booking()
                {
                    TourId = 3,
                    StartDate = new DateTime(2022, 1, 19),
                    EndDate = new DateTime(2022, 1, 26),
                    CustomerId = 3,
                    TourParticipantCount = 14,
                    Note = "on budget",
                    Status = "Completed"
                },
                new Booking()
                {
                    TourId = 3,
                    StartDate = new DateTime(2022, 2, 19),
                    EndDate = new DateTime(2022, 2, 26),
                    CustomerId = 1,
                    TourParticipantCount = 5,
                    Note = "on budget",
                    Status = "Completed"
                },
                new Booking()
                {
                    TourId = 2,
                    StartDate = new DateTime(2022, 2, 19),
                    EndDate = new DateTime(2022, 2, 26),
                    CustomerId = 2,
                    TourParticipantCount = 4,
                    Note = "on budget",
                    Status = "Completed"
                });
        }
        private void SeedCustomer()
        {
            if (_context.Customers.Any())
                return;
            _context.Customers.AddRange(
                new Customer()
                {
                    CustomerName = "Pham To Nhi",
                    Phone = "0145582331",
                    Address = "Hà Nội",
                    Email = "ptn@gmail.com",
                    IdentityCardNumber = "0014885222301",
                },
                new Customer()
                {
                    CustomerName = "Luu Van Dat",
                    Phone = "035582331",
                    Address = "Hà Nam",
                    Email = "huent@gmail.com",
                    IdentityCardNumber = "0014885221471",
                },
                new Customer()
                {
                    CustomerName = "David Beckam",
                    Phone = "0988668866",
                    Address = "Thailand",
                    Email = "davidbeckham@gmail.com",
                    IdentityCardNumber = "7788885221471",
                });
            _context.SaveChanges();
        }
        private void SeedLocation()
        {
            if (_context.Locations.Any())
                return;
            _context.Locations.AddRange(
                new Location()
                {
                    LocationName = "England",
                    Description = @"<h1>	Attractions in England</h1><p>	One of the most popular travel destinations in the world, England offers almost endless possibilities for vacationers seeking fun things to do and top attractions to visit.</p><p>	Part of the beautiful British Isles, this&nbsp;<strong>small but influential country</strong>&nbsp;bursts with fascinating history, exciting cities, and rich cultural traditions. Historic sites are at every turn, from prehistoric megaliths and ancient Roman sites to&nbsp;<strong>centuries</strong>-<strong>old castles&nbsp;</strong>and town centers dating back to the Middle Ages<strong>.</strong></p><p>	England is also extremely easy to get around, with its most popular tourist destinations well connected by trains and buses. Alternatively, you can drive between points of interest on a well-planned system of motorways. Whether you choose to tour the country by car or public transport, you&#39;re guaranteed an unforgettable experience.</p><p>	To help you get the most out of your travel itinerary, be sure to use our list of the best places to visit in England.</p><p>	Note: Some businesses may be temporarily closed due to recent global health and safety issues.</p><h2>	1. Stonehenge</h2><p>	<img alt=""Stonehenge"" src=""https://www.planetware.com/photos-large/ENG/england-stonehenge.jpg"" style=""height:468px; width:730px""></p><p>	&nbsp;</p><h2>	2. Tower of London</h2><p>	<img alt=""Tower of London"" src=""https://www.planetware.com/photos-large/ENG/england-tower-of-london.jpg"" style=""height:503px; width:730px""></p><p>	&nbsp;</p><h2>	3. The Roman Baths and Georgian City of Bath</h2><p>	<img alt=""The Roman Baths and Georgian City of Bath"" src=""https://www.planetware.com/photos-large/ENG/england-city-of-bath.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	4. The British Museum</h2><p>	<img alt=""Iron Age piece in the British Museum"" src=""https://www.planetware.com/photos-large/ENG/england-london-british-museum.jpg"" style=""height:429px; width:730px""></p><p>	&nbsp;</p><h2>	5. York Minster and Historic Yorkshire</h2><p>	<img alt=""York Minster and Historic Yorkshire"" src=""https://www.planetware.com/photos-large/ENG/england-historic-yorkshire.jpg"" style=""height:458px; width:730px""></p><p>	&nbsp;</p><h2>	6. Windsor Castle</h2><p>	<img alt=""Windsor Castle"" src=""https://www.planetware.com/wpimages/2021/10/england-top-attractions-windsor-castle.jpg"" style=""height:501px; width:730px""></p><p>	&nbsp;</p><h2>	7. Chester Zoo</h2><p>	<img alt=""Zebra at the Chester Zoo"" src=""https://www.planetware.com/photos-large/ENG/england-chester-zoo-2.jpg"" style=""height:515px; width:730px""></p><p>	&nbsp;</p><h2>	8. Lake District National Park</h2><p>	<img alt=""Lake District National Park"" src=""https://www.planetware.com/photos-large/ENG/england-lake-district-national-park.jpg"" style=""height:479px; width:730px""></p><p>	&nbsp;</p><h2>	9. Canterbury Cathedral</h2><p>	<img alt=""Canterbury Cathedral"" src=""https://www.planetware.com/photos-large/ENG/england-canterbury-cathedral.jpg"" style=""height:545px; width:730px""></p><p>	&nbsp;</p><h2>	10. Liverpool &amp; The Beatles</h2><p>	<img alt=""Penny Lane in Liverpool"" src=""https://www.planetware.com/wpimages/2021/10/england-top-attractions-liverpool-the-beatles-penny-lane.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	11. Eden Project</h2><p>	<img alt=""Eden Project"" src=""https://www.planetware.com/photos-large/ENG/england-eden-project.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	12. The Cotswolds</h2><p>	<img alt=""The Cotswolds"" src=""https://www.planetware.com/photos-large/ENG/england-the-cotswolds.jpg"" style=""height:486px; width:730px""></p><p>	&nbsp;</p><h2>	13. The National Gallery</h2><p>	<img alt=""The National Gallery"" src=""https://www.planetware.com/photos-large/ENG/england-london-national-gallery.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	14. Warwick Castle<img alt=""Warwick Castle"" src=""https://www.planetware.com/wpimages/2020/04/england-top-attractions-warwick-castle.jpg"" style=""height:487px; width:730px""></h2><p>	&nbsp;</p><h2>	15. Tate Modern</h2><p>	<img alt=""Tate Modern"" src=""https://www.planetware.com/photos-large/ENG/england-london-tate-modern.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p>",
                    UrlSlug = "england",
                    ImageLink = "assets/images/Location/1/england-gog.jpg",
                },
                new Location()
                {
                    LocationName = "France",
                    Description = @"<h1>	Attractions in France</h1><p>	From the boulevards of&nbsp;<a href=""https://www.planetware.com/tourist-attractions-/paris-f-p-paris.htm"">Paris</a>&nbsp;to the fashionable seaside resorts of the&nbsp;<a href=""https://www.planetware.com/tourist-attractions-/cote-dazur-f-az-azur.htm"">C&ocirc;te d&#39;Azur</a>, France offers some of the most beautiful scenery in the world. Fairy-tale castles, glorious cathedrals, and picture-perfect villages delight romantics. At the same time, the country&#39;s contemporary monuments and rapid train transit jolt visitors from the storybook surroundings into the ambience of the 21st century.</p><p>	Begin with the Eiffel Tower, the modern emblem of France. Then discover famous masterpieces of art at the Louvre Museum. Spend a day pretending to be royalty at the elegant Palace of Versailles. Save time for leisurely gourmet meals. Traditional French gastronomy has been inscribed on the UNESCO list of Intangible Cultural Heritage.</p><p>	Each region has its own distinctive cuisine and culture. The coastal region of&nbsp;<a href=""https://www.planetware.com/tourist-attractions-/brittany-f-bret-brit.htm"">Brittany</a>&nbsp;offers the old-world charm of quaint fishing villages and ancient seaports, while the&nbsp;<a href=""https://www.planetware.com/tourist-attractions-/savoy-f-rh-sav.htm"">French Alps</a>&nbsp;boasts a hearty cuisine of cheese fondue and&nbsp;<em>charcuterie</em>&nbsp;served in cozy chalets near ski slopes.</p><p>	Savor the country&#39;s irresistible charm and learn about the best things to do with our list of the top attractions in France.</p><p>	Note: Some businesses may be temporarily closed due to recent global health and safety issues.</p><h2>	1. Eiffel Tower</h2><p>	<img alt=""Eiffel Tower"" src=""https://www.planetware.com/photos-large/F/france-eiffel-tower.jpg"" style=""height:483px; width:730px""></p><p>	&nbsp;</p><h2>	2. Mus&eacute;e du Louvre</h2><p>	<img alt=""Louvre Museum"" src=""https://www.planetware.com/wpimages/2021/11/france-top-attractions-musee-du-louvre.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	3. Ch&acirc;teau de Versailles</h2><p>	<img alt=""Château de Versailles "" src=""https://www.planetware.com/photos-large/F/france-versailles.jpg"" style=""height:475px; width:730px""><img alt=""Gardens at the Palace of Versailles"" src=""https://www.planetware.com/wpimages/2021/10/france-top-attractions-chateau-versailles-les-jardins.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	4. C&ocirc;te d&#39;Azur</h2><p>	<img alt=""Menton, Côte d'Azur"" src=""https://www.planetware.com/photos-large/F/france-cote-d-azure.jpg"" style=""height:543px; width:730px""></p><p>	&nbsp;</p><h2>	5. Mont Saint-Michel</h2><p>	<img alt=""Mont Saint-Michel"" src=""https://www.planetware.com/photos-large/F/france-mont-saint-michel-2.jpg"" style=""height:472px; width:730px""></p><p>	&nbsp;</p><h2>	6. Loire Valley Ch&acirc;teaux</h2><p>	<img alt=""Loire Valley Châteaux"" src=""https://www.planetware.com/photos-large/F/france-loire-valley.jpg"" style=""height:598px; width:730px""></p><p>	&nbsp;</p><h2>	7. Cath&eacute;drale Notre-Dame de Chartres</h2><p>	<img alt=""Cathédrale Notre-Dame de Chartres"" src=""https://www.planetware.com/wpimages/2020/04/france-top-attractions-cathedrale-notre-dame-de-chartres-france.jpg"" style=""height:534px; width:730px""></p><p>	&nbsp;</p><h2>	8. Provence</h2><p>	<img alt=""Lavender field near Valensole, Provence"" src=""https://www.planetware.com/wpimages/2020/04/france-top-attractions-provence.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	9. Chamonix-Mont-Blanc</h2><p>	<img alt=""Chamonix-Mont-Blanc"" src=""https://www.planetware.com/photos-large/F/france-chamonix.jpg"" style=""height:485px; width:730px""></p><p>	&nbsp;</p><h2>	10. Alsace Villages</h2><p>	<img alt=""Colorful Riquewihr Village in the Alsace region of France"" src=""https://www.planetware.com/wpimages/2020/04/france-top-attractions-alsace-villages.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	11. Carcassonne</h2><p>	<img alt=""Carcassonne"" src=""https://www.planetware.com/wpimages/2020/04/france-top-attractions-carcassonne.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	12. Brittany</h2><p>	<img alt=""Brittany"" src=""https://www.planetware.com/photos-large/F/france-brittany.jpg"" style=""height:450px; width:730px""></p><p>	&nbsp;</p><h2>	13. Biarritz</h2><p>	<img alt=""Biarritz"" src=""https://www.planetware.com/photos-large/F/france-basque-country.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	14. Rocamadour</h2><p>	<img alt=""Rocamadour"" src=""https://www.planetware.com/photos-large/F/france-rocamadour.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	15. Prehistoric Cave Paintings in Lascaux</h2><p>	<img alt=""Prehistoric Cave Paintings in Lascaux"" src=""https://www.planetware.com/photos-large/F/france-lascaux-caves.jpg"" style=""height:573px; width:730px""></p>",
                    UrlSlug = "france",
                    ImageLink = "assets/images/Location/2/fran ce gogo.jpg"
                },
                new Location()
                {
                    LocationName = "Italy",
                    Description = @"<h1>	Attractions in Italy</h1><p>	As the birthplace of the Roman Empire and the Renaissance, it&#39;s not surprising that Italy should be so rich in masterpieces of art and architecture, or that it should have&nbsp;<strong>more UNESCO World Heritage cultural sites than any other country in the world</strong>.</p><p>	But Italy&#39;s top attractions for tourists are not all art and architecture; the country is blessed with lakes, mountains, and a dramatic coastline that give it outstanding natural attractions, as well. You could plan an entire itinerary inspired by a single interest, from Renaissance art to hiking, but most first-time visitors like to get a sampling of the best Italy offers in several different kinds of experiences.</p><p>	The attractions that follow show off Italy&#39;s art, architecture, stunning landscapes, and history, and provide opportunities for active pursuits, as well. To be sure you find the best places to visit and things to do, plan your itinerary using this list of the top attractions in Italy.</p><p>	Note: Some businesses may be temporarily closed due to recent global health and safety issues.</p><h2>	1. Colosseum</h2><p>	<img alt=""Colosseum"" src=""https://www.planetware.com/photos-large/I/italy-colosseum-day.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	2. Florence Duomo Santa Maria del Fiore</h2><p>	<img alt=""Florence Duomo Santa Maria del Fiore"" src=""https://www.planetware.com/photos-large/I/italy-florence-duomo-santa-maria-del-fiore.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	3. The Grand Canal in Venice</h2><p>	<img alt=""Venice Canals"" src=""https://www.planetware.com/photos-large/I/italy-venice-canals.jpg"" style=""height:487px; width:730px""></p><p>	&nbsp;</p><h2>	4. Leaning Tower of Pisa</h2><p>	<img alt=""Leaning Tower of Pisa"" src=""https://www.planetware.com/photos-large/I/italy-leaning-tower-of-pisa.jpg"" style=""height:550px; width:730px""></p><p>	&nbsp;</p><h2>	5. Vatican City: Basilica of St. Peter, Sistine Chapel &amp; Vatican Museums</h2><p>	<img alt=""Vatican City at sunset"" src=""https://www.planetware.com/wpimages/2020/08/italy-top-attractions-vatican-city.jpg"" style=""height:475px; width:730px""></p><p>	&nbsp;</p><h2>	6. The Uffizi Gallery in Florence</h2><p>	<img alt=""Uffizi Gallery in Florence"" src=""https://www.planetware.com/wpimages/2022/02/italy-top-attractions-uffizi-gallery-florence-2.jpg"" style=""height:487px; width:730px""></p><p>	Uffizi Gallery in Florence</p><p>	&nbsp;</p><p>	In addition to being one of the world&#39;s foremost art museums, the Uffizi is a one-stop history of Italian Renaissance art. Although it contains works by some of the great masters of western art, its greatest treasure is its collection of paintings that show step-by-step the evolution in painting that occurred here from the 14th to the 16th centuries.</p><p>	Here, you will see the first experiments with perspective, as well as some of the early portraits as painters moved beyond religious art, and some of the first use of naturalistic and scenic backgrounds in religious art.</p><p>	Be sure to see the Uffizi&#39;s most famous work:&nbsp;<strong>Botticelli&#39;s&nbsp;<em>Birth of Venus</em>.</strong></p><h2>	7. Cinque Terre</h2><p>	&nbsp;</p><p>	<img alt=""Cinque Terre"" src=""https://www.planetware.com/photos-large/I/italy-cinque-terre-village.jpg"" style=""height:479px; width:730px""></p><p>	Cinque Terre</p><p>	&nbsp;</p><p>	Cinque Terre is a lovely coastal region with steep hills and sheer cliffs overlooking the Mediterranean. The&nbsp;<strong>five picturesque villages of Monterosso al Mare, Vernazza, Corniglia, Manarola</strong>, and&nbsp;<strong>Riomaggiore</strong>&nbsp;can be reached by several means, joined to each other by walking paths, a railroad that tunnels through the headlands to emerge at each town, or a scenic narrow road high on the hillside above.</p><p>	<strong>Hiking between the villages</strong>&nbsp;is one of the most popular things to do as it gives travelers the chance to enjoy the landscape. The small towns have maintained a feel of old-world fishing villages and offer a sense of remoteness even in the face of modern tourism.</p><p>	&nbsp;</p><h2>	8. Lake Como</h2><p>	<img alt=""Lake Como"" src=""https://www.planetware.com/photos-large/I/italy-lake-como-calm-water.jpg"" style=""height:476px; width:730px""></p><p>	Lake Como</p><p>	&nbsp;</p><p>	Lake Como is one of Italy&#39;s most scenic areas, surrounded by mountains and lined by small picturesque towns. A haunt of the wealthy since Roman times, the lake has many opulent villas and palaces along its wooded shores; Villa Balbianello and Villa Carlotta are the best known, both surrounded by gardens that are open to the public.</p><p>	The mild climate that makes the lake shore ideal for gardens is also a draw for tourists, with characteristics similar to that of the Mediterranean. Along with the resort towns around the lake, there&#39;s an 11th-century abbey.</p><p>	At the foot of the lake, the small city of Como, important since Roman times, is&nbsp;<a href=""https://www.planetware.com/italy/from-milan-to-lake-como-best-ways-to-get-there-i-1-77.htm"">a short train ride from Milan</a>. From its waterfront, you can embark on excursions around the lake on regularly scheduled steamers that make&nbsp;<a href=""https://www.planetware.com/tourist-attractions-/como-i-lo-co.htm"">visiting the lakeside attractions</a>&nbsp;easy.</p><p>	&nbsp;</p><h2>	9. Pantheon</h2><p>	<img alt=""The Pantheon"" src=""https://www.planetware.com/wpimages/2020/08/italy-top-attractions-pantheon.jpg"" style=""height:499px; width:730px""></p><p>	The Pantheon</p><p>	&nbsp;</p><p>	The Pantheon, an&nbsp;<strong>exceptionally well preserved remnant from Roman times</strong>, reveals the incredible architectural achievements of the Roman Empire.</p><p>	The precise proportions of the building, dedicated to the planetary gods, with the height equal to the diameter, and a single beam of light entering the room from the top of the dome, were intended to represent the firmament and the sun.</p><p>	Disused after early Christian kings forbade use of a pagan temple as a church, it was later consecrated by the Pope in 609 CE. Italian Kings, the Renaissance painter Raphael, and other great Italians are buried in the Pantheon.</p><h2>	10. Verona&#39;s Roman Arena and Historic Center</h2><p>	<img alt=""Verona's Roman Arena"" src=""https://www.planetware.com/wpimages/2022/02/italy-top-attractions-veronas-roman-arena-historic-center.jpg"" style=""height:486px; width:730px""></p><p>	Verona&#39;s Roman Arena</p><p>	&nbsp;</p><p>	<strong>One of the largest and best-preserved Roman amphitheaters still in existence</strong>, Arena di Verona is the centerpiece of the centro storico &ndash; the town&#39;s historic center. It is one of several features from ancient times, when Verona was an important Roman city. In naming it a World Heritage Site, UNESCO notes that &quot;Verona has preserved a remarkable number of monuments from antiquity, the medieval and Renaissance periods.&quot;</p><p>	Verona continued to thrive under the rule of the Scaliger family in the 13th and 14th centuries and as part of the Republic of Venice from the 15th to 18th centuries. The imposing&nbsp;<strong>Castelvecchio</strong>&nbsp;was both palace and defensive fortress (now an outstanding art museum), overlooking the beautiful castellated&nbsp;<strong>Ponte Scaligero</strong>, a 14th-century bridge.</p><p>	Throughout the old center are Romanesque churches, regal buildings with characteristic Venetian Gothic windows, and stone gates that are more reminders of its Roman origins. And, of course, in a courtyard close to Piazza del Erbe&#39;s daily market, you&#39;ll find&nbsp;<strong>Juliet&#39;s Balcony</strong>&nbsp;(which was actually built in the 1930s as a tourist attraction).</p>",
                    UrlSlug = "italy",
                    ImageLink = "assets/images/Location/3/italy gogo.jpg"
                }
                );
            _context.SaveChanges();
            SeedRestaurant();
            SeedHotel();
        }
        private void SeedRestaurant()
        {
            if (_context.Restaurants.Any())
                return;
            _context.Restaurants.AddRange(
                new Restaurant()
                {
                    RestaurantName = "Emm's Cafe Bistro",
                    LocationId = 1,
                    Description = "<p><strong>PRICE RANGE</strong><br>5 - 15$</p><p><br><strong>DISH</strong><br>French,Cafe,European,Healthy,Spirits</p><p><br><strong>INCREDIBLE DIET</strong><br>Vegetarian Friendly,Vegan Options,Gluten Free Options</p><p><br><strong>MEAL</strong><br>Morning and evening,contemplation,dark scene,morning study,Drinks</p><p><br><strong>FEATURED</strong><br>Delivery,Takeout,Seating,Outdoors,Seating,Parking Available,Street Parking,Free Off - Street Parking,Highchairs Available,Vehicle Access Roller,Serves Alcohol,Full Bar,Wine and Beer,Accepts American Express,Accepts Mastercard,Accepts Visa,Digital Payments,Free Wifi,Accepts Credit,Translation Desk service</p><p>&nbsp;</p>",
                    Phone = "0462936361",
                    Email = "emms.cafe@gmail.com",
                    Status = "Active",
                    UrlSlug = "emm's-cafe-bistro",
                    ImageLink = "assets/images/Restaurant/3/Emm's Cafe Bistro.jpg"
                },
                new Restaurant()
                {
                    RestaurantName = "French Grill",
                    LocationId = 1,
                    Description = "<p>	<strong>DISH</strong><br>	Seafood, French, European, Healthy, Grill</p><p>	<br>	<strong>SPECIAL DIET</strong><br>	Vegetarian Friendly, Vegan Options, Gluten Free Options</p><p>	<br>	<strong>MEAL</strong><br>	Dinner</p><p>	<br><strong>FEATURED</strong><br>	Seating, Parking Available, Highchairs Available, Wheelchair Accessible, Serves Alcohol, Wine and Beer, Accepts American Express, Accepts Mastercard, Accepts Visa, Free Wifi Fees, Reservations, Private Dining, Validated Parking, Valet Parking, Full Bar, Accepts Credit Cards, Table Service</p><p>	&nbsp;</p>",
                    Phone = "0415668479",
                    Email = "frenchgrill@gmail.com",
                    Status = "Active",
                    UrlSlug = "french-grill",
                    ImageLink = "assets/images/Restaurant/2/FrenchGrill.jpg"
                },
                new Restaurant()
                {
                    RestaurantName = "Hemispheres Steak & Seafood Grill",
                    LocationId = 2,
                    Description = "<p>	<strong>PRICE RANGE</strong><br>	568,182 dong - 2,272,727 dong</p><p>	<br>strong>DISH</strong><br>	Steakhouse, Seafood, European</p><p>	<br>	<strong>SPECIAL DIET</strong><br>	Gluten-free food options</p><p>	<br>	<strong>MEAL</strong><br>Lunch, Dinner, Drinks</p><p>	<br>	<strong>FEATURED</strong><br>	Delivery, Outdoor Seating, Seating, Parking Available, Validated Parking, Wheelchair Accessible, Serves Alcohol, Full Bar, Wine and Beer, Accepts American Express, Accepts Mastercard, Accepts Visa, Free Wifi, Private Dining, Highchairs Available, Digital Payments, Accepts Credit Cards, Table Service</p><p>	&nbsp;</p>",
                    Phone = "0665122237",
                    Email = "hsandsg@gmail.com",
                    Status = "Active",
                    UrlSlug = "hemispheres-steak-&-seafood-grill",
                    ImageLink = "assets/images/Restaurant/1/HemispheresSteak&SeafoodGrill.jpg"
                },
                new Restaurant()
                {
                    RestaurantName = "La Badiane",
                    LocationId = 2,
                    Description = "<p>	<strong>PRICE RANGE</strong><br>	227,273 dong - 1,500,000 dong</p><p>	<br><strong>DISH</strong><br>	French, European, International, Fusion</p><p>	<br><strong>SPECIAL DIET</strong><br>	Vegetarian Friendly, Vegan Options, Gluten Free Options</p><p>	<br><strong>MEAL</strong><br>	Lunch, Dinner</p><p>	<br><strong>FEATURED</strong><br>	Seating, Wheelchair Accessible, Serves Alcohol, Full Bar, Accepts American Express, Accepts Mastercard, Accepts Visa, Free Wifi, Reservations, Private Dining, Highchairs Available, Accepts Credit Cards, Table Service, Live Music, Family style, Non-smoking restaurants, Gift Cards Available</p><p>	&nbsp;</p>",
                    Phone = "0612884759",
                    Email = "labadiane@gmail.com",
                    Status = "Active",
                    UrlSlug = "la-badiane",
                    ImageLink = "assets/images/Restaurant/4/La Badiane.jpg"
                },
                new Restaurant()
                {
                    RestaurantName = "Lighthouse Sky Bar",
                    LocationId = 3,
                    Description = "<p>	<strong>PRICE RANGE</strong><br>	181,818 dong - 4,772,727 dong</p><p>	<br><strong>DISH</strong><br>	American, Bar, Fusion, Vietnamese, Wine Bar, European, Asian</p><p>	<br>	<strong>SPECIAL DIET</strong><br>	Vegan Options, Gluten Free Options</p><p>	<br>	<strong>MEAL</strong><br>	Dinner, Late Night, Drinks</p><p>	<br>	<strong>FEATURED</strong><br>	Reservations, Outdoor Seating, Seating, Television, Serves Alcohol, Full Bar, Free Wifi, Accepts Credit Cards, Table Service, Wine and Beer</p><p>	&nbsp;</p>",
                    Phone = "0817445912",
                    Email = "lighthouseskybar@gmail.com",
                    Status = "Active",
                    UrlSlug = "lighthouse-sky-bar",
                    ImageLink = "assets/images/Restaurant/5/Lighthouse Sky Bar.jpg"
                },
                new Restaurant()
                {
                    RestaurantName = "Opera Garden",
                    LocationId = 3,
                    Description = "<p>	<strong>PRICE RANGE</strong><br>	340,909 dong - 1,931,818 dong</p><p>	<br>	<strong>DISH</strong><br>	Fusion, Vietnamese, European, Asian</p><p>	<br>	<strong>SPECIAL DIET</strong><br>	Vegetarian Friendly, Vegan Options</p><p>	<br>	<strong>MEAL</strong><br>	Lunch, Dinner, Brunch, Drinks</p><p>	<br>	<strong>FEATURED</strong><br>	Reservations, Private Dining, Seating, Highchairs Available, Wheelchair Accessible, Serves Alcohol, Full Bar, Free Wifi, Accepts Credit Cards, Table Service, Parking Available, Street Parking, Wine and Beer, Digital Payments, Live Music, Jazz Bar, Direct Delivery</p><p>	&nbsp;</p>",
                    Phone = "0897448226",
                    Email = "operagarden@gmail.com",
                    Status = "Active",
                    UrlSlug = "opera-garden",
                    ImageLink = "assets/images/Restaurant/6/Opera Garden.jpg"
                });
            _context.SaveChanges();
        }
        private void SeedHotel()
        {
            if (_context.Hotels.Any())
                return;
            _context.Hotels.AddRange(
                new Hotel()
                {
                    HotelName = "Royal King",
                    LocationId = 1,
                    ShortDescription = "The only hotel you need in England",
                    Description = "All things cozy and Austrian meet in this legendary inn, which first welcomed guests in the 15th century and now lists Prince Charles among its loyal fans. The hotel is in the heart of the medieval old town, surrounded by shops displaying wrought-iron guild signs. You can walk to pretty much anything, including Mozart’s birthplace, just down the street. Because driving can be a hassle—pedestrian-only areas, inscrutable road signs—you’re better off taking the train from Vienna or Munich. If it wasn’t so authentic, you’d swear a set designer had orchestrated the vaulted ceilings, antique farmers’ furniture, stag heads, and staff in lederhosen and dirndls.",
                    Phone = "0897448227",
                    Email = "royalking@gmail.com",
                    Status = "Active",
                    UrlSlug = "royal-king",
                    ImageLink = "assets/images/Hotel/5/hotel0.jpg"
                },
                new Hotel()
                {
                    HotelName = "Simple love",
                    LocationId = 1,
                    ShortDescription = "Come here for your honeymoon and enjoy romantic atmosphere",
                    Description = "There is nothing that does not dazzle at the Santa Caterina, hewn from a cliffside off the staggeringly stunning Amalfi Coast—and even on looks alone, we’d have to agree. Terraces cleaved from natural rock formations and sprinkled with citrus groves and assorted gardens appear with astonishing regularity around every turn, ready to lend themselves to a quiet moment. The interiors are vaguely reminiscent of one of the island’s little Catholic churches—white walls, white linens, vaulted ceilings, gold-hued curtains, little baroque wooden chairs, and tiled floors decked out in primary colors—pretty angelic, really, and not a bad vibe to gravitate toward when you're seeking a peaceful stay away (you could also try the spa!). Some rooms feature ceramic accents and charming family heirlooms, and all bathrooms benefit from Bvlgari toiletries.",
                    Phone = "0891348227",
                    Email = "simplelove@gmail.com",
                    Status = "Active",
                    UrlSlug = "simple-love",
                    ImageLink = "assets/images/Hotel/4/hotel1.jpg"
                },
                new Hotel()
                {
                    HotelName = "The Langham",
                    LocationId = 2,
                    ShortDescription = "Redeveloped by Skidmore, Owings & Merrill, Xintiandi is Shanghai’s car-free entertainment district, built in and around a series of 19th-century shikumen (or “stone gate”) houses.",
                    Description = "Redeveloped by Skidmore, Owings & Merrill, Xintiandi is Shanghai’s car-free entertainment district, built in and around a series of 19th-century shikumen (or “stone gate”) houses. Perfectly fitting in with that old-meets-new vibe is this 357-room luxury hotel, which occupies a contemporary granite-and-glass tower inspired by Chinese latticework. Inside, at the Chuan Spa, personalized treatments incorporate the five elements of wuxing philosophy: wood, earth, water, fire, and metal. And the property is filled with other nods to traditional art and culture, including a recurring horse motif that draws on Han Dynasty imagery. Guests shouldn’t miss a meal at the Michelin-starred T’ang Court, where Cantonese dishes include roasted goose, drunken pigeon in rice wine, and bird’s nest soup with crab roe. ",
                    Phone = "0217448227",
                    Email = "thelangham@gmail.com",
                    Status = "Active",
                    UrlSlug = "the-langham",
                    ImageLink = "assets/images/Hotel/3/hotel2.jpg"
                },
                new Hotel()
                {
                    HotelName = "Ellerman House",
                    LocationId = 2,
                    ShortDescription = "Twenty-six years on, Ellerman House is still everybody’s fantasy bolthole in Cape Town: minutes from the best beaches and the Table Mountain cableway, but close enough to the city and its dynamic food, art, and design scene. Sandwiched between Lion’s Head and the Atlantic Ocean, the Cape Edwardian mansion looks like a private residence from the road and that’s exactly what keeps guests coming back.",
                    Description = "Twenty-six years on, Ellerman House is still everybody’s fantasy bolthole in Cape Town: minutes from the best beaches and the Table Mountain cableway, but close enough to the city and its dynamic food, art, and design scene. Sandwiched between Lion’s Head and the Atlantic Ocean, the Cape Edwardian mansion looks like a private residence from the road and that’s exactly what keeps guests coming back. Owner Paul Harris takes enormous pride in his country—his impressive collection of South African art spans original works from the turn of the last century to current contemporary art. An informal tour of the collection with one of the in-house art experts is a fascinating lesson in the country’s socio-political history. Then there are the 7,500 bottles of rare and vintage South African wines in the cellar, and the indigenous plants sourced from Kirstenbosch (Cape Town’s botanical garden) in the 1.5-acre terraced gardens. Besides the main house, there are two modern, minimalist private villas built into the granite mountainside, as well as a wine gallery, and an excellent little spa. ",
                    Phone = "0123448227",
                    Email = "ellermanhouse@gmail.com",
                    Status = "Active",
                    UrlSlug = "ellerman-house",
                    ImageLink = "assets/images/Hotel/2/hotel3.jpg"
                },
                new Hotel()
                {
                    HotelName = "Rosewood Luang Prabang",
                    LocationId = 3,
                    ShortDescription = "Legend holds that on his pilgrimage across Asia, the Buddha stopped to rest where the Mekong and Nam Khan Rivers merge, in the middle of what we now know as Luang Prabang.",
                    Description = "Legend holds that on his pilgrimage across Asia, the Buddha stopped to rest where the Mekong and Nam Khan Rivers merge, in the middle of what we now know as Luang Prabang. He prophesied that a rich and powerful metropolis would rise along these banks. Though that apex only lasted from the 14th to the 16th century, this Kingdom of a Million Elephants lived on for architect Bill Bensley, who celebrated this era at Rosewood’s low-slung riverside retreat. Minimalist it is not. Hilltop tents overflow with romantic touches—chubby camp beds, clawfoot tubs, silk and velvet accents. At riverfront villas, the rush of water somersaulting over time-smoothed boulders acts as nature’s alarm clock for an early morning meditation with monk-in-residence Sommaiy. Deep community ties mean guests take tea with Tiao Somsanith Nithakhong, a local royal turned patron of lost Lao arts, or join a procession of 800 saffron-clad novices gliding through rice fields and primary forests for a private blessing ceremony. Rosewood’s elephant figurine–festooned cocktail bar is a delightful aerie arched over the waterfall, and make sure to ask to see the secret boutique, stocked with finds like kaleidoscopic scarves woven by a cooperative of young disabled Laotians who are some of the town’s most promising artisans. ",
                    Phone = "098748227",
                    Email = "rosewoodluanprabang@gmail.com",
                    Status = "Active",
                    UrlSlug = "rosewood-luang-prabang",
                    ImageLink = "assets/images/Hotel/1/hotel4.jpg"
                });
            _context.SaveChanges();
            SeedRoom();
        }
        private void SeedRoom()
        {
            if (_context.Rooms.Any())
                return;
            _context.Rooms.AddRange(
                new Room()
                {
                    HotelId = 1,
                    RoomId = 1,
                    RoomName = "Casual",
                    Price = 300000,
                    Description = "Casual room",
                    UrlSlug = "casual",
                    ImageLink = "assets/images/Hotel/1/Room/1/casual.jpg"
                },
                new Room()
                {
                    HotelId = 1,
                    RoomId = 2,
                    RoomName = "Professional",
                    Price = 500000,
                    Description = "Professional room",
                    UrlSlug = "professional",
                    ImageLink = "assets/images/Hotel/1/Room/2/professional.jpg"
                },
                new Room()
                {
                    HotelId = 2,
                    RoomId = 1,
                    RoomName = "Deluxe",
                    Price = 1000000,
                    Description = "Deluxe room",
                    UrlSlug = "deluxe",
                    ImageLink = "assets/images/Hotel/2/Room/1/deluxe.jpg"
                },
                new Room()
                {
                    HotelId = 3,
                    RoomId = 1,
                    RoomName = "Default",
                    Price = 250000,
                    Description = "Default room",
                    UrlSlug = "default",
                    ImageLink = "assets/images/Hotel/3/Room/1/default.jpg"
                },
                new Room()
                {
                    HotelId = 4,
                    RoomId = 1,
                    RoomName = "Casual",
                    Price = 200000,
                    Description = "Casual room",
                    UrlSlug = "casual",
                    ImageLink = "assets/images/Hotel/4/Room/1/casual.jpg"
                },
                new Room()
                {
                    HotelId = 4,
                    RoomId = 2,
                    RoomName = "Business",
                    Price = 2000000,
                    Description = "Business-class room",
                    UrlSlug = "business",
                    ImageLink = "assets/images/Hotel/4/Room/2/business.jpg"
                },
                new Room()
                {
                    HotelId = 5,
                    RoomId = 1,
                    RoomName = "Business",
                    Price = 1500000,
                    Description = "Business-class room",
                    UrlSlug = "business",
                    ImageLink = "assets/images/Hotel/5/Room/1/business.jpg"
                },
                new Room()
                {
                    HotelId = 5,
                    RoomId = 2,
                    RoomName = "VIP",
                    Price = 10000000,
                    Description = "VIP-only room",
                    UrlSlug = "vip",
                    ImageLink = "assets/images/Hotel/5/Room/2/vip.jpg"
                });
            _context.SaveChanges();
        }
    }
}
