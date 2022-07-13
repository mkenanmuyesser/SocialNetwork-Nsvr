#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "846950d27f39e7964598402b9d9e75d1e7418f37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bilgi_Iletisim), @"mvc.1.0.view", @"/Views/Bilgi/Iletisim.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"846950d27f39e7964598402b9d9e75d1e7418f37", @"/Views/Bilgi/Iletisim.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Bilgi_Iletisim : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NeSever.Common.Models.Program.IletisimVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Bilgi/Partials/IletisimTalep.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
  
    ViewData["Title"] = "Iletisim";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
 if (!string.IsNullOrEmpty(Model.SirketMapCode))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <section class=\"mt-0\">\r\n        <div class=\"section\">\r\n");
            WriteLiteral("            <div style=\"height: 480px\">\r\n                ");
#nullable restore
#line 13 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
           Write(Html.Raw(Model.SirketMapCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 17 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""medium-padding80"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12"">
                <div class=""contact-item-wrap"">
                    <h3 class=""contact-title"">Adres/Telefon</h3>
                    <div class=""contact-item"">
                        <a href=""javascript:;"">");
#nullable restore
#line 26 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                                          Write(Model.SirketAdres);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </div>\r\n                    <div class=\"contact-item\">\r\n                        <h6 class=\"sub-title\">E-posta:</h6>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1023, "\"", 1056, 2);
            WriteAttributeValue("", 1030, "mailto:", 1030, 7, true);
#nullable restore
#line 30 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
WriteAttributeValue("", 1037, Model.SirketEposta, 1037, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 30 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                                                        Write(Model.SirketEposta);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </div>\r\n");
#nullable restore
#line 32 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                     if (!string.IsNullOrEmpty(Model.SirketTelefon1))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"contact-item\">\r\n                            <h6 class=\"sub-title\">Tel:</h6>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1348, "\"", 1380, 2);
            WriteAttributeValue("", 1355, "tel:", 1355, 4, true);
#nullable restore
#line 36 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
WriteAttributeValue("", 1359, Model.SirketTelefon1, 1359, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 36 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                                                           Write(Model.SirketTelefon1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n");
#nullable restore
#line 38 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                     if (!string.IsNullOrEmpty(Model.SirketTelefon2))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"contact-item\">\r\n                            <h6 class=\"sub-title\">Tel:</h6>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1701, "\"", 1733, 2);
            WriteAttributeValue("", 1708, "tel:", 1708, 4, true);
#nullable restore
#line 43 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
WriteAttributeValue("", 1712, Model.SirketTelefon2, 1712, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 43 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                                                           Write(Model.SirketTelefon2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n");
#nullable restore
#line 45 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                     if (!string.IsNullOrEmpty(Model.SirketFax1))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"contact-item\">\r\n                            <h6 class=\"sub-title\">Fax 1:</h6>\r\n                            <a href=\"javascript:;\">");
#nullable restore
#line 50 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                                              Write(Model.SirketFax1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n");
#nullable restore
#line 52 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                     if (!string.IsNullOrEmpty(Model.SirketFax2))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"contact-item\">\r\n                            <h6 class=\"sub-title\">Fax 2:</h6>\r\n                            <a href=\"javascript:;\">");
#nullable restore
#line 57 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                                              Write(Model.SirketFax2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n");
#nullable restore
#line 59 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
            <div class=""col col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12"">
                <div class=""contact-item-wrap"">
                    <h3 class=""contact-title"">Şirket Bilgileri</h3>
                    <div class=""contact-item"">
                        <h6 class=""sub-title"">Marka Adı:</h6>
                        <a href=""javascript:;"">Ne Sever</a>
                    </div>
                    <div class=""contact-item"">
                        <h6 class=""sub-title"">Ticaret Sicil No:</h6>
                        <a href=""javascript:;"">452340</a>
                    </div>
                    <div class=""contact-item"">
                        <h6 class=""sub-title"">Mersis No:</h6>
                        <a href=""javascript:;"">0631148844400001</a>
                    </div>
                    <div class=""contact-item"">
                        <h6 class=""sub-title"">Kayıtlı Elektronik Posta Adresi:</h6>
                        <a href=""javascrip");
            WriteLiteral(@"t:;"">neseveryazilim@hs02.kep.tr</a>
                    </div>
                    <div class=""contact-item"">
                        <h6 class=""sub-title"">Bağlı Olduğu Meslek Odası:</h6>
                        <a href=""javascript:;"">Ankara Ticaret Odası - ATO</a>
                    </div>
                </div>
            </div>

            <div class=""col col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12"">
                <div class=""contact-item-wrap"">
                    <h3 class=""contact-title"">Sosyal Ağ Hesapları</h3>
");
#nullable restore
#line 91 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                     if (!string.IsNullOrEmpty(Model.FacebookHesapUrl))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"contact-item\">\r\n                            <h6 class=\"sub-title\">Facebook:</h6>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 4293, "\"", 4323, 1);
#nullable restore
#line 95 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
WriteAttributeValue("", 4300, Model.FacebookHesapUrl, 4300, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 95 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                                                                         Write(Model.FacebookHesapUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n");
#nullable restore
#line 97 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                     if (!string.IsNullOrEmpty(Model.TwitterHesapUrl))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"contact-item\">\r\n                            <h6 class=\"sub-title\">Twitter:</h6>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 4667, "\"", 4696, 1);
#nullable restore
#line 102 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
WriteAttributeValue("", 4674, Model.TwitterHesapUrl, 4674, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 102 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                                                                        Write(Model.TwitterHesapUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n");
#nullable restore
#line 104 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 105 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                     if (!string.IsNullOrEmpty(Model.InstagramHesapUrl))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"contact-item\">\r\n                            <h6 class=\"sub-title\">Instagram:</h6>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 5043, "\"", 5074, 1);
#nullable restore
#line 109 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
WriteAttributeValue("", 5050, Model.InstagramHesapUrl, 5050, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 109 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                                                                          Write(Model.InstagramHesapUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n");
#nullable restore
#line 111 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "846950d27f39e7964598402b9d9e75d1e7418f3717657", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 118 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Bilgi\Iletisim.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.IletisimTalep;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NeSever.Common.Models.Program.IletisimVM> Html { get; private set; }
    }
}
#pragma warning restore 1591