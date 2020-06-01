
using ClienteApiClinica.Helpers;
using ClienteApiClinica.Repositories;
using ClienteApiClinica.VIewModels;
using FisioXamarin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClienteApiClinica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class LoginPage : ContentPage
    {
       RepositoryClinica repo;
        public LoginPage()
        {
            InitializeComponent();
            repo = new RepositoryClinica();
            (this.BindingContext as LoginViewModel).Navigation = this.Navigation;
        }

        private async void BotonCrearCuennta(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaRegistro());
        }

        private void Boton_AbrirSesion(object sender, EventArgs e)
        {
           
            //if (Settings.Response.Equals(false))
            //{
            //    await Navigation.PushAsync(new LoginPage());
            //}
            //await Navigation.PushAsync(new MenuPrincipal());

        }

        protected override bool OnBackButtonPressed()
        {
            if (Settings.ObtenerToken == "") 
            {
                return false;
            }
            return base.OnBackButtonPressed();

        }
    }
}