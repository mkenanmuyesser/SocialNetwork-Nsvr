#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\FotograflarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca0f26817c55379e76a93c69f671ecb0bd1f3c10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kullanici_Partials_FotograflarPartial), @"mvc.1.0.view", @"/Views/Kullanici/Partials/FotograflarPartial.cshtml")]
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
#line 1 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\FotograflarPartial.cshtml"
using NeSever.Common.Models.Uyelik;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca0f26817c55379e76a93c69f671ecb0bd1f3c10", @"/Views/Kullanici/Partials/FotograflarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Kullanici_Partials_FotograflarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NeSever.Common.Models.Uyelik.KullaniciResimVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12\">\r\n        <div class=\"tab-content\">\r\n\r\n            <div class=\"tab-pane active\" id=\"home\" role=\"tabpanel\" aria-expanded=\"true\">\r\n                <div class=\"row\">\r\n");
#nullable restore
#line 11 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\FotograflarPartial.cshtml"
                     foreach (KullaniciResimVM item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""choose-photo-item w-33"" data-mh=""choose-item"">
                            <div class=""radio"">
                                <label class=""custom-radio"">
                                    <img style=""height:200px""");
            BeginWriteAttribute("src", " src=\"", 701, "\"", 754, 4);
            WriteAttributeValue("", 707, "data:", 707, 5, true);
#nullable restore
#line 16 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\FotograflarPartial.cshtml"
WriteAttributeValue("", 712, item.ResimUzanti, 712, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 729, ";base64,", 729, 8, true);
#nullable restore
#line 16 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\FotograflarPartial.cshtml"
WriteAttributeValue("", 737, item.ResimBase64, 737, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"photo\">\r\n                                    <input type=\"radio\" name=\"optionsRadios\"");
            BeginWriteAttribute("id", " id=\"", 846, "\"", 894, 2);
            WriteAttributeValue("", 851, "radioButton+", 851, 12, true);
#nullable restore
#line 17 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\FotograflarPartial.cshtml"
WriteAttributeValue("", 863, item.KullaniciResim.ToString(), 863, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 895, "\"", 923, 1);
#nullable restore
#line 17 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\FotograflarPartial.cshtml"
WriteAttributeValue("", 903, item.KullaniciResim, 903, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"circle\"></span><span class=\"check\"></span>\r\n                                </label>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 21 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Kullanici\Partials\FotograflarPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>


            </div>
        </div>
    </div>
    <div class=""col col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
        <button class=""btn btn-secondary btn-lg btn--half-width"" style=""float:left"" onclick=""profilFotografiYap();"">Profil Fotoğrafı Yap</button>
        <button class=""btn btn-primary btn-lg btn--half-width"" style=""float:left"" onclick=""fotografSil();"">Sil</button>


    </div>
</div>

<script type=""text/javascript"">
    function profilFotografiYap() {
        var resimId = $(""input[type='radio']:checked"").val();
        $.ajax({
            url: '/Kullanici/ProfilFotografiDegistir',
            type: ""post"",
            data: {
                resimId: resimId
            }
            ,
            success: function (result) {
                $('#choose-from-my-photo').hide();
                $('#update-profile-photo').hide();
                Swal.fire({
                    title: 'İşlem Başarılı!',
                    text: ""Profil Resmi Değ");
            WriteLiteral(@"iştirildi!"",
                    icon: 'success',
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Kapat'
                }).then((result) => {
                        window.location.href = ""../../../Kullanici/Profil"";
                });

            },
            error: function () {
                Swal.fire({
                    title: '',
                    text: ""Fotoğrafınız bulunmamaktadır."",
                    icon: 'warning',
                    confirmButtonColor: '#d33',
                    cancelButtonColor: '#3085d6',
                })
            }
        });
    }
    function fotografSil() {
        var resimId = $(""input[type='radio']:checked"").val();
        $.ajax({
            url: '/Kullanici/FotografSil',
            type: ""post"",
            data: {
                resimId: resimId
            }
            ,
            success: function (result) {
            ");
            WriteLiteral(@"    if (result.Type == 2) {
                    $('#choose-from-header-photo').hide();
                    Swal.fire({
                        title: 'İşlem Başarısız!',
                        text: ""Hiç Fotoğrafınız Yok!"",
                        icon: 'warning',
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Kapat'
                    });
                }
                else
                {
                    $('#choose-from-my-photo').hide();
                    $('#update-profile-photo').hide();
                    Swal.fire({
                        title: 'İşlem Başarılı!',
                        text: ""Fotoğraf Silindi!"",
                        icon: 'success',
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Kapat'
                    }).then((result) => {
              ");
            WriteLiteral(@"          if (result.value) {
                            window.location.href = ""../../../Kullanici/Profil"";
                        }
                    });
                }
            },
            error: function () {

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NeSever.Common.Models.Uyelik.KullaniciResimVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
