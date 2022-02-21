using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Models
{
    [Table("USUARIOS")]
    public class User
    {
        [Key]
        [Column("IdUsuario")]
        public int idUsuario { get; set; }
        [Column("Nombre")]
        public String nombre { get; set; }
        [Column("Apellidos")]
        public String apellidos { get; set; }
        [Column("Email")]
        public String email { get; set; }
        [Column("Pass")]
        public String password { get; set; }
        [Column("Foto")]
        public String foto { get; set; }

    }
}
