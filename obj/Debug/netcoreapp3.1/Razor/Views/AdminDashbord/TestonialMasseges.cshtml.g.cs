#pragma checksum "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f90dfffb5ce2f247ca384af7a1dc32e84fc252d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminDashbord_TestonialMasseges), @"mvc.1.0.view", @"/Views/AdminDashbord/TestonialMasseges.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f90dfffb5ce2f247ca384af7a1dc32e84fc252d", @"/Views/AdminDashbord/TestonialMasseges.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e5c3d39956c41e4926d06204a2325a78e206429", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminDashbord_TestonialMasseges : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TUITY_STORE.Models.Test_emonial>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml"
  
    Layout = "_DashbordLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content"" style=""margin-left:100px;"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-lg-10 col-md-10"">
                <div class=""card"">
                    <div class=""card-header card-header-tabs card-header-primary"">
                        <div class=""nav-tabs-navigation"">
                            <div class=""nav-tabs-wrapper"">
                                <span class=""nav-tabs-title"">Testmonial Message</span>
                                

                            </div>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class=""tab-content"">
                            <div class=""tab-pane active"" id=""profile"">
                                <table class=""table"">
                                    <thead class=""text-warning"">
                                        <tr>
                                            <th>User ID</th>
         ");
            WriteLiteral(@"                                   <th>User Name</th>
                                            <th>Testemonial ID</th>
                                            <th>Testemonial Message</th>
                                            <th>User Image</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 36 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 39 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml"
                                           Write(item.user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 40 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml"
                                           Write(item.user.Fname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 41 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml"
                                           Write(item.testmonial.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 42 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml"
                                           Write(item.testmonial.UserMassege);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n                                                <img");
            BeginWriteAttribute("src", " src=", 2198, "", 2247, 1);
#nullable restore
#line 44 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml"
WriteAttributeValue("", 2203, Url.Content("~/Image/"+item.user.Imagepath), 2203, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""Alterenate Text"" width=""100"" height=""100"" />
                                            </td>
                                            <td>
                                                <button type=""button"" rel=""tooltip"" title=""Edit Task"" class=""btn btn-primary btn-link btn-sm"">
                                                    <a");
            BeginWriteAttribute("href", " href=\"", 2598, "\"", 2642, 2);
            WriteAttributeValue("", 2605, "/Testmonials/Edit/", 2605, 18, true);
#nullable restore
#line 48 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml"
WriteAttributeValue("", 2623, item.testmonial.Id, 2623, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""material-icons"">edit</i></a>
                                                </button>
                                            </td>
                                            <td>
                                                <div>
                                                    <button type=""button"" rel=""tooltip"" title=""Remove"" class=""btn btn-danger btn-link btn-sm"">
                                                        <a");
            BeginWriteAttribute("href", " href=\"", 3101, "\"", 3147, 2);
            WriteAttributeValue("", 3108, "/Testmonials/Delete/", 3108, 20, true);
#nullable restore
#line 54 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml"
WriteAttributeValue("", 3128, item.testmonial.Id, 3128, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""material-icons"">close</i></a>
                                                    </button>
                                                </div>
                                            </td>

                                        </tr>
");
#nullable restore
#line 60 "D:\Tahaluf First Project (Store)\TUITY STORE\Views\AdminDashbord\TestonialMasseges.cshtml"

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>





");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TUITY_STORE.Models.Test_emonial>> Html { get; private set; }
    }
}
#pragma warning restore 1591
