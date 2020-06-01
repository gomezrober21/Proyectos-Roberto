using ClienteApiClinica.Helpers;
using ClienteApiClinica.ViewModels;
using ClienteApiClinica.VIewModels;
using ClienteApiClinica.Views.Chat;
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
    
    public partial class MenuPrincipal : MasterDetailPage
    {
        public static INavigation Navegator { get; set; }
        public List<MasterPageArticulo> listamenu { get; set; }
        public String Nombre { get; set; }
      
        public MenuPrincipal()
        {
            InitializeComponent();
            //MessagingCenter.Send(this, "EventoLog");

            ComprobarLogin();

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
            Settings.Navegator = Navigation;

            MessagingCenter.Subscribe<LoginViewModel>(this, "EventoLog", (sender) =>
            {
                this.ComprobarLogin();
            });

            MessagingCenter.Subscribe<LogOutViewModel>(this, "EventoLog", (sender) =>
            {
                this.ComprobarLogin();
            });

        }

        private void ComprobarLogin()
        {
            listamenu = new List<MasterPageArticulo>();
            
            listamenu.Add(new MasterPageArticulo() { Titulo = "Home", Icono = "home.png", TipoObjetivo = typeof(HomePage) });
            listamenu.Add(new MasterPageArticulo() { Titulo = "Contacto", Icono = "contacto.png", TipoObjetivo = typeof(Contacto) });
            listamenu.Add(new MasterPageArticulo() { Titulo = "Cerrar Sesión", Icono = "cerrarsesion.png", TipoObjetivo = typeof(LogOut) });
            listamenu.Add(new MasterPageArticulo() { Titulo = "Login",  TipoObjetivo = typeof(LoginPage) });

            if (Settings.ObtenerToken != "")
            {
                listamenu.Add(new MasterPageArticulo() { Titulo = "Cita Online", Icono = "cita.png", TipoObjetivo = typeof(CitiaFisio) });
                listamenu.Add(new MasterPageArticulo() { Titulo = "Entrenamiento Personal", Icono = "entrenamiento.png", TipoObjetivo = typeof(EntrenamientoPersonal) });
                listamenu.Add(new MasterPageArticulo() { Titulo = "Foro", Icono = "foro.png", TipoObjetivo = typeof(Foro) });
                listamenu.Add(new MasterPageArticulo() { Titulo = "Perfil", Icono = "perfil.png", TipoObjetivo = typeof(Perfil) });
                listamenu.Add(new MasterPageArticulo() { Titulo = "Chat", TipoObjetivo = typeof(ChatListView) });
            }
            if (Settings.Role == "administrador")
            {
                listamenu.Add(new MasterPageArticulo() { Titulo = "Administración", Icono = "cerrarsesion.png", TipoObjetivo = typeof(Administracion) });
            }

            this.navigationDrawerList.ItemsSource = listamenu;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
            
            var item = (MasterPageArticulo)e.SelectedItem;
            Type page = item.TipoObjetivo;
           
            //cliente
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

        //protected override void OnAppearing()
        //{
        //    ComprobarLogin();
        //    base.OnAppearing();
        //}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}