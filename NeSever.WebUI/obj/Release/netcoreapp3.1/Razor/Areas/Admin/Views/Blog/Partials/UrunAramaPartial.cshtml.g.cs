#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Blog\Partials\UrunAramaPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b44023d33be582771e443d74e41bb2122b71b13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Blog_Partials_UrunAramaPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Blog/Partials/UrunAramaPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b44023d33be582771e443d74e41bb2122b71b13", @"/Areas/Admin/Views/Blog/Partials/UrunAramaPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b76a0a34bd0a8b80dec4af84b64c200dd6debf11", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Blog_Partials_UrunAramaPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NeSever.Common.Models.Urun.UrunAramaVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_formAra"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b44023d33be582771e443d74e41bb2122b71b135025", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5b44023d33be582771e443d74e41bb2122b71b135287", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 4 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Blog\Partials\UrunAramaPartial.cshtml"
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
                WriteLiteral("\r\n    <div class=\"col-md-12\">\r\n        <div class=\"col-md-6\" style=\"float:left\">\r\n            <label class=\"control-label\">SKU</label>\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5b44023d33be582771e443d74e41bb2122b71b137167", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 8 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Blog\Partials\UrunAramaPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Sku);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-6\" style=\"float:left\">\r\n            <label class=\"control-label\">Ürün Adı</label>\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5b44023d33be582771e443d74e41bb2122b71b138905", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 12 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Blog\Partials\UrunAramaPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UrunAdi);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
    <div class=""col-md-12"">
    
            <button type=""button"" onclick=""javascript: urunAra();"" style=""margin-top:1%;margin-left:47%"" class=""btn btn-primary btn-primary--icon"">Ara <i class=""la la-search""></i></button>
       
    </div>
        <div class=""col-md-12"">
            <table id=""dtArama"" class=""table table-bordered table-hover table-checkable"">
                <thead>
                    <tr>
                        <th></th>
                        <th>UrunId</th>
                        <th>Sku</th>
                        <th>UrunAdi</th>
                    </tr>
                </thead>
            </table>
        </div>
        <div class=""col-md-12"">
         
                <button type=""button"" onclick=""javascript: UrunleriSec();"" style=""margin-top:1%"" class=""btn btn-primary btn-primary--icon"">Ürünleri Ekle</button>
          

        </div>







");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script src=""/Themes/Admin/dist/assets/plugins/custom/datatables/datatables.bundle.js?v=7.0.5""></script>

<script type=""text/javascript"">
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
    function UrunleriSec() {
        var secilenUrunlerArray = [];
        $.each($(""input[name^='selectedCheckbox']""), function (key, value) {
            if ($(this)[0].checked == true) {
                secilenUrunlerArray.push($(this).val());
            }
        });
    

    
        $.ajax({
            url: '../../../Admin/Blog/UrunListesiGuncelle',
            type: ""Get"",
            contentType: ""application/json; charset=utf-8"",
            dataType: 'JSON',
            data: {
                seciliUrunler: JSON.stringify(secilenUrunle");
            WriteLiteral(@"rArray)
            },
            success: function (result) {

                $('#m_modal').modal('hide');
                var tbl = $('#urunTable');
                $('#urunTable tr').remove();
                var rowBaslik = $('<tr></tr>').attr({ class: [""class1"", ""class2"", ""class3""].join(' ') }).appendTo(tbl);
                $('<th>SKU</th><th>Urun Adi</th><th></th>').appendTo(rowBaslik);
                for (var i = 0; i < result.length; i++) {
                    var row = $('<tr></tr>').attr({ class: [""class1"", ""class2"", ""class3""].join(' ') }).appendTo(tbl);
                    $('<td></td>').text(result[i].Sku).appendTo(row);
                    $('<td></td>').text(result[i].UrunAdi).appendTo(row);
                    $('<td><input type=""button"" onclick=""UrunSil(' + result[i].UrunId + ')"" class=""btn btn-warning"" value=""Sil""></button></td>').appendTo(row);
                }

                tbl.appendTo($(""#urunTableDiv""));

            },
            error: function () {
       ");
            WriteLiteral(@"         alert(""hata"");
            }
        });

    }

    function urunAra() {

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
            ajax: {

                url: ""/Admin/Blog/UrunAramaSonuclariniGetir"",
                type: ""POST"",

                dataType: ""json"",
                data: sendData,
                beforeSend: function () {
                    showLoading('dtArama');
                },
                complete: function () {
                    hideLoading('dtArama');
                },
                error: function (error) {
                    hideLoading('dtArama');
                }
            },

            columns: [
               ");
            WriteLiteral(@" { data: 'UrunId', defaultContent: '' },
                { data: 'UrunId', defaultContent: '' },
                { data: 'Sku', defaultContent: '' },
                { data: 'UrunAdi', defaultContent: '' }


            ],
            columnDefs: [
                {
                    targets: 0, width: '5%', ""render"": function (data) {

                        return '<input type=""checkbox"" name=""selectedCheckbox"" id=""chc' + data + '""  value=""'
                            + $('<div/>').text(data).html() + '"">';

                    },
                },

                { targets: 1, width: '5%' },
                { targets: 2, width: '5%' },
                { targets: 3, width: '5%' },
            ],
            dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
                    <'row'<'col-sm-12'tr>>
                    <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
            lengthMenu: [[5, 25, 50], [5, 25, 50]],
            buttons: [],");
            WriteLiteral("\r\n            language: {\r\n                url: \'https://cdn.datatables.net/plug-ins/1.10.21/i18n/Turkish.json\'\r\n            }\r\n        });\r\n\r\n    }\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NeSever.Common.Models.Urun.UrunAramaVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
