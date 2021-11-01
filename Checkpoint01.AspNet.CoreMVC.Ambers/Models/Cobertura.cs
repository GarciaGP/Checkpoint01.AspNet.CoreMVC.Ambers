using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Models
{
    [Table("Tbl_Cobertura")]
    public class Cobertura
    {
        [Column("Id"), HiddenInput]
        public int CoberturaId { get; set; }

        [Column("Descricao"), Required, MaxLength(50), DisplayName("Descrição")]
        public string Descricao { get; set; }

    }
}
