#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Katalog\KategoriBannerArama.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "deab7dc788e83dfacfb8c5e853e37681a6129bfb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Katalog_KategoriBannerArama), @"mvc.1.0.view", @"/Areas/Admin/Views/Katalog/KategoriBannerArama.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"deab7dc788e83dfacfb8c5e853e37681a6129bfb", @"/Areas/Admin/Views/Katalog/KategoriBannerArama.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b76a0a34bd0a8b80dec4af84b64c200dd6debf11", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Katalog_KategoriBannerArama : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NeSever.Common.Models.Urun.KategoriBannerAramaVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control datatable-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "radio", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("checked", new global::Microsoft.AspNetCore.Html.HtmlString("checked"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("AktifRadioButton"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("kt-form kt-form--fit mb-15"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_formAra"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Katalog\KategoriBannerArama.cshtml"
  
    ViewData["Title"] = "Ara";
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
                        <h5 class=""text-dark font-weight-bold my-1 mr-5"">Kategori Banner Arama</h5>

                        <ul class=""breadcrumb breadcrumb-transparent breadcrumb-dot font-weight-bold p-0 my-2 font-size-sm"">

                            <li class=""breadcrumb-item"">
                                <a href=""Admin/Katalog"" class=""text-muted"">Katolog</a>
                            </li>
                            <li class=""breadcrumb-item"">
                                <a href=""/Admin/Katalog/KategoriBannerArama"" class=""tex");
            WriteLiteral(@"t-muted"">Kategori Banner Arama</a>
                            </li>
                        </ul>
                    </div>
                </div>

                <div class=""d-flex align-items-center"">
                    <a href=""#"" class=""btn btn-icon btn-circle btn-sm btn-light-success mr-1"" data-card-tool=""reload"" onclick=""loadPage()"">
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
                    <div class=""card-toolbar"">
   ");
            WriteLiteral(@"                     <div class=""dropdown dropdown-inline mr-2"">

                            <div class=""dropdown-menu dropdown-menu-sm dropdown-menu-right"">
                                <ul class=""navi flex-column navi-hover py-2"">
                                    <li class=""navi-header font-weight-bolder text-uppercase font-size-sm text-primary pb-2"">Seçiniz:</li>
                                    <li class=""navi-item"">
                                        <a href=""#"" class=""navi-link"">
                                            <span class=""navi-icon"">
                                                <i class=""la la-print""></i>
                                            </span>
                                            <span class=""navi-text"">Yazdır</span>
                                        </a>
                                    </li>
                                    <li class=""navi-item"">
                                        <a href=""#"" class=""navi-link"">
       ");
            WriteLiteral(@"                                     <span class=""navi-icon"">
                                                <i class=""la la-file-excel-o""></i>
                                            </span>
                                            <span class=""navi-text"">Excel</span>
                                        </a>
                                    </li>
                                    <li class=""navi-item"">
                                        <a href=""#"" class=""navi-link"">
                                            <span class=""navi-icon"">
                                                <i class=""la la-file-pdf-o""></i>
                                            </span>
                                            <span class=""navi-text"">PDF</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>

                        <a href=""/Admi");
            WriteLiteral(@"n/Katalog/KategoriBannerKayit"" class=""btn btn-primary font-weight-bolder"">
                            <span class=""svg-icon svg-icon-md"">
                                <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                    <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                        <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                                        <circle fill=""#000000"" cx=""9"" cy=""15"" r=""6"" />
                                        <path d=""M8.8012943,7.00241953 C9.83837775,5.20768121 11.7781543,4 14,4 C17.3137085,4 20,6.6862915 20,10 C20,12.2218457 18.7923188,14.1616223 16.9975805,15.1987057 C16.9991904,15.1326658 17,15.0664274 17,15 C17,10.581722 13.418278,7 9,7 C8.93357256,7 8.86733422,7.00080962 8.8012943,7.00241953 Z"" fill=""#000000"" opacity=""0.3"" />
                                    </g>
                ");
            WriteLiteral("                </svg>\r\n                            </span>Yeni Kayıt\r\n                        </a>\r\n                    </div>\r\n                </div>\r\n                <div class=\"card-body\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "deab7dc788e83dfacfb8c5e853e37681a6129bfb13284", async() => {
                WriteLiteral("\r\n                        <div class=\"row mb-6\">\r\n                            <div class=\"col-lg-3 mb-lg-0 mb-6\">\r\n                                <label>ID:</label>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "deab7dc788e83dfacfb8c5e853e37681a6129bfb13750", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 97 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Katalog\KategoriBannerArama.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.KategoriBannerId);

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
                WriteLiteral("\r\n                            </div>\r\n\r\n                            <div class=\"col-lg-3 mb-lg-0 mb-6\">\r\n                                <label>Adı:</label>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "deab7dc788e83dfacfb8c5e853e37681a6129bfb15850", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 102 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Katalog\KategoriBannerArama.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Adi);

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
                            </div>
                            <div class=""col-lg-3 mb-lg-0 mb-6"">
                                <label>Durum:</label>
                                <div class=""input-group"">
                                    <div class=""radio-inline"">
                                        <label class=""radio radio-lg"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "deab7dc788e83dfacfb8c5e853e37681a6129bfb18142", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 109 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Katalog\KategoriBannerArama.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.AktifMi);

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
                                            <span></span>
                                            Tümü
                                        </label>
                                        <label class=""radio radio-lg"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "deab7dc788e83dfacfb8c5e853e37681a6129bfb20346", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
#nullable restore
#line 114 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Katalog\KategoriBannerArama.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.AktifMi);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "deab7dc788e83dfacfb8c5e853e37681a6129bfb22725", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
#nullable restore
#line 119 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Katalog\KategoriBannerArama.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.AktifMi);

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
                                            <span></span>
                                            Pasif
                                        </label>
                                    </div>
                                </div>
                            </div>                            
                        </div>
                        <div class=""row mt-8"">
                            <div class=""col-lg-12"">
                                <button type=""button"" onclick=""javascript: kategoriBannerAra();"" class=""btn btn-primary btn-primary--icon"">Ara <i class=""la la-search""></i></button>


                                <button class=""btn btn-secondary btn-secondary--icon"" id=""kt_reset"" onclick=""javascript: temizle();"">
                                    <span>
                                        <i class=""la la-close""></i>
                                        <span>Temizle</span>
                                    </span>
                                </button");
                WriteLiteral(">\r\n                            </div>\r\n                        </div>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                    <table class=""table table-bordered table-hover table-checkable"" id=""dtBannerArama"">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Resim</th>
                                <th>Adı</th>
                                <th>Üst Kategori</th>
                                <th>Üst Banner Kategori</th>
                                <th>Anasayfa</th>
                                <th>Sıra</th>
                                <th>Parametre</th>
                                <th>İşlemler</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>ID</th>
                                <th>Resim</th>
                                <th>Adı</th>
                                <th>Üst Kategori</th>
                                <th>Üst Banner Kategori</th>");
            WriteLiteral(@"
                                <th>Anasayfa</th>
                                <th>Sıra</th>
                                <th>Parametre</th>
                                <th>İşlemler</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""/Themes/Admin/dist/assets/plugins/custom/datatables/datatables.bundle.js?v=7.0.5""></script>
    <script src=""/Themes/Admin/dist/assets/js/pages/crud/datatables/search-options/advanced-search.js?v=7.0.5""></script>
    <script>

        function kategoriBannerGuncelle(kategoriId) {

            window.location.href = ""/Admin/Katalog/KategoriBannerKayit/"" + kategoriId;
        }
        function loadPage() {
            location.reload();
        }
        function kategoriBannerSil(Id) {
            event.preventDefault();
            var kategoriId = Id;

            Swal.fire({
                title: 'Emin misiniz?',
                text: ""Kategori silinecek"",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sil',
                cancelButtonText: ""Vazgeç"",
            }).then((result) => {
                if (result.v");
                WriteLiteral(@"alue) {
                    $.ajax({
                        url: '/Admin/Katalog/KategoriBannerSil',
                        data: { id: kategoriId },
                        type: ""Post"",
                        success: function (result) {
                            $('#dtBannerArama').DataTable().ajax.reload();
                            Swal.fire(""İşlem Başarılı!"", ""Kategori silindi!"", ""success"");

                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert(xhr.status);
                            alert(thrownError);
                        }
                    });
                }
            })




        }
        function showLoading(id) {
            KTApp.block(document.getElementById(id), {
                overlayColor: '#000000',
                state: 'danger',
                message: 'Lütfen bekleyin...'
            });
        };
        function hideLoading(id) {
            KTApp.un");
                WriteLiteral(@"block(document.getElementById(id));
        };
        function kategoriBannerAra() {
            var sendData = $('#_formAra').serializeObject();
            $('#dtBannerArama').DataTable().destroy();
            var table = $('#dtBannerArama').DataTable({
                processing: true,
                serverSide: true,
                filter: false,
                responsive: true,
                orderMulti: false,
                autoWidth: true,
                ordering: false,
                paging: true,
                //fixedColumns: true,
                //deferRender: true,
                ajax: {                   
                    url: ""/Admin/Katalog/KategoriBannerArama"",
                    type: ""POST"",
                    dataType: ""json"",
                    data: sendData,
                    beforeSend: function () {
                        showLoading('dtBannerArama');
                    },
                    complete: function () {
                     ");
                WriteLiteral(@"   hideLoading('dtBannerArama');
                    },
                    error: function (error) {
                        hideLoading('dtBannerArama');
                        Swal.fire(
                            ""Hata"",
                            ""İşlem sırasında hata oluştu. "" + error,
                            ""error""
                        );
                    }
                },

                columns: [
                    { data: 'KategoriBannerId', defaultContent: '' },
                    { data: 'ResimBase64', defaultContent: '' },
                    { data: 'Adi', defaultContent: '' },
                    { data: 'UstKategoriAdi', defaultContent: '' },
                    { data: 'UstKategoriBannerAdi', defaultContent: '' },
                    { data: 'AnasayfadaGosterDurum', defaultContent: '' },
                    { data: 'Sira', defaultContent: '' },
                    { data: 'Parametre', defaultContent: '' },
                    { data: 'KategoriBannerId");
                WriteLiteral(@"', defaultContent: '' },
                ],
                fixedColumns: true,
                columnDefs: [
                    { targets: 0, width: '5%' },
                    {
                        targets: 1, width: '15%', ""render"": function (data) {
                            if (data != """" && data != null)
                                return '<img style=""max-height:200px;max-width:150px"" ' + data + '"" />';
                            else
                                return '<img src=""/Themes/Admin/design/noimage.png"" id=""emptyFile"" style=""max-height:200px;max-width:150px"" />';

                        },
                    },
                    { targets: 2, width: '10%' },
                    { targets: 3, width: '15%' },
                    { targets: 4, width: '15%' },
                    { targets: 5, width: '10%' },
                    { targets: 6, width: '10%' },
                    { targets: 7, width: '10%' },
                    {
                        targ");
                WriteLiteral(@"ets: 8, responsivePriority: 1, width: ""10%"", render: function (data, type, row, meta) {
                            return ""<div class='list-icons'>"" +
                                ""<a href = '#' style='float:left' data-toggle='tooltip' data-placement='bottom' title='Sil'  onClick='javascript: kategoriBannerSil("" + data + ""); ' class='btn  btn-icon-only yellow'><i class='la la-remove'></i></a>"" +
                                ""<a href = '#' style='float:left' data-toggle='tooltip' data-placement='bottom' title='Güncelle'  onClick='javascript: kategoriBannerGuncelle("" + data + ""); ' class='btn  btn-icon-only yellow'><i class='la la-search'></i></a>"" +
                                ""</div>"";
                        }
                    },
                ],
                dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
                        <'row'<'col-sm-12'tr>>
                        <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
                l");
                WriteLiteral(@"engthMenu: [[5, 25, 50], [5, 25, 50]],
                buttons: [
                    {
                        extend: 'print',
                        text: 'Yazdır'
                    },
                    {
                        extend: 'excelHtml5',
                        text: 'Excel'
                    },
                    {
                        extend: 'pdfHtml5',
                        text: 'Pdf'
                    }
                ],
                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.10.21/i18n/Turkish.json'
                }
            });

        }

        function temizle() {
            $('#KategoriBannerId').val("""");
            $('#AktifRadioButton').prop(""checked"", true);
        }

    </script>

");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NeSever.Common.Models.Urun.KategoriBannerAramaVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
