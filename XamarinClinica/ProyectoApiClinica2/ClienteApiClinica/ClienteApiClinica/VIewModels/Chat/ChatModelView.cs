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
            Messages = new ObservableCollection<Mensaje>();

            //Messages.Add(new Mensaje() { Message = "pataat", IsRemote = true, TimeStamp = DateTime.Now });
            //Messages.Add(new Mensaje() { Message = "patata2", IsRemote = false, TimeStamp = DateTime.Now });

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
