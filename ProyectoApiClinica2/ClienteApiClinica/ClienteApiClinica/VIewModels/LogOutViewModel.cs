using ClienteApiClinica.Helpers;
using ClienteApiClinica.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClienteApiClinica.VIewModels
{
   public class LogOutViewModel:ViewModelBase
    {
      
      

        public String Mensaje { get; set; }
        public LogOutViewModel()
        {
            MessagingCenter.Subscribe<LogOutViewModel>
               (this, "EventoLog", async (sender) =>
               {
                   if (Settings.ObtenerToken == "")
                   {
                       Mensaje = "Login";
                   }
                   else{
                       Mensaje = "Cerrar  sesion";
                   }
                   this.RaisePropertyChanged(() => Mensaje);
               });
        }

       
        public ICommand CommandCerrar
        {
            get
            {
                return new Command(() => {
                    Settings.ObtenerToken = "";
                    Settings.Username = "";
                    Settings.Password = "";
                    Settings.Role = "";
                });
            }
        }
    }
}
