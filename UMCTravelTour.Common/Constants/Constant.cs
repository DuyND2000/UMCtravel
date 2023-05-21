﻿namespace UMCTravelTour.Common.Constants
{
    public static class Constant
    {
        //5% phí dịch vụ
        public const decimal ServicePricePercentage = 0.05m;

        public const int PageSize = 5;
        public const string BookTourSuccesed = "Đặt chuyến thành công";
        public class Sort
        {
            public const string ASC = "Tăng dần";
            public const string DESC = "Giảm dần";
        }
        public class SortBy
        {
            public const string Name = "Tên";
            public const string ModifiedOn = "Tạo ngày";
            public const string Rate = "Điểm đánh giá";
        }
        public class DeletedMessage
        {
            public const string DeleteSuccess = "Xóa thành công";
        }
        public class StatusTour
        {
            public const string Active = "Hoạt động";
            public const string NonActive = "Ngừng hoạt động";

        }
        public class StatusBooking
        {
            public const string Completed = "Hoàn thành";
            public const string Pending = "Chờ xác nhận";
            public const string Approved = "Phê duyệt";
            public const string Cancelled = "Hủy";
            public const string Deposited = "Đã đặt cọc";
        }
        public class StatusHotel
        {
            public const string Active = "Hoạt động";
            public const string NonActive = "Ngừng hoạt động";

        }

        public class Role
        {
            public const string Administrator = "Administrator";
            public const string Manager = "Manager";
            public const string Employee = "Employee";
        }
        public class RoleName
        {
            public const string Administrator = "Quản trị viên";
            public const string Manager = "Quản lý";
            public const string Employee = "Nhân viên";
        }
        public class EmailTitleTemplate
        {
            public const string ConfirmRegister = "confirm-register-success";
            public const string BookingSuccess = "booking-success";
            public const string PaymentSuccess = "payment-success";
            public const string TourCancel = "tour-cancel";
            public const string CustomerSucess = "customer-sucess";
            public const string ThankYou = "thank-you";
            public const string PendingTour = "pending-tour";
            public const string ForgetPassword = "forget-password";

            public const string EmailHeader = @"<!DOCTYPE HTML PUBLIC "" -//W3C//DTD XHTML 1.0 Transitional //EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd""><html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office""><head>    <style type=""text/css"">        @media only screen and (min-width: 620px) {            .u-row {                width: 600px !important;            }            .u-row .u-col {                vertical-align: top;            }            .u-row .u-col-100 {                width: 600px !important;            }        }                @media (max-width: 620px) {            .u-row-container {                max-width: 100% !important;                padding-left: 0px !important;                padding-right: 0px !important;            }            .u-row .u-col {                min-width: 320px !important;                max-width: 100% !important;                display: block !important;            }            .u-row {                width: calc(100% - 40px) !important;            }            .u-col {                width: 100% !important;            }            .u-col>div {                margin: 0 auto;            }        }                body {            margin: 0;            padding: 0;        }                table,        tr,        td {            vertical-align: top;            border-collapse: collapse;        }                p {            margin: 0;        }                .ie-container table,        .mso-container table {            table-layout: fixed;        }                * {            line-height: inherit;        }                a[x-apple-data-detectors='true'] {            color: inherit !important;            text-decoration: none !important;        }                @media (max-width: 480px) {            .hide-mobile {                max-height: 0px;                overflow: hidden;                display: none !important;            }        }                table,        td {            color: #000000;        }                a {            color: #0000ee;            text-decoration: underline;        }                @media (max-width: 480px) {            #u_content_image_1 .v-container-padding-padding {                padding: 10px !important;            }            #u_content_image_1 .v-src-width {                width: auto !important;            }            #u_content_image_1 .v-src-max-width {                max-width: 32% !important;            }            #u_content_image_1 .v-text-align {                text-align: center !important;            }            #u_content_heading_2 .v-container-padding-padding {                padding: 10px 40px !important;            }            #u_content_heading_2 .v-font-size {                font-size: 50px !important;            }            #u_content_image_2 .v-container-padding-padding {                padding: 10px 10px 30px !important;            }            #u_content_image_2 .v-src-width {                width: 100% !important;            }            #u_content_image_2 .v-src-max-width {                max-width: 100% !important;            }            #u_content_heading_1 .v-font-size {                font-size: 20px !important;            }            #u_content_heading_1 .v-line-height {                line-height: 150% !important;            }            #u_content_text_1 .v-container-padding-padding {                padding: 10px 15px 0px 20px !important;            }            #u_content_text_4 .v-container-padding-padding {                padding: 40px 15px 0px 20px !important;            }            #u_content_heading_3 .v-container-padding-padding {                padding: 50px 15px 20px !important;            }            #u_content_heading_3 .v-font-size {                font-size: 16px !important;            }        }    </style>    <link href=""https://fonts.googleapis.com/css?family=Montserrat:400,700&display=swap"" rel=""stylesheet"" type=""text/css""></head><body class=""clean-body u_body"" style=""margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #ffffff;color: #000000"">    <table style=""border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #ffffff;width:100%"" cellpadding=""0"" cellspacing=""0"">        <tbody>            <tr style=""vertical-align: top"">                <td style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">                    <div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #bfedd2;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">                                            <table id=""u_content_image_1"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:22px 10px 20px 35px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"">                                                                <tr>                                                                    <td class=""v-text-align"" style=""padding-right: 0px;padding-left: 0px;"" align=""center"">                                                                        <a href=""https://unlayer.com"" target=""_blank"">                                                                            <img align=""center"" border=""0"" src=""cid:{0}"" alt=""Logo"" title=""Logo"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 50%;max-width: 277.5px;""                                                                                width=""277.5"" class=""v-src-width v-src-max-width"" />                                                                        </a>                                                                    </td>                                                                </tr>                                                            </table>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>";

            public const string EmailFooter = @"<div class=""u-row-container"" style=""padding: 0px;background-color: #a2c1d6"">                        <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #489066;"">                            <div style=""border-collapse: collapse;display: table;width: 100%;background-color: transparent;"">                                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">                                    <div style=""width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                        <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">                                            <table id=""u_content_heading_3"" style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:50px 10px 20px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <h1 class=""v-text-align v-line-height v-font-size"" style=""margin: 0px; color: #ffffff; line-height: 140%; text-align: center; word-wrap: break-word; font-weight: normal; font-family: trebuchet ms,geneva; font-size: 22px;"">                                                                https://localhost:44390/Home                                                            </h1>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                            <table style=""font-family:arial,helvetica,sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">                                                <tbody>                                                    <tr>                                                        <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 10px 45px;font-family:arial,helvetica,sans-serif;"" align=""left"">                                                            <div align=""center"">                                                                <div style=""display: table; max-width:140px;"">                                                                    <table align=""left"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""32"" height=""32"" style=""border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 15px"">                                                                        <tbody>                                                                            <tr style=""vertical-align: top"">                                                                                <td align=""left"" valign=""middle"" style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">                                                                                    <a href=""https://facebook.com/"" title=""Facebook"" target=""_blank"">                                                                                        <img src=""cid:{0}"" alt=""Facebook"" title=""Facebook"" width=""32"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important"">                                                                                    </a>                                                                                </td>                                                                            </tr>                                                                        </tbody>                                                                    </table>                                                                    <table align=""left"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""32"" height=""32"" style=""border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 15px"">                                                                        <tbody>                                                                            <tr style=""vertical-align: top"">                                                                                <td align=""left"" valign=""middle"" style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">                                                                                    <a href=""https://linkedin.com/"" title=""LinkedIn"" target=""_blank"">                                                                                        <img src=""cid:{1}"" alt=""LinkedIn"" title=""LinkedIn"" width=""32"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important"">                                                                                    </a>                                                                                </td>                                                                            </tr>                                                                        </tbody>                                                                    </table>                                                                    <table align=""left"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""32"" height=""32"" style=""border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 0px"">                                                                        <tbody>                                                                            <tr style=""vertical-align: top"">                                                                                <td align=""left"" valign=""middle"" style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">                                                                                    <a href=""https://twitter.com/"" title=""Twitter"" target=""_blank"">                                                                                        <img src=""cid:{2}"" alt=""Twitter"" title=""Twitter"" width=""32"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important"">                                                                                    </a>                                                                                </td>                                                                            </tr>                                                                        </tbody>                                                                    </table>                                                                </div>                                                            </div>                                                        </td>                                                    </tr>                                                </tbody>                                            </table>                                        </div>                                    </div>                                </div>                            </div>                        </div>                    </div>                </td>            </tr>        </tbody>    </table></body></html>";
        }
    }
}