using ClienteApiClinica.Helpers;
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
    public partial class Perfil : ContentPage
    {
        public Perfil()
        {
            InitializeComponent();
            //if (Settings.ObtenerToken == "")
            //{

            //    Navigation.PushAsync(new LoginPage());
            //}
        }
    }
}