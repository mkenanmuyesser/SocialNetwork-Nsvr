#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecd08bc18d56b40360599c481701f37ce52ea0f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Arkadas_Partials_ArkadasAramaList), @"mvc.1.0.view", @"/Views/Arkadas/Partials/ArkadasAramaList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecd08bc18d56b40360599c481701f37ce52ea0f0", @"/Views/Arkadas/Partials/ArkadasAramaList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Arkadas_Partials_ArkadasAramaList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<NeSever.Common.Models.Uyelik.ArkadasVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal fade"" id=""MesajGonder"" tabindex=""-1"" role=""dialog"" aria-labelledby=""fav-page-popup"" aria-hidden=""true"">
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

<div class=""row"">
");
#nullable restore
#line 20 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
     if (!Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 align-center pb80 pt80\">\r\n            <p>\r\n                <h3>Aradığınız kişi bulunamadı.</h3>\r\n            </p>\r\n        </div>\r\n");
#nullable restore
#line 27 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
         foreach (var arkadas in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col col-xl-3 col-lg-6 col-md-6 col-sm-6 col-12\">\r\n                <div class=\"ui-block\">\r\n                    <div class=\"friend-item\">\r\n                        <div class=\"friend-header-thumb\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1319, "\"", 1350, 1);
#nullable restore
#line 36 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
WriteAttributeValue("", 1325, arkadas.DuvarResimBase64, 1325, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""friend"" height=""292"" width=""112"" />
                        </div>

                        <div class=""friend-item-content"">
                            <div class=""friend-avatar"">
                                <div class=""author-thumb"" style=""height:auto; width:auto;"">
                                    <a");
            BeginWriteAttribute("id", " id=\"", 1675, "\"", 1701, 1);
#nullable restore
#line 42 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
WriteAttributeValue("", 1680, arkadas.KullaniciAdi, 1680, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"javascript:;\" name=\"ProfileGit\" style=\"cursor:pointer;\">\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 1811, "\"", 1843, 1);
#nullable restore
#line 43 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
WriteAttributeValue("", 1817, arkadas.ProfilResmiBase64, 1817, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""author"" style=""max-height:120px; max-width:120px;"" />
                                    </a>
                                </div>
                                <div class=""author-content"" style="" margin-top: 4%;"">
                                    <a");
            BeginWriteAttribute("id", " id=\"", 2112, "\"", 2138, 1);
#nullable restore
#line 47 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
WriteAttributeValue("", 2117, arkadas.KullaniciAdi, 2117, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"javascript:;\" name=\"ProfileGit\" class=\"h5 author-name\">");
#nullable restore
#line 47 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                                                                                          Write(arkadas.KullaniciAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    <br />\r\n                                    <a");
            BeginWriteAttribute("id", " id=\"", 2310, "\"", 2336, 1);
#nullable restore
#line 49 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
WriteAttributeValue("", 2315, arkadas.KullaniciAdi, 2315, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"javascript:;\" name=\"ProfileGit\" class=\"h5 author-name\">");
#nullable restore
#line 49 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                                                                                          Write(arkadas.Adi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 49 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                                                                                                       Write(arkadas.Soyadi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 50 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                     if (string.IsNullOrEmpty(arkadas.Sehir))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"country\">&nbsp;</div>\r\n");
#nullable restore
#line 53 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"country\">");
#nullable restore
#line 56 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                        Write(arkadas.Sehir);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 57 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>

                            <div class=""swiper-container"" data-slide=""fade"">
                                <div class=""swiper-wrapper"">
                                    <div class=""swiper-slide"">
                                        <div class=""friend-count"" data-swiper-parallax=""-500"">
");
            WriteLiteral("                                            <a class=\"friend-count-item\">\r\n                                                <div class=\"h6\">");
#nullable restore
#line 70 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                           Write(arkadas.HediyeSepetiUrunSayisi);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                                <div class=""title"">Hediye</div>
                                            </a>
                                        </div>
                                        <div class=""control-block-button"" data-swiper-parallax=""-100"">
");
#nullable restore
#line 75 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                             if (arkadas.ArkadasIstekTalepleriDurum == 1 || arkadas.ArkadasIstekTalepleriDurum == 3)
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                 switch (arkadas.ArkadaslikIstekDurum)
                                                {
                                                    default:
                                                    case 0:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <a");
            BeginWriteAttribute("id", " id=\"", 4513, "\"", 4538, 1);
#nullable restore
#line 81 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
WriteAttributeValue("", 4518, arkadas.KullaniciId, 4518, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""ArkadasEkle"" href=""javascript:;"" class=""accept-request"">
                                                            <span class=""icon-add without-text"">
                                                                <svg class=""olymp-happy-face-icon""><use xlink:href=""#olymp-happy-face-icon""></use></svg>
                                                            </span>
                                                        </a>
");
#nullable restore
#line 86 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                        break;
                                                    case 1:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <a");
            BeginWriteAttribute("id", " id=\"", 5170, "\"", 5195, 1);
#nullable restore
#line 88 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
WriteAttributeValue("", 5175, arkadas.KullaniciId, 5175, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"ArkadaslikIstekGonderildi\" href=\"javascript:;\" class=\"accept-request\">\r\n                                                            İstek Gönderildi\r\n                                                        </a>\r\n");
#nullable restore
#line 91 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                        break;
                                                    case 2:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <a");
            BeginWriteAttribute("id", " id=\"", 5598, "\"", 5623, 1);
#nullable restore
#line 93 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
WriteAttributeValue("", 5603, arkadas.KullaniciId, 5603, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"ArkadasKabulEdildi\" href=\"javascript:;\" class=\"accept-request\">\r\n                                                            Zaten Arkadaşsınız\r\n                                                        </a>\r\n");
#nullable restore
#line 96 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                        break;
                                                    case 3:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <a");
            BeginWriteAttribute("id", " id=\"", 6021, "\"", 6046, 1);
#nullable restore
#line 98 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
WriteAttributeValue("", 6026, arkadas.KullaniciId, 6026, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"ArkadaslikIstekBanaGonderildi\" href=\"javascript:;\" class=\"accept-request\">\r\n                                                            Size İstek Gönderildi\r\n                                                        </a>\r\n");
#nullable restore
#line 101 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                        break;
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                 
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            <a");
            BeginWriteAttribute("id", " id=\"", 6485, "\"", 6510, 1);
#nullable restore
#line 105 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
WriteAttributeValue("", 6490, arkadas.KullaniciId, 6490, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""MesajGonder"" href=""javascript:;"" class=""accept-request chat-message"">
                                                <svg class=""olymp-chat---messages-icon""><use xlink:href=""#olymp-chat---messages-icon""></use></svg>
                                            </a>
                                        </div>
                                    </div>

                                    <div class=""swiper-slide"">
                                        <p class=""friend-about"" data-swiper-parallax=""-500"">
                                            ");
#nullable restore
#line 113 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                       Write(arkadas.Hakkinda);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </p>\r\n\r\n                                        <div class=\"friend-since\" data-swiper-parallax=\"-100\">\r\n                                            <span>Doğum Tarihi</span>\r\n");
#nullable restore
#line 118 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                             switch (arkadas.DogumTarihi.Month)
                                            {
                                                case 1:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 121 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Ocak </div>\r\n");
#nullable restore
#line 122 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 2:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 124 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Şubat</div>\r\n");
#nullable restore
#line 125 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 3:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 127 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Mart</div>\r\n");
#nullable restore
#line 128 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 4:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 130 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Nisan</div>\r\n");
#nullable restore
#line 131 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 5:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 133 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Mayıs </div>\r\n");
#nullable restore
#line 134 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 6:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 136 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Haziran</div>\r\n");
#nullable restore
#line 137 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 7:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 139 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Temmuz</div>\r\n");
#nullable restore
#line 140 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 8:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 142 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Ağustos </div>\r\n");
#nullable restore
#line 143 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 9:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 145 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Eylül</div>\r\n");
#nullable restore
#line 146 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 10:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 148 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Ekim</div>\r\n");
#nullable restore
#line 149 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 11:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 151 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Kasım</div>\r\n");
#nullable restore
#line 152 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;
                                                case 12:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"h6\">");
#nullable restore
#line 154 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                               Write(arkadas.DogumTarihi.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Aralık </div>\r\n");
#nullable restore
#line 155 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
                                                    break;

                                                default:
                                                    break;
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                </div>

                                <div class=""swiper-pagination""></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
");
#nullable restore
#line 171 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 171 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
#nullable restore
#line 175 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
 if (Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <nav aria-label=\"Page navigation\">\r\n        ");
#nullable restore
#line 178 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
   Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("Ara",
         new
         {
             p = page,
             q = Context.Request.Query["q"],
             c = Context.Request.Query["c"],
             m = Context.Request.Query["m"],
             u = Context.Request.Query["u"],
             s = Context.Request.Query["s"],

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
            WriteLiteral("\r\n    </nav>\r\n");
#nullable restore
#line 205 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Arkadas\Partials\ArkadasAramaList.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    $(document).ready(function () {
        $(""a"").click(function (event) {
            var clickedItem = $(this);
            var id = $(this)[0].id;
            if ($(this)[0].name === ""ProfileGit"" || $(this)[0].name === ""KullaniciProfil"") {
                window.location.href = ""/Kullanici/Profil/"" + id
            }
            else if ($(this)[0].name === ""ProfiliSikayetEt"") {

            }
            else if ($(this)[0].name === ""ProfiliEngelle"") {

            }
            else if ($(this)[0].name === ""ArkadasEkle"") {
                $.ajax({
                    url: ""/Arkadas/ArkadaslikIsteginiGonder"",
                    type: ""POST"",
                    dataType: 'json',
                    data: { ""kullaniciId"": id },
                    success: function (data) {
                        if (data == false) {
                            ShowModal();
                        }
                        else if (data.Data == false && data.ErrorMessage == ""istekVar"")");
            WriteLiteral(@" {

                            clickedItem.empty();
                            clickedItem.addClass(""accept-request"")
                                .append(
                                    '<span class=""icon-add without-text""><svg class=""olymp-happy-face-icon""><use xlink:href=""#olymp-happy-face-icon""></use></svg></span>'
                                ).fadeIn('slow');
                        }
                        else if (data.Data == false && data.ErrorMessage == ""arkadaslikVar"") {
                            Swal.fire({
                                title: '',
                                text: ""Zaten arkadaşsınız."",
                                icon: 'warning',
                                confirmButtonColor: '#d33',
                                cancelButtonColor: '#3085d6',
                            })
                        }
                        else if (data.Data == false && data.ErrorMessage == ""banaIstekVar"") {
                            clickedIte");
            WriteLiteral(@"m.empty();
                            clickedItem.addClass(""accept-request"")
                                .append(
                                    'Size İstek Gönderildi'
                                ).fadeIn('slow');
                        }
                        else if (data.Data == false && data.ErrorMessage == ""ArkadasiminArkadasiDegil"") {
                            Swal.fire({
                                title: '',
                                text: ""Sadece Arkadaşlarının Arkadaşları İstek Yollayabilir!"",
                                icon: 'warning',
                                confirmButtonColor: '#d33',
                                cancelButtonColor: '#3085d6',
                                confirmButtonText: ""Tamam"",
                            })
                        }
                        else {
                            clickedItem.empty();
                            clickedItem.addClass(""accept-request"")
                               ");
            WriteLiteral(@" .append(
                                    'İstek Gönderildi'
                                ).fadeIn('slow');
                        }

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log(""hata!"");
                    }
                });
            }
            else if ($(this)[0].name === ""ArkadaslikIstekGonderildi"") {
                $.ajax({
                    url: ""/Arkadas/ArkadaslikIstekGonderildiMi"",
                    type: ""POST"",
                    dataType: 'json',
                    data: { ""kullaniciId"": id },
                    success: function (data) {
                        if (data == false) {
                            ShowModal();
                        }
                        else {
                            if (data.Data == false && data.ErrorMessage == ""ArkadaslikTalebiSilindi"") {
                                clickedItem.empty();
                       ");
            WriteLiteral(@"         clickedItem.addClass(""accept-request"")
                                    .append(
                                        '<span class=""icon-add without-text""><svg class=""olymp-happy-face-icon""><use xlink:href=""#olymp-happy-face-icon""></use></svg></span>'
                                    ).fadeIn('slow');
                            }
                            else {
                                clickedItem.empty();
                                clickedItem.addClass(""accept-request"")
                                    .append(
                                        'İstek Gönderildi'
                                    ).fadeIn('slow');
                            }

                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log(""hata!"");
                    }
                });
            }
            else if ($(this)[0].name === ""ArkadaslikIstekBanaGonderildi"") ");
            WriteLiteral(@"{
                $.ajax({
                    url: ""/Arkadas/ArkadaslikIstekBanaGonderildiMi"",
                    type: ""POST"",
                    dataType: 'json',
                    data: { ""kullaniciId"": id },
                    success: function (data) {
                        if (data == false) {
                            ShowModal();
                        }
                        else {
                            Swal.fire({
                                title: '',
                                text: ""Zaten üye tarafından size arkadaşlık talebi yapılmıştır."",
                                icon: 'warning',
                                confirmButtonColor: '#d33',
                                cancelButtonColor: '#3085d6',
                            })
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log(""hata!"");
                    }
              ");
            WriteLiteral(@"  });
            }
            else if ($(this)[0].name === ""MesajGonder"") {
                $.ajax({
                    url: ""/Arkadas/MesajGonder"",
                    type: ""POST"",
                    data: { ""kullaniciId"": id },
                    success: function (data) {
                        if (data == false) {
                            ShowModal();
                        } else {
                            $('#MesajGonderModalBody').html(data);
                            $('#MesajGonder').modal('show');
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log(""hata!"");
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
            }
        });
    });

    function ShowModal() {
        $('#loginlink').modal('show');
    }

    function profilSikayet(id) {
        ");
            WriteLiteral(@"$.get(""/Kullanici/ProfilSikayetPartial/"" + id, function (data) {
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
                    data: { ProfilEngellenenKullaniciId: id },
                    success: function (data) {
                        if (data.error == true && data.message == ""Bu Profil Zaten Engel Listenizde"") {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Uy");
            WriteLiteral(@"arı!',
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
                                text: ""Seçtiğiniz kişi engellenmiştir."",
                                confirmButtonText: ""Tamam""
                            });
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
 ");
            WriteLiteral("                       console.log(\"hata!\");\r\n                        console.log(textStatus);\r\n                        console.log(errorThrown);\r\n                    }\r\n                });\r\n            }\r\n        })\r\n    };\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<NeSever.Common.Models.Uyelik.ArkadasVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591