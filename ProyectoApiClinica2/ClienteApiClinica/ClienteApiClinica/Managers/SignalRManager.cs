
using Autofac;
using ClienteApiClinica.Helpers;
using ClienteApiClinica.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClienteApiClinica.Managers
{
    class SignalRManager
    {
        public Dictionary<String, ObservableCollection<Mensaje>> ListaMensaje;
        HubConnection connection;
        public string Url { get; }
        public SignalRManager()
        {
            //this.Url = "https://proyectoapiclinica2.azurewebsites.net" + "/chatHub";
            //this.Url = "http://localhost:56668" + "/chatHub";
            this.Url = "https://proyectoapiclinicatajamar.azurewebsites.net" + "/chatHub";

            this.ListaMensaje = new Dictionary<string, ObservableCollection<Mensaje>>();
        }

        public async void StartConnection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(this.Url, options => {
                    options.AccessTokenProvider = () => Task.FromResult(Settings.ObtenerToken);
                })
                .Build();

            await this.connection.StartAsync().ContinueWith((task) => {
                Debug.WriteLine("SignalR ConnectionStarted");

                connection.On<string, string>("RecibedFrom", (message,user ) =>
                {
                    if (!ListaMensaje.ContainsKey(user))
                    {
                        ListaMensaje[user] = new ObservableCollection<Mensaje>();
                        MessagingCenter.Send(this, "NewChat");
                    }
                    ListaMensaje[user]
                        .Add(new Mensaje() 
                        { 
                            IsRemote = true,
                            Message  =message,
                            TimeStamp = DateTime.Now
                        });

                });

                //Implementacion global sin hacer
                //connection.On<string, string>("ReceiveGloval", (message) =>
                //{

                //});

            });
                
        }

        public void SendMessageTo(string msg, string targetUserName)
        {
            if (this.connection.State == HubConnectionState.Connected)
            {
                this.connection.SendAsync("SendMessageToUser", msg, targetUserName);

                if (ListaMensaje[targetUserName] == null)
                {
                    ListaMensaje[targetUserName] = new ObservableCollection<Mensaje>();
                }
                ListaMensaje[targetUserName]
                    .Add(new Mensaje()
                    {
                        IsRemote = false,
                        Message = msg,
                        TimeStamp = DateTime.Now
                    });
            }
        }


        //public void SendMessageGlobal(string msg)
        //{
        //    if (this.connection.State == HubConnectionState.Connected)
        //    {
        //        this.connection.SendAsync("SendGlobalMessage", msg);
        //    }
        //    else
        //    {
        //        throw new Exception("Connection not started. Current state " + this.connection.State);
        //    }
        //}

    }
}
