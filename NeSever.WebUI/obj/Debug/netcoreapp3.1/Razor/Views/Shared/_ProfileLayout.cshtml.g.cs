#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba95563890d144f6a5ed63ca6fd869501dc43c40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProfileLayout), @"mvc.1.0.view", @"/Views/Shared/_ProfileLayout.cshtml")]
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
#line 2 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
using NeSever.Common.Models.Uyelik;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba95563890d144f6a5ed63ca6fd869501dc43c40", @"/Views/Shared/_ProfileLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProfileLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
  
    ViewData["Title"] = "_ProfileLayout";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var uye = ViewBag.Uye as NeSever.Common.Models.FrontEnd.UyeVM;
    var sayfaDurum = ViewBag.SayfaDurum;
    var controller = @ViewContext.RouteData.Values["Controller"].ToString();
    var action = @ViewContext.RouteData.Values["Action"].ToString();

    KullaniciVM kullaniciBilgileri = new KullaniciVM();

    if (Context.Session.GetString("Kullanici") != null && Context.Session.GetString("KullaniciBilgileri") != null)
    {
        kullaniciBilgileri = Newtonsoft.Json.JsonConvert.DeserializeObject<KullaniciVM>(Context.Session.GetString("KullaniciBilgileri"));
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style type=""text/css"">
    .bootstrap-select {
        width: 100%;
    }
</style>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-ajax-unobtrusive/3.2.6/jquery.unobtrusive-ajax.min.js"" integrity=""sha512-DedNBWPF0hLGUPNbCYfj8qjlEnNE92Fqn7xd3Sscfu7ipy7Zu33unHdugqRD3c4Vj7/yLv+slqZhMls/4Oc7Zg=="" crossorigin=""anonymous""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.12.2/js/bootstrap-select.min.js""></script>

<script type=""text/javascript"">
    $(document.body).removeClass('body-bg-white');
</script>

");
#nullable restore
#line 32 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
 if (string.IsNullOrEmpty(sayfaDurum))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container"">
        <div class=""row"">
            <div class=""col col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
                <div class=""ui-block"">
                    <div class=""top-header"">
                        <div class=""top-header-thumb"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 1690, "\"", 1717, 1);
#nullable restore
#line 40 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 1696, uye.DuvarResimBase64, 1696, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                        </div>
                        <div class=""profile-section"">
                            <div class=""row"">
                                <div class=""col col-lg-5 col-md-5 col-sm-12 col-12"">
                                    <ul class=""profile-menu"">
");
#nullable restore
#line 46 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                         if (uye.ArkadasProfil)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li>\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 2212, "\"", 2254, 2);
            WriteAttributeValue("", 2219, "/Kullanici/Profil/", 2219, 18, true);
#nullable restore
#line 49 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 2237, uye.KullaniciAdi, 2237, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2255, "\"", 2300, 1);
#nullable restore
#line 49 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 2263, action == "Profil" ? "active" : "", 2263, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Profil</a>\r\n                                            </li>\r\n");
#nullable restore
#line 51 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li>\r\n                                                <a href=\"/Kullanici/Profil\"");
            BeginWriteAttribute("class", " class=\"", 2622, "\"", 2667, 1);
#nullable restore
#line 55 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 2630, action == "Profil" ? "active" : "", 2630, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Profil</a>\r\n                                            </li>\r\n");
#nullable restore
#line 57 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                         if (!uye.ArkadasProfil)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li>\r\n                                                <a href=\"/Kullanici/Arkadaslar\"");
            BeginWriteAttribute("class", " class=\"", 3013, "\"", 3062, 1);
#nullable restore
#line 61 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 3021, action == "Arkadaslar" ? "active" : "", 3021, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Arkadaşlar</a>\r\n                                            </li>\r\n");
#nullable restore
#line 63 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </ul>\r\n                                </div>\r\n                                <div class=\"col col-lg-5 ml-auto col-md-5 col-sm-12 col-12\">\r\n                                    <ul class=\"profile-menu\">\r\n");
#nullable restore
#line 68 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                         if (!uye.ArkadasProfil)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li>\r\n                                                <a href=\"/Kullanici/Fotograflar\"");
            BeginWriteAttribute("class", " class=\"", 3653, "\"", 3703, 1);
#nullable restore
#line 71 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 3661, action == "Fotograflar" ? "active" : "", 3661, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Fotoğraflar</a>\r\n                                            </li>\r\n                                            <li>\r\n                                                <a href=\"/Kullanici/Ayarlar\"");
            BeginWriteAttribute("class", " class=\"", 3899, "\"", 3950, 1);
