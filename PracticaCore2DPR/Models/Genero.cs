using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Models
{
    [Table("GENEROS")]
    public class Genero
    {
        [Key]
        [Column("IdGenero")]
        public int idgenero { get; set; }
        [Column("Nombre")]
        public String nombre { get; set; }
    }
}
