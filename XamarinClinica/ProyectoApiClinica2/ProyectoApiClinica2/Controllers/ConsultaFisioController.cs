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
    public class ConsultaFisioController : ControllerBase
    {
        RepositoryClinica repo;
        public ConsultaFisioController(RepositoryClinica repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<ConsultaFisio>> Get()
        {
            return this.repo.GetConsultaFisio();
        }

        [HttpGet("{id}")]
        public ActionResult<ConsultaFisio> BuscarConsultaFisio(int id)
        {
            return this.repo.BuscarConsultaFisio(id);
        }

        [HttpPost]
        public void CogerCitaFisio(ConsultaFisio consulta)
        {
            this.repo.CogerCitaFisio(consulta.Id, consulta.Nombre, consulta.Apellido, consulta.Fecha/*, consulta.Hora*/, consulta.Edad, consulta.Direccion, consulta.telefono);
        }

        [HttpPut]
        public void ModificarCitaFisio(ConsultaFisio consulta)
        {
            this.repo.ModificarCitaFisio(consulta.Id, consulta.Nombre, consulta.Apellido, consulta.Fecha, consulta.Edad, consulta.Direccion, consulta.telefono);

        }

        [HttpDelete("{id}")]
        public void EliminarConsultaFisio(int id)
        {
            this.repo.EliminarConsultaFisio(id);
        }
    }
}