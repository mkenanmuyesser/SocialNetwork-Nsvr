#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Kullanici\YoneticiKullaniciArama.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf8c66c4959414766e648ac38af69c2f6c6396db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Kullanici_YoneticiKullaniciArama), @"mvc.1.0.view", @"/Areas/Admin/Views/Kullanici/YoneticiKullaniciArama.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf8c66c4959414766e648ac38af69c2f6c6396db", @"/Areas/Admin/Views/Kullanici/YoneticiKullaniciArama.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b76a0a34bd0a8b80dec4af84b64c200dd6debf11", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Kullanici_YoneticiKullaniciArama : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NeSever.Common.Models.Admin.AramaVM.YoneticiKullaniciAramaVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control datatable-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "radio", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("kt-form kt-form--fit mb-15"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Kullanici\YoneticiKullaniciArama.cshtml"
  var yoneticiKullaniciGirisVM = ViewBag.KullaniciGirisData as YoneticiKullaniciGirisVM; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Kullanici\YoneticiKullaniciArama.cshtml"
  
    ViewData["Title"] = "YoneticiKullaniciArama";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex flex-row flex-column-fluid container"">
    <div class=""main d-flex flex-column flex-row-fluid"">
        <div class=""subheader py-2 py-lg-4 subheader-transparent"" id=""kt_subheader"">
            <div class=""container d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap"">
                <div class=""d-flex align-items-center flex-wrap mr-1"">
                    <div class=""d-flex align-items-baseline flex-wrap mr-5"">
                        <h5 class=""text-dark font-weight-bold my-1 mr-5"">Kullanıcı Arama</h5>

                        <ul class=""breadcrumb breadcrumb-transparent breadcrumb-dot font-weight-bold p-0 my-2 font-size-sm"">
                            <li class=""breadcrumb-item"">
                                <a href=""/Admin/Kullanici"" class=""text-muted"">Kullanıcı</a>
                            </li>
                            <li class=""breadcrumb-item"">
                                <a href=""/Admin/Kullanici/YoneticiKullaniciArama"" class=""t");
            WriteLiteral(@"ext-muted"">Kullanıcı Arama</a>
                            </li>
                        </ul>
                    </div>
                </div>

                <div class=""d-flex align-items-center"">
                    <a href=""/Admin/Kullanici/YoneticiKullaniciArama"" class=""btn btn-icon btn-circle btn-sm btn-light-success mr-1"" data-card-tool=""reload"">
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
                    <div class=""card-t");
            WriteLiteral(@"oolbar"">
                        <a href=""/Admin/Kullanici/YoneticiKullaniciKayit"" class=""btn btn-primary font-weight-bolder"">
                            <span class=""svg-icon svg-icon-md"">
                                <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                    <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                        <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                                        <circle fill=""#000000"" cx=""9"" cy=""15"" r=""6"" />
                                        <path d=""M8.8012943,7.00241953 C9.83837775,5.20768121 11.7781543,4 14,4 C17.3137085,4 20,6.6862915 20,10 C20,12.2218457 18.7923188,14.1616223 16.9975805,15.1987057 C16.9991904,15.1326658 17,15.0664274 17,15 C17,10.581722 13.418278,7 9,7 C8.93357256,7 8.86733422,7.00080962 8.8012943,7.00241953 Z"" fill=""#000000"" opacity=""0.3"" />
     ");
            WriteLiteral(@"                               </g>
                                </svg>
                            </span>Yeni Kayıt
                        </a>
                    </div>
                </div>
                <div class=""card-body"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf8c66c4959414766e648ac38af69c2f6c6396db10449", async() => {
                WriteLiteral("\r\n                        <div class=\"row mb-6\">\r\n                            <div class=\"col-lg-3 mb-lg-0 mb-6\">\r\n                                <label>Eposta:</label>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bf8c66c4959414766e648ac38af69c2f6c6396db10919", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 64 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Kullanici\YoneticiKullaniciArama.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Eposta);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
                            <div class=""col-lg-3 mb-lg-0 mb-6"">
                                <label>Aktif Mi?:</label>
                                <div class=""input-group"">
                                    <div class=""radio-inline"">
                                        <label class=""radio radio-lg"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bf8c66c4959414766e648ac38af69c2f6c6396db13133", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 71 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Kullanici\YoneticiKullaniciArama.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bf8c66c4959414766e648ac38af69c2f6c6396db15340", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 76 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Kullanici\YoneticiKullaniciArama.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bf8c66c4959414766e648ac38af69c2f6c6396db17548", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 81 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Kullanici\YoneticiKullaniciArama.cshtml"
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
                                   ");
                WriteLiteral(@"     <i class=""la la-close""></i>
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                    <table id=""dtArama"" class=""table table-bordered table-hover table-checkable"">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>E-posta</th>
                                <th>Kayıt Tarihi</th>
                                <th>Aktif</th>
                                <th>İşlemler</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>ID</th>
                                <th>E-posta</th>
                                <th>Kayıt Tarihi</th>
                                <th>Aktif</th>
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

    <script type=""text/javascript"">
        function ara() {
            var data = $('#_form').serializeObject();

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
                    url: '/Admin/Kullanici/YoneticiKullaniciArama',
                    type: ""POST"",
                    dataType: ""json"",
                    data: data,
                    beforeSend: function () {
                        showLoading('dtArama');
                    },
                    complete: function () {
  ");
                WriteLiteral(@"                      hideLoading('dtArama');
                    },
                    error: function (error) {
                        hideLoading('dtArama');

                        Swal.fire(
                            ""Hata"",
                            ""İşlem sırasında hata oluştu. "" + error,
                            ""error""
                        )
                    }
                },
                columns: [
                    { data: 'YoneticiKullaniciId', defaultContent: '' },
                    { data: 'Eposta', defaultContent: '' },
                    { data: 'KayitTarih', defaultContent: '' },
                    { data: 'AktifMi', defaultContent: '' },
                    { data: 'YoneticiKullaniciId', responsivePriority: -1 },
                ],
                columnDefs: [
                    { targets: 0, width: '5%' },
                    { targets: 1, width: '50%' },
                    { targets: 2, width: '15%' },
                    {
           ");
                WriteLiteral(@"             targets: 3,
                        width: '5%',
                        render: function (data) {
                            if (data == true) {
                                return '<span class=""label label-lg font-weight-bold label-light-success label-inline"">Aktif</span>';
                            }
                            else {
                                return '<span class=""label label-lg font-weight-bold label-light-danger label-inline"">Pasif</span>';
                            }
                        }
                    },
                    {
                        targets: 4,
                        width: '10%',
                        render: function (data) {
                            return ""<a href='#' onclick='sil("" + data + ""); return false;' class='btn btn-sm btn-clean btn-icon' title='Sil'><i class='la la-trash'></i></a>"" +
                                ""<a href='/Admin/Kullanici/YoneticiKullaniciKayit/"" + data + ""' class='btn btn-sm b");
                WriteLiteral(@"tn-clean btn-icon' title='Güncelle' ><i class='la la-edit'></i></a>"";
                        }
                    },
                ],
                dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
                              <'row'<'col-sm-12'tr>>
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
            ");
                WriteLiteral(@"});
        };

        function sil(id) {
            event.stopPropagation();
            $.ajaxSetup({ cache: false });

            Swal.fire({
                title: ""Emin misiniz?"",
                text: ""Veri silinecektir"",
                icon: ""warning"",
                showCancelButton: true,
                confirmButtonText: ""Evet"",
                cancelButtonText: ""İptal"",
            }).then(function (result) {
                if (result.value) {

                    $.ajax({
                        url: ""/Admin/Kullanici/YoneticiKullaniciSil/"" + id,
                        type: ""get"",
                        datatype: ""json"",
                        complete: function (data) {
                            if (data) {
                                ara();
                                Swal.fire(
                                    ""Silindi!"",
                                    ""Veri silinmiştir."",
                                    ""success""
                    ");
                WriteLiteral(@"            )
                            }
                            else {
                                Swal.fire(
                                    ""Hata"",
                                    ""İşlem sırasında hata oluştu."",
                                    ""error""
                                )
                            }
                        }
                    });
                }
            });
        };

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NeSever.Common.Models.Admin.AramaVM.YoneticiKullaniciAramaVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
