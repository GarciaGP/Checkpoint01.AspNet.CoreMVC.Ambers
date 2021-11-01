using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Models
{
    [Table("Tbl_Recheio")]
    public class Recheio
    {
        [Column("Id")]
        public int RecheioId { get; set; }

        [Required, MaxLength(50), DisplayName("Descrição")]
        public string Descricao { get; set; }

        // Relacionamento N:1
        public virtual ICollection<Churros> Churros { get; set; }
    }
}
