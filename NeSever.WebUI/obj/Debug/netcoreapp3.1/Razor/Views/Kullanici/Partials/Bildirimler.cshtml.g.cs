#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a21ba4b11b2839315a8709298e300dc46754d1b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kullanici_Partials_Bildirimler), @"mvc.1.0.view", @"/Views/Kullanici/Partials/Bildirimler.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a21ba4b11b2839315a8709298e300dc46754d1b1", @"/Views/Kullanici/Partials/Bildirimler.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Kullanici_Partials_Bildirimler : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<NeSever.Common.Models.Uyelik.KullaniciBildirimVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Uploads/Site/notification.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"ui-block\">\r\n    <div class=\"ui-block-title\">\r\n        <h6 class=\"title\">Bildirimler</h6>\r\n");
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 8 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
     if (!Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"align-center pb80 pt80\">\r\n            <p>\r\n                <h3>Henüz bildiriminiz yoktur.</h3>\r\n            </p>\r\n        </div>\r\n");
#nullable restore
#line 15 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul class=\"notification-list\">\r\n");
#nullable restore
#line 19 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
             foreach (var bildirim in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li");
            BeginWriteAttribute("class", " class=\"", 641, "\"", 682, 1);
#nullable restore
#line 21 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
WriteAttributeValue("", 649, bildirim.OkunduMu?"":"un-read", 649, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 22 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                     if (bildirim.AktifMi)
                    {
                        /* <div class="author-thumb">
                             <img src="@bildirim.IlgiliKullaniciProfilResimBase64" alt="author" style="max-width:36px; height:36px">
                         </div>*/

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"notification-event\">\r\n                        <!--<a href=\"javascript:;\" class=\"h6 notification-friend\"></a>-->\r\n\r\n\r\n");
#nullable restore
#line 31 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                         switch (bildirim.BildirimTipId)
                        {
                            case 1:
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                           Write(Html.Raw(@bildirim.BildirimIcerik));

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                   
                                break;
                            case 2:
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                           Write(Html.Raw(@bildirim.BildirimIcerik));

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                   
                                break;
                            case 3:
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                           Write(Html.Raw(@bildirim.BildirimIcerik));

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                   
                                break;
                            case 6:
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                           Write(Html.Raw(@bildirim.BildirimIcerik));

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                   
                                break;
                            case 7:
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                           Write(Html.Raw(@bildirim.BildirimIcerik));

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                   
                                /*<a href="/Kullanici/Profil/@bildirim.IlgiliKullaniciAdi" class="notification-link">Profile Gözat</a>*/
                                break;
                            case 4:
                                /*<a href="javascript:;" class="notification-link">Mesajını Oku</a>*/
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                           Write(Html.Raw(@bildirim.BildirimIcerik));

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                   
                                break;
                            case 5:
                                /*<a href="javascript:;" class="notification-link">Kartına Bak</a>*/
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                           Write(Html.Raw(@bildirim.BildirimIcerik));

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                   
                                break;
                            case 8:
                                /*<a href="javascript:;" class="notification-link">Hediyeye Bak</a>*/
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                           Write(Html.Raw(@bildirim.BildirimIcerik));

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                   
                                break;
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <span class=\"notification-date\"><time class=\"entry-date updated\">");
#nullable restore
#line 63 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                                    Write(bildirim.KayitTarihi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</time></span>\r\n                    </div>\r\n");
#nullable restore
#line 65 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"author-thumb\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a21ba4b11b2839315a8709298e300dc46754d1b113230", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"notification-event\">\r\n                            <a href=\"#\" class=\"h6 notification-friend\"></a> ");
#nullable restore
#line 72 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                       Write(Html.Raw(@bildirim.BildirimIcerik));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            <span class=\"notification-date\"><time class=\"entry-date updated\">");
#nullable restore
#line 74 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                                                                                        Write(bildirim.KayitTarihi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</time></span>\r\n                        </div>\r\n");
#nullable restore
#line 76 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 78 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                     switch (bildirim.BildirimTipId)
                    {
                        case 1:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"notification-icon\">\r\n                                    <svg class=\"olymp-calendar-icon\"><use xlink:href=\"#olymp-cupcake-icon\"></use></svg>\r\n                            </span>\r\n");
#nullable restore
#line 84 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                            break;
                        case 2:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"notification-icon\">\r\n                                    <svg class=\"olymp-calendar-icon\"><use xlink:href=\"#olymp-calendar-icon\"></use></svg>\r\n                            </span>\r\n");
#nullable restore
#line 89 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                            break;
                        case 3:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"notification-icon\">\r\n                                    <svg class=\"olymp-happy-face-icon\"><use xlink:href=\"#olymp-happy-face-icon\"></use></svg>\r\n                            </span>\r\n");
