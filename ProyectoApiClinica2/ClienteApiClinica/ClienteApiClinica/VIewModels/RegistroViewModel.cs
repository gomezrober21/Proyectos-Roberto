using FisioXamarin.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FisioXamarin.ViewModels
{
 public  class RegistroViewModel
    {
        ApiService _apiServices = new ApiService();  
        public String Email { get; set; }
        public String Password { get; set; }       
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
                return new Command(async ()  =>
                {
                  var isSuccess =   _apiServices.RegisterAsync(Email, Password, NombreUsuario, Nombre, Apellido, Edad, Telefono);
                    if (await isSuccess)
                    {
                        Mensaje = "Registro realizado";
                    }

                    else
                    {
                        Mensaje = "Vuelvelo a intentar";
                    }
                        
                });
            }
        }
    }
}
