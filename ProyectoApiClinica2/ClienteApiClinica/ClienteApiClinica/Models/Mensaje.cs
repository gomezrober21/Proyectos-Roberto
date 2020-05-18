using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteApiClinica.Models
{
    public class Mensaje
    {
        public String Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsRemote { get; set; }

    }
}
