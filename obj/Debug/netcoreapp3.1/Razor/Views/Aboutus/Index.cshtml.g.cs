#pragma checksum "D:\Tahaluf First Project (Store)\TUITY STORE\Views\Aboutus\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a887bb277ff33362258f8e20fab376a255360b39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Aboutus_Index), @"mvc.1.0.view", @"/Views/Aboutus/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a887bb277ff33362258f8e20fab376a255360b39", @"/Views/Aboutus/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e5c3d39956c41e4926d06204a2325a78e206429", @"/Views/_ViewImports.cshtml")]
    public class Views_Aboutus_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TUITY_STORE.Models.Aboutu>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\Aboutus\Index.cshtml"
  
    Layout = "_AboutDashbord";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("<table class=\"table\">\r\n");
            WriteLiteral("    <tbody>\r\n        <h1 style=\"text-align:center\" class=\"h1\">About Us</h1>\r\n");
#nullable restore
#line 23 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\Aboutus\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <tr>
                <td>
                    <div class=""container row"">
                        <h1 class=""col-md-2 offset-md-2"">About <span style=""color:blue"">T</span>UITY</h1>
                        <h3 class=""col-md-8"">
                            ");
#nullable restore
#line 30 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\Aboutus\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AboutText));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h3>\r\n                    </div>\r\n\r\n                </td>\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 41 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\Aboutus\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </tbody>
</table>
<br />
<br />
<h1 style=""text-align:center"">Location</h1>
<hr />

<br />
<br />
<div class=""mapouter row"" style=""margin-left:450px;"">
    <div class=""gmap_canvas"">
        <iframe width=""636"" height=""600"" id=""gmap_canvas"" src=""https://maps.google.com/maps?q=%D8%B9%D9%86%D8%A8%D9%87&t=&z=13&ie=UTF8&iwloc=&output=embed"" frameborder=""0"" scrolling=""no"" marginheight=""0"" marginwidth=""0""></iframe><br>
        <style>
            .mapouter {
                position: relative;
                text-align: right;
                height: 636px;
                width: 600px;
            }
        </style>
        <style>
            .gmap_canvas {
                overflow: hidden;
                background: none !important;
                height: 800px;
                width: 600px;
            }
        </style>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TUITY_STORE.Models.Aboutu>> Html { get; private set; }
    }
}
#pragma warning restore 1591
