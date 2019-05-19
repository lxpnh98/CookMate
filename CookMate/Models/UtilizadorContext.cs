using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CookMate.Models;
using CookMate.Controllers;
using CookMate.shared;

namespace CookMate.Models {

    public class UtilizadorContext : DbContext {

        public UtilizadorContext(DbContextOptions<UtilizadorContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Task>()
                    .HasOne(t => t.User)
                    .WithMany(u => u.Tasks)
                    .HasForeignKey(t => t.User_id)
                    .HasConstraintName("ForeignKey_User_Task");
        }

        public DbSet<Utilizador>    Utilizador { get; set; }

        public DbSet<Receita>       Receita { get; set; }

        public DbSet<Categoria>     Categoria { get; set; }

        public DbSet<Ingrediente>   Ingrediente { get; set; }

        public DbSet<Operacao>      Operacao { get; set; }

        public DbSet<Passo>         Passo { get; set; }

        public DbSet<Ciclo>         Ciclo { get; set; }

        public DbSet<Classificacao> Classificao { get; set; }

        public DbSet<Avaliacao>     Avaliacao { get; set; }

        public DbSet<Termo>         Termo { get; set; }

        public DbSet<Video>         Video { get; set; }

        public DbSet<Imagem>        Imagem { get; set; }

        public DbSet<Descricao>     Descricao { get; set; }

        public DbSet<Hiperligacao>  Hiperligacao { get; set; }

        public DbSet<Recurso>       Recurso { get; set; }

        public DbSet<Utensilio>     Utensilio { get; set; }

        public DbSet<Task> task { get; set; }
    }
}
