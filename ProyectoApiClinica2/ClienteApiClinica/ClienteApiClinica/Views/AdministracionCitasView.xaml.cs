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
    public partial class AdministracionCitasView : ContentPage
    {
        public AdministracionCitasView()
        {
            InitializeComponent();
        }

        private async void botoncogercitafisio_Clicked(object sender, EventArgs e)
        {
            AdminCogerCitaFisio view = new AdminCogerCitaFisio();
            await Navigation.PushModalAsync(view);
        }

        private async void botoncogercitaEntr_Clicked(object sender, EventArgs e)
        {
            AdminCogerCItaEntr view = new AdminCogerCItaEntr();
            await Navigation.PushModalAsync(view);
        }
    }
}