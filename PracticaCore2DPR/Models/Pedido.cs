using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Models
{
    [Table("PEDIDOS")]
    public class Pedido
    {
        [Key]
        [Column("IDPEDIDO")]
        public int idPedido {get;set;}
        [Column("IDFACTURA")]
        public int idFactura { get; set; }
        [Column("FECHA")]
        public DateTime fecha { get; set; }
        [Column("IDLIBRO")]
        public int idLibro { get; set; }
        [Column("IDUSUARIO")]
        public int idUsuario { get; set; }
        [Column("CANTIDAD")]
        public int cantidad { get; set; }

    }
}
