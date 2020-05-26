using ClienteApiClinica.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ClienteApiClinica.Helpers;

namespace ClienteApiClinica.ViewModels
{
 public  class RegistroViewModel: ViewModelBase
    {
        RepositoryClinica repo;
       public RegistroViewModel()
        {
            this.repo = new RepositoryClinica();
        }
        public String Email { get; set; }
        public String Contrasena { get; set; }       
        public String NombreUsuario { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public String Mensaje { get; set; }
        public ICommand ComandoRegistro
        {
            get
            {
                return new Command( ()  =>
                {
                    
                    var insertado =   this.repo.RegistrarUsuario(NombreUsuario, Contrasena, Nombre, Apellido, Edad, Telefono, Email);

                    
                        Mensaje = "Es incorecto";
                    
                   

                    Settings.Username = NombreUsuario;
                    Settings.Password = Contrasena;

                });
            }
        }
    }
}
