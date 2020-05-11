using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarCore.Models;
using ProyectoTajamarCore.Repositories;

namespace ProyectoTajamarCore.Controllers
{
    public class ManageController : Controller
    {
        RepositoryClinica repo;
        public ManageController(RepositoryClinica repo)
        {
            this.repo = repo;
        }

        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(String usuario, String password) { 

            //BUSCAMOS EL TOKEN PARA COMPROBAR LAS CREDENCIALES
            //DEL EMPLEADO
            String token = await this.repo.GetToken(usuario, password);
            //SI EL TOKEN ES NULL, NO TIENE CREDENCIALES
            if (token != null)
            {
                //SI TENEMOS TOKEN, TENEMOS EMPLEADO
                //POR LO QUE PODEMOS RECUPERARLO DEL METODO PERFILEMPLEADO
                Usuario user = await
                    this.repo.PerfilEmpleado(token);
                //CREAMOS AL USUARIO PARA EL ENTORNO MVC DE CORE
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                //ALMACENAMOS EL ID DE EMPLEADO
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier
                    , user.NombreUsuario.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.NombreUsuario));
                //GUARDAMOS TAMBIEN EL ROLE DEL EMPLEADO
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme, principal
                    , new AuthenticationProperties
                    {
                        IsPersistent = true
                    ,//DEBERIAMOS DAR EL MISMO TIEMPO DE SESSION QUE TOKEN
                        ExpiresUtc = DateTime.Now.AddMinutes(10)
                    });
                //UNA VEZ QUE TENEMOS A NUESTRO EMPLEADO ALMACENADO
                //DEBEMOS ALMACENAR EL TOKEN EN SESSION PARA PODER REUTILIZARLO
                //EN OTROS METODOS DE LA APP
                HttpContext.Session.SetString("TOKEN", token);
                //REDIRECCIONAMOS A UNA PAGINA DE INICIO PROTEGIDA
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = "Usuario/Contrasena incorrectos";
                return View();
            }
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);
            if (HttpContext.Session.GetString("TOKEN") != null)
            {
                HttpContext.Session.Remove("TOKEN");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}