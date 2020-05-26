using ClienteApiClinica.Helpers;
using ClienteApiClinica.VIewModels;
using ClienteApiClinica.Views;
using ClienteApiClinica.Views.Chat;
using FisioXamarin.Views;
using Autofac;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;


namespace ClienteApiClinica
{
    public partial class App : Application
    {
        public static IContainer container { get; set; }
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MenuPrincipal());
            InicioTokenPage();
            
            container = DependencyInjection.DependencyDeclarations.BuildContainer();
            DependencyResolver.ResolveUsing(type => container.IsRegistered(type) ? container.Resolve(type) : null);

            //MainPage = new MenuPrincipal();

        }
        private void InicioTokenPage()
        {
            if (!string.IsNullOrEmpty(Settings.ObtenerToken))
            {
                if (DateTime.UtcNow.AddHours(1) > Settings.ObtenerExpirarToken)
                {
                    var viewmodel = new LoginViewModel();
                    viewmodel.ComandoLogin.Execute(null);
                    var vm = new LogOutViewModel();
                    vm.CommandCerrar.Execute(null);

                }

                MainPage = new NavigationPage(new MenuPrincipal());
            }
            else
            {
                MainPage = new NavigationPage(new MenuPrincipal());
            }
        }

        //private void InicioTokenPage()
        //{
        //    if (!string.IsNullOrEmpty(Settings.ObtenerToken))
        //    {
        //        if (DateTime.UtcNow.AddSeconds(10) > Settings.ObtenerExpirarToken)
        //        {
        //            var viewModel = new LoginViewModel();
        //            viewModel.ComandoLogin.Execute(null);
        //        }

        //        MainPage = new NavigationPage(new LoginPage());
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

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
