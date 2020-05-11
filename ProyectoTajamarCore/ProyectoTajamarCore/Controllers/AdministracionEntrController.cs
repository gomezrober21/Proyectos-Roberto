using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarCore.Models;
using ProyectoTajamarCore.Repositories;

namespace ProyectoTajamarCore.Controllers
{
    public class AdministracionEntrController : Controller
    {
        RepositoryClinica repo;
        public AdministracionEntrController(RepositoryClinica repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> MostrarCitasEntr()
        {
            List<ConsultaEntrenamiento> consultaEntrenamientos = await this.repo.GetConsultasEntrenamiento();
            return View(consultaEntrenamientos);
        }

        public async Task<IActionResult> EliminarCitasEntrPersonal(int id)
        {
            await this.repo.EliminarConsultaEntrPersonal(id);
            return RedirectToAction("MostrarCitasEntr");
        }

        public async Task<IActionResult> ModificarCitasEntrPersonal(int id)
        {
            ConsultaEntrenamiento cons = await this.repo.BuscarCitaEntrPersonal(id);
            return View(cons);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarCitasEntrPersonal(ConsultaEntrenamiento consulta)
        {
            await this.repo.ModificarConsultaEntrPersonal(consulta.Id, consulta.Nombre, consulta.Apellido, consulta.Fecha, consulta.Edad, consulta.Telefono);
            return RedirectToAction("MostrarCitasEntr");
        }

        public IActionResult CogerCita()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CogerCita(ConsultaEntrenamiento consulta)
        {
            await this.repo.CogerCitaEntrenamiento(consulta.Id
                , consulta.Nombre, consulta.Apellido, consulta.Fecha, /*consulta.Hora,*/ consulta.Edad, consulta.Telefono);
            return RedirectToAction("MostrarCitasEntr");
        }
    }
}