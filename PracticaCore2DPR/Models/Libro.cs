using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Models
{
    [Table("LIBROS")]
    public class Libro
    {
        [Key]
        [Column("IdLibro")]
        public int idLibro { get; set; }
        [Column("Titulo")]
        public String titulo { get; set; }
        [Column("Autor")]
        public String autor { get; set; }
        [Column("Editorial")]
        public String editorial { get; set; }
        [Column("Portada")]
        public String portada { get; set; }
        [Column("Resumen")]
        public String resumen { get; set; }
        [Column("Precio")]
        public int precio { get; set; }
        [Column("IdGenero")]
        public int idGenero { get; set; }
    }
}
