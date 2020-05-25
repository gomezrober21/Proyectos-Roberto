using Autofac;
using ClienteApiClinica.Views;
using ClienteApiClinica.Views.Chat;
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

            container = DependencyInjection.DependencyDeclarations.BuildContainer();
            DependencyResolver.ResolveUsing(type => container.IsRegistered(type) ? container.Resolve(type) : null);

            MainPage = new MenuPrincipal();

        }

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
