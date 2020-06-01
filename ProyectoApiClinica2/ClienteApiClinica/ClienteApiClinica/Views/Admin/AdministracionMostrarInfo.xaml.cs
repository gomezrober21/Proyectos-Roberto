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
    public partial class AdministracionMostrarInfo : ContentPage
    {
        public AdministracionMostrarInfo()
        {
            InitializeComponent();
        }

        private async void botonmostrarusuarios_Clicked(object sender, EventArgs e)
        {
                MostrarUsuariosAdministracionView view = new MostrarUsuariosAdministracionView();
                await Navigation.PushModalAsync(view);
        }

        private async void botonmostrarcitafisio_Clicked(object sender, EventArgs e)
        {
            MostrarCitasAdministracionView view = new MostrarCitasAdministracionView();
            await Navigation.PushModalAsync(view);
        }

        private async void botonmostrarEntrPersonal_Clicked(object sender, EventArgs e)
        {
            MostrarEntrCitasView view = new MostrarEntrCitasView();
            await Navigation.PushModalAsync(view);
        }
    }
}