#pragma checksum "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e4f6677d650d17b8f15748de32265017992aa5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurant_Detail), @"mvc.1.0.view", @"/Views/Restaurant/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e4f6677d650d17b8f15748de32265017992aa5a", @"/Views/Restaurant/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a91fd89b3aaa79b60b793995cd41773cfa0786a6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Restaurant_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UMCTravelTour.ViewModel.Restaurants.RestaurantVm>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
  
    ViewData["Title"] = ViewBag.RestaurantName;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
 if (!string.IsNullOrEmpty(Model.ImageLink))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <style>\r\n        #header {\r\n            background-image: url(\'/");
#nullable restore
#line 9 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
                               Write(Model.ImageLink);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n        }\r\n    </style>\r\n");
#nullable restore
#line 12 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7e4f6677d650d17b8f15748de32265017992aa5a4873", async() => {
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
            WriteLiteral(@"

<section class=""ftco-section ftco-degree-bg wrapper-restaurent"">
    <div class=""container container-restaurent"" style=""padding: 20px 30px"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""row"">
                    <div class=""col-md-12 ftco-animate"">
                        <div class=""single-slider owl-carousel"">
                            <div class=""item"">
                                <div class=""hotel-img"" style=""background-image: url(images/hotel-2.jpg);""></div>
                            </div>
                            <div class=""item"">
                                <div class=""hotel-img"" style=""background-image: url(images/hotel-3.jpg);""></div>
                            </div>
                            <div class=""item"">
                                <div class=""hotel-img"" style=""background-image: url(images/hotel-4.jpg);""></div>
                            </div>
                        </div>
                    </div>
");
            WriteLiteral("                    <div class=\"col-md-12 hotel-single mt-4 mb-5 ftco-animate\">\r\n                        <span>Khách sạn Phổ biến</span>\r\n                        <h2>");
#nullable restore
#line 35 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
                       Write(Model.RestaurantName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                        <div class=""rate mb-2"">
                            <p class=""loc"">
                                <a href=""#""><i class=""icon-map""></i>Rất hân hạnh được phục vụ quý khách</a>
                            </p>
                            <span class=""star"">
                                <i class=""fas fa-star"" style=""color: #FFD700;""></i>
                                <i class=""fas fa-star"" style=""color: #FFD700;""></i>
                                <i class=""fas fa-star"" style=""color: #FFD700;""></i>
                                <i class=""fas fa-star"" style=""color: #FFD700;""></i>
                                <i class=""far fa-star""></i>
                                8 Rating

                            </span>
                        </div>
                        ");
#nullable restore
#line 50 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
                   Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        <div class=\"col-md-12 hotel-single ftco-animate mb-5 mt-5\">\r\n                            <h4 class=\"mb-4\">Nhà hàng liên quan</h4>\r\n                            <div class=\"row\">\r\n");
#nullable restore
#line 55 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
                                 foreach (var item in ViewBag.relateRestaurants)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""col-md-4"">
                                        <div class=""destination"">
                                            <a href=""hotel-single.html"" class=""img img-2"" style=""background-image: url(images/hotel-1.jpg);""></a>
                                            <div class=""text p-3"">
                                                <div class=""item-restaurant"">
                                                    <div class=""one"">
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7e4f6677d650d17b8f15748de32265017992aa5a9732", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3264, "~/", 3264, 2, true);
#nullable restore
#line 63 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
AddHtmlAttributeValue("", 3266, item.ImageLink, 3266, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                        <h3><a href=\"hotel-single.html\">");
#nullable restore
#line 64 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
                                                                                   Write(item.RestaurantName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></h3>
                                                        <p class=""rate"">
                                                            <i class=""fas fa-star"" style=""color: #FFD700;""></i>
                                                            <i class=""fas fa-star"" style=""color: #FFD700;""></i>
                                                            <i class=""fas fa-star"" style=""color: #FFD700;""></i>
                                                            <i class=""fas fa-star"" style=""color: #FFD700;""></i>
                                                            <i class=""fas fa-star-o""></i>
                                                        </p>
                                                    </div>

                                                </div>
                                                <p>Chúng tôi rất mong được phục vụ quý khách</p>
                                                <hr>
                                                <p class=""bottom");
            WriteLiteral("-area d-flex\">\r\n                                                    <span class=\"ml-auto\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e4f6677d650d17b8f15748de32265017992aa5a12798", async() => {
                WriteLiteral("XEM");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4518, "~/Restaurant/Detail?id=", 4518, 23, true);
#nullable restore
#line 78 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
AddHtmlAttributeValue("", 4541, Model.RestaurantId, 4541, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n                                                </p>\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 83 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Restaurant\Detail.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n\r\n                    </div>\r\n                </div> <!-- .col-md-8 -->\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section> <!-- .section -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UMCTravelTour.ViewModel.Restaurants.RestaurantVm> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
