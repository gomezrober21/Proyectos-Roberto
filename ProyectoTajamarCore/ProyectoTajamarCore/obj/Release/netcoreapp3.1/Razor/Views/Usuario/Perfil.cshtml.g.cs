#pragma checksum "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1e7c5c92c7d603d05f43cffe413e85c8c9690ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Perfil), @"mvc.1.0.view", @"/Views/Usuario/Perfil.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1e7c5c92c7d603d05f43cffe413e85c8c9690ea", @"/Views/Usuario/Perfil.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7136735eab21be7dabd16b108ae20e82263a21af", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Perfil : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProyectoTajamarCore.Models.Usuario>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
  
    ViewData["Title"] = "Perfil";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Perfil de usuario.</h1>\r\n\r\n<div>\r\n   \r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayNameFor(model => model.NombreUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayFor(model => model.NombreUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayNameFor(model => model.Edad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayFor(model => model.Edad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayNameFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 53 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
Write(Html.ActionLink("Modificar datos", "ModificarDatosUsuario", new { username = Model.NombreUsuario  }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 54 "C:\Users\rober\source\repos\ProyectoTajamarCore\ProyectoTajamarCore\Views\Usuario\Perfil.cshtml"
Write(Html.ActionLink("Eliminar Cuenta", "EliminarUsuario", new {  username = Model.NombreUsuario }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProyectoTajamarCore.Models.Usuario> Html { get; private set; }
    }
}
#pragma warning restore 1591
