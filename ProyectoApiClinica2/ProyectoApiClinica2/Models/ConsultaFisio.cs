using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoApiClinica2.Data
{
    [Table("PACIENTE_FISIO")]
    public class ConsultaFisio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("COD_PACIENTE_FISIO")]
        [Required]
        public int Id { get; set; }
        [Column("NOMBRE")]
        [Required]
        public String Nombre { get; set; }
        [Column("APELLIDO")]
        [Required]
        public String Apellido { get; set; }
        [Column("FECHA")]
        [Required]
        //[DataType(DataType.Time)]
        public String Fecha { get; set; }
        //[Column("HORA")]
        //[DataType(DataType.Time)]
        //public DateTime Hora { get; set; }
        [Column("EDAD")]
        [Required]
        public int Edad { get; set; }
        [Column("DIRECCION")]
        [Required]
        public String Direccion { get; set; }
        [Column("TELEFONO")]
        [Required]
        public int telefono { get; set; }
    }
}
