#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c9cd00b04ddfca9d2fbd1a98b876499d9c9aa57"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Icerik_IlgiAlanKayit), @"mvc.1.0.view", @"/Areas/Admin/Views/Icerik/IlgiAlanKayit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c9cd00b04ddfca9d2fbd1a98b876499d9c9aa57", @"/Areas/Admin/Views/Icerik/IlgiAlanKayit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b76a0a34bd0a8b80dec4af84b64c200dd6debf11", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Icerik_IlgiAlanKayit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NeSever.Common.Models.Icerik.IlgiAlanVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "number", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-switch", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-on-color", new global::Microsoft.AspNetCore.Html.HtmlString("success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-off-color", new global::Microsoft.AspNetCore.Html.HtmlString("danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-on-text", new global::Microsoft.AspNetCore.Html.HtmlString("Evet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-off-text", new global::Microsoft.AspNetCore.Html.HtmlString("Hayır"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Themes/Admin/design/noimage.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("emptyFile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-height:200px;max-width:150px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_16 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"
  
    ViewData["Title"] = "Kayit";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""d-flex flex-row flex-column-fluid container"">
    <div class=""main d-flex flex-column flex-row-fluid"">
        <div class=""subheader py-2 py-lg-4 subheader-transparent"" id=""kt_subheader"">
            <div class=""container d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap"">
                <div class=""d-flex align-items-center flex-wrap mr-1"">
                    <div class=""d-flex align-items-baseline flex-wrap mr-5"">
                        <h5 class=""text-dark font-weight-bold my-1 mr-5"">İlgi Alan Kayıt</h5>

                        <ul class=""breadcrumb breadcrumb-transparent breadcrumb-dot font-weight-bold p-0 my-2 font-size-sm"">
                            <li class=""breadcrumb-item"">
                                <a href=""/Admin/Icerik"" class=""text-muted"">İçerik</a>
                            </li>
                            <li class=""breadcrumb-item"">
                                <a href=""Admin/Icerik/IlgiAlanKayit"" class=""text-muted"">Ilgi Alan ");
            WriteLiteral(@"Kayıt</a>
                            </li>

                        </ul>
                    </div>
                </div>


            </div>
        </div>

        <div class=""content flex-column-fluid"" id=""kt_content"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""card card-custom gutter-b example example-compact"">
                        <div class=""card-header"">
                            <h3 class=""card-title"">Kayıt Alanları</h3>

                        </div>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c9cd00b04ddfca9d2fbd1a98b876499d9c9aa5711574", async() => {
                WriteLiteral("\r\n                            <input id=\"hdnIlgiAlanId\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1878, "\"", 1903, 1);
#nullable restore
#line 39 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"
WriteAttributeValue("", 1886, Model.IlgiAlanId, 1886, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                            <div class=""card-body"">
                                <div class=""form-group row"">

                                    <div class=""col-lg-6"">
                                        <label><span class=""text-danger"">* </span>Adı:</label>
                                        <div class=""input-group"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0c9cd00b04ddfca9d2fbd1a98b876499d9c9aa5712695", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 46 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IlgiAlanAdi);

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
                                                    <i class=""la la-bookmark-o""></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""col-lg-3"">
                                        <label>Sıra:</label>
                                        <div class=""input-group"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0c9cd00b04ddfca9d2fbd1a98b876499d9c9aa5715273", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 57 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Sira);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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
                                                    <i class=""la la-sort-numeric-down""></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""col-lg-3"">
                                        <label>Aktif Mi?:</label>
                                        <div class=""input-group"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0c9cd00b04ddfca9d2fbd1a98b876499d9c9aa5717857", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 68 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.AktifMi);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
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
                                        </div>
                                    </div>

                                </div>

                            
                                <div class=""form-group row"">
                                    <div class=""col-lg-12"">
                                        <div class=""fileinput fileinput-new"" data-provides=""fileinput"">
                                            <div class=""fileinput-new thumbnail"" style=""height: 100px; float:left;max-height:300px;max-width:300px"">

");
#nullable restore
#line 80 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"
                                                 if (string.IsNullOrEmpty(Model.ResimUrl))
                                                {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0c9cd00b04ddfca9d2fbd1a98b876499d9c9aa5720964", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 84 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"

                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <img style=\"max-height:200px;max-width:150px\"");
                BeginWriteAttribute("src", " src=\"", 5076, "\"", 5140, 2);
                WriteAttributeValue("", 5082, "data:image/png;base64,", 5082, 22, true);
