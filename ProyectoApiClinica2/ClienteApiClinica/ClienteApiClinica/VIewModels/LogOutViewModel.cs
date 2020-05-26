using ClienteApiClinica.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClienteApiClinica.VIewModels
{
   public class LogOutViewModel
    {
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
