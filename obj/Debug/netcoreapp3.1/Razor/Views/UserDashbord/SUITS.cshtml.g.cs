#pragma checksum "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "892a4af88e322894dfbbc11ae76e0a5882907778"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserDashbord_SUITS), @"mvc.1.0.view", @"/Views/UserDashbord/SUITS.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"892a4af88e322894dfbbc11ae76e0a5882907778", @"/Views/UserDashbord/SUITS.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e5c3d39956c41e4926d06204a2325a78e206429", @"/Views/_ViewImports.cshtml")]
    public class Views_UserDashbord_SUITS : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TUITY_STORE.Models.StoresPrductTable>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Adidas.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml"
  
    Layout = "_UserDashbord";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "892a4af88e322894dfbbc11ae76e0a58829077785095", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n");
#nullable restore
#line 8 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"container col-md-3 offset-md-1\">\r\n\r\n            <div class=\"card\">\r\n                <style>\r\n                    .container .card:after {\r\n                        content: \"");
#nullable restore
#line 15 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml"
                             Write(item.store.StoreName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
                        position: absolute;
                        top: 30%;
                        left: -10%;
                        font-size: 12em;
                        font-weight: 600;
                        font-style: italic;
                        color: rgba(255, 255, 255, 0.04);
                    }
                </style>

                <div class=""imgBx"">
                    <img");
            BeginWriteAttribute("src", " src=", 845, "", 900, 1);
#nullable restore
#line 27 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml"
WriteAttributeValue("", 850, Url.Content("~/Image/" + item.productt.Imagepath), 850, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alterenate Text\" width=\"100\" height=\"100\" />\r\n                </div>\r\n\r\n                <div class=\"contentBx\">\r\n\r\n                    <h2>");
#nullable restore
#line 32 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml"
                   Write(item.productt.Namee);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <h2>Sale: ");
#nullable restore
#line 33 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml"
                         Write(item.productt.Sale);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <h2>Price: ");
#nullable restore
#line 34 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml"
                          Write(item.productt.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</h2>\r\n\r\n\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "892a4af88e322894dfbbc11ae76e0a58829077788739", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "892a4af88e322894dfbbc11ae76e0a58829077789021", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 38 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
                WriteLiteral("\r\n");
                WriteLiteral("                        <div class=\"form-group\">\r\n                            <label hidden for=\"productid\"><i class=\"zmdi zmdi-lock\"></i></label>\r\n                            <input hidden type=\"text\" name=\"productid\" id=\"productid\"");
                BeginWriteAttribute("value", " value=\"", 2636, "\"", 2661, 1);
#nullable restore
#line 57 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml"
WriteAttributeValue("", 2644, item.productt.Id, 2644, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Product ID "" style=""width:200px; height:30px; font-size:20px;"" />
                        </div>
                        <div class=""form-group"">
                            <label for=""quantiti""><i class=""zmdi zmdi-lock""></i></label>
                            <input type=""number"" name=""quantiti"" id=""quantiti"" placeholder=""Quantity"" style=""width:200px; height:30px; font-size:20px;"" />
                        </div>
                        <div class=""form-group"">
                            <input type=""submit"" value=""Add To Cart"" class=""btn btn-primary"" style=""width:60px; height:30px;"" />
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                </div>\r\n                }\r\n\r\n            </div>\r\n\r\n            <br />\r\n\r\n        </div>\r\n");
#nullable restore
#line 76 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\UserDashbord\SUITS.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<br />\r\n<br />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TUITY_STORE.Models.StoresPrductTable>> Html { get; private set; }
    }
}
#pragma warning restore 1591
