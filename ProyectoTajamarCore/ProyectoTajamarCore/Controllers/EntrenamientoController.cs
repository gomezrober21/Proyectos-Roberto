using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarCore.Filters;
using ProyectoTajamarCore.Models;
using ProyectoTajamarCore.Repositories;

namespace ProyectoTajamarCore.Controllers
{
    public class EntrenamientoController : Controller
    {
        RepositoryClinica repo;
        public EntrenamientoController(RepositoryClinica repo)
        {
            this.repo = repo;
        }
        [UsuariosAuthorize]
        public IActionResult CogerCita()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CogerCita(ConsultaEntrenamiento consulta)
        {
            await this.repo.CogerCitaEntrenamiento(consulta.Id
                , consulta.Nombre, consulta.Apellido, consulta.Fecha, /*consulta.Hora,*/ consulta.Edad, consulta.Telefono);
            return RedirectToAction("Index", "Home");
        }
    }
}