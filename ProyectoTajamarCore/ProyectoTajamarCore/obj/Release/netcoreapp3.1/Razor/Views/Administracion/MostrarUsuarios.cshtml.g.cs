#pragma checksum "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4689ceff37f809a04d08b6b0c819dc95244f85bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administracion_MostrarUsuarios), @"mvc.1.0.view", @"/Views/Administracion/MostrarUsuarios.cshtml")]
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
#line 1 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\_ViewImports.cshtml"
using ProyectoTajamarCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\_ViewImports.cshtml"
using ProyectoTajamarCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4689ceff37f809a04d08b6b0c819dc95244f85bf", @"/Views/Administracion/MostrarUsuarios.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7136735eab21be7dabd16b108ae20e82263a21af", @"/Views/_ViewImports.cshtml")]
    public class Views_Administracion_MostrarUsuarios : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProyectoTajamarCore.Models.Usuario>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
  
    ViewData["Title"] = "MostrarUsuarios";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Usuarios</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayNameFor(model => model.Contrasena));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayNameFor(model => model.Edad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayNameFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 37 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayFor(modelItem => item.NombreUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayFor(modelItem => item.Contrasena));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayFor(modelItem => item.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayFor(modelItem => item.Edad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayFor(modelItem => item.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
           Write(Html.ActionLink("Eliminar", "EliminarUsuario", new {  username=item.NombreUsuario}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 64 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Administracion\MostrarUsuarios.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProyectoTajamarCore.Models.Usuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
