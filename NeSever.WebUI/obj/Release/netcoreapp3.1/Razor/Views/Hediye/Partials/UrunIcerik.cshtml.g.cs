#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9904f8784e9f4c71ea74cd6484c7b1b75b619d6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hediye_Partials_UrunIcerik), @"mvc.1.0.view", @"/Views/Hediye/Partials/UrunIcerik.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9904f8784e9f4c71ea74cd6484c7b1b75b619d6c", @"/Views/Hediye/Partials/UrunIcerik.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Hediye_Partials_UrunIcerik : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<NeSever.Common.Models.Urun.UrunIcerikVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/Partials/UyeHediye.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/Partials/UyeAlisveris.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<script src=\"/js/jquery.lazy.min.js\"></script>\r\n\r\n<div class=\"row\">\r\n");
#nullable restore
#line 6 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
     if (!Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 align-center pb80 pt80\">\r\n            <p>\r\n                <h3>Aradığınız ürün bulunamadı.</h3>\r\n            </p>\r\n        </div>\r\n");
#nullable restore
#line 13 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
         foreach (var urun in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col col-xl-3 col-lg-4 col-md-6 col-sm-6 col-12\">\r\n                <div class=\"shop-product-item\">\r\n                    <div class=\"product-thumb\" style=\"background-color:transparent;\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 673, "\"", 706, 2);
            WriteAttributeValue("", 680, "/Hediye/Detay/", 680, 14, true);
#nullable restore
#line 21 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
WriteAttributeValue("", 694, urun.UrunId, 694, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100%; text-align:center\">\r\n                            <img class=\"lazy\" src=\"/Uploads/Site/loading_250_250.gif\" data-src=\"");
#nullable restore
#line 22 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
                                                                                           Write(urun.ResimUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" alt=\"product\" style=\"height:250px;\">\r\n                        </a>\r\n                    </div>\r\n\r\n                    <div class=\"product-content\">\r\n                        <div class=\"block-title\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1090, "\"", 1123, 2);
            WriteAttributeValue("", 1097, "/Hediye/Detay/", 1097, 14, true);
#nullable restore
#line 28 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
WriteAttributeValue("", 1111, urun.UrunId, 1111, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"product-category\">");
#nullable restore
#line 28 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
                                                                                     Write(urun.MarkaAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1200, "\"", 1233, 2);
            WriteAttributeValue("", 1207, "/Hediye/Detay/", 1207, 14, true);
#nullable restore
#line 29 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
WriteAttributeValue("", 1221, urun.UrunId, 1221, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"h5 title\">");
#nullable restore
#line 29 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
                                                                             Write(urun.UrunAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n                        <div class=\"block-price\">\r\n");
#nullable restore
#line 32 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
                             if (urun.SatilabilirUrun && urun.Fiyat > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1513, "\"", 1561, 3);
            WriteAttributeValue("", 1523, "alisverisSepetineEkle(\'", 1523, 23, true);
