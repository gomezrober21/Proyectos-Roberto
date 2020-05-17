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
        List<String> Admins ;
        public ChatListView()
        {
            InitializeComponent();
            Admins = new List<String>() { "admin1", "admin2", "admin3" };
            //Admins = new List<String>() ;

            this.AddAdminToList();
        }

        private void AddAdminToList()
        {
            if (Admins.Any())
            {
                Admins.ForEach(a =>
                {
                    StackLayout adminChatRow = this.GenerateRowForAdmin(a);

                    this.AdminList.Children.Add(adminChatRow);


                    BoxView separator = new BoxView()
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        HeightRequest = 1,
                        WidthRequest = 300,
                        Color = Color.Gray
                    };

                    this.AdminList.Children.Add(separator);
                });

                //Remove the last separator
                this.AdminList.Children.RemoveAt(this.AdminList.Children.Count - 1);

            }
            else
            {
                this.AdminList.Children.Add(
                    new Label()
                    {
                        Text= "No hay ningun admin conectado, prueba mas tarde",
                        HorizontalOptions=LayoutOptions.FillAndExpand,
                        VerticalOptions =LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment =TextAlignment.Center
                    }
                    );
            }



        }

        private StackLayout GenerateRowForAdmin(string a)
        {
            StackLayout stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            Label UsermameLbl = new Label()
            {
                Text = a,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                Padding = new Thickness(20, 0, 0, 0),
                FontSize=20

            };

            Button button = new Button()
            {
                Text = "Iniciar chat",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                CornerRadius = 20 ,
                Margin = new Thickness( 0,10,5,10)
            };

           
            stackLayout.Children.Add(UsermameLbl);
            stackLayout.Children.Add(button);

            return stackLayout;
        }
    }
}