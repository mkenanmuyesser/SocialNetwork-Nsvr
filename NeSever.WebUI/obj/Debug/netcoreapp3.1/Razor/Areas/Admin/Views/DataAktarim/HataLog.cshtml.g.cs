#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\DataAktarim\HataLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6e667837de62e283ca293b5a987959778643010"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_DataAktarim_HataLog), @"mvc.1.0.view", @"/Areas/Admin/Views/DataAktarim/HataLog.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6e667837de62e283ca293b5a987959778643010", @"/Areas/Admin/Views/DataAktarim/HataLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b76a0a34bd0a8b80dec4af84b64c200dd6debf11", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_DataAktarim_HataLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NeSever.Common.Models.DataAktarim.HataLogVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control datatable-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control selectpicker"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Başlangıç"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Bitiş"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-date-format", new global::Microsoft.AspNetCore.Html.HtmlString("dd/mm/yyyy"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-provide", new global::Microsoft.AspNetCore.Html.HtmlString("datepicker"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("kt-form kt-form--fit mb-15"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\DataAktarim\HataLog.cshtml"
  
    ViewData["Title"] = "HataLog";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""d-flex flex-row flex-column-fluid container"">
    <div class=""main d-flex flex-column flex-row-fluid"">
        <div class=""subheader py-2 py-lg-4 subheader-transparent"" id=""kt_subheader"">
            <div class=""container d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap"">
                <div class=""d-flex align-items-center flex-wrap mr-1"">
                    <div class=""d-flex align-items-baseline flex-wrap mr-5"">
                        <h5 class=""text-dark font-weight-bold my-1 mr-5"">Hata Log</h5>

                        <ul class=""breadcrumb breadcrumb-transparent breadcrumb-dot font-weight-bold p-0 my-2 font-size-sm"">
                            <li class=""breadcrumb-item"">
                                <a href=""/Admin/DataAktarim"" class=""text-muted"">Data Aktarım</a>
                            </li>
                            <li class=""breadcrumb-item"">
                                <a href=""/Admin/DataAktarim/HataLog"" class=""text-muted"">Hata L");
            WriteLiteral(@"og</a>
                            </li>
                        </ul>
                    </div>
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
                        <div class=""dropdown dropdown-inline mr-2"">
                         
                            <div class=""dropdown-menu dropdown-menu-sm dropdown-menu-right"">
                                <ul class=""navi flex-column navi-hover py-2"">
                                    <li class=""navi-header fo");
            WriteLiteral(@"nt-weight-bolder text-uppercase font-size-sm text-primary pb-2"">Seçiniz:</li>
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
                                            <span class=""navi-icon"">
                                                <i class=""la la-file-excel-o""></i>
                                            </span>
                                            <span class=""navi-text"">Excel</span>
                    ");
            WriteLiteral(@"                    </a>
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
                    </div>
                </div>
                <div class=""card-body"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6e667837de62e283ca293b5a98795977864301011690", async() => {
                WriteLiteral("\r\n                        <div class=\"row mb-6\">\r\n                            <div class=\"col-lg-3 mb-lg-0 mb-6\">\r\n                                <label>ID:</label>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e6e667837de62e283ca293b5a98795977864301012156", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 79 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\DataAktarim\HataLog.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ErrorLogId);

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
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col-lg-3 mb-lg-0 mb-6\">\r\n                                <label>Web Site:</label>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6e667837de62e283ca293b5a98795977864301014243", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 83 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\DataAktarim\HataLog.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.WebSiteId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 83 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\DataAktarim\HataLog.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(Model.WebSiteListesi,"WebSiteId","WebSiteAdi"));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                            </div>\r\n                            <div class=\"col-lg-3 mb-lg-0 mb-6\">\r\n                                <label>Hata Icerik:</label>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e6e667837de62e283ca293b5a98795977864301016568", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 88 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\DataAktarim\HataLog.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.ErrorLogContent);

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
                                   </div>

                        </div>
                        <div class=""row mb-6"">
                            <div class=""col-lg-12 mb-lg-0 mb-6"">
                                <label>Tarih:</label>

                                <div class=""input-daterange input-group"" id=""kt_datepicker_5"" data-date-format=""dd/mm/yyyy"" data-provide=""datepicker"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e6e667837de62e283ca293b5a98795977864301019009", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
#nullable restore
#line 99 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\DataAktarim\HataLog.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e6e667837de62e283ca293b5a98795977864301021257", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
#nullable restore
#line 105 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\DataAktarim\HataLog.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BitisTarihi);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
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
                                <button type=""button"" onclick=""javascript: Ara();"" class=""btn btn-primary btn-primary--icon"">Ara <i class=""la la-search""></i></button>


                                <button class=""btn btn-secondary btn-secondary--icon"" id=""kt_reset"" onclick=""javascript: Temizle();"">
                                    <span>
                                        <i class=""la la-close""></i>
                                        <span>Temizle</span>
                                    </span>
                                </button>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                    <table class=""table table-bordered table-hover table-checkable"" id=""dtArama"">
                        <thead>
                            <tr>
                                <th>ErrorLogID</th>
                                <th>WebSite</th>
                                <th>ProcessName</th>
                                <th>ErrorLogContent</th>
                                <th>LastModifiedDate</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>ErrorLogID</th>
                                <th>WebSite</th>
                                <th>ProcessName</th>
                                <th>ErrorLogContent</th>
                                <th>LastModifiedDate</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>
            WriteLiteral("\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""/Themes/Admin/dist/assets/plugins/custom/datatables/datatables.bundle.js?v=7.0.5""></script>
    <script src=""/Themes/Admin/dist/assets/js/pages/crud/datatables/search-options/advanced-search.js?v=7.0.5""></script>
<script>
    function Ara() {

        var sendData = $('#_formAra').serializeObject();
        $('#dtArama').DataTable().destroy();

        var table = $('#dtArama').DataTable({
            processing: true,
            serverSide: true,
            filter: false,
            responsive: true,
            orderMulti: false,
            autoWidth: false,
            ordering: false,
            //fixedColumns: true,
            //deferRender: true,
            ajax: {

                url: ""/Admin/DataAktarim/HataLogAramaSonuclariniGetir"",
                type: ""POST"",

                dataType: ""json"",
                data: sendData,
                beforeSend: function () {
                    //showLoading();
                },
                comple");
                WriteLiteral(@"te: function () {
                    //hideLoading();
                },
                error: function (error) {
                    //hideLoading();
                    alert(error);
                }
            },

            columns: [
                { data: 'ErrorLogId', defaultContent: '' },
                { data: 'WebSiteAdi', defaultContent: '' },
                { data: 'ProcessName', defaultContent: '' },
                { data: 'ErrorLogContent', defaultContent: '' },
                { data: 'LastModifiedDate', defaultContent: '' },


            ],
            fixedColumns: true,
            columnDefs: [
                { targets: 0, width: '5%' },
                { targets: 1, width: '5%' },
                { targets: 2, width: '5%' },
                { targets: 3, width: '5%' },
                { targets: 4, width: '5%' },
              
            ],
            dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
                <'row'<'col-sm-12'tr>");
                WriteLiteral(@">
                <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
            lengthMenu: [[5, 25, 50], [5, 25, 50]],
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

    function Temizle() {

        $('#ErrorLogId').val('');
        $('#ErrorLogContent').val('');
        $(""#WebSiteId"").val(""-1"").change();
        $('#BaslangicTarihi').val("""");
        $('#BitisTarihi').val("""");


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NeSever.Common.Models.DataAktarim.HataLogVM> Html { get; private set; }
    }
}
#pragma warning restore 1591