using ClienteApiClinica.VIewModels;
using ClienteApiClinica.Views;
using FisioXamarin.Views;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClienteApiClinica.Helpers
{
    public static class Settings
    {
        public static INavigation Navegator { get;  set; }
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }

        }

        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault("USERNAME", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("USERNAME", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("PASSWORD", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("PASSWORD", value);
            }
        }

        public static string ObtenerToken
        {
            get
            {
                if (!string.IsNullOrEmpty(Settings.ObtenerToken))
                {
                    return AppSettings.GetValueOrDefault("TOKEN", "");

                }

                else if (!string.IsNullOrEmpty(Settings.Username) && !string.IsNullOrEmpty(Settings.Password))
                {
                    Navegator.PushAsync(new LoginPage());
                }
                else
                {
                    Navegator.PushAsync(new PaginaRegistro());
                }
                return null;
            }
            set
            {
                AppSettings.AddOrUpdateValue("TOKEN", value);
            }
        }
        public static DateTime ObtenerExpirarToken
        {
            get
            {

               

                return AppSettings.GetValueOrDefault("TOKENEXPIRACION", DateTime.UtcNow);

            }
            set
            {
                AppSettings.AddOrUpdateValue("TOKENEXPIRACION", value);
            }
        }

        
    }
}

//private void InicioTokenPage()
//{
//    if (!string.IsNullOrEmpty(Settings.ObtenerToken))
//    {
//        if (DateTime.UtcNow.AddHours(1) > Settings.ObtenerExpirarToken)
//        {
//            var viewModel = new LoginViewModel();
//            viewModel.ComandoLogin.Execute(null);
//        }

//        MainPage = new NavigationPage(new CitiaFisio());
//    }
//    else if (!string.IsNullOrEmpty(Settings.Username) && !string.IsNullOrEmpty(Settings.Password))
//    {
//        MainPage = new NavigationPage(new LoginPage());
//    }
//    else
//    {
//        MainPage = new NavigationPage(new PaginaRegistro());
//    }
//}