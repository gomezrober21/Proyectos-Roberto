using ClienteApiClinica.Helpers;
using ClienteApiClinica.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClienteApiClinica.Views.Chat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatListView : ContentPage
    {
        public ChatListView()
        {
            InitializeComponent();

            if (Settings.ObtenerToken == "")
            {
                Navigation.PushAsync(new LoginPage());
            }

        }

        public void GoToChat(object sender, EventArgs e)
        {
            string username = ((Button)sender).BindingContext as string;
            Navigation.PushAsync(new ChatView(username));
        }

    }
}