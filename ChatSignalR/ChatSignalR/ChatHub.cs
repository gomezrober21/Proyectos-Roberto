using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatSignalR
{
    public class ChatHub : Hub
    {
       public void Send(String usuario, String mensaje)
        {
            Clients.All.EnviarMensaje(usuario, mensaje);
        }
    }
}