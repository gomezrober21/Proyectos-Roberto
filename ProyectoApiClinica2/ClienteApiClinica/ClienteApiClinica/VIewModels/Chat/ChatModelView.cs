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

        private SignalRManager chatManager;

        public ChatModelView(SignalRManager chatManager)
        {
            this.chatManager = chatManager;
            //Misma referencia en el chat manager y en el modelview
            this.Messages = chatManager.ListaMensaje[this.TargetUserName];
        }

        private ObservableCollection<Mensaje> _messages;
        public ObservableCollection<Mensaje> Messages {
            get
            {
                return _messages;
            } 
            set 
            {
                _messages = value;
                RaisePropertyChanged(() => Messages);
            }
        }

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

        public Command AddMessage
        {
            get
            {
                return new Command(() =>
                {
                    if (MessageEntry!="")
                    {
                        Messages.Add(new Mensaje() { 
                         TimeStamp = DateTime.Now,
                         IsRemote = false,
                         Message = MessageEntry
                        });

                        MessageEntry = "";

                    }
                });


            }
        }

    }
}
