using ClienteApiClinica.Helpers;
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
   
    public partial class CitiaFisio : ContentPage
    {
        public CitiaFisio()
        {
            InitializeComponent();
            if (Settings.ObtenerToken == "")
            {

                Navigation.PushAsync(new LoginPage());
            }
        }

        private async void Boton_Logout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}