using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Models
{
    [Table("Tbl_Pedido")]
    public class Pedido
    {
        [Column("Id")]
        public int PedidoId { get; set; }

        [Column("Dt_Nascimento"), Display(Name = "Data do Pedido"), DataType(DataType.Date)]
        public DateTime DataPedido { get; set; }

        // Relacionamento N:N
        public ICollection<ChurrosPedido> ChurrosPedidos { get; set; }
    }
}