#nullable restore
#line 74 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 3907, action == "Ayarlar" ? "active" : "false", 3907, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Ayarlar</a>\r\n                                            </li>\r\n");
#nullable restore
#line 76 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                         if (uye.ArkadasProfil && !uye.DisKullanici)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <li>
                                                <div class=""more"">
                                                    <svg class=""olymp-three-dots-icon""><use xlink:href=""#olymp-three-dots-icon""></use></svg>
                                                    <ul class=""more-dropdown more-with-triangle"">
                                                        <li>
                                                            <a href=""javascript:;"" onclick=""profilSikayet();"">Profili Şikayet Et</a>
                                                        </li>
                                                        <li>
                                                            <a href=""javascript:;"" onclick=""profilEngel();"">Profili Engelle</a>
                                                        </li>
                                                    </ul>
                                                </div>
                                     ");
            WriteLiteral("       </li>\r\n");
#nullable restore
#line 92 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </ul>\r\n                                </div>\r\n                            </div>\r\n\r\n                            <div class=\"control-block-button\">\r\n");
#nullable restore
#line 98 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                 if (uye.ArkadasProfil && !uye.KullaniciArkadasiMi && uye.ArkadasIstekTalepleriDurum != 2)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5671, "\"", 5725, 3);
            WriteAttributeValue("", 5681, "profilArkadaslikTalepEt(\'", 5681, 25, true);
#nullable restore
#line 100 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 5706, uye.KullaniciId, 5706, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5722, "\');", 5722, 3, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-control bg-blue"" title=""Arkadaşlık Talebi Gönder"">
                                        <svg class=""olymp-happy-face-icon"">
                                            <use xlink:href=""#olymp-happy-face-icon"" xlink:title=""Arkadaşlık Talebi Gönder"">
                                                <title>Arkadaşlık Talebi Gönder</title>
                                            </use>
                                        </svg>
                                    </a>
");
#nullable restore
#line 107 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6317, "\"", 6372, 3);
            WriteAttributeValue("", 6327, "profilArkadasMesajGonder(\'", 6327, 26, true);
#nullable restore
#line 108 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 6353, uye.KullaniciId, 6353, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6369, "\');", 6369, 3, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-control bg-purple"">
                                    <svg class=""olymp-chat---messages-icon""><use xlink:href=""#olymp-chat---messages-icon""></use></svg>
                                </a>
                            </div>
                        </div>
                        <div class=""top-header-author"">
");
#nullable restore
#line 114 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                             if (uye.ArkadasProfil)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6847, "\"", 6913, 3);
            WriteAttributeValue("", 6857, "kullaniciBuyukProfilResimModalGetir(\'", 6857, 37, true);
#nullable restore
#line 116 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 6894, uye.KullaniciId, 6894, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6910, "\');", 6910, 3, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"author-thumb\" style=\"width:inherit;height:inherit;\">\r\n                                    <img alt=\"author\"");
            BeginWriteAttribute("src", " src=\"", 7029, "\"", 7060, 1);
#nullable restore
#line 117 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 7035, uye.KullaniciResimBase64, 7035, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"avatar\" style=\"max-width:120px;max-height:120px;\" />\r\n                                </a>\r\n                                <div class=\"author-content\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 7261, "\"", 7303, 2);
            WriteAttributeValue("", 7268, "/Kullanici/Profil/", 7268, 18, true);
#nullable restore
#line 120 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 7286, uye.KullaniciAdi, 7286, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"h4 author-name\">");
#nullable restore
#line 120 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                                                                                    Write(uye.KullaniciAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    <div class=\"country\">");
#nullable restore
#line 121 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                                    Write(uye.Sehir);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 121 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                                                Write(uye.Ulke);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                </div>\r\n");
#nullable restore
#line 123 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 7627, "\"", 7693, 3);
            WriteAttributeValue("", 7637, "kullaniciBuyukProfilResimModalGetir(\'", 7637, 37, true);
#nullable restore
#line 126 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 7674, uye.KullaniciId, 7674, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7690, "\');", 7690, 3, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"author-thumb\" style=\"width:inherit;height:inherit;\">\r\n                                    <img alt=\"author\"");
            BeginWriteAttribute("src", " src=\"", 7809, "\"", 7840, 1);
#nullable restore
#line 127 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 7815, uye.KullaniciResimBase64, 7815, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"avatar\" style=\"max-width:120px;max-height:120px;\" />\r\n                                </a>\r\n                                <div class=\"author-content\">\r\n                                    <a href=\"javascript:;\" class=\"h4 author-name\">");
#nullable restore
#line 130 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                                                             Write(uye.KullaniciAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>&nbsp;<a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 8134, "\"", 8192, 3);
            WriteAttributeValue("", 8144, "profilKullaniciAdiDegistir(\'", 8144, 28, true);
