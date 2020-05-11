using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarCore.Models;
using ProyectoTajamarCore.Repositories;

namespace ProyectoTajamarCore.Controllers
{
    public class UsuarioController : Controller
    {
        RepositoryClinica repo;
        public UsuarioController(RepositoryClinica repo)
        {
            this.repo = repo;
        }
       
        public IActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario usuario)
        {
            await this.repo.RegistrarUsuario(usuario.NombreUsuario, usuario.Contrasena, usuario.Nombre, usuario.Apellido, usuario.Edad, usuario.Telefono, usuario.Email);
            return RedirectToAction("Index", "Home");
        }

        public async Task <IActionResult> Perfil()
        {
            String tok = HttpContext.Session.GetString("TOKEN");
            Usuario usuario = await this.repo.PerfilEmpleado(tok);
           
            return View(usuario);
        }

        public async Task<IActionResult> ModificarDatosUsuario(String username)
        {
            Usuario user = await this.repo.BuscarUsuario(username);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarDatosUsuario(Usuario usuario)
        {
            await this.repo.ModificarPerfilUsuario(usuario.NombreUsuario, usuario.Contrasena, usuario.Nombre, usuario.Apellido, usuario.Edad, usuario.Telefono, usuario.Email);
            return RedirectToAction("Perfil");
        }

        public async Task<IActionResult> EliminarUsuario(String username)
        {
            await this.repo.EliminarUsuario(username);
            return RedirectToAction("Home", "Index");
        }
    }
}