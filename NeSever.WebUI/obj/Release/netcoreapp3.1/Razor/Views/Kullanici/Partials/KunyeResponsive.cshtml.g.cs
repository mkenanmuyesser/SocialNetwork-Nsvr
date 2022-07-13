#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e70c1d9a5bfd6068de3ece668b803a82b09a1012"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kullanici_Partials_KunyeResponsive), @"mvc.1.0.view", @"/Views/Kullanici/Partials/KunyeResponsive.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e70c1d9a5bfd6068de3ece668b803a82b09a1012", @"/Views/Kullanici/Partials/KunyeResponsive.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Kullanici_Partials_KunyeResponsive : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NeSever.Common.Models.FrontEnd.ProfilSolMenuVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"profile-settings-responsive\">\r\n    <a href=\"javascript:;\" ");
            WriteLiteral(@" class=""js-profile-settings-open profile-settings-open"" style=""z-index:2000;"">
        <i class=""fa fa-angle-right"" aria-hidden=""true""></i>
        <i class=""fa fa-angle-left"" aria-hidden=""true""></i>
    </a>
    <div class=""mCustomScrollbar"" data-mcs-theme=""dark"">
        <div class=""ui-block"">
            <div class=""your-profile"">
                <div class=""ui-block-title ui-block-title-small"">
                    <h6 class=""title"">PROFİL</h6>
                </div>

                <div id=""accordion"" role=""tablist"" aria-multiselectable=""false"">
                    <div class=""card"">
                        <div class=""card-header"" role=""tab"" id=""headingOne"">
                            <h6 class=""mb-0"">
                                Kişisel Bilgiler
                            </h6>
                        </div>

                        <div id=""collapseOne"" class=""collapse show"" aria-labelledby=""headingOne"" data-parent=""#accordion"">
                            <div class=""ui-bloc");
            WriteLiteral("k-content\" style=\"padding: 0px 23px 0px 24px;\">\r\n                                <ul class=\"widget w-personal-info item-block\">\r\n");
#nullable restore
#line 26 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                     if (Model.KisiselBilgiGosterimDurum)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li style=\"padding: 5px 0;\">\r\n                                            <span class=\"title\">Hakkında:</span>\r\n");
#nullable restore
#line 30 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                             if (string.IsNullOrEmpty(Model.Hakkinda))
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"text\">Henüz Belirtilmemiş</span>\r\n");
#nullable restore
#line 33 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                            }
                                            else
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                 if (Model.Hakkinda.Count() > 100)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">\r\n                                                        ");
#nullable restore
#line 39 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                   Write(Model.Hakkinda.Substring(0, 97).Insert(97, "..."));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </span>\r\n");
#nullable restore
#line 41 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">\r\n                                                        ");
#nullable restore
#line 45 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                   Write(Model.Hakkinda);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </span>\r\n");
#nullable restore
#line 47 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                 
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </li>
                                        <li style=""padding: 5px 0;"">
                                            <span class=""title"">Yaşadığı Yer:</span>
                                            <span class=""text"">");
#nullable restore
#line 52 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                          Write(Model.Sehir);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 52 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                        Write(Model.Ulke);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        </li>\r\n");
            WriteLiteral("                                        <li style=\"padding: 5px 0;\">\r\n                                            <span class=\"title\">İlişki Durumu:</span>\r\n");
