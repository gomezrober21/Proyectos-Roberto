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
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BotonCrearCuennta(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaRegistro());
        }

        private async void Boton_AbrirSesion(object sender, EventArgs e)
        {

            await Navigation.PopAsync();
        }
    }
}