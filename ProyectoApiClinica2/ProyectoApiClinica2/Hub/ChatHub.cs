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
        static Dictionary<string, string> User_ConnId_Pair = new Dictionary<string, string>();

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
            
            //Send only if the reciber is admin
            //Do not allow comunication between users
            if (Reciber.Rol == "administrador")
            {
                String ReciberConnId = User_ConnId_Pair[TargetUsername];

                //Check if the user is connected
                if (ReciberConnId != null)
                {
                    String JsonSenderObj = this.Context.GetHttpContext().User.Claims.First(c => c.Type == "UserData").Value;
                    Usuario Sender = JsonConvert.DeserializeObject<Usuario>(JsonSenderObj);

                    //Send the message and the sender Username to the reciber
                    await Clients.Client(ReciberConnId).RecibedFrom(message, Sender.NombreUsuario );

                }

            }

        }

        public override Task OnConnectedAsync()
        {
            String JsonSenderObj = this.Context.GetHttpContext().User.Claims.First(c => c.Type == "UserData").Value;
            Usuario Sender = JsonConvert.DeserializeObject<Usuario>(JsonSenderObj);
            User_ConnId_Pair.Add(Sender.NombreUsuario, this.Context.ConnectionId);


            return base.OnConnectedAsync();


        }
    }
}
