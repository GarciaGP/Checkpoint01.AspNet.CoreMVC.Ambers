using Checkpoint01.AspNet.CoreMVC.Ambers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Persistencia
{
    public class IChurrosContext : DbContext
    {
        public DbSet<Churros> Churros { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Recheio> Recheios{ get; set; }
        public DbSet<Cobertura> Coberturas { get; set; }
        public DbSet<ChurrosPedido> ChurrosPedidos { get; set; }

        //Construtor que recebe a string de conexão do banco
        public IChurrosContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chave composta da tabela associativa
            modelBuilder.Entity<ChurrosPedido>().HasKey(a => new { a.ChurrosId, a.PedidoId });

            //Configurar o relacionamento do filme com a tabela associativa
            modelBuilder.Entity<ChurrosPedido>()
                .HasOne(a => a.Churros)
                .WithMany(a => a.ChurrosPedidos)
                .HasForeignKey(a => a.ChurrosId);

            //Configurar o relacionamento do ator com a tabela associativa
            modelBuilder.Entity<ChurrosPedido>()
                .HasOne(a => a.Pedido)
                .WithMany(a => a.ChurrosPedidos)
                .HasForeignKey(a => a.PedidoId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
