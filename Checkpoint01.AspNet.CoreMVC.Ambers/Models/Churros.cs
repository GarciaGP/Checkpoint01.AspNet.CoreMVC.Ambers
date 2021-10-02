using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Models
{
    public class Churros
    {
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

        [Required]
        public string Cobertura { get; set; }

        [Required]
        public string Recheio { get; set; }
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
