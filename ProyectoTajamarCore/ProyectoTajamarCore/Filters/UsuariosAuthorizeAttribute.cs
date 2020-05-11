using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarCore.Filters
{
    public class UsuariosAuthorizeAttribute : AuthorizeAttribute
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //SOLO QUEREMOS QUE ENTREN LOS EMPLEADOS
            //NO TENDREMOS VALIDACION CON ROLES
            var usuario = context.HttpContext.User;
            if (usuario.Identity.IsAuthenticated == false)
            {
                //SI NO ESTA VALIDADO, LO ENVIAMOS A LOGIN
                //CONTROLLER, ACTION
                RouteValueDictionary rutalogin =
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Manage"
                            ,
                            action = "LogIn"
                        });
                RedirectToRouteResult action =
                    new RedirectToRouteResult(rutalogin);
                context.Result = action;
            }
        }
    }
}
