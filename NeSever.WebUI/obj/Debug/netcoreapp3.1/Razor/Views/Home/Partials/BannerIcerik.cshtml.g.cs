#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43e0383d31092514c8b5b4a9bf6e7b2fc1e47e50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Partials_BannerIcerik), @"mvc.1.0.view", @"/Views/Home/Partials/BannerIcerik.cshtml")]
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
#line 1 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\_ViewImports.cshtml"
using NeSever.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\_ViewImports.cshtml"
using NeSever.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\_ViewImports.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\_ViewImports.cshtml"
using X.PagedList.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\_ViewImports.cshtml"
using X.PagedList.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43e0383d31092514c8b5b4a9bf6e7b2fc1e47e50", @"/Views/Home/Partials/BannerIcerik.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Partials_BannerIcerik : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<NeSever.Common.Models.Sayfa.BannerIcerikVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"carouselIndicators\" class=\"carousel slide\" data-ride=\"carousel\" style=\"z-index:1;\">\r\n    <ol class=\"carousel-indicators\">\r\n");
#nullable restore
#line 5 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
           int sayac = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li data-target=\"#carouselIndicators\" data-slide-to=\"");
#nullable restore
#line 8 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
                                                            Write(sayac);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("class", " class=\"", 341, "\"", 372, 1);
#nullable restore
#line 8 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
WriteAttributeValue("", 349, sayac==0?"active":"", 349, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></li>\r\n");
#nullable restore
#line 9 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
            sayac++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ol>\r\n    <div class=\"carousel-inner\">\r\n        ");
#nullable restore
#line 13 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
    Write(sayac=0);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n");
#nullable restore
#line 14 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 545, "\"", 590, 2);
            WriteAttributeValue("", 553, "carousel-item", 553, 13, true);
#nullable restore
#line 16 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
WriteAttributeValue(" ", 566, sayac==0?"active":"", 567, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 17 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
                 if (string.IsNullOrEmpty(item.Link))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 714, "\"", 737, 1);
#nullable restore
#line 19 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
WriteAttributeValue("", 720, item.ResimBase64, 720, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 20 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
                }
                else
                {
                    if (item.Link.Contains("nesever"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 906, "\"", 923, 1);
#nullable restore
#line 25 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
WriteAttributeValue("", 913, item.Link, 913, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 981, "\"", 1004, 1);
#nullable restore
#line 26 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
WriteAttributeValue("", 987, item.ResimBase64, 987, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </a>\r\n");
#nullable restore
#line 28 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 1136, "\"", 1153, 1);
#nullable restore
#line 31 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
WriteAttributeValue("", 1143, item.Link, 1143, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">\r\n                            <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 1227, "\"", 1250, 1);
#nullable restore
#line 32 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
WriteAttributeValue("", 1233, item.ResimBase64, 1233, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </a>\r\n");
#nullable restore
#line 34 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 37 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Home\Partials\BannerIcerik.cshtml"
            sayac++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <a class=""carousel-control-prev"" href=""#carouselIndicators"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Önce</span>
    </a>
    <a class=""carousel-control-next"" href=""#carouselIndicators"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Sonra</span>
    </a>
</div>

<script type=""text/javascript"">
    $(document).ready(function () {
        $('.carousel').carousel({
            touch: true,
            interval: 3000
        })
    });
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<NeSever.Common.Models.Sayfa.BannerIcerikVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591