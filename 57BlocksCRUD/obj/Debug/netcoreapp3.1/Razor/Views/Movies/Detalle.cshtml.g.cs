#pragma checksum "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8dc52dee163f045800a81d3a5f16d5681ad8ca9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Detalle), @"mvc.1.0.view", @"/Views/Movies/Detalle.cshtml")]
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
#line 1 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\_ViewImports.cshtml"
using _57BlocksCRUD;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\_ViewImports.cshtml"
using _57BlocksCRUD.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8dc52dee163f045800a81d3a5f16d5681ad8ca9", @"/Views/Movies/Detalle.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb9772f97a88870848662ba9ad5be662a80338d", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Detalle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_57BlocksCRUD.Models.MoviesModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <table class=""table-responsive table table-striped"">
               <thead class=""table-dark"">
                <tr>

                    <th>
                        <label>Movie name</label>
                    </th>
                    <th>
                        <label>Duration</label>
                    </th>
                    <th>
                        <label>Gender</label>
                    </th>
                    <th>
");
#nullable restore
#line 17 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                         if (Model.likes.Equals(true))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <label>Do you like it?</label>\r\n");
#nullable restore
#line 20 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </th>\r\n");
#nullable restore
#line 22 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                     if (Model.likes.Equals(false))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 833, "\"", 909, 1);
#nullable restore
#line 25 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
WriteAttributeValue("", 840, Url.Action("DeleteAllMyMovies", "Movies", new { id = Model.UserId }), 840, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"Delete everything\"><span class=\"material-icons\">remove_done</span></a>\r\n                        </th>\r\n");
#nullable restore
#line 27 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n            </thead>\r\n            <tbody>\r\n\r\n");
#nullable restore
#line 32 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                 foreach (var item in Model.DataShow)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 37 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                       Write(Html.DisplayFor(modelItem => item.MovieName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 40 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 43 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Gender[0].GenderDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n");
#nullable restore
#line 45 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                         if (Model.likes.Equals(false))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                <a href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1800, "\"", 1888, 10);
            WriteAttributeValue("", 1810, "Editar(", 1810, 7, true);
#nullable restore
#line 48 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
WriteAttributeValue("", 1817, item.id, 1817, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1825, ",", 1825, 1, true);
            WriteAttributeValue(" ", 1826, "\'", 1827, 2, true);
#nullable restore
#line 48 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
WriteAttributeValue("", 1828, item.MovieName.ToString(), 1828, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1854, "\',", 1854, 2, true);
#nullable restore
#line 48 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
WriteAttributeValue(" ", 1856, item.GenderId, 1857, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1871, ",", 1871, 1, true);
#nullable restore
#line 48 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
WriteAttributeValue(" ", 1872, item.Duration, 1873, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1887, ")", 1887, 1, true);
            EndWriteAttribute();
            WriteLiteral(" title=\"Edite\"><span class=\"material-icons\">build</span></a>\r\n                            </td>\r\n");
            WriteLiteral("                            <td>\r\n                                <!--");
#nullable restore
#line 52 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                               Write(Html.ActionLink("X", "Delete", "Movies", new { id = item.id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("-->\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2160, "\"", 2220, 1);
#nullable restore
#line 53 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
WriteAttributeValue("", 2167, Url.Action("Delete", "Movies", new { id = item.id }), 2167, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"Delete\"><span class=\"material-icons\">delete_outline</span></a>\r\n                            </td>\r\n");
#nullable restore
#line 55 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2480, "\"", 2544, 1);
#nullable restore
#line 59 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
WriteAttributeValue("", 2487, Url.Action("LikesMovie", "Movies", new { id = item.id }), 2487, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 60 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                                     if (item.likeIt.Equals(false))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"material-icons\">pan_tool</span> ");
#nullable restore
#line 61 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                                                                                  }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"material-icons\">thumb_up</span>");
#nullable restore
#line 63 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                                                                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </a>\r\n                            </td>\r\n");
#nullable restore
#line 66 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n");
#nullable restore
#line 68 "D:\Documentos\Prueba 57Blocks\57BlocksCRUD\57BlocksCRUD\57BlocksCRUD\Views\Movies\Detalle.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>

        <div id=""divConfirmacion"" style=""display: none"">
            <div class=""form-group"">
                <label class=""control-label"">Do you want to delete this record?</label>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_57BlocksCRUD.Models.MoviesModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
