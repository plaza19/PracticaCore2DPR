using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Models
{
    [Table("VISTAPEDIDOS")]
    public class VistaPedidos
    {
        [Key]
        [Column("IDVISTAPEDIDOS")]
        public long idVistaPedidos { get; set; }
        [Column("IdUsuario")]
        public int idUsuario { get; set; }
        [Column("Nombre")]
        public String nombre { get; set; }
        [Column("Apellidos")]
        public String apellido { get; set; }
        [Column("Titulo")]
        public String titulo { get; set; }
        [Column("Precio")]
        public int precio { get; set; }
        [Column("Portada")]
        public String portada { get; set; }
        [Column("FECHA")]
        public DateTime fecha { get; set; }
        [Column("PRECIOFINAL")]
        public int preciofinal { get; set; }


    }
}
