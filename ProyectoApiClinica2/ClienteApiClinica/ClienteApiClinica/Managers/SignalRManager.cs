
using ClienteApiClinica.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClienteApiClinica.Managers
{
    class SignalRManager
    {
        public Dictionary<String, ObservableCollection<Mensaje>> ListaMensaje;
        HubConnection connection;
        public string Url { get; }
        SignalRManager()
        {
            this.Url = "https://proyectoapiclinica2.azurewebsites.net" + "/chatHub";
        }

        public void StartConnection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(this.Url, options => {
                    options.AccessTokenProvider = () => throw new NotImplementedException("Aqui deberia de ir el token");
                })
                .Build();
            this.connection.StartAsync().ContinueWith((task) => {
                if (!task.IsFaulted)
                {
                    Debug.WriteLine("SignalR connection started: OK");
                }
                else
                {
                    throw new Exception("Could not connect to singalR Server");
                }
            });

            connection.On<string, string>("RecibedFrom", (msg, user) =>
            {
                if (!this.ListaMensaje.ContainsKey(user))
                {
                    this.ListaMensaje[user] = new ObservableCollection<Mensaje>();
                }

                this.ListaMensaje[user].Add(new Mensaje() { IsRemote = true, Message = msg, TimeStamp = DateTime.Now });

            });
        }

        public void SendMessageTo(string msg, string targetUserName)
        {
            if (this.connection.State == HubConnectionState.Connected)
            {
                this.connection.SendAsync("SendMessageToUser", msg, targetUserName);
            }else
            {
                throw new Exception("Connection not started. Current state "+ this.connection.State);
            }
        }

        public void SendMessageGlobal(string msg)
        {
            if (this.connection.State == HubConnectionState.Connected)
            {
                this.connection.SendAsync("SendGlobalMessage", msg);
            }
            else
            {
                throw new Exception("Connection not started. Current state " + this.connection.State);
            }
        }

    }
}
