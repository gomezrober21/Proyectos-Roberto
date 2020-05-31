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

        public ObservableCollection<Mensaje> Messages { 
            get 
            {
                return this._messages;
            } 
            set 
            {
                this._messages = value;
                this.RaisePropertyChanged(() => Messages);
            } 
        }
        public ObservableCollection<Mensaje> _messages;
        private SignalRManager chatManganer;
        
            public String TargetUserName { 
            get { return this._targetUserName; } 
            set {
                this._targetUserName = value;
                RaisePropertyChanged(() => TargetUserName);

                chatManganer = App.container.Resolve<SignalRManager>();

                if (chatManganer.ListaMensaje.ContainsKey(TargetUserName))
                {
                   
                    this.Messages = chatManganer.ListaMensaje[TargetUserName];
                }
                else
                {
                    this.Messages = chatManganer.ListaMensaje[TargetUserName] = new ObservableCollection<Mensaje>();
                }

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
            this.MessageEntry = "";

            Messages = new ObservableCollection<Mensaje>();
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
