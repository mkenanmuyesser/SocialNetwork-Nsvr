#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f012a8861aebd668e32d7c6a68bd25ca38d7dd76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kullanici_Partials_ArkadasMesajDetay), @"mvc.1.0.view", @"/Views/Kullanici/Partials/ArkadasMesajDetay.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f012a8861aebd668e32d7c6a68bd25ca38d7dd76", @"/Views/Kullanici/Partials/ArkadasMesajDetay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Kullanici_Partials_ArkadasMesajDetay : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NeSever.Common.Models.FrontEnd.MesajlarVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<style type=\"text/css\">\r\n    .scroll {\r\n        max-height: 400px;\r\n        overflow-y: scroll;\r\n    }\r\n</style>\r\n\r\n<div id=\"ToplamMesajSayisi\" hidden>");
#nullable restore
#line 10 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
                              Write(Model.MesajList.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
#nullable restore
#line 12 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
 if (!Model.MesajList.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""ui-block-title"">
        <div class=""col col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 align-center pb80 pt80"">
            <p>
                <h3>Mesaj Kutunuz Boş</h3>
            </p>
        </div>
        <a href=""javascript:;"" class=""more"" title=""Yenile"" onclick=""MesajYenile();""><svg class=""olymp-little-delete""><use xlink:href=""#olymp-weather-refresh-icon"" xlink:title=""Yenile""></use></svg></a>
");
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 23 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"ui-block-title\">\r\n        <h6 class=\"title\">\r\n            ");
#nullable restore
#line 28 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
       Write(Model.KullaniciAd);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </h6>\r\n        <a href=\"javascript:;\" class=\"more\" title=\"Yenile\" onclick=\"MesajYenile();\"><svg class=\"olymp-little-delete\"><use xlink:href=\"#olymp-weather-refresh-icon\" xlink:title=\"Yenile\"></use></svg></a>\r\n");
            WriteLiteral("    </div>\r\n");
            WriteLiteral("    <div id=\"MesajScroll\" class=\"scroll\" data-mcs-theme=\"dark\">\r\n        <ul class=\"notification-list chat-message chat-message-field\">\r\n\r\n");
#nullable restore
#line 37 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
             foreach (var mesaj in Model.MesajList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>\r\n                    <div id=\"AliciId\" hidden>");
#nullable restore
#line 40 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
                                        Write(mesaj.AliciKullanici.KullaniciId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div id=\"GondrenId\" hidden>");
#nullable restore
#line 41 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
                                          Write(mesaj.GonderenKullanici.KullaniciId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 42 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
                     if (Model.KullaniciAd == @mesaj.GonderenKullanici.KullaniciAdi)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"author-thumb\">\r\n                            <svg class=\"olymp-little-delete\"><use xlink:href=\"#olymp-popup-left-arrow\"></use></svg>\r\n                        </div>\r\n");
#nullable restore
#line 47 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"author-thumb\">\r\n                            <svg class=\"olymp-little-delete\"><use xlink:href=\"#olymp-popup-right-arrow\"></use></svg>\r\n\r\n                        </div>\r\n");
#nullable restore
#line 54 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"notification-event\">\r\n                        <div class=\"event-info-wrap\">\r\n                            <a href=\"javascript:;\" class=\"h6 notification-friend\">");
#nullable restore
#line 57 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
                                                                             Write(mesaj.GonderenKullanici.KullaniciAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            <span style=\"position:absolute; right:20px;\" class=\"notification-date\"><time class=\"entry-date updated\">");
#nullable restore
#line 58 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
                                                                                                                               Write(mesaj.KayitTarihi.ToString("dd.MM.yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</time></span>\r\n                        </div>\r\n                        <span class=\"chat-message-item\">");
#nullable restore
#line 60 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
                                                   Write(mesaj.Mesaj);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"more\">\r\n                        <a href=\"javascript:;\"");
            BeginWriteAttribute("id", " id=\"", 3048, "\"", 3067, 1);
#nullable restore
#line 63 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
WriteAttributeValue("", 3053, mesaj.MesajId, 3053, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"MesajSil\">\r\n                            <svg class=\"olymp-little-delete\"><use xlink:href=\"#olymp-little-delete\"></use></svg>\r\n                        </a>\r\n                    </div>\r\n                </li>\r\n");
#nullable restore
#line 68 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n");
#nullable restore
#line 71 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\ArkadasMesajDetay.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    $(document).ready(function () {
        $(""a"").click(function (event) {
            var id = $(this)[0].id;
            if ($(this)[0].name === ""MesajSil"") {
                MesajSil(id);
            }
        });

    });

    function MesajSil(id) {
        $.ajax({
            url: ""/Arkadas/MesajSil"",
            type: ""POST"",
            data: { ""mesajId"": id },
            success: function (data) {
                if (data.Type == 2) {
                    location.reload();
                }
                else {
                    var alici = $('#AliciId');
                    alicId = alici.text();
                    $.ajax({
                        url: ""/Arkadas/MesajDetayGetir"",
                        type: ""POST"",
                        data: { ""gonderenKullaniciId"": alicId },
                        success: function (data) {
                            if (data == false) {
                                location.reload();
                      ");
            WriteLiteral(@"      }
                            else {
                                var modelCount = $(data).filter('#ToplamMesajSayisi').text();

                                if (parseInt(modelCount) > 0) {
                                    var middleContent = $('#MesajDetayContainer');
                                    middleContent.html('');
                                    middleContent.html(data);
                                    $('#MesajScroll').scrollTop($('#MesajScroll')[0].scrollHeight);
                                    $('#MesajBox').removeAttr('hidden');
                                }
                                else {
                                    var middleContent = $('#middleContent');
                                    middleContent.html('');
                                    $('#middleContent').html(data);
                                }
                            }
                        },
                        error: function (XMLHttpRequest, ");
            WriteLiteral(@"textStatus, errorThrown) {
                            console.log(""hata!"");
                        }
                    });
                }                
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(""hata!"");
            }
        });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NeSever.Common.Models.FrontEnd.MesajlarVM> Html { get; private set; }
    }
}
#pragma warning restore 1591