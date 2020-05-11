using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarCore.Models;
using ProyectoTajamarCore.Repositories;

namespace ProyectoTajamarCore.Controllers
{
    public class ForoController : Controller
    {
        RepositoryClinica repo;
        public ForoController(RepositoryClinica repo)
        {
            this.repo = repo;
        }

        public async Task <IActionResult> Index()
        {
            
            List<Usuario> users = await this.repo.GetUsuarios();
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> Index(String comentarios, String nombreuser)
        {

            await this.repo.Comentarios(comentarios, nombreuser);
            return RedirectToAction("Index", "Foro");
        }
    }
}