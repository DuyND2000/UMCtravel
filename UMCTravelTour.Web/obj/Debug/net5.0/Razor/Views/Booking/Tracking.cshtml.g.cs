#pragma checksum "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Booking\Tracking.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2034b2a38a32dc1997a9fba06f4462775f5fe67e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booking_Tracking), @"mvc.1.0.view", @"/Views/Booking/Tracking.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\_ViewImports.cshtml"
using UMCTravelTour.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\_ViewImports.cshtml"
using UMCTravelTour.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\_ViewImports.cshtml"
using UMCTravelTour.ViewModel.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2034b2a38a32dc1997a9fba06f4462775f5fe67e", @"/Views/Booking/Tracking.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a91fd89b3aaa79b60b793995cd41773cfa0786a6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Booking_Tracking : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UMCTravelTour.ViewModel.Bookings.BookingVm>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_HeaderPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Booking\Tracking.cshtml"
  
    ViewData["Title"] = "Booking Tracking";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2034b2a38a32dc1997a9fba06f4462775f5fe67e3902", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div");
            BeginWriteAttribute("oncontextmenu", " oncontextmenu=\'", 142, "\'", 158, 0);
            EndWriteAttribute();
            WriteLiteral(@" class='snippet-body'>
        <div class=""container"">
            <article class=""card"">
                <header class=""card-header""> Tracking your booking </header>
                <div class=""card-body"">
                    <h3>BOOKING CONFIRMATION</h3>
                    <article class=""card"">
                        <div class=""card-body row"">
                            <div class=""col""> <strong>Estimated Delivery time:</strong> <br>29 nov 2019 </div>
                            <div class=""col""> <strong>Shipping BY:</strong> <br> BLUEDART, | <i class=""fa fa-phone""></i> +1598675986 </div>
                            <div class=""col""> <strong>Status:</strong> <br> Picked by the courier </div>
                            <div class=""col""> <strong>Tracking #:</strong> <br> BD045903594059 </div>
                        </div>
                    </article>
                    <div class=""track"">
                        <div class=""step active""> <span class=""icon""> <i class=""fa fa-check""></i>");
            WriteLiteral(@" </span> <span class=""text"">Order confirmed</span> </div>
                        <div class=""step active""> <span class=""icon""> <i class=""fa fa-user""></i> </span> <span class=""text""> Picked by courier</span> </div>
                        <div class=""step""> <span class=""icon""> <i class=""fa fa-truck""></i> </span> <span class=""text""> On the way </span> </div>
                        <div class=""step""> <span class=""icon""> <i class=""fa fa-box""></i> </span> <span class=""text"">Ready for pickup</span> </div>
                    </div>
                    <hr style=""margin-top: 150px;"">
                    <table class=""table"">
                        <tr>
                            <td scope=""col"">BOOKING #</th>
                                <td scope=""col"">000001</th>
                                    <td scope=""col"">Your BusinessName</th>
                        </tr>
                        <tr>
                            <td>BOOKING DATE</td>
                            <td>mm/dd/yyyy</td>
 ");
            WriteLiteral(@"                           <td>Your Street 123<br> 12345 Your City<br>

                            </td>
                        </tr>
                        <tr>
                            <td>BOOKING DETAILS</td>
                            <td></td>
                            <td>
                                Your Country
                            </td>
                        </tr>
                        <tr>
                            <td>Check in</td>
                            <td>mm/dd/yyyy</td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>Check out</td>
                            <td>mm/dd/yyyy</td>
                            <td>
                                youremail@email.com
                            </td>
                        </tr>
                        <tr>
                            <td>Roome type</td>
                            ");
            WriteLiteral(@"<td>single</td>
                            <td>
                                yourwebsite.com
                            </td>
                        </tr>
                        <tr>
                            <td>#Guests</td>
                            <td>0</td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>BOOKED BY</td>
                            <td></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>Name</td>
                            <td style=""font-weight: bold;"">Guest Name</td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>Contact</td>
                            <td style=""font-weight: bold;""> <u>quest@gmail.com</u> </td>
          ");
            WriteLiteral(@"                  <td>
                            </td>
                        </tr>
                    </table>
                    <br><br>
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th scope=""col"">DESCRIPTION</th>
                                <th scope=""col"">UNIT COST</th>
                                <th scope=""col"">QUANTITY</th>
                                <th scope=""col"">AMOUNT</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope=""row"">aaaaaaaaaaaaaaaaaa</th>
                                <td>$</td>
                                <td style=""text-align: center;"">1</td>
                                <td>$</td>
                            </tr>
                            <tr>
                                <th scope=""row"">aaaaaaaaaaaaaaaaaa</th>
            WriteLiteral(@"
                                <td>$</td>
                                <td style=""text-align: center;"">1</td>
                                <td>$</td>
                            </tr>
                            <tr>
                                <th scope=""row"">aaaaaaaaaaaaaaaaaa</th>
                                <td>$</td>
                                <td style=""text-align: center;"">1</td>
                                <td>$</td>
                            </tr>
                            <tr>
                                <th scope=""row"">aaaaaaaaaaaaaaaaaa</th>
                                <td>$</td>
                                <td style=""text-align: center;"">1</td>
                                <td>$</td>
                            </tr>
                            <tr style=""font-weight: bold;"">
                                <th scope=""row""></th>
                                <td></td>
                                <td>Subtotal</td>
              ");
            WriteLiteral(@"                  <td>$</td>
                            </tr>
                            <tr style=""font-weight: bold;"">
                                <th scope=""row""></th>
                                <td></td>
                                <td>VAT rate(%)</td>
                                <td style=""text-align: center;"">0%</td>
                            </tr>
                            <tr style=""font-weight: bold;"">
                                <th scope=""row""></th>
                                <td></td>
                                <td>VAT</td>
                                <td>$</td>
                            </tr>
                            <tr style=""font-weight: bold;"">
                                <th scope=""row""></th>
                                <td></td>
                                <td>Total</td>
                                <td>$</td>
                            </tr>
                        </tbody>
                    </table>
    ");
            WriteLiteral("                <hr>\r\n                    <a href=\"#\" class=\"btn btn-warning\" data-abc=\"true\"> <i class=\"fa fa-chevron-left\"></i> Back to orders</a>\r\n                </div>\r\n            </article>\r\n        </div>\r\n    </div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UMCTravelTour.ViewModel.Bookings.BookingVm> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591