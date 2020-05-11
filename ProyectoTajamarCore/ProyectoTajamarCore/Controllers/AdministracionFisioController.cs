using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarCore.Models;
using ProyectoTajamarCore.Repositories;

namespace ProyectoTajamarCore.Controllers
{
    public class AdministracionFisioController : Controller
    {
        RepositoryClinica repo;
        public AdministracionFisioController(RepositoryClinica repo)
        {
            this.repo = repo;
        }
        public async Task <IActionResult> MostrarCitasFisio()
        {
            List<ConsultaFisio> citas = await this.repo.GetConsultas();
            return View(citas);
        }

        public async Task<IActionResult> EliminarCitaFisio(int id)
        {
            await this.repo.EliminarCitaFisio(id);
            return RedirectToAction("MostrarCitasFisio");
        }

        public async Task<IActionResult> ModificarCitasfisio(int id)
        {
            ConsultaFisio cons = await this.repo.BuscarConsulta(id);
            return View(cons);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarCitasfisio(ConsultaFisio consulta)
        {
            await this.repo.ModificarCitaFisio(consulta.Id, consulta.Nombre, consulta.Apellido, consulta.Fecha, consulta.Edad, consulta.Direccion, consulta.Telefono);
            return RedirectToAction("MostrarCitasFisio");
        }

        public IActionResult CogerCita()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CogerCita(ConsultaFisio consulta)
        {
            await this.repo.CogerCitaFisio(consulta.Id
                , consulta.Nombre, consulta.Apellido, consulta.Fecha, /*consulta.Hora,*/ consulta.Edad, consulta.Direccion, consulta.Telefono);
            return RedirectToAction("MostrarCitasFisio");
        }
    }
}