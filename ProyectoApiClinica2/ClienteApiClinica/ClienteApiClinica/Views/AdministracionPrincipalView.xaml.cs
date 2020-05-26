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

        private async void botonmostrarusuarios_Clicked(object sender, EventArgs e)
        {
            MostrarUsuariosAdministracionView view = new MostrarUsuariosAdministracionView();
            await Navigation.PushModalAsync(view);
        }

        private void botonmostrarcitafisio_Clicked(object sender, EventArgs e)
        {

        }

        private void botonmostrarEntrPersonal_Clicked(object sender, EventArgs e)
        {

        }

        private async void botoneliminarusuario_Clicked(object sender, EventArgs e)
        {
            String nombreusuario = this.txtnombreusuario.Text;
            await this.repo.EliminarUsuario(nombreusuario);
            this.lblmensaje.Text = "Usuario eliminado";
        }
    }
}