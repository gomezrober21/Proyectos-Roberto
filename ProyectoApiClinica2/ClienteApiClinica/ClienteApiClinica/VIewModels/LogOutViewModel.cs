using ClienteApiClinica.Helpers;
using ClienteApiClinica.ViewModels;
using ClienteApiClinica.Views;
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
            CheckUserAuth();

            //MessagingCenter.Subscribe<MenuPrincipal>(this, "EventoLog"(sender)=>{

            //})

            //MessagingCenter.Subscribe<MenuPrincipal>
            //   (this, "EventoLog", async (sender) =>
            //   {
            //       if (Settings.ObtenerToken == String.Empty)
            //       {
            //           Mensaje = "Login";
            //       }
            //       else
            //       {
            //           Mensaje = "Cerrar  sesion";
            //       }
            //       this.RaisePropertyChanged(() => Mensaje);
            //   });
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
                    CheckUserAuth();
                    Application.Current.MainPage.DisplayAlert("Alerta", "Sesión Cerrada", "Ok");
                    MessagingCenter.Send(this, "EventoLog");

                });
            }
        }

        public void CheckUserAuth()
        {
            if (Settings.ObtenerToken == String.Empty)
            {
                Mensaje = "No se ha Iniciado Sesión";
            }
            else
            {
                Mensaje = "Usuario Logeado";

            }
            this.RaisePropertyChanged(() => Mensaje);
        }
    }
}
