#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Rapor\YonlendirilenUrunRaporu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d7bd6eeb4c794afeb92918f8dadc2b75b03627d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Rapor_YonlendirilenUrunRaporu), @"mvc.1.0.view", @"/Areas/Admin/Views/Rapor/YonlendirilenUrunRaporu.cshtml")]
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
#line 1 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using NeSever.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using NeSever.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using NeSever.Common.Models.Admin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d7bd6eeb4c794afeb92918f8dadc2b75b03627d", @"/Areas/Admin/Views/Rapor/YonlendirilenUrunRaporu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b76a0a34bd0a8b80dec4af84b64c200dd6debf11", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Rapor_YonlendirilenUrunRaporu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NeSever.Common.Models.Admin.AramaVM.YonlendirilenUrunAramaVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "hepsi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control selectpicker"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "radio", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Başlangıç"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Bitiş"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-date-format", new global::Microsoft.AspNetCore.Html.HtmlString("dd/mm/yyyy"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-provide", new global::Microsoft.AspNetCore.Html.HtmlString("datepicker"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("kt-form kt-form--fit mb-15"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Rapor\YonlendirilenUrunRaporu.cshtml"
  
    ViewData["Title"] = "UyeIslem";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""d-flex flex-row flex-column-fluid container"">
    <div class=""main d-flex flex-column flex-row-fluid"">
        <div class=""subheader py-2 py-lg-4 subheader-transparent"" id=""kt_subheader"">
            <div class=""container d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap"">
                <div class=""d-flex align-items-center flex-wrap mr-1"">
                    <div class=""d-flex align-items-baseline flex-wrap mr-5"">
                        <h5 class=""text-dark font-weight-bold my-1 mr-5"">Yönlendirilen Ürün Raporları</h5>

                        <ul class=""breadcrumb breadcrumb-transparent breadcrumb-dot font-weight-bold p-0 my-2 font-size-sm"">
                            <li class=""breadcrumb-item"">
                                <a href=""/Admin/Rapor/"" class=""text-muted"">Ürün Raporları</a>
                            </li>
                            <li class=""breadcrumb-item"">
                                <a href=""/Admin/Rapor/YonlendirilenUrunRapo");
            WriteLiteral(@"ru"" class=""text-muted"">Yönlendirilen Ürün Raporları</a>
                            </li>
                        </ul>
                    </div>
                </div>

                <div class=""d-flex align-items-center"">
                    <a href=""/Admin/Rapor/YonlendirilenUrunRaporu"" class=""btn btn-icon btn-circle btn-sm btn-light-success mr-1"" data-card-tool=""reload"">
                        <i class=""ki ki-reload icon-nm""></i>
                    </a>
                </div>
            </div>
        </div>

        <div class=""content flex-column-fluid"" id=""kt_content"">
            <div class=""card card-custom"">
                <div class=""card-header"">
                    <div class=""card-title"">
                        <span class=""card-icon"">
                            <i class=""flaticon2-delivery-package text-primary""></i>
                        </span>
                        <h3 class=""card-label"">Filtreleme Kriterleri</h3>
                    </div>
                ");
            WriteLiteral("</div>\r\n                <div class=\"card-body\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d7bd6eeb4c794afeb92918f8dadc2b75b03627d11180", async() => {
                WriteLiteral("\r\n                        <div class=\"row mb-6\">\r\n                            <div class=\"col-lg-6\">\r\n                                <label>Marka:</label>\r\n                                <div class=\"input-group\">\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d7bd6eeb4c794afeb92918f8dadc2b75b03627d11703", async() => {
                    WriteLiteral("\r\n                                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d7bd6eeb4c794afeb92918f8dadc2b75b03627d12012", async() => {
                        WriteLiteral("Hepsi");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    BeginWriteTagHelperAttribute();
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 51 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Rapor\YonlendirilenUrunRaporu.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.MarkaAdi);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 51 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Rapor\YonlendirilenUrunRaporu.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(Model.MarkaListesi.BenzersizMarkaIsimleri));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </div>
                            </div>
                            <div class=""col-lg-3 mb-lg-0 mb-6"">
                                <label>Aktif Mi?:</label>
                                <div class=""input-group"">
                                    <div class=""radio-inline"">
                                        <label class=""radio radio-lg"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4d7bd6eeb4c794afeb92918f8dadc2b75b03627d16024", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 61 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Rapor\YonlendirilenUrunRaporu.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Aktiflik);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                            <span></span>
                                            Tümü
                                        </label>
                                        <label class=""radio radio-lg"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4d7bd6eeb4c794afeb92918f8dadc2b75b03627d18228", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 66 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Rapor\YonlendirilenUrunRaporu.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Aktiflik);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                            <span></span>
                                            Aktif
                                        </label>
                                        <label class=""radio radio-lg"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4d7bd6eeb4c794afeb92918f8dadc2b75b03627d20433", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 71 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Rapor\YonlendirilenUrunRaporu.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Aktiflik);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                            <span></span>
                                            Pasif
                                        </label>
                                    </div>
                                </div>
                            </div><br /><br /><br /><br /><br />
                            <div class=""col-lg-3 mb-lg-0 mb-6"">
                                <label>Kayıt Başlangıç-Bitiş Tarihi:</label>
                                <div class=""input-daterange input-group"" id=""kt_datepicker_5"" data-date-format=""dd/mm/yyyy"" data-provide=""datepicker"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4d7bd6eeb4c794afeb92918f8dadc2b75b03627d23011", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
#nullable restore
#line 81 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Rapor\YonlendirilenUrunRaporu.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BaslangicTarihi);

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
                WriteLiteral(@"
                                    <div class=""input-group-append"">
                                        <span class=""input-group-text"">
                                            <i class=""la la-ellipsis-h""></i>
                                        </span>
                                    </div>
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4d7bd6eeb4c794afeb92918f8dadc2b75b03627d25269", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
#nullable restore
#line 87 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Rapor\YonlendirilenUrunRaporu.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BitisTarihi);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                        <div class=""row mt-8"">
                            <div class=""col-lg-12"">
                                <button type=""button"" class=""btn btn-primary btn-primary--icon"" onclick=""javascript: ara();"">
                                    <span>
                                        <i class=""la la-search""></i>
                                        <span>Ara</span>
                                    </span>
                                </button>&#160;&#160;
                                <button type=""button"" class=""btn btn-secondary btn-secondary--icon"" onclick='location.reload();'>
                                    <span>
                                        <i class=""la la-close""></i>
                                        <span>Temizle</span>
                                    </span>
                                </button>
                    ");
                WriteLiteral("        </div>\r\n                        </div>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <div id=""chartdiv"" style=""width:100%; height:500px;""></div><br />
                <p style=""font-weight:bold"">Toplam Yönlendirme Sayısı: <div id=""toplamYonlendirme""></div></p>
            </div>
        </div>
    </div>
</div>





");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""/Themes/Admin/dist/assets/plugins/custom/datatables/datatables.bundle.js?v=7.0.5""></script>
    <script src=""/Themes/Admin/dist/assets/js/pages/crud/forms/widgets/bootstrap-switch.js?v=7.0.5""></script>
    <script src=""https://cdn.amcharts.com/lib/4/core.js""></script>
    <script src=""https://cdn.amcharts.com/lib/4/charts.js""></script>
    <script src=""https://cdn.amcharts.com/lib/4/themes/animated.js""></script>

    <script type=""text/javascript"">
        function ara() {
            var data = $('#_form').serializeObject();
            $.ajax({
                url: '/Admin/Rapor/YonlendirilenUrunRaporu',
                type: ""POST"",
                dataType: ""json"",
                data: data,
                success: function (data) {
                    if (data == null || data.length == 0) {
                        Swal.fire({
                            title: 'Uyarı!',
                            text: ""Yönlendirilen Ürün Bulunmamakta"",
                           ");
                WriteLiteral(@" icon: 'warning',
                            confirmButtonColor: '#3085d6',
                            cancelButtonColor: '#d33',
                            confirmButtonText: 'Kapat'
                        })
                    }
                    else {
                        am4core.ready(function () {

                            am4core.useTheme(am4themes_animated);

                            var chart = am4core.create(""chartdiv"", am4charts.XYChart3D);

                            var veri = [];

                            for (i = 0; i < data.length; i++) {
                                veri.push({ ""urunadi"": data[i].UrunAdi, ""yonlendirme"": data[i].YonlendirmeSayisi });
                            }

                            chart.data = veri;

                            // Create axes
                            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
                            categoryAxis.dataFields.category = ""urunadi"";
           ");
                WriteLiteral(@"                 categoryAxis.renderer.grid.template.location = 0;
                            categoryAxis.renderer.minGridDistance = 30;

                            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
                            valueAxis.title.text = ""Yönlendirme"";
                            valueAxis.renderer.labels.template.adapter.add(""text"", function (text) {
                                return text;
                            });

                            // Create series
                            var series = chart.series.push(new am4charts.ColumnSeries3D());
                            series.dataFields.valueY = ""yonlendirme"";
                            series.dataFields.categoryX = ""urunadi"";
                            series.name = ""Urun Yonlendirme"";
                            series.clustered = false;
                            series.columns.template.tooltipText = ""Yönlendirme Sayısı: [bold]{valueY}[/]"";
                            series.");
                WriteLiteral(@"columns.template.fillOpacity = 0.9;

                            chart.exporting.menu = new am4core.ExportMenu();
                        });

                        $('#toplamYonlendirme').html(data[0].ToplamYonlendirme);
                    }

                },
                error: function (error) {
                    Swal.fire({
                        title: 'Hata!',
                        text: ""Veri Çekerken Hata Oluştu"",
                        icon: 'error',
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Kapat'
                    })
                }
            });
        }

        function showLoading(id) {
            KTApp.block(document.getElementById(id), {
                overlayColor: '#000000',
                state: 'danger',
                message: 'Lütfen bekleyin...'
            });
        };

        function hideLoading(id) {
            KTApp");
                WriteLiteral(".unblock(document.getElementById(id));\r\n        };\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NeSever.Common.Models.Admin.AramaVM.YonlendirilenUrunAramaVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
