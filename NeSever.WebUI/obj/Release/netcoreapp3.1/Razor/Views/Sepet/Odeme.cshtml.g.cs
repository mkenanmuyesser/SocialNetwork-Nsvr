#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbbd3e928042a37e5b15945c54a63d5b6352c25f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sepet_Odeme), @"mvc.1.0.view", @"/Views/Sepet/Odeme.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbbd3e928042a37e5b15945c54a63d5b6352c25f", @"/Views/Sepet/Odeme.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fb13401ce2b569830ec01d821dce8b4cda8a87", @"/Views/_ViewImports.cshtml")]
    public class Views_Sepet_Odeme : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NeSever.Common.Models.Satis.OdemeIcerikVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Sepet/Partials/SepettekiUrunler.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("OdemeForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
  
    ViewData["Title"] = "Odeme";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<style type=\"text/css\">\r\n    td {\r\n        text-align: center !important;\r\n        vertical-align: middle !important;\r\n    }\r\n</style>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbbd3e928042a37e5b15945c54a63d5b6352c25f6441", async() => {
                WriteLiteral("\r\n    <input id=\"hdnFaturaAdresId\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 366, "\"", 394, 1);
#nullable restore
#line 15 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
WriteAttributeValue("", 374, Model.FaturaAdresId, 374, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <input id=\"hdnGonderimAdresId\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 448, "\"", 478, 1);
#nullable restore
#line 16 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
WriteAttributeValue("", 456, Model.GonderimAdresId, 456, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <input id=\"hdnOdemeTipId\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 527, "\"", 559, 1);
#nullable restore
#line 17 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
WriteAttributeValue("", 535, Model.SiparisOdemeTipId, 535, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />

    <section>
        <div class=""container"">
            <div class=""row"">
                <div class=""col col-xl-7 col-lg-7 col-md-6 col-sm-6 col-12"">
                    <div>
                        <a href=""/Sepet"" class=""btn btn-primary btn-sm""><= Sepete Geri Dön</a>

                        <div class=""crumina-module crumina-heading with-title-decoration"">
                            <h5 class=""heading-title"">Sepetteki Ürünler</h5>
                        </div>

                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbbd3e928042a37e5b15945c54a63d5b6352c25f8507", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 30 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.SepetIcerik.SepetUrunList;

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
                WriteLiteral(@"
                    </div>

                    <div style=""margin:20px 0px 0px 0px;"">
                        <div class=""crumina-module crumina-heading with-title-decoration"" style=""margin-bottom:0px;"">
                            <h5 class=""heading-title"">Sözleşmeler ve Formlar</h5>
                        </div>

                        <div class=""row"">
                            <div class=""col col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
                                <div id=""accordion"" role=""tablist"" aria-multiselectable=""false"" class=""accordion-faqs"">
                                    <div class=""card"">
                                        <div class=""card-header"" role=""tab"" id=""headingOne-2"" style=""padding:0px;"">
                                            <h3 class=""mb-0"">
                                                <a data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseOne-2"" aria-expanded=""true"" aria-controls=""collapseOne"">
                              ");
                WriteLiteral(@"                      Ön Bilgilendirme Formu
                                                    <span class=""icons-wrap"">
                                                        <svg class=""olymp-plus-icon""><use xlink:href=""#olymp-plus-icon""></use></svg>
                                                        <svg class=""olymp-accordion-close-icon""><use xlink:href=""#olymp-accordion-close-icon""></use></svg>
                                                    </span>
                                                </a>
                                            </h3>
                                        </div>
                                    </div>
                                    <div class=""card"">
                                        <div id=""collapseOne-2"" class=""collapse show"" role=""tabpanel"" aria-labelledby=""headingOne-2"" style=""max-height:150px; overflow-y:auto; margin-bottom:0px;"">
                                            ");
#nullable restore
#line 56 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                                       Write(Html.Raw(Model.OnBilgilendirmeFormuIcerik));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""card"">
                                        <div class=""card-header"" role=""tab"" id=""headingOne-3"" style=""padding:0px;"">
                                            <h3 class=""mb-0"">
                                                <a data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseOne-3"" aria-expanded=""true"" aria-controls=""collapseOne-3"">
                                                    Mesafeli Satış Sözleşmesi
                                                    <span class=""icons-wrap"">
                                                        <svg class=""olymp-plus-icon""><use xlink:href=""#olymp-plus-icon""></use></svg>
                                                        <svg class=""olymp-accordion-close-icon""><use xlink:href=""#olymp-accordion-close-icon""></use></svg>
                                                    </span>
           ");
                WriteLiteral(@"                                     </a>
                                            </h3>
                                        </div>
                                    </div>
                                    <div class=""card"">
                                        <div id=""collapseOne-3"" class=""collapse show"" role=""tabpanel"" aria-labelledby=""headingOne"" style=""max-height:150px; overflow-y:auto; margin-bottom:0px;"">
                                            ");
#nullable restore
#line 74 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                                       Write(Html.Raw(Model.MesafeliSatisSozlesmesiIcerik));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12 ml-auto"">
                    <div class=""crumina-module crumina-heading with-title-decoration"">
                        <h5 class=""heading-title"">Sipariş Toplamları</h5>
                    </div>

                    <ul class=""order-totals-list"">
                        <li>
                            Kdv Hariç Tutar <span>");
#nullable restore
#line 89 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                                              Write(Model.SepetIcerik.KdvHaricTutar.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
                WriteLiteral("&nbsp;TL</span>\r\n                        </li>\r\n                        <li>\r\n                            Kdv Tutarı <span>");
#nullable restore
#line 92 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                                         Write(Model.SepetIcerik.KdvTutar.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
                WriteLiteral("&nbsp;TL</span>\r\n                        </li>\r\n                        <li>\r\n                            Ara Toplam <span>");
#nullable restore
#line 95 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                                         Write(Model.SepetIcerik.KdvDahilTutar.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
                WriteLiteral("&nbsp;TL</span>\r\n                        </li>\r\n\r\n");
#nullable restore
#line 98 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                         if (Model.SepetIcerik.GonderimTutar != 0)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <li>\r\n                                Gönderim Ücreti <span>");
#nullable restore
#line 101 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                                                  Write(Model.SepetIcerik.GonderimTutar.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
                WriteLiteral("&nbsp;TL</span>\r\n                            </li>\r\n");
#nullable restore
#line 103 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 105 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                         if (Model.SepetIcerik.OdemeYontemiTutar != 0)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <li>\r\n                                Ödeme Yöntemi Ücreti <span>");
#nullable restore
#line 108 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                                                       Write(Model.SepetIcerik.OdemeYontemiTutar.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
                WriteLiteral("&nbsp;TL</span>\r\n                            </li>\r\n");
#nullable restore
#line 110 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 112 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                         if (Model.SepetIcerik.IndirimTutar != 0)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <li>\r\n                                İndirim <span>");
#nullable restore
#line 115 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                                          Write(Model.SepetIcerik.IndirimTutar.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
                WriteLiteral("&nbsp;TL</span>\r\n                            </li>\r\n");
#nullable restore
#line 117 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <li class=\"total\">\r\n                            <input id=\"hdnOdenecekTutar\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 6965, "\"", 7005, 1);
#nullable restore
#line 120 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
WriteAttributeValue("", 6973, Model.SepetIcerik.OdenecekTutar, 6973, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            Ödenecek Tutar <span>");
#nullable restore
#line 121 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                                             Write(Model.SepetIcerik.OdenecekTutar.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
                WriteLiteral("&nbsp;TL</span>\r\n                        </li>\r\n                    </ul>\r\n\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbbd3e928042a37e5b15945c54a63d5b6352c25f20008", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 125 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.SiparisOdemeTipId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbbd3e928042a37e5b15945c54a63d5b6352c25f21730", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 126 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.KrediKartiAdSoyad);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbbd3e928042a37e5b15945c54a63d5b6352c25f23452", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 127 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.KrediKartiNo);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbbd3e928042a37e5b15945c54a63d5b6352c25f25169", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 128 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.KrediKartiCvv);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbbd3e928042a37e5b15945c54a63d5b6352c25f26887", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 129 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.KrediKartiSonKullanmaTarihiAy);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbbd3e928042a37e5b15945c54a63d5b6352c25f28621", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 130 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.KrediKartiSonKullanmaTarihiYil);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                    Ödeme Yöntemi :\r\n");
#nullable restore
#line 133 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                     switch (Model.SiparisOdemeTipId)
                    {
                        default:

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span>Ödeme Yöntemi Seçilmedi</span>\r\n");
#nullable restore
#line 137 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                            break;
                        case 1:

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span>Kredi Kartı</span>\r\n");
#nullable restore
#line 140 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                            break;
                        case 2:

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span>Banka Havalesi</span>\r\n");
#nullable restore
#line 143 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                            break;
                        case 3:

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span>Kapıda Ödeme</span>\r\n");
#nullable restore
#line 146 "D:\Programlar\NeSeverProject\NeSever.WebUI\Views\Sepet\Odeme.cshtml"
                            break;
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <br />
                    <br />

                    <div class=""row"">
                        <div class=""col"">
                            <div class=""checkbox"">
                                <label>
                                    <input id=""sozlesmeKosulKabul"" type=""checkbox"" name=""optionsCheckboxes"">
                                    <a href=""javascript:;"" onclick=""onBilgilendirmeFormuGetir();"">Ön Bilgilendirme Koşulları</a>'nı ve <a href=""javascript:;"" onclick=""mesafeliSatisSozlesmesiGetir();"">Mesafeli Satış Sözleşmesi</a>'ni okudum, onaylıyorum.
                                </label>
                            </div>
                        </div>

                        <button class=""btn btn-purple btn-lg full-width"">Sipariş Ver</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div id=""sms""></div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script src=""/lib/jquery-validation/dist/jquery.validate.js""></script>
<script type=""text/javascript"">
    function onBilgilendirmeFormuGetir() {
        var popupModalContent = $('#popupModalContent');
        var icerik = $('#collapseOne-2').html();
        var popupModal = $(""#popupModal"");

        popupModalContent.html('');       
        popupModalContent.html(icerik);        
        popupModal.modal('show');
    }

    function mesafeliSatisSozlesmesiGetir() {
        var popupModalContent = $('#popupModalContent');
        var icerik = $('#collapseOne-3').html();
        var popupModal = $(""#popupModal"");

        popupModalContent.html('');
        popupModalContent.html(icerik);
        popupModal.modal('show');
    }

    $(""#OdemeForm"").validate({
                    submitHandler: function (form) {

                            var faturaAdresId = $('#hdnFaturaAdresId').val();
                            var teslimatAdresId = $('#hdnGonderimAdresId').val();
       ");
            WriteLiteral(@"                     if (faturaAdresId == '0' || teslimatAdresId == '0') {
                                Swal.fire({
                                icon: 'warning',
                                title: 'Uyarı!',
                                text: """",
                                html: 'Lütfen Geri Dönerek Adres Seçimi Yapınız.',
                                confirmButtonText: ""Tamam""
                                });
                                return;
                            }

                            var odemeTip = $('#hdnOdemeTipId').val();
                            if (odemeTip == '0') {
                                Swal.fire({
                                icon: 'warning',
                                title: 'Uyarı!',
                                text: """",
                                html: 'Lütfen Ödeme Yöntemi Seçiniz.',
                                confirmButtonText: ""Tamam""
                                });
                         ");
            WriteLiteral(@"       return;
                            }

                            if ($('#sozlesmeKosulKabul').is(':checked')) {
                                var sendData = $('#OdemeForm').serializeObject();
                                sendData.FaturaAdresId = faturaAdresId;
                                sendData.GonderimAdresId = teslimatAdresId;
                                sendData.SiparisOdemeTipId = odemeTip;
                                sendData.OdenecekToplamTutar = $('#hdnOdenecekTutar').val();

                            $.ajax({
                                url: ""/Sepet/OdemeYap"",
                                type: ""POST"",
                                dataType: 'json',
                                data: sendData,
                                success: function (result) {
                                                        if (result.error == true) {
                                                            Swal.fire({
                                    ");
            WriteLiteral(@"                        icon: 'error',
                                            title: 'Upps',
                                            text: result.message,
                                            confirmButtonText: ""Tamam""
                                                            });
                                    }
                                    else if (result.type ==""3D""){
                                        $(""#sms"").html(result.message);
                                    }
                                    else {
                                        window.location = result.location;
                                    }
                                },
                             });
                            }
                            else {
                                Swal.fire({
                                icon: 'warning',
                                title: 'Uyarı!',
                                text: """",
                  ");
            WriteLiteral(@"              html: 'Ön Bilgilendirme Koşulları ve Mesafeli Satış Sözleşmesini Onaylamalısınız.',
                                confirmButtonText: ""Tamam""
                                });
                            }
                        }
                    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NeSever.Common.Models.Satis.OdemeIcerikVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
