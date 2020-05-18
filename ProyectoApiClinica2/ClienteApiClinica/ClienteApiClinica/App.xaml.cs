using ClienteApiClinica.Views.Chat;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ClienteApiClinica
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ChatListView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