#nullable restore
#line 94 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                            break;
                        case 4:

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <span class=""notification-icon"">
                                    <svg class=""olymp-comments-post-icon""><use xlink:href=""#olymp-comments-post-icon""></use></svg>
                            </span>                          
");
#nullable restore
#line 99 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                            break;
                        case 5:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"notification-icon\">\r\n                                    <svg class=\"olymp-heart-icon\"><use xlink:href=\"#olymp-heart-icon\"></use></svg>\r\n                            </span>\r\n");
#nullable restore
#line 104 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                            break;
                        case 6:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"notification-icon\">\r\n                                    <svg class=\"olymp-heart-icon\"><use xlink:href=\"#olymp-heart-icon\"></use></svg>\r\n                            </span>\r\n");
#nullable restore
#line 109 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                            break;
                        case 7:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"notification-icon\">\r\n                                    <svg class=\"olymp-calendar-icon\"><use xlink:href=\"#olymp-plus-icon\"></use></svg>\r\n                            </span>\r\n");
#nullable restore
#line 114 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                            break;
                        case 8:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"notification-icon\">\r\n                                    <svg class=\"olymp-calendar-icon\"><use xlink:href=\"#olymp-star-icon\"></use></svg>\r\n                            </span>\r\n");
#nullable restore
#line 119 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
                            break;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    <!--<div class=""more"">
                        <a href=""#"">
                            <svg class=""olymp-little-delete""><use xlink:href=""#olymp-little-delete""></use></svg>
                        </a>
                    </div>-->
                </li>
");
#nullable restore
#line 128 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("        </ul>\r\n        <a href=\"javascript:;\" onclick=\"TumBildirimleriSil();\" class=\"btn btn-danger btn-sm\" style=\"margin-left:10px; margin-top:10px;\">Tümünü Sil</a>\r\n");
#nullable restore
#line 163 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
#nullable restore
#line 166 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
 if (Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 align-center pb80 pt80\">\r\n        <nav aria-label=\"Page navigation\">\r\n            ");
#nullable restore
#line 170 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
       Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("BildirimlerPartial",
            new
            {
               p = page
            }),
            PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(
            new PagedListRenderOptions
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
            },
            new AjaxOptions
            {
                HttpMethod = "GET",
                UpdateTargetId = "targetElement",
                OnBegin = "onAjaxBegin",
                OnSuccess = "onAjaxSuccess",
                OnFailure = "onAjaxFailure"
            })));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </nav>\r\n    </div>\r\n");
#nullable restore
#line 201 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\Bildirimler.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    function bildirimOkundu(id) {
        $.ajax({
            url: ""/Hediye/KullaniciHediyeSil/"" + id,
            type: ""GET"",
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success: function (data) {
                if (data.error == true) {
                    if (data.operation == ""message"") {
                        Swal.fire({
                            icon: 'error',
                            title: 'Upps',
                            text: data.message,
                            confirmButtonText: ""Tamam""
                        })
                    }
                }
                else {
                    hediyeSepetiGetir();

                    var hediyeSepetiSayi = $('#hediyeSepetiSayi').text();
                    $('#hediyeSepetiSayi').text(hediyeSepetiSayi - 1);

                    Swal.fire({
                        icon: 'success',
                ");
            WriteLiteral(@"        title: 'Evvet!',
                        text: ""Hediye sepetinizden kaldırıldı."",
                        confirmButtonText: ""Tamam""
                    })
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(""hata!"");
            }
        });
    }

    function TumBildirimleriSil() {
        $.ajax({
            url: ""/Kullanici/KullaniciTumBildirimleriSil/"",
            type: ""POST"",
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success: function (data) {
                if (data == false) {
                    if (data.operation == ""message"") {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Bildirim Silme',
                            text: 'Bildirim silerken bir hata oluştu!',
                            confirmButtonText: ""Tamam""
                    ");
            WriteLiteral(@"    })
                    }
                }
                else {
                    bildirimleriGetir();

                    Swal.fire({
                        icon: 'success',
                        title: 'Evet!',
                        text: ""Bildirimleriniz kaldırıldı."",
                        confirmButtonText: ""Tamam""
                    })
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(""hata!"");
            }
        });
    }

    function onAjaxBegin(data, status, xhr) {
        showLoading();
    }

    function onAjaxSuccess(data, status, xhr) {
        hideLoading();

        var middleContent = $('#middleContent');
        middleContent.html('');
        middleContent.html(data);
    }

    function onAjaxFailure(xhr, status, error) {
        $(""#targetElement"").html(""<strong>İşlem sırasında bir hata oluştu:"" + error + ""<br/>.</strong>"");
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<NeSever.Common.Models.Uyelik.KullaniciBildirimVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591