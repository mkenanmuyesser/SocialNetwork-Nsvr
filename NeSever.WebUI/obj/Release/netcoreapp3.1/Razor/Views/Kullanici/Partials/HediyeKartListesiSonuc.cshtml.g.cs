#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de366b73e1a358930a6ffa07f9287355b8e29ad2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kullanici_Partials_HediyeKartListesiSonuc), @"mvc.1.0.view", @"/Views/Kullanici/Partials/HediyeKartListesiSonuc.cshtml")]
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
#nullable restore
#line 4 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
using NeSever.Common.Models.FrontEnd;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de366b73e1a358930a6ffa07f9287355b8e29ad2", @"/Views/Kullanici/Partials/HediyeKartListesiSonuc.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Kullanici_Partials_HediyeKartListesiSonuc : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<NeSever.Common.Models.Uyelik.HediyeKartKonusmaListesiVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
  
    ProfilVM profil = new ProfilVM();

    if (Context.Session.GetString("ArkadasProfil") != null)
    {
        profil = Newtonsoft.Json.JsonConvert.DeserializeObject<ProfilVM>(Context.Session.GetString("ArkadasProfil"));
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<style type=\"text/css\">\r\n    .olymp-little-delete {\r\n        width: 12px;\r\n        height: 12px;\r\n    }\r\n</style>\r\n\r\n\r\n<div id=\"ToplamMesajSayisi\" hidden>0</div>\r\n<div class=\"row\">\r\n    <div id=\"AliciId\" hidden></div>\r\n");
#nullable restore
#line 26 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
     if (!Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 align-center pb80 pt80\">\r\n            <p>\r\n                <h3>Hediye Kart Listeniz Boş</h3>\r\n            </p>\r\n        </div>\r\n");
#nullable restore
#line 33 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col col-xl-5 col-lg-6 col-md-12 col-sm-12 col-12 padding-r-0\">\r\n            <ul class=\"notification-list chat-message\">\r\n");
#nullable restore
#line 38 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                 foreach (var mesaj in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>\r\n                    <div class=\"author-thumb\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1193, "\"", 1223, 1);
#nullable restore
#line 42 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
WriteAttributeValue("", 1199, mesaj.ProfilResmiBase64, 1199, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"author\" style=\"max-height:16px; max-height:16px;\">\r\n                    </div>\r\n                    <div class=\"notification-event\">\r\n");
#nullable restore
#line 45 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                         if (mesaj.OkunduMu)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a href=\"javascript:;\"");
            BeginWriteAttribute("id", " id=\"", 1487, "\"", 1510, 1);
#nullable restore
#line 47 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
WriteAttributeValue("", 1492, mesaj.KullaniciId, 1492, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"MesajDetay\" class=\"h6 notification-friend\" style=\"font-weight:400\">");
#nullable restore
#line 47 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                                                                                                                                               Write(mesaj.Adi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 47 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                                                                                                                                                          Write(mesaj.Soyadi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 48 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a href=\"javascript:;\"");
            BeginWriteAttribute("id", " id=\"", 1749, "\"", 1772, 1);
#nullable restore
#line 51 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
WriteAttributeValue("", 1754, mesaj.KullaniciId, 1754, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"MesajDetay\" class=\"h6 notification-friend\">");
#nullable restore
#line 51 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                                                                                                                       Write(mesaj.Adi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 51 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                                                                                                                                  Write(mesaj.Soyadi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 52 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"chat-message-item\">");
#nullable restore
#line 53 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                                                   Write(mesaj.Aciklama);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ...</span>\r\n                        <span class=\"notification-date\"><time class=\"entry-date updated\">");
#nullable restore
#line 54 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                                                                                    Write(mesaj.SonKonusmaTarihi.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</time></span>\r\n                    </div>\r\n                    <span class=\"notification-icon\">\r\n                        <a href=\"javascript:;\"");
            BeginWriteAttribute("id", " id=\"", 2249, "\"", 2272, 1);
