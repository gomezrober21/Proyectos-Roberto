using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoApiClinica2.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("NOMBRE_USUARIO")]
        public String NombreUsuario { get; set; }
        [Column("CONTRASENA")]
        public String Contrasena { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("APELLIDO")]
        public String Apellido { get; set; }
        [Column("EDAD")]
        public int Edad { get; set; }
        [Column("TELEFONO")]
        public int Telefono { get; set; }
        [Column("EMAIL")]
        public String Email { get; set; }
        [Column("ROL")]
        public String Rol { get; set; }
        [Column("COMENTARIOS")]
        public String Comentarios { get; set; }
    }
}
