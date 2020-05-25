using Autofac;
using ClienteApiClinica.Managers;
using ClienteApiClinica.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ClienteApiClinica.ViewModels.Chat
{
    class ChatModelView:ViewModelBase
    {

        public ObservableCollection<Mensaje> Messages { get; }
        private SignalRManager chatManganer;
        
            public String TargetUserName { 
            get { return this._targetUserName; } 
            set {
                this._targetUserName = value;
                RaisePropertyChanged(() => TargetUserName);    
                    
            } 
        }
        private String _targetUserName;

        private String _messageEntry  = "";
        public String MessageEntry { 
            get { return _messageEntry; }
            set
            {
                this._messageEntry = value;
                this.RaisePropertyChanged(() => MessageEntry);
            } 
        }

        public ChatModelView()
        {

            chatManganer = App.container.Resolve<SignalRManager>();

            Messages = chatManganer.ListaMensaje[TargetUserName];

            this.MessageEntry = "";
        }

        public Command AddMessage
        {
            get
            {
                return new Command(() =>
                {
                    if (MessageEntry!="")
                    {


                        chatManganer.SendMessageTo(MessageEntry, TargetUserName);

                        MessageEntry = "";

                        
                    }
                });


            }
        }

    }
}
