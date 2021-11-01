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
    [Table("Tbl_Churros")]
    public class Churros
    {
        [Column("Id"), HiddenInput]
        public int Id { get; set; }
        [MaxLength(30), Required]
        public string Nome { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime DataDeAlteracao { get; set; }

        [DisplayName("Descrição"), MaxLength(40), Required]
        public string Descricao { get; set; }

        [Required]
        public Tamanho Tamanho { get; set; }

        [DisplayName("Disponível")]
        public bool Disponivel { get; set; }

        // Relacionamento 1:1
        [Required]
        public Cobertura Cobertura { get; set; }
        public int CoberturaId { get; set; }

        // Relacionamento 1:N
        [Required]
        public Recheio Recheio { get; set; }
        public int RecheioId { get; set; }

        // Relacionamento N:N
        public ICollection<ChurrosPedido> ChurrosPedidos { get; set; }

    }

    public enum Tamanho
    {
        [Description("Pequeno")]
        [Display(Name = "Pequeno")]
        PEQUENO,
        [Display(Name = "Médio")]
        [Description("Médio")]
        MEDIO,
        [Display(Name = "Grande")]
        [Description("Grande")]
        GRANDE
    }
}
