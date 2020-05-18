using ClienteApiClinica.Models;
using ClienteApiClinica.VIewModels.Chat;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public ChatView(String username)
        {
            InitializeComponent();

            ChatModelView bindingcontext = (this.BindingContext as ChatModelView);
            bindingcontext.TargetUserName = username;

            bindingcontext.Messages.CollectionChanged += ((object sender, NotifyCollectionChangedEventArgs e) =>
            {
                Mensaje msg = (this.BindingContext as ChatModelView).Messages.Last();
                chatList.ScrollTo(msg, ScrollToPosition.End, false);
            });
        }
    }
}