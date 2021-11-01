using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Models
{
    [Table("Tbl_Churros_Pedido")]
    public class ChurrosPedido
    {
        public Churros Churros { get; set; }
        public int ChurrosId { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
    }
}