#nullable restore
#line 130 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
WriteAttributeValue("", 8172, uye.KullaniciAdi, 8172, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8189, "\');", 8189, 3, true);
            EndWriteAttribute();
            WriteLiteral("><svg style=\"max-height:20px;max-width:20px;\" class=\"olymp-speech-balloon-icon\"><use xlink:href=\"#olymp-speech-balloon-icon\"></use></svg></a>\r\n                                    <div class=\"country\">");
#nullable restore
#line 131 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                                    Write(uye.Sehir);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 131 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                                                Write(uye.Ulke);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                </div>\r\n");
#nullable restore
#line 133 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""modal fade"" id=""MesajGonder"" role=""dialog"" aria-labelledby=""fav-page-popup"" aria-hidden=""true"">
        <div class=""modal-dialog window-popup fav-page-popup"" role=""document"">
            <div class=""modal-content"">
                <a href=""#"" class=""close icon-close"" data-dismiss=""modal"" aria-label=""Close"">
                    <svg class=""olymp-close-icon""><use xlink:href=""#olymp-close-icon""></use></svg>
                </a>
                <div class=""modal-header"">
                    <h6 class=""title"">Mesaj Gönder</h6>
                </div>

                <div id=""MesajGonderModalBody"" class=""modal-body"">
                </div>
            </div>
        </div>
    </div>
