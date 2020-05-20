using ClienteApiClinica.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FisioXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogOut : ContentPage
    {
        public LogOut()
        {
            InitializeComponent();
        }
        private async void Boton_CerrarSesion(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}