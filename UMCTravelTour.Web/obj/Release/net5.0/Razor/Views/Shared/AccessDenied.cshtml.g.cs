#pragma checksum "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1e40dbfca7d2872e7cf574713c1e1b619fbc253"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_AccessDenied), @"mvc.1.0.view", @"/Views/Shared/AccessDenied.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1e40dbfca7d2872e7cf574713c1e1b619fbc253", @"/Views/Shared/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a91fd89b3aaa79b60b793995cd41773cfa0786a6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_AccessDenied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\AccessDenied.cshtml"
  
    ViewData["Title"] = "Access denied";
    Layout = "";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    h1{
        color: red;
        font-size: 100px;
    }
    p {
        color: red;
        font-size: 50px;
    }

    .container {
        width: 800px;
        margin-left: auto;
        margin-right: auto;
        text-align: center;
    }
</style>

<div class=""container"">
    <h1>");
#nullable restore
#line 25 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Views\Shared\AccessDenied.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
    <p>Không có quyền truy cập</p>
    <img src=""https://media.istockphoto.com/vectors/shield-with-hand-block-icon-in-flat-style-with-shadow-vector-id867726980?k=20&m=867726980&s=612x612&w=0&h=ge5fg-rTBLy_OVAyhCiawo4Ou9bHcIQ9WtVORH20N8U="" alt=""denied""/>
</div>

<script>
    window.setTimeout(myFunction, 2000);

    function myFunction() {
      alert(""Đi tới Admin"")
      history.back();
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