#nullable restore
#line 88 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"
WriteAttributeValue("", 5104, Convert.ToBase64String(Model.Resim), 5104, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"emptyFile\" />\r\n");
#nullable restore
#line 89 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"

                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                            </div>
                                            <div class=""fileinput-preview fileinput-exists thumbnail"" style="" max-height: 200px;float:left""> </div>
                                            <div style=""float:left"">
                                                <span class=""btn default btn-file"">

                                                    <input id=""file"" name=""file"" type=""file"">
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class=""card-footer"">
                                <div class=""row"">
                                    <div class=""col-lg-6"">
");
#nullable restore
#line 107 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"
                                         if (Model.IlgiAlanId > 0)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <button id=\"btnGuncelle\" type=\"submit\" class=\"btn btn-success mr-2\">Güncelle</button>\r\n");
#nullable restore
#line 110 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <button id=\"btnKaydet\" type=\"submit\" class=\"btn btn-primary mr-2\">Kaydet</button>\r\n");
#nullable restore
#line 114 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Icerik\IlgiAlanKayit.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                        <button type=""button"" class=""btn btn-secondary"" onclick='location.reload();'>İptal</button>

                                    </div>

                                </div>
                            </div>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_15.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_15);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""/Themes/Admin/dist/assets/plugins/custom/ckeditor/ckeditor-classic.bundle.js?v=7.0.5""></script>

    <script src=""/Themes/Admin/dist/assets/js/pages/crud/forms/widgets/bootstrap-switch.js?v=7.0.5""></script>
    <script src=""/Themes/Admin/dist/assets/js/pages/crud/forms/widgets/bootstrap-datepicker.js?v=7.0.5""></script>

    <script type=""text/javascript"">
        FormValidation.formValidation(
            document.getElementById('_form'),
            {
                fields: {
                    IlgiAlanAdi: {
                        validators: {
                            notEmpty: {
                                message: 'Zorunlu alan'
                            }
                        }
                    },

                },
                plugins: {
                    submitButton: new FormValidation.plugins.SubmitButton(),
                    bootstrap: new FormValidation.plugins.Bootstrap({
                        eleInvalidClass: '',
            ");
                WriteLiteral(@"            eleValidClass: '',
                    })
                }
            }
        ).on('core.form.valid', function () {

            var data = new FormData($('#_form')[0]);
            var totalFiles = document.getElementById(""file"").files.length;
            for (var i = 0; i < totalFiles; i++) {
                var file = document.getElementById(""file"").files[i];
                data.append('Resim', file);
            }
            data.append('IlgiAlanId', $('#hdnIlgiAlanId').val());
            data.append('AktifMi', $('#AktifMi').prop('checked'));
            $.ajax({
                type: ""post"",
                url: ""/Admin/Icerik/IlgiAlanKayit"",
                data: data,
                contentType: false,
                processData: false,
                beforeSend: function () {
                    showLoading('_form');
                },
                success: function (result) {
                    hideLoading('_form');


                    if (result");
                WriteLiteral(@".id > 0) {
                        $('#hdnIlgiAlanId').val(result.id);

                        if (result.operation == ""insert"") {
                            $(""#btnKaydet"").removeClass('btn-primary');
                            $(""#btnKaydet"").addClass('btn-success');
                            $(""#btnKaydet"").html('Güncelle');
                            window.history.pushState("""", """", ""IlgiAlanKayit/"" + result.id);
                        }

                        Swal.fire({
                            icon: 'success',
                            title: 'İşlem Başarılı!',
                            text: '',
                            showCloseButton: true,
                            confirmButtonText: ""Tamam"",
                            cancelButtonText: ""İptal"",
                        });
                    }
                    else if (result.id == -1) {
                        Swal.fire({
                            icon: 'warning',
                            title:");
                WriteLiteral(@" 'Uyarı!',
                            text: 'Bu İsim de İlgi Alanı Mevcut',
                            showCloseButton: true,
                            confirmButtonText: ""Tamam"",
                            cancelButtonText: ""İptal"",
                        });
                    }
                    else {
                        Swal.fire({
                            icon: 'error',
                            title: 'İşlem Sırasında Hata Oluştu!',
                            text: '',
                            showCloseButton: true,
                            confirmButtonText: ""Tamam"",
                            cancelButtonText: ""İptal"",
                        });
                    }
                },

                error: function (err) {
                    hideLoading('_form');

                    Swal.fire(
                        ""Hata"",
                        ""İşlem sırasında hata oluştu. "" + err,
                        ""error""
                    )
  ");
                WriteLiteral(@"              }
            });

        }

        );
        function showLoading(id) {
            KTApp.block(document.getElementById(id), {
                overlayColor: '#000000',
                state: 'danger',
                message: 'Lütfen bekleyin...'
            });
        };
        function hideLoading(id) {
            KTApp.unblock(document.getElementById(id));
        };
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#emptyFile').attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }

        $(""#file"").change(function () {
            readURL(this);
        });

    
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NeSever.Common.Models.Icerik.IlgiAlanVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
