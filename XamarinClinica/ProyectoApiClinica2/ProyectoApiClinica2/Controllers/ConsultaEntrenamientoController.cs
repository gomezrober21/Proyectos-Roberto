using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoApiClinica2.Data;
using ProyectoApiClinica2.Repositories;

namespace ProyectoApiClinica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaEntrenamientoController : ControllerBase
    {
        RepositoryClinica repo;
        public ConsultaEntrenamientoController(RepositoryClinica repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<ConsultaEntrenamiento>> Get()
        {
            return this.repo.GetConsultaEntrenamientos();
        }

        [HttpGet("{id}")]
        public ActionResult<ConsultaEntrenamiento> BuscarCitaEntrenamiento(int id)
        {
            return this.repo.BuscarConsultaEntrenamiento(id);
        }

        [HttpPost]
        public void CogerCitaEntrenamiento(ConsultaEntrenamiento consulta)
        {
            this.repo.CogerCitaEntrenamiento(consulta.Id, consulta.Nombre, consulta.Apellido, consulta.Fecha /*consulta.Hora*/, consulta.Edad, consulta.Telefono);
        }

        [HttpPut]
        public void ModificarCitaEntrPersonal(ConsultaEntrenamiento consulta)
        {
            this.repo.ModificarCitaEntrPersonal(consulta.Id, consulta.Nombre, consulta.Apellido, consulta.Fecha, consulta.Edad, consulta.Telefono);

        }

        [HttpDelete("{id}")]
        public void EliminarConsultaEntrenamiento(int id)
        {
            this.repo.EliminarConsultaEntrenamiento(id);
        }
    }
}