#nullable restore
#line 34 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
WriteAttributeValue("", 1546, urun.UrunId, 1546, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1558, "\');", 1558, 3, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""in-cart"" style=""opacity: 50 !important; background-color: #38a9ff !important; top:-80px;"" title=""AlışVeriş Sepetine Ekle"">
                                    <svg class=""olymp-shopping-bag-icon"">
                                        <title>AlışVeriş Sepetine Ekle</title>
                                        <use xlink:href=""#olymp-shopping-bag-icon"">
                                            <title>AlışVeriş Sepetine Ekle</title>
                                        </use>
                                    </svg>
                                </a>
");
#nullable restore
#line 42 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2231, "\"", 2312, 6);
            WriteAttributeValue("", 2241, "hediyeSepetineEkle(\'", 2241, 20, true);
#nullable restore
#line 44 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
WriteAttributeValue("", 2261, urun.UrunId, 2261, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2273, "\',", 2273, 2, true);
            WriteAttributeValue(" ", 2275, "\'", 2276, 2, true);
#nullable restore
#line 44 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
WriteAttributeValue("", 2277, urun.HediyeSepetindekiUrunAdeti, 2277, 32, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2309, "\');", 2309, 3, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""in-cart"" style=""opacity: 50 !important; background-color: #ff5e3a !important; top: -30px;"" title=""Hediye Sepetine Ekle"">
                                <svg class=""olymp-shopping-bag-icon"">
                                    <title>Hediye Sepetine Ekle</title>
                                    <use xlink:href=""#olymp-like-post-icon"">
                                        <title>Hediye Sepetine Ekle</title>
                                    </use>
                                </svg>
                            </a>

                            <div style="" margin-right: 0; font-size: 16px; font-weight: 700;"">
");
#nullable restore
#line 54 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
                                 if (urun.SatilabilirUrun && urun.Fiyat > 0)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
                               Write(Html.Raw((urun.Fiyat.ToString("#,##0.00"))+" TL"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
                                                                                      ;
                                }
                                else
                                {

                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
                               Write(Html.Raw(" "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
                                                  ;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 68 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 align-center pb80 pt80\">\r\n            <nav aria-label=\"Page navigation\">\r\n                ");
#nullable restore
#line 72 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
           Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("Ara",
                 new
                 {
                     p = page,
                     s = Context.Request.Query["s"],
                     sk = Context.Request.Query["sk"],
                     q = Context.Request.Query["q"],
                     m = Context.Request.Query["m"],
                     k = Context.Request.Query["k"],
                     w = Context.Request.Query["w"],
                     kb = Context.Request.Query["kb"],
                 }),
               new PagedListRenderOptionsBase
               {
                   UlElementClasses = new string[] { "pagination justify-content-center" },
                   LiElementClasses = new string[] { "page-item" },
                   ActiveLiElementClass = "page-item active",
                   PageClasses = new string[] { "page-link" },
                   EllipsesFormat = "<a class='page-link' style='padding:12px 0px 0px 0px; border:none;'>...</a>",
                   Display = PagedListDisplayMode.Always,
                   DisplayLinkToFirstPage = PagedListDisplayMode.Always,
                   DisplayLinkToLastPage = PagedListDisplayMode.Always,
                   DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
                   DisplayLinkToNextPage = PagedListDisplayMode.Always,
                   MaximumPageNumbersToDisplay = 5,
                   ContainerDivClasses = null,
               }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </nav>\r\n        </div>\r\n");
#nullable restore
#line 101 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Hediye\Partials\UrunIcerik.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9904f8784e9f4c71ea74cd6484c7b1b75b619d6c16369", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9904f8784e9f4c71ea74cd6484c7b1b75b619d6c17486", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script type=""text/javascript"" charset=""utf-8"">
    $('.lazy').Lazy({
        scrollDirection: 'vertical',
        effect: 'fadeIn',
        visibleOnly: true,
        onError: function (element) {
            console.log('error loading ' + element.data('src'));
        }
    });
</script>
<script type=""text/javascript"">
    function hediyeSepetineEkle(id, adet) {
        $.ajax({
            url: ""/Hediye/KullaniciHediyeEkle/"" + id,
            type: ""GET"",
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success: function (data) {
                if (data.error == true) {
                    if (data.operation == ""show"") {
                        hediyeSepetiShowModal(adet);
                    }
                    else if (data.operation == ""message"") {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Uyarı!',
                            te");
            WriteLiteral(@"xt: data.message,
                            confirmButtonText: ""Tamam""
                        })
                    }
                }
                else {
                    Swal.fire({
                        icon: 'success',
                        title: 'Evvet!',
                        text: ""Hediye sepetinize eklendi."",
                        confirmButtonText: ""Tamam""
                    })
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(""hata!"");
            }
        });
    }

    function hediyeSepetiShowModal(adet) {
        $('#hediyeSepetiToplamUrunSayisi').html(adet);
        $('#hediyeEkleModal').modal('show');
    }

    function alisverisSepetineEkle(id) {
        var sendData = { UrunId: id, Adet: 1 };

        $.ajax({
            url: ""/Sepet/SepetUrunEkle"",
            type: ""POST"",
            dataType: 'json',
            data: sendData,
            success: f");
            WriteLiteral(@"unction (data) {
                if (data.error == true) {
                    if (data.operation == ""show"") {
                        alisverisSepetiShowModal();
                    }
                    else if (data.operation == ""message"") {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Uyarı!',
                            text: data.message,
                            confirmButtonText: ""Tamam""
                        })
                    }
                }
                else {
                    $(""#headerSepetUrunSayisi"").empty();
                    $(""#headerMobilSepetUrunSayisi"").empty();
                    $(""#headerSepetUrunSayisi"").html(data.recordsTotal);
                    $(""#headerMobilSepetUrunSayisi"").html(data.recordsTotal);

                    Swal.fire({
                        icon: 'success',
                        title: 'Evvet!',
                        text: ""Alışveriş sepetinize ");
            WriteLiteral(@"eklendi."",
                        confirmButtonText: ""Tamam""
                    })
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(""hata!"");
            }
        });
    }

    function alisverisSepetiShowModal() {
        $('#uyeAlisverisModal').modal('show');
    }
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<NeSever.Common.Models.Urun.UrunIcerikVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
