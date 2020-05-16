using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using ProyectoApiClinica2.Hub;
using ProyectoApiClinica2.Models;
using ProyectoApiClinica2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoApiClinica2.Hubs
{
    [Authorize]
    public class ChatHub: Hub<IChatClient>
    {
        RepositoryClinica Repository;
        static Dictionary<string, string> _User_ConnId_Pair = new Dictionary<string, string>();

        public static Dictionary<string, string> UserConn { get => _User_ConnId_Pair; }


        public ChatHub(RepositoryClinica repository)
        {
            Repository = repository;
        }

        public async Task SendGlobalMessage(string message)
        {
            await Clients.All.ReceiveGloval(message);
        }

        public async Task SendMessageToUser(string message , String TargetUsername)
        {
            
            Usuario Reciber = Repository.BuscarUsuario(TargetUsername);
            
            String JsonSenderObj = this.Context.GetHttpContext().User.Claims.First(c => c.Type == "UserData").Value;
            Usuario Sender = JsonConvert.DeserializeObject<Usuario>(JsonSenderObj);
            //Send only if the reciber is admin or if the admin whants to send a message
            //Do not allow comunication between users
            if (Reciber.Rol == "administrador" || Sender.Rol == "administrador")
            {
                String ReciberConnId = _User_ConnId_Pair[TargetUsername];

                //Check if the user is connected
                if (ReciberConnId != null)
                {

                    //Send the message and the sender Username to the reciber
                    await Clients.Client(ReciberConnId).RecibedFrom(message, Sender.NombreUsuario);

                }
            }
        }
        public override Task OnConnectedAsync()
        {
            String JsonSenderObj = this.Context.GetHttpContext().User.Claims.First(c => c.Type == "UserData").Value;
            Usuario Sender = JsonConvert.DeserializeObject<Usuario>(JsonSenderObj);
            _User_ConnId_Pair.Add(Sender.NombreUsuario, this.Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception e)
        {
            //Remove the user on disconnected
            _User_ConnId_Pair = _User_ConnId_Pair
                                .Where(pair => pair.Value != this.Context.ConnectionId)
                                .ToDictionary(pair => pair.Key,pair => pair.Value);

            return base.OnDisconnectedAsync(e);
        }
    }
}