#nullable restore
#line 57 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                             switch (Model.IliskiDurumu)
                                            {
                                                default:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Belirtmek İstemiyorum</span>\r\n");
#nullable restore
#line 61 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "BI":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Belirtmek İstemiyor</span>\r\n");
#nullable restore
#line 64 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "B":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Bekar</span>\r\n");
#nullable restore
#line 67 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "E":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Evli</span>\r\n");
#nullable restore
#line 70 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "N":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Nişanlı</span>\r\n");
#nullable restore
#line 73 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "S":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Sözlü</span>\r\n");
#nullable restore
#line 76 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "YCM":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Yalnız Çok Mutlu</span>\r\n");
#nullable restore
#line 79 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "AA":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Arkadaş Arıyor</span>\r\n");
#nullable restore
#line 82 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "IV":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">İlişkisi Var</span>\r\n");
#nullable restore
#line 85 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "G":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Gizli</span>\r\n");
#nullable restore
#line 88 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </li>\r\n                                        <li style=\"padding: 5px 0;\">\r\n                                            <span class=\"title\">Cinsiyet:</span>\r\n");
#nullable restore
#line 93 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                             switch (Model.Cinsiyet)
                                            {
                                                case "G":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Gizli</span>\r\n");
#nullable restore
#line 97 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "E":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Erkek</span>\r\n");
#nullable restore
#line 100 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                case "K":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Kadın</span>\r\n");
#nullable restore
#line 103 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                                default:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text\">Belirtmek İstemiyorum</span>\r\n");
#nullable restore
#line 106 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                    break;
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </li>\r\n                                        <li style=\"padding: 5px 0;\">\r\n                                            <span class=\"title\">Doğum Tarihi:</span>\r\n");
#nullable restore
#line 111 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                             if (Model.DogumTarihi.HasValue)
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 113 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                 switch (Model.DogumTarihi.Value.Month)
                                                {
                                                    case 1:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 116 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Ocak</span>\r\n");
#nullable restore
#line 117 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 2:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 119 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Şubat</span>\r\n");
#nullable restore
#line 120 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 3:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 122 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Mart</span>\r\n");
#nullable restore
#line 123 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 4:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 125 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Nisan</span>\r\n");
#nullable restore
#line 126 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 5:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 128 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Mayıs</span>\r\n");
#nullable restore
#line 129 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 6:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 131 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Haziran</span>\r\n");
#nullable restore
#line 132 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 7:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 134 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Temmuz</span>\r\n");
#nullable restore
#line 135 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 8:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 137 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Ağustos</span>\r\n");
#nullable restore
#line 138 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 9:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 140 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Eylül</span>\r\n");
#nullable restore
#line 141 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 10:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 143 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Ekim</span>\r\n");
#nullable restore
#line 144 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 11:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 146 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Kasım</span>\r\n");
#nullable restore
#line 147 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    case 12:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text\">");
#nullable restore
#line 149 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                      Write(Model.DogumTarihi.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Aralık</span>\r\n");
#nullable restore
#line 150 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                        break;
                                                    default:
                                                        break;
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 153 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                 
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"text\">Gizli</span>\r\n");
#nullable restore
#line 158 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </li>\r\n");
#nullable restore
#line 161 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li style=\"padding: 5px 0;\">\r\n                                            <span class=\"text\">Gizli</span>\r\n                                        </li>\r\n");
#nullable restore
#line 167 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </ul>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=""ui-block-title"">
                    <div class=""sharethis-inline-share-buttons"" data-url=""https://www.nesever.com.tr/Kullanici/Profil/");
#nullable restore
#line 175 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                                                                 Write(Model.KullaniciAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-title=\"NeSever.com.tr\"></div>\r\n                </div>\r\n\r\n");
            WriteLiteral(@"
                <div class=""ui-block-title"">
                    <a href=""javascript:"" name=""hediyeSepeti"" class=""h6 title"">Hediye Sepeti</a>
                    <a href=""javascript:"" name=""hediyeSepeti"" id=""hediyeSepetiSayiMobil"" class=""items-round-little bg-breez"">");
#nullable restore
#line 193 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                                                                        Write(Model.HediyeSepetiSayi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </div>\r\n\r\n");
#nullable restore
#line 196 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                 if (!Model.ArkadasProfil)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""ui-block-title"">
                        <a href=""javascript:"" name=""indirimKuponlari"" class=""h6 title"">İndirim Kuponları</a>
                        <a href=""javascript:"" name=""indirimKuponlari"" id=""indirimKuponSayi"" class=""items-round-little bg-red"">");
#nullable restore
#line 200 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                                                                         Write(Model.IndirimKuponuSayisi);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                    </div>
                    <div class=""ui-block-title"">
                        <a href=""javascript:"" name=""mesajlar"" class=""h6 title"">Mesajlar</a>
                        <a href=""javascript:"" name=""mesajlar"" id=""mesajKutusuSayiMobil"" class=""items-round-little bg-dribbble"">");
#nullable restore
#line 204 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                                                                          Write(Model.MesajSayi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </div>\r\n");
            WriteLiteral(@"                    <div class=""ui-block-title"">
                        <a href=""javascript:"" name=""bildirimler"" class=""h6 title"">Bildirimler</a>
                        <a href=""javascript:"" name=""bildirimler"" id=""profilMobilBildirimSayisi"" class=""items-round-little bg-primary"">");
#nullable restore
#line 212 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                                                                                 Write(Model.BildirimSayi);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                    </div>
                    <div class=""ui-block-title"">
                        <a href=""javascript:"" name=""arkadaslikIstekleri"" class=""h6 title"">Arkadaşlık İstekleri</a>
                        <a href=""javascript:"" name=""arkadaslikIstekleri"" id=""arkadaslikIstekleriSayiMobil"" class=""items-round-little bg-blue"">");
#nullable restore
#line 216 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                                                                                         Write(Model.ArkadasIstekSayi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </div>\r\n");
#nullable restore
#line 218 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                <div class=""ui-block-title"">
                    <a data-toggle=""modal"" data-target=""#create-friend-group-add-friends"" href=""#"" class=""h6 title"">Arkadaşlar</a>
                    <a data-toggle=""modal"" data-target=""#create-friend-group-add-friends"" href=""#"" class=""items-round-little bg-red"">");
#nullable restore
#line 222 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                                                                                Write(Model.ArkadasSayi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </div>\r\n\r\n");
#nullable restore
#line 225 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                 if (Model.ArkadasProfil)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"ui-block-title\">\r\n                        <a href=\"javascript:;\" onclick=\"history.go(-1);\" class=\"btn btn-primary btn-sm full-width\">");
#nullable restore
#line 228 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                                                                                                              Write(Html.Raw("<= Geri Dön"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </div>\r\n");
#nullable restore
#line 230 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\KunyeResponsive.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""create-friend-group-add-friends"" tabindex=""-1"" role=""dialog"" aria-labelledby=""create-friend-group-add-friends"" aria-hidden=""true"">
    <div class=""modal-dialog window-popup create-friend-group create-friend-group-add-friends"" role=""document"">
        <div class=""modal-content"">
            <a href=""#"" class=""close icon-close"" data-dismiss=""modal"" aria-label=""Close"">
                <svg class=""olymp-close-icon""><use xlink:href=""#olymp-close-icon""></use></svg>
            </a>

            <div class=""modal-header"">
                <h6 class=""title"">Arkadaş Listesi</h6>
            </div>

            <div class=""modal-body"">
                <div class=""container"">
                    <div class=""row"">
");
            WriteLiteral(@"                    </div>
                </div>

                <div id=""arkadasListesi"">
                </div>
            </div>
        </div>
    </div>
</div>

<script src=""/Themes/FrontEnd/src/js/main.js""></script>
<script type=""text/javascript"">
    /* function bildirimAciksaKapat() {
         document.getElementById(""mobilBildirimKapat"").className = ""nav-link"";
         document.getElementById(""notification"").className = ""tab-pane"";
     }*/
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NeSever.Common.Models.FrontEnd.ProfilSolMenuVM> Html { get; private set; }
    }
}
#pragma warning restore 1591