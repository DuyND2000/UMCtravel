#pragma checksum "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "809c3598bc8974459a7e2212174c24d7fabfedd5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_Components_TourLocation_Default), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/Components/TourLocation/Default.cshtml")]
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
#line 5 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\_ViewImports.cshtml"
using System.Reflection;

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
#line 1 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
using UMCTravelTour.ViewModel.Locations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
using UMCTravelTour.ViewModel.Restaurants;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"809c3598bc8974459a7e2212174c24d7fabfedd5", @"/Areas/Admin/Views/Shared/Components/TourLocation/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4854bc5e0980edf680c03f90b167be9125e91e95", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Shared_Components_TourLocation_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LocationVm>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("hotelId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "hotelId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:50px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
  
    var res =  ViewBag.restaurants;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js""></script>
<script>
    function checkAll(){
        $("".ckcbox"").prop(""checked"", $('#ckcAll').prop('checked'));
    }
    $(document).ready(function() {
        function getRestaurant(){
            var restaurant = JSON.parse('");
#nullable restore
#line 14 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                                    Write(Html.Raw(ViewBag.restaurants));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
            if(restaurant.length > 0){
                appenData(restaurant);
               var ckcboxs = document.getElementsByClassName(""ckcbox"");
                for(let i = 0; i < ckcboxs.length; i++){
                    for(let j=0; j< restaurant.length; j++)
                    {
                        if(ckcboxs[i].value == restaurant[j].Id)
                           ckcboxs[i].checked = true;
                    }
                      
                    }
                }
            }
    getRestaurant();
    });
    
    function appenData(restaurant){
        var res = ``;
        var res1 = ``;
        for(var j=0;j<restaurant.length;j++){
            res+= `<tr><td>${restaurant[j].Name}</td></tr>`;
            res1+= `<option value=""${restaurant[j].Id}"" selected></option>`;
            console.log(restaurant[j].Name)
        }

        document.getElementById('resList').innerHTML = res + `<select name=""restaurantId"" hidden multiple>${res1}</select>`;
    }
");
            WriteLiteral(@"     function saveChanges(){
        var restaurant = [];
        var arr = document.getElementsByClassName(""ckcbox"");
        for(var i=0;i < arr.length;i++){
             if(arr[i].checked){
                 var resName = (arr[i].parentElement).nextElementSibling.nextElementSibling.innerText;
                 restaurant.push({Id:arr[i].value, Name: resName});
             }
        }
        appenData(restaurant);
    }
</script>



");
#nullable restore
#line 57 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
  
    ViewData["Hotels"] = new SelectList(Model.Hotels, "HotelId", "HotelName");
    ViewData["Restaurants"] = new SelectList(Model.Restaurants, "RestaurantId", "RestaurantName");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"form-group\">\r\n    <label for=\"hotelId\" class=\"control-label\">Hotels</label>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "809c3598bc8974459a7e2212174c24d7fabfedd59508", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 65 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Hotels;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<div class=""form-group"">
    <label for=""restaurantList"" class=""control-label"">Restaurants</label>
    <table id=""resList"" class=""table table-borderd border"">
      
    </table>
    <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#myModal"">
        Add/Remove restaurant
    </button>
</div>


<div id=""myModal"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog modal-xl"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Add or remove restaurant</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <table class=""table"">
                    <thead>
                        <tr>
                            <th>
                                <inp");
            WriteLiteral("ut id=\"ckcAll\" type=\"checkbox\" class=\"form-control\" onchange=\"checkAll()\" />\r\n                            </th>\r\n                            <th>No.</th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 97 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                           Write(Html.DisplayNameFor(l => l.Restaurants.GetEnumerator().Current.RestaurantName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <th>\r\n                                    ");
#nullable restore
#line 99 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                               Write(Html.DisplayNameFor(l => l.Restaurants.GetEnumerator().Current.ImageLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                    ");
#nullable restore
#line 102 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                               Write(Html.DisplayNameFor(l => l.Restaurants.GetEnumerator().Current.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                    ");
#nullable restore
#line 105 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                               Write(Html.DisplayNameFor(l => l.Restaurants.GetEnumerator().Current.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 110 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                          
                            int d = 0;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 113 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                         foreach (var item in Model.Restaurants)
                        {
                            d++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <input type=\"checkbox\" class=\"form-control ckcbox\"");
            BeginWriteAttribute("value", " value=\"", 4680, "\"", 4706, 1);
#nullable restore
#line 118 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
WriteAttributeValue("", 4688, item.RestaurantId, 4688, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 121 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                               Write(d);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 124 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                               Write(Html.DisplayFor(modelItem => item.RestaurantName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "809c3598bc8974459a7e2212174c24d7fabfedd516699", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5136, "~/", 5136, 2, true);
#nullable restore
#line 127 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
AddHtmlAttributeValue("", 5138, item.ImageLink, 5138, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 130 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 133 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 136 "C:\Users\Ssun4\Desktop\đồ án\UMCTourTravel\UMCTravelTour.Web\Areas\Admin\Views\Shared\Components\TourLocation\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </tbody>
                </table>
            </div>
            <div class=""modal-footer"" style=""position: sticky; bottom: 0; background-color: white;"">
                <button onclick=""saveChanges()"" type=""button"" class=""btn btn-primary"">Save changes</button>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LocationVm> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
