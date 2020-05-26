using Microsoft.EntityFrameworkCore;
using ProyectoApiClinica2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoApiClinica2.Data
{
    public class ContextoClinica : DbContext
    {
        public ContextoClinica(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ConsultaEntrenamiento> ConsultaEntrenamientos { get; set; }
        public DbSet<ConsultaFisio> ConsultaFisioterapia { get; set; }
    }
}
