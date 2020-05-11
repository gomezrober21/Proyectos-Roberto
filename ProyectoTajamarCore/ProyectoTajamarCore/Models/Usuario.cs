using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarCore.Models
{
    public class Usuario
    {
        [JsonProperty("nombreUsuario")]
        public String NombreUsuario { get; set; }
        [JsonProperty("contrasena")]
        public String Contrasena { get; set; }
        [JsonProperty("nombre")]
        public String Nombre { get; set; }
        [JsonProperty("apellido")]
        public String Apellido { get; set; }
        [JsonProperty("edad")]
        public int Edad { get; set; }
        [JsonProperty("telefono")]
        public int Telefono { get; set; }
        [JsonProperty("email")]
        public String Email { get; set; }
        [JsonProperty("rol")]
        public String Role { get; set; }
        [JsonProperty("comentarios")]
        public String Comentarios { get; set; }
    }
}
