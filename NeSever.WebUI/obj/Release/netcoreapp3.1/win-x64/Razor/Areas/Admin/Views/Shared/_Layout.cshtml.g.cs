#pragma checksum "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "162acfa2d01701e26785dcaf8cfb4158d44140f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__Layout), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_Layout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"162acfa2d01701e26785dcaf8cfb4158d44140f4", @"/Areas/Admin/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b76a0a34bd0a8b80dec4af84b64c200dd6debf11", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Areas/Admin/Views/Shared/Partials/Header.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Areas/Admin/Views/Shared/Partials/Menu.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Areas/Admin/Views/Shared/Partials/Footer.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("kt_body"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("header-fixed header-mobile-fixed page-loading"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Shared\_Layout.cshtml"
  var kullaniciGirisModel = ViewBag.KullaniciGirisData as YoneticiKullaniciGirisVM; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Shared\_Layout.cshtml"
  
    var controller = @ViewContext.RouteData.Values["Controller"].ToString();
    var action = @ViewContext.RouteData.Values["Action"].ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "162acfa2d01701e26785dcaf8cfb4158d44140f45975", async() => {
                WriteLiteral(@"
    <title>Nesever.Net Yönetim Paneli</title>

    <meta charset=""utf-8"">
    <meta name=""description"" content=""Login page example"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"" />

    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700"" />
    <link rel=""shortcut icon"" href=""/favicon.ico"" type=""image/x-icon"">
    <link rel=""icon"" href=""/favicon.ico"" type=""image/x-icon"">

    <link href=""/Themes/Admin/dist/assets/css/pages/login/classic/login-4.css?v=7.0.5"" rel=""stylesheet"" type=""text/css"" />
    <link href=""/Themes/Admin/dist/assets/plugins/global/plugins.bundle.css?v=7.0.5"" rel=""stylesheet"" type=""text/css"" />
    <link href=""/Themes/Admin/dist/assets/plugins/custom/prismjs/prismjs.bundle.css?v=7.0.5"" rel=""stylesheet"" type=""text/css"" />
    <link href=""/Themes/Admin/dist/assets/css/style.bundle.css?v=7.0.5"" rel=""stylesheet"" type=""text/css"" />

    <link rel=""shortcut icon"" href=""/Themes/Admin/dist/as");
                WriteLiteral("sets/media/logos/favicon.ico\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "162acfa2d01701e26785dcaf8cfb4158d44140f48091", async() => {
                WriteLiteral(@"
    <div class=""d-flex flex-column flex-root"">
        <div class=""d-flex flex-row flex-column-fluid page"">
            <div class=""d-flex flex-column flex-row-fluid wrapper"" id=""kt_wrapper"">
                <div id=""kt_header_mobile"" class=""header-mobile header-mobile-fixed"">
                    <a href=""/Admin"">
                        <img alt=""Logo"" src=""/Uploads/Site/logo.png"" class=""max-h-30px"" />
                    </a>

                    <div class=""d-flex align-items-center"">
                        <button class=""btn p-0 burger-icon burger-icon-left"" id=""kt_header_mobile_toggle"">
                            <span></span>
                        </button>
                        <button class=""btn p-0 ml-4"" id=""kt_header_mobile_topbar_toggle"">
                            <span class=""svg-icon svg-icon-xxl"">
                                <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">");
                WriteLiteral(@"
                                    <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                        <polygon points=""0 0 24 0 24 24 0 24"" />
                                        <path d=""M12,11 C9.790861,11 8,9.209139 8,7 C8,4.790861 9.790861,3 12,3 C14.209139,3 16,4.790861 16,7 C16,9.209139 14.209139,11 12,11 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3"" />
                                        <path d=""M3.00065168,20.1992055 C3.38825852,15.4265159 7.26191235,13 11.9833413,13 C16.7712164,13 20.7048837,15.2931929 20.9979143,20.2 C21.0095879,20.3954741 20.9979143,21 20.2466999,21 C16.541124,21 11.0347247,21 3.72750223,21 C3.47671215,21 2.97953825,20.45918 3.00065168,20.1992055 Z"" fill=""#000000"" fill-rule=""nonzero"" />
                                    </g>
                                </svg>
                            </span>
                        </button>
                    </div>
                </div>

                <div id=""kt_hea");
                WriteLiteral("der\" class=\"header flex-column header-fixed\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "162acfa2d01701e26785dcaf8cfb4158d44140f410606", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "162acfa2d01701e26785dcaf8cfb4158d44140f411807", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n\r\n                ");
#nullable restore
#line 61 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Shared\_Layout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "162acfa2d01701e26785dcaf8cfb4158d44140f413286", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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

    <div id=""kt_quick_user"" class=""offcanvas offcanvas-right p-10"">
        <div class=""offcanvas-header d-flex align-items-center justify-content-between pb-5"">
            <h3 class=""font-weight-bold m-0"">
                Yönetici Paneli
                <small class=""text-muted font-size-sm ml-2"">");
                WriteLiteral(@"</small>
            </h3>
            <a href=""#"" class=""btn btn-xs btn-icon btn-light btn-hover-primary"" id=""kt_quick_user_close"">
                <i class=""ki ki-close icon-xs text-muted""></i>
            </a>
        </div>

        <div class=""offcanvas-content pr-5 mr-n5"">
            <div class=""d-flex align-items-center mt-5"">
                <div class=""symbol symbol-100 mr-5"">
                    <div class=""symbol-label"" style=""background-image: url('/Themes/Admin/dist/assets/media/users/blank.png') ""></div>
                    <i class=""symbol-badge bg-success""></i>
                </div>
                <div class=""d-flex flex-column"">
                    <a href=""#"" class=""font-weight-bold font-size-h5 text-dark-75 text-hover-primary"">");
#nullable restore
#line 86 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Shared\_Layout.cshtml"
                                                                                                  Write(kullaniciGirisModel ==null? "nesever@nesever.com" :kullaniciGirisModel.Eposta);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                    <div class=\"text-muted mt-1\">Yönetici Kullanıcı</div>\r\n                    <div class=\"navi mt-2\">\r\n                        <a");
                BeginWriteAttribute("href", " href=\"", 5218, "\"", 5251, 3);
                WriteAttributeValue("", 5225, "/Admin/", 5225, 7, true);
#nullable restore
#line 89 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 5232, controller, 5232, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5245, "/Cikis", 5245, 6, true);
                EndWriteAttribute();
                WriteLiteral(@" class=""btn btn-sm btn-light-primary font-weight-bolder py-2 px-5"">Çıkış</a>
                    </div>
                </div>
            </div>

            <div class=""separator separator-dashed mt-8 mb-5""></div>
        </div>
    </div>

    <div id=""kt_scrolltop"" class=""scrolltop"">
        <span class=""svg-icon"">
            <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                    <polygon points=""0 0 24 0 24 24 0 24"" />
                    <rect fill=""#000000"" opacity=""0.3"" x=""11"" y=""10"" width=""2"" height=""10"" rx=""1"" />
                    <path d=""M6.70710678,12.7071068 C6.31658249,13.0976311 5.68341751,13.0976311 5.29289322,12.7071068 C4.90236893,12.3165825 4.90236893,11.6834175 5.29289322,11.2928932 L11.2928932,5.29289322 C11.6714722,4.91431428 12.2810586,4.90106866 12.6757246,5.26284586 L18.675724");
                WriteLiteral(@"6,10.7628459 C19.0828436,11.1360383 19.1103465,11.7686056 18.7371541,12.1757246 C18.3639617,12.5828436 17.7313944,12.6103465 17.3242754,12.2371541 L12.0300757,7.38413782 L6.70710678,12.7071068 Z"" fill=""#000000"" fill-rule=""nonzero"" />
                </g>
            </svg>
        </span>
    </div>

    <script>var HOST_URL = ""https://keenthemes.com/metronic/tools/preview"";</script>

    <script>var KTAppSettings = { ""breakpoints"": { ""sm"": 576, ""md"": 768, ""lg"": 992, ""xl"": 1200, ""xxl"": 1200 }, ""colors"": { ""theme"": { ""base"": { ""white"": ""#ffffff"", ""primary"": ""#6993FF"", ""secondary"": ""#E5EAEE"", ""success"": ""#1BC5BD"", ""info"": ""#8950FC"", ""warning"": ""#FFA800"", ""danger"": ""#F64E60"", ""light"": ""#F3F6F9"", ""dark"": ""#212121"" }, ""light"": { ""white"": ""#ffffff"", ""primary"": ""#E1E9FF"", ""secondary"": ""#ECF0F3"", ""success"": ""#C9F7F5"", ""info"": ""#EEE5FF"", ""warning"": ""#FFF4DE"", ""danger"": ""#FFE2E5"", ""light"": ""#F3F6F9"", ""dark"": ""#D6D6E0"" }, ""inverse"": { ""white"": ""#ffffff"", ""primary"": ""#ffffff"", ""secondary"": ""#212121"", ""success"": """);
                WriteLiteral(@"#ffffff"", ""info"": ""#ffffff"", ""warning"": ""#ffffff"", ""danger"": ""#ffffff"", ""light"": ""#464E5F"", ""dark"": ""#ffffff"" } }, ""gray"": { ""gray-100"": ""#F3F6F9"", ""gray-200"": ""#ECF0F3"", ""gray-300"": ""#E5EAEE"", ""gray-400"": ""#D6D6E0"", ""gray-500"": ""#B5B5C3"", ""gray-600"": ""#80808F"", ""gray-700"": ""#464E5F"", ""gray-800"": ""#1B283F"", ""gray-900"": ""#212121"" } }, ""font-family"": ""Poppins"" };</script>

    <script src=""/Themes/Admin/dist/assets/plugins/global/plugins.bundle.js?v=7.0.5""></script>
    <script src=""/Themes/Admin/dist/assets/plugins/custom/prismjs/prismjs.bundle.js?v=7.0.5""></script>
    <script src=""/Themes/Admin/dist/assets/js/scripts.bundle.js?v=7.0.5""></script>
    <script src=""/js/jquery.serializeObject.min.js""></script>

    ");
#nullable restore
#line 119 "D:\Programlar\NeSeverProject\NeSever.WebUI\Areas\Admin\Views\Shared\_Layout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
