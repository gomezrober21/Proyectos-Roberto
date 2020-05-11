using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarCore.Models;
using ProyectoTajamarCore.Repositories;

namespace ProyectoTajamarCore.Controllers
{
    [ViewComponent]
    public class AdministracionController : Controller
    {
        RepositoryClinica repo;
        public AdministracionController(RepositoryClinica repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> MostrarUsuarios()
        {
            List<Usuario> usuarios = await this.repo.GetUsuarios();
            return View(usuarios);
        }
        public async Task<IActionResult> EliminarUsuario(String username)
        {
            await this.repo.EliminarUsuario(username);
            return RedirectToAction("MostrarUsuarios");
        }

     
     
    }
}