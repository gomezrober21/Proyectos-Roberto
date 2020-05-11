using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarCore.Models
{
    public class ConsultaEntrenamiento
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nombre")]
        public String Nombre { get; set; }
        [JsonProperty("apellido")]
        public String Apellido { get; set; }
        [JsonProperty("fecha")]
        public String Fecha { get; set; }
        //[JsonProperty("hora")]
        //public DateTime Hora { get; set; }
        [JsonProperty("edad")]
        public int Edad { get; set; }
        [JsonProperty("telefono")]
        public int Telefono { get; set; }
    }
}
