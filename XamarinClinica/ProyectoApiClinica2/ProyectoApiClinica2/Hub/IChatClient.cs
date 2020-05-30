using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoApiClinica2.Hub
{
    public interface IChatClient { 
        Task ReceiveGloval(string message);
        Task RecibedFrom(string message,String userName); 
    
    }

}
