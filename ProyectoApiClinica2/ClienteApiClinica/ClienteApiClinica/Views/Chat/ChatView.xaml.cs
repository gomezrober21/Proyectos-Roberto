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
    public partial class ChatView : ContentPage
    {
        public ChatView()
        {
            InitializeComponent();

            //When a new meessage is added the scroll is move to the las message
            this.Chat.ChildAdded += async (object sender, ElementEventArgs e) =>
            {
                //esto no funciona por lo que se calcula mediante la altura del chat  
                //this.ChatScroll.ScrollToAsync(e.Element, ScrollToPosition.Start, false);

                //Alguien me explica porque no hay un evento que sea despues de insertar el hijo¿?
                //This method needs to wait to the child to be aded to the chat so the calculation of the height of the stack layout is ok
                await Task.Delay(10);
                this.ChatScroll.ScrollToAsync(0, this.Chat.Height, false);
            };

            this.btnMessageInput.Clicked += (Object sender, EventArgs e) =>
            {
                String msg = this.MessageInput.Text;

                if (msg != "")
                {
                    this.AddMyMessage(msg);

                    //Enviar msg a signalR
                    this.MessageInput.Text = "";
                }

            };

        }

        private void AddRemoteMessage(String msg) 
        {
            Frame FrameMsg = GenerateMessage(msg, LayoutOptions.Start, Color.LightGreen);
            this.Chat.Children.Add(FrameMsg);
        }
        private void AddMyMessage(String msg) 
        {
            Frame FrameMsg = GenerateMessage(msg, LayoutOptions.End, Color.White);
            this.Chat.Children.Add(FrameMsg);
        }

        private Frame  GenerateMessage(string text, LayoutOptions position,Color backgroundColor)
        {
            Frame msgFrame = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(10, 5, 15, 5),
                HorizontalOptions = position,
                BackgroundColor = backgroundColor,
            };

            StackLayout msgRow = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
            };

            msgRow.Children.Add(new Label()
            {
                Text = text,
                FontSize = 20,
                TextColor = Color.DarkSlateGray

            });

            msgFrame.Content = msgRow;

            return msgFrame;
        }
    }
}