#nullable restore
#line 57 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
WriteAttributeValue("", 2254, mesaj.KullaniciId, 2254, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""MesajDetay"">
                            <svg class=""olymp-chat---messages-icon""><use xlink:href=""#olymp-chat---messages-icon""></use></svg>
                        </a>
                    </span>
                    <div class=""more"" style=""opacity:50 !important"">
                        <a href=""javascript:;""");
            BeginWriteAttribute("id", " id=\"", 2597, "\"", 2620, 1);
#nullable restore
#line 62 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
WriteAttributeValue("", 2602, mesaj.KullaniciId, 2602, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"KonusmaSil\">\r\n                            <svg class=\"olymp-little-delete\"><use xlink:href=\"#olymp-little-delete\"></use></svg>\r\n                        </a>\r\n                    </div>\r\n                </li>\r\n");
#nullable restore
#line 67 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"col col-xl-7 col-lg-6 col-md-12 col-sm-12 col-12 padding-l-0\">\r\n            <div class=\"chat-field\">\r\n                <div id=\"MesajDetayContainer\">\r\n\r\n                </div>\r\n            </div>\r\n      \r\n        </div>\r\n");
#nullable restore
#line 79 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 100 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
 if (Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <nav aria-label=\"Page navigation\">\r\n        ");
#nullable restore
#line 103 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
   Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("HediyeKartiPartial", new
        {
            p = page,
            q = Context.Request.Query["q"],
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
            WriteLiteral("\r\n    </nav>\r\n");
#nullable restore
#line 133 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\HediyeKartListesiSonuc.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""/js/ajax-bootstrap-select.js""></script>
<script src=""/js/ajax-bootstrap-select.tr-TR.js""></script>
<script>

    $(document).ready(function () {

        $.ajax({
            url: ""/Kullanici/MenuDegerleri"",
            type: ""POST"",
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success: function (data) {
                if (data == false) {
                    location.reload();
                }

                $('#ArkadasSayisi').text(""("" + data.ArkadasSayisi + "")"");
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(""hata!"");
            }
        });

        var options = {
            ajax: {
                url: '/Arkadas/ArkadasAra',
                dataType: 'json',
                data: {
                    query: '{{{q}}}'
                }
            },
            locale: {
                emptyTitle: 'Arkadaş Ara");
            WriteLiteral(@"...'
            },
            log: 3,
            preprocessData: function (data) {
                var i, l = data.length, array = [];
                if (l) {
                    for (i = 0; i < l; i++) {
                        array.push($.extend(true, data[i], {
                            text: data[i].Adi + "" "" + data[i].Soyadi,
                            value: data[i].ArkadasKullaniciId
                        }));
                    }
                }

                return array;
            }
        };

        $("".selectpicker"")
            .selectpicker()
            .filter("".with-ajax"")
            .ajaxSelectPicker(options);
        $(""select"").trigger(""change"");



        $(""a"").click(function (event) {
            var clickedItem = $(this);
            var id = $(this)[0].id;
            if (id.length) {
                $('#AliciId').text(id);
            }
            if ($(this)[0].name === ""MesajDetay"") {
                document.getElementById(id");
            WriteLiteral(@").style.fontWeight = 400;
                MesajlarListesiPartialGetir(id);
            }

            if ($(this)[0].name === ""KonusmaSil"") {

                KonusmaSil(id);

            }

        });

        //document.addEventListener(""keypress"", function onEvent(event) {
        //    if (event.key === ""Enter"") {
        //        MesajGonder();
        //    }
        //});
    });


    function MesajYenile() {
        var alici = $('#AliciId');

        if (alici != null) {
            var id = alici.text();
            MesajlarListesiPartialGetir(id);
        }
    }

    function KonusmaSil(id) {
        $.ajax({
            url: ""/Arkadas/HediyeKartKonusmaSil"",
            type: ""POST"",
            data: { ""gonderenKullaniciId"": id },
            success: function (data) {
                if (data.ErrorMessage != null) {
                    var hediyeKartSayisi = $('#hediyeKartiSayi').html();
                    var hediyeKartSayisiInt = parseInt(hediyeKartSayi");
            WriteLiteral(@"si);
                    var silinenHediyeKartSayisi = parseInt(data.ErrorMessage);
                    hediyeKartSayisiInt -= silinenHediyeKartSayisi;
                    $('#hediyeKartiSayi').html(hediyeKartSayisiInt);
                    $('#hediyeKartiSayiMobil').html(hediyeKartSayisiInt);                 
                }
                $.ajax({
                    url: ""/Kullanici/HediyeKartiPartial/?q="",
                    type: 'GET',
                    cache: false,
                    success: function (result) {
                        var middleContent = $('#middleContent');
                        middleContent.html('');
                        $('#middleContent').html(result);
                    }
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(""hata!"");
            }
        });
    }

    function MesajlarListesiPartialGetir(id) {
        $.ajax({
            url: ""/Arkadas/Hedi");
            WriteLiteral(@"yeKartDetayGetir"",
            type: ""POST"",
            data: { ""gonderenKullaniciId"": id },
            success: function (data) {
                var middleContent = $('#MesajDetayContainer');
                middleContent.html('');
                middleContent.html(data);
                $('#MesajScroll').scrollTop($('#MesajScroll')[0].scrollHeight);
                $('#MesajBox').removeAttr('hidden');
                $.ajax({
                    url: ""/Arkadas/HediyeKartOkunduIsaretle"",
                    type: ""POST"",
                    data: { ""gonderenKullaniciId"": id },
                    success: function (data) {
                        var hediyeKartSayisi = $('#hediyeKartiSayi').html();
                        var hediyeKartSayisiInt = parseInt(hediyeKartSayisi);
                        hediyeKartSayisiInt -= data;
                        $('#hediyeKartiSayi').html(hediyeKartSayisiInt);
                        $('#hediyeKartiSayiMobil').html(hediyeKartSayisiInt); 
         ");
            WriteLiteral(@"           },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log(""hata!"");
                    }
                });
                
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(""hata!"");
            }
        });
    }

</script>

<script>

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
        $(""#targetElement"").html(""<strong>İşlem sırasında bir hata oluştu:"" + error + ""<br />.</strong>"");
    }

</script>

");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<NeSever.Common.Models.Uyelik.HediyeKartKonusmaListesiVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
