
using ClienteApiClinica.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClienteApiClinica.Managers
{
    class SignalRManager
    {
        Dictionary<String, List<Mensaje>> ListaMensaje;
        HubConnection connection;
        public string Url { get; }
        public SignalRManager()
        {
            this.Url = "https://proyectoapiclinica2.azurewebsites.net" + "/chatHub";
        }

        public async void StartConnection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(this.Url, options => {
                    options.AccessTokenProvider = () => throw new NotImplementedException("Aqui deberia de ir el token");
                })
                .Build();
            this.connection.StartAsync().ContinueWith((task) => {
                if (!task.IsFaulted)
                {
                    Debug.WriteLine("SignalR ConnectionStarted");

                    connection.On<string, string>("RecibedFrom", (message,user ) =>
                    {
                        if (ListaMensaje[user] == null)
                        {
                            ListaMensaje[user] = new List<Mensaje>();
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

                }
                else
                {
                    throw new Exception("Could not connect to singalR Server");
                }
            });
                
        }

        public void SendMessageTo(string msg, string targetUserName)
        {
            if (this.connection.State == HubConnectionState.Connected)
            {
                this.connection.SendAsync("SendMessageToUser", msg, targetUserName);

                if (ListaMensaje[targetUserName] == null)
                {
                    ListaMensaje[targetUserName] = new List<Mensaje>();
                }
                ListaMensaje[targetUserName]
                    .Add(new Mensaje()
                    {
                        IsRemote = false,
                        Message = msg,
                        TimeStamp = DateTime.Now
                    });
            }
            else
            {
                throw new Exception("Connection not started. Current state "+ this.connection.State);
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
