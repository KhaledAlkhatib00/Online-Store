#pragma checksum "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SendInvoice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b7dab24fd9b8e30f29d74ede4fc9c49da0b9068"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserDashbord_SendInvoice), @"mvc.1.0.view", @"/Views/UserDashbord/SendInvoice.cshtml")]
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
#line 1 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\_ViewImports.cshtml"
using TUITY_STORE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\_ViewImports.cshtml"
using TUITY_STORE.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b7dab24fd9b8e30f29d74ede4fc9c49da0b9068", @"/Views/UserDashbord/SendInvoice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e5c3d39956c41e4926d06204a2325a78e206429", @"/Views/_ViewImports.cshtml")]
    public class Views_UserDashbord_SendInvoice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TUITY_STORE.Models.Gmail>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SendInvoice.cshtml"
  
    Layout = "_UserDashbord";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b7dab24fd9b8e30f29d74ede4fc9c49da0b90683755", async() => {
                WriteLiteral("\r\n    <title>SendMail</title>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b7dab24fd9b8e30f29d74ede4fc9c49da0b90684756", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"row col-md-8 offset-md-2\">\r\n");
#nullable restore
#line 17 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SendInvoice.cshtml"
         using (Html.BeginForm("SendMail", "Gmail", FormMethod.Post, new { enctype = "multipart/form-data" }))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b7dab24fd9b8e30f29d74ede4fc9c49da0b90685400", async() => {
                    WriteLiteral("\r\n                <table>\r\n                    <tr>\r\n                        <td>\r\n                            To:\r\n                        </td>\r\n                        <td style=\"width:80px;\">\r\n                            ");
#nullable restore
#line 26 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SendInvoice.cshtml"
                       Write(Html.TextBoxFor(model => model.To));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            Subject:\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 34 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SendInvoice.cshtml"
                       Write(Html.TextBoxFor(model => model.Subject));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td valign=\"top\">\r\n                            Body:\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 42 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SendInvoice.cshtml"
                       Write(Html.TextAreaFor(model => model.Body));

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <input type=""submit"" value=""Send"" />
                        </td>

                    </tr>

                </table>
                <span style=""color:green"">");
#nullable restore
#line 54 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SendInvoice.cshtml"
                                     Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" </span>\r\n\r\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 57 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SendInvoice.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TUITY_STORE.Models.Gmail> Html { get; private set; }
    }
}
#pragma warning restore 1591
