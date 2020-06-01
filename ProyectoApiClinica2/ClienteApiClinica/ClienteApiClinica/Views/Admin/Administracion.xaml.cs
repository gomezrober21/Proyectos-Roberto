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

            Button btn1 = new Button() { Text = "Ir a insertar citas" };
            btn1.Clicked += delegate
            {
                GoToPage<AdministracionCitasView>();
            };
            this.mainViewPort.Children.Add(btn1);


            Button btn3 = new Button() { Text = "Ir a mostrar info users/citas" };
            btn3.Clicked += delegate
            {
                GoToPage<AdministracionMostrarInfo>();
            };
            this.mainViewPort.Children.Add(btn3);
        }

        public void GoToPage<T>() where T:Page,new()
        {
            Navigation.PushAsync(new T());
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    if (Settings.ObtenerToken == "")
        //    {
        //        Navigation.PushAsync(new LoginPage());
        //    }
        //}

    }
}