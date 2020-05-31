using ClienteApiClinica.Repositories;
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
    public partial class AdministracionPrincipalView : ContentPage
    {
        RepositoryClinica repo;

        public AdministracionPrincipalView()
        {
            InitializeComponent();
            this.repo = new RepositoryClinica();
        }

        //private async void botonmostrarusuarios_Clicked(object sender, EventArgs e)
        //{
        //    MostrarUsuariosAdministracionView view = new MostrarUsuariosAdministracionView();
        //    await Navigation.PushModalAsync(view);
        //}

        //private async void botonmostrarcitafisio_Clicked(object sender, EventArgs e)
        //{
        //    AdminCogerCitaFisio view = new AdminCogerCitaFisio();
        //    await Navigation.PushModalAsync(view);
        //}

        //private async void botonmostrarEntrPersonal_Clicked(object sender, EventArgs e)
        //{
        //    AdminCogerCItaEntr view = new AdminCogerCItaEntr();
        //    await Navigation.PushModalAsync(view);
        //}

        //private async void botoneliminarusuario_Clicked(object sender, EventArgs e)
        //{
        //    String nombreusuario = this.txtnombreusuario.Text;
        //    await this.repo.EliminarUsuario(nombreusuario);
        //    this.lblmensaje.Text = "Usuario eliminado";
        //}

        private void botoninformacion_Clicked(object sender, EventArgs e)
        {
            AdministracionMostrarInfo view = new AdministracionMostrarInfo();
            Navigation.PushModalAsync(view);
        }

        private void botoninsertar_Clicked(object sender, EventArgs e)
        {
            AdministracionCitasView view = new AdministracionCitasView();
            Navigation.PushModalAsync(view);
        }
    }
}