");
            WriteLiteral(@"    <div class=""modal fade"" id=""KullaniciAdiDegistir"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <a href=""#"" class=""close icon-close"" data-dismiss=""modal"" aria-label=""Close"">
                    <svg class=""olymp-close-icon""><use xlink:href=""#olymp-close-icon""></use></svg>
                </a>
                <div id=""KullaniciAdiDegistirModalBody"" class=""modal-body"">

                </div>
            </div>
        </div>
    </div>
");
            WriteLiteral("    <div class=\"container\">\r\n        ");
#nullable restore
#line 171 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
   Write(RenderSection("Content", required: true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div id=\"ProfilFotografPartialGetir\"></div>\r\n");
            WriteLiteral(@"    <script type=""text/javascript"">

    var fotoAcildiMi = false;
    function kullaniciBuyukProfilResimModalGetir(id) {       
        if (fotoAcildiMi == false) {
            fotoAcildiMi = true;
            $.ajax({
                url: ""/Kullanici/BuyukProfilFotografPartial"",
                type: ""POST"",
                data: { ""kullaniciId"": id },
                success: function (data) {
                    if (data == false) {
                        location.reload();
                    }
                    else {
                        var middleContent = $('#ProfilFotografPartialGetir');
                        middleContent.html('');
                        middleContent.html(data);
                        $('#buyuk-profile-photo').modal('show');
                    }

                    fotoAcildiMi = false;
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    fotoAcildiMi = false;

                    c");
            WriteLiteral("onsole.log(\"hata!\");\r\n                    console.log(textStatus);\r\n                    console.log(errorThrown);\r\n                }\r\n            });\r\n        }        \r\n    }\r\n\r\n    function profilArkadaslikTalepEt(id) {\r\n        if (\'");
#nullable restore
#line 210 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
        Write(kullaniciBilgileri.KullaniciAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' == \'");
#nullable restore
#line 210 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                              Write(uye.KullaniciAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"') {
                Swal.fire({
                    title: '',
                    text: ""Kendi profiline talep gönderemezsin!"",
                    icon: 'warning',
                    confirmButtonText: ""Tamam""
                });
        }
        else {
            if ('");
#nullable restore
#line 219 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
            Write(uye.DisKullanici);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' == 'True') {
                $('#loginlink').modal('show');
            }
            else {
                $.ajax({
                    url: ""/Arkadas/ProfilArkadasEkle"",
                    type: ""POST"",
                    dataType: 'json',
                    data: { ""kullaniciId"": id },
                    success: function (data) {
                        if (data == false) {
                            ShowModal();
                        }
                        else if (data.Data == false && data.ErrorMessage == ""istekVar"") {

                            Swal.fire({
                                title: '',
                                text: ""Zaten arkadaşlık isteği gönderdiniz."",
                                icon: 'warning',
                                confirmButtonColor: '#d33',
                                cancelButtonColor: '#3085d6',
                            })
                        }
                        else if (data.Data == false && data.ErrorM");
            WriteLiteral(@"essage == ""arkadaslikVar"") {
                            Swal.fire({
                                title: '',
                                text: ""Zaten arkadaşsınız."",
                                icon: 'warning',
                                confirmButtonColor: '#d33',
                                cancelButtonColor: '#3085d6',
                            })
                        }
                        else if (data.Data == false && data.ErrorMessage == ""banaIstekVar"") {
                            Swal.fire({
                                title: '',
                                text: ""Zaten size arkadaşlık isteği var."",
                                icon: 'warning',
                                confirmButtonColor: '#d33',
                                cancelButtonColor: '#3085d6',
                            })
                        }
                        else if (data.Data == false && data.ErrorMessage == ""ArkadasiminArkadasiDegil"") {
                  ");
            WriteLiteral(@"          Swal.fire({
                                title: '',
                                text: ""Sadece Arkadaşlarının Arkadaşları İstek Yollayabilir!"",
                                icon: 'warning',
                                confirmButtonColor: '#d33',
                                cancelButtonColor: '#3085d6',
                                confirmButtonText: ""Tamam"",
                            })
                        }
                        else {
                            Swal.fire({
                                title: '',
                                text: ""İstek Gönderildi"",
                                icon: 'success',
                                confirmButtonColor: '#d33',
                                cancelButtonColor: '#3085d6',
                            })
                        }

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log(""hata!"");
    ");
            WriteLiteral("                }\r\n                });\r\n            }\r\n        }\r\n    }\r\n\r\n    function profilArkadasMesajGonder(id) {\r\n        if (\'");
#nullable restore
#line 290 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
        Write(uye.DisKullanici);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' == \'True\') {\r\n            if (\'");
#nullable restore
#line 291 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
            Write(kullaniciBilgileri.KullaniciAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' == \'");
#nullable restore
#line 291 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                                  Write(uye.KullaniciAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"') {
                Swal.fire({
                    title: '',
                    text: ""Kendi profiline mesaj gönderemezsin!"",
                    icon: 'warning',
                    confirmButtonText: ""Tamam""
                });
            }
            else {
                $('#loginlink').modal('show');
            }
        }
        else {
            $.ajax({
                url: ""/Arkadas/ArkadasAraMesajGonder"",
                type: ""POST"",
                data: { ""kullaniciId"": id },
                success: function (data) {
                    if (data == false) {
                        location.reload();
                    }
                    else {
                        $('#MesajGonderModalBody').html(data);
                        $('#MesajGonder').modal('show');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(""hata!"");
                    console.log(textS");
            WriteLiteral("tatus);\r\n                    console.log(errorThrown);\r\n                }\r\n            });\r\n        }\r\n    }\r\n\r\n        function profilSikayet() {\r\n        $.get(\"/Kullanici/ProfilSikayetPartial/\" + \"");
#nullable restore
#line 327 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                               Write(uye.KullaniciId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""", function (data) {
            $('#ProfilSikayetModalBody').html(data);
            $('#ProfilSikayetModal').modal('show');
        });
    };

    function profilEngel(id) {
        Swal.fire({
            title: '',
            text: ""Engellemek istediğine emin misin?"",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, engelle!',
            cancelButtonText: 'Hayır'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: ""/Kullanici/ProfilEngelKaydet"",
                    type: ""POST"",
                    data: { ProfilEngellenenKullaniciId: """);
#nullable restore
#line 346 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
                                                     Write(uye.KullaniciId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" },
                    success: function (data) {
                        if (data.error == true && data.message == ""Bu Profil Zaten Engel Listenizde"") {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Uyarı!',
                                text: data.message,
                                confirmButtonText: ""Tamam""
                            });
                        }
                        else if (data.error == true) {
                            Swal.fire({
                                icon: 'error',
                                title: 'Hata!',
                                text: data.message,
                                confirmButtonText: ""Tamam""
                            });
                        }
                        else {
                            Swal.fire({
                                icon: 'success',
                                title: 'Başarılı!',
        ");
            WriteLiteral(@"                        text: ""Seçtiğiniz kişi engellenmiştir."",
                                confirmButtonText: ""Tamam""
                            });
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log(""hata!"");
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
            }
        })
    };
    function profilKullaniciAdiDegistir(kullaniciAdi) {
        $.ajax({
            url: ""/Kullanici/KullaniciAdiModalPartial"",
            type: ""GET"",
            data: { ""kullaniciAdi"": kullaniciAdi },
            success: function (data) {
                $('#KullaniciAdiDegistirModalBody').html(data);
                $('#KullaniciAdiDegistir').modal('show');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(""hata!"");
   ");
            WriteLiteral("             console.log(textStatus);\r\n                console.log(errorThrown);\r\n            }\r\n        });\r\n    }\r\n\r\n    function fotografSec() {\r\n        var url = \'");
#nullable restore
#line 400 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
              Write(Url.Action("FotografListele", "Kullanici"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        $(\"#fotografListe\").load(url);\r\n    };\r\n\r\n    </script>\r\n");
#nullable restore
#line 405 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n        ");
#nullable restore
#line 409 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
   Write(RenderSection("Content", required: true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 411 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Shared\_ProfileLayout.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
