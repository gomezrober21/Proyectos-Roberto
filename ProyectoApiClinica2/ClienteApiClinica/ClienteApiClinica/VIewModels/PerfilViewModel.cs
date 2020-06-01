using ClienteApiClinica.Helpers;
using ClienteApiClinica.Models;
using ClienteApiClinica.Repositories;
using ClienteApiClinica.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApiClinica.VIewModels
{
   public class PerfilViewModel: ViewModelBase
    {

        RepositoryClinica repo;
        public PerfilViewModel()
        {
            this.repo = new RepositoryClinica();
            Task.Run(async () =>
            {
              await  CargarUsuario();
            });

        }
        private Usuario _Usuario { get; set; }
        public Usuario Usuario
        {

            get { return this._Usuario; }
            set
            {
                this._Usuario = value;
                RaisePropertyChanged(() => Usuario);
            }

        }

        private async Task CargarUsuario()
        {
            Usuario users = await this.repo.PerfilEmpleado(Settings.ObtenerToken);
            this.Usuario = users;
        }
    }
}
