using ClienteApiClinica.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClienteApiClinica.VIewModels
{
   public class LogOutViewModel
    {
        public Command ComandoLogOut
        {
            get
            {
                return new Command(() => {
                    Settings.ObtenerToken = "";
                    Settings.Username = "";
                    Settings.Password = "";
                });
            }
        }
    }
}
