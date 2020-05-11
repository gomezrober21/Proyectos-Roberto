using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarCore.ViewComponents
{
    public class EntrViewComponent : ViewComponent
    {
        RepositoryClinica repo;
        public EntrViewComponent(RepositoryClinica repo)
        {
            this.repo = repo;
        }

        //public IViewComponentResult Invoke()
        //{
        //    var resultado = repo.GetConsultasEntrenamiento();
        //    return View(resultado);
        //}
    }
}
