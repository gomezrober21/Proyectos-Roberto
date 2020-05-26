using ClienteApiClinica.Filter;
using ClienteApiClinica.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClienteApiClinica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //[Authorize]
    public partial class Administracion : ContentPage
    {
        public Administracion()
        {
            InitializeComponent();
           
            Debug.WriteLine(Settings.ObtenerToken);
            if (Settings.ObtenerToken == "")
            {

                Navigation.PushAsync(new LoginPage());
            }
        }
    }
}