#pragma checksum "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bffe791274971ebe7f24251aa3c33b43aa313e2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_StaticContents_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/StaticContents/Index.cshtml")]
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
#line 1 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\_ViewImports.cshtml"
using UMCTravelTour.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\_ViewImports.cshtml"
using UMCTravelTour.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\_ViewImports.cshtml"
using UMCTravelTour.Common.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\_ViewImports.cshtml"
using UMCTravelTour.ViewModel.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\_ViewImports.cshtml"
using UMCTravelTour.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
using System.Reflection;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bffe791274971ebe7f24251aa3c33b43aa313e2c", @"/Areas/Admin/Views/StaticContents/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4854bc5e0980edf680c03f90b167be9125e91e95", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_StaticContents_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UMCTravelTour.Core.Models.StaticContent>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-group"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bffe791274971ebe7f24251aa3c33b43aa313e2c5254", async() => {
                WriteLiteral("\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>Key</th>\r\n                <th>Value</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 18 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
              
                var properties = Model.GetType().GetProperties();
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
             foreach (var property in properties)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 24 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
                   Write(property.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>\r\n                        <input type=\"text\"");
                BeginWriteAttribute("name", " name=\"", 653, "\"", 674, 1);
#nullable restore
#line 26 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
WriteAttributeValue("", 660, property.Name, 660, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 675, "\"", 708, 1);
#nullable restore
#line 26 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
WriteAttributeValue("", 683, property.GetValue(Model), 683, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("placeholder", " placeholder=\"", 709, "\"", 737, 1);
#nullable restore
#line 26 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
WriteAttributeValue("", 723, property.Name, 723, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                        ");
#nullable restore
#line 27 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
                         if(property.Name=="LanguageCode")
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                WriteLiteral("readonly\r\n");
#nullable restore
#line 30 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        >\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 34 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\StaticContents\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n    <button class = \"btn btn-primary\" type=\"submit\">Submit changes</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UMCTravelTour.Core.Models.StaticContent> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591