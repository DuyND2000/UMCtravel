#pragma checksum "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d93df01f88e0651e35cf30ae354b17fdd820de78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__HeaderPartial), @"mvc.1.0.view", @"/Views/Shared/_HeaderPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d93df01f88e0651e35cf30ae354b17fdd820de78", @"/Views/Shared/_HeaderPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a91fd89b3aaa79b60b793995cd41773cfa0786a6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__HeaderPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-solid-lg page-scroll"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Tour/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<header id=\"header\" class=\"header\" >\r\n    <div class=\"header-content\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-lg-12\">\r\n                    <div class=\"text-container\">\r\n");
#nullable restore
#line 7 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                         if (ViewData["Title"].ToString() == "Home Page")
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                            {
                                var requestedLanguage = Context.Request.Query["lang"].ToString();
                                if (requestedLanguage == String.Empty)
                                    requestedLanguage = "en";
                                ViewBag.LanguagePack = unitOfWork.StaticContentRepository.GetById(requestedLanguage);
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h1>");
#nullable restore
#line 16 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                           Write(ViewBag.LanguagePack.GreatWord);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span id=\"js-rotating\">");
#nullable restore
#line 16 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                                                                                  Write(ViewBag.LanguagePack.DynamicWord1);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 16 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                                                                                                                      Write(ViewBag.LanguagePack.DynamicWord2);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 16 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                                                                                                                                                          Write(ViewBag.LanguagePack.DynamicWord3);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h1>\r\n                            <p class=\"p-heading p-large\">\r\n                                ");
#nullable restore
#line 18 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                           Write(ViewBag.LanguagePack.Quote);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <br>\r\n                                <span style=\"font-size: 13px;\" class=\"testimonial-text\">- ");
#nullable restore
#line 20 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                                                                                     Write(ViewBag.LanguagePack.QuoteAuthor);

#line default
#line hidden
#nullable disable
            WriteLiteral(" -</span>\r\n                            </p>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d93df01f88e0651e35cf30ae354b17fdd820de787699", async() => {
                WriteLiteral("Đặt tour ngay");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 23 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h1>");
#nullable restore
#line 26 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                           Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 27 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\_HeaderPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <!-- end of col -->\r\n            </div>\r\n            <!-- end of row -->\r\n        </div>\r\n        <!-- end of container -->\r\n    </div>\r\n    <!-- end of header-content -->\r\n</header>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UMCTravelTour.DAL.Infrastructures.IUnitOfWork unitOfWork { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
