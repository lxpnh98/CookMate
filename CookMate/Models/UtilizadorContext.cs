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
            // 1 Receita, * Passo
            modelBuilder.Entity<Passo>()
                    .HasOne(p => p.Receita)
                    .WithMany(r => r.Passos)
                    .HasForeignKey(p => p.idReceita)
                    .HasConstraintName("fk_Passo_Receita1");
            
            // 1 Receita, * Ciclo
            modelBuilder.Entity<Ciclo>()
                    .HasOne(c => c.Receita)
                    .WithMany(r => r.Ciclos)
                    .HasForeignKey(c => c.idReceita)
                    .HasConstraintName("fk_Ciclo_Receita1");
            
            // 1 Receita, * Classificacao
            modelBuilder.Entity<Classificacao>()
                    .HasOne(c => c.Receita)
                    .WithMany(r => r.Classificacoes)
                    .HasForeignKey(c => c.idReceita)
                    .HasConstraintName("idReceita1");

            // Classificacao composite key
            modelBuilder.Entity<Classificacao>()
                    .HasKey(c => new { c.idUtilizador, c.idReceita });

            // * Receita, * Ingrediente
            modelBuilder.Entity<IngredienteReceita>()
                    .HasKey(ir => new { ir.idIngrediente, ir.idReceita });
            modelBuilder.Entity<IngredienteReceita>()
                    .HasOne<Receita>(ir => ir.Receita)
                    .WithMany(r => r.IngredienteReceitas)
                    .HasForeignKey(ir => ir.idReceita);
            modelBuilder.Entity<IngredienteReceita>()
                    .HasOne<Ingrediente>(ir => ir.Ingrediente)
                    .WithMany(i => i.IngredienteReceitas)
                    .HasForeignKey(ir => ir.idIngrediente);

            // * Receita, * Utensilio
            modelBuilder.Entity<UtensilioReceita>()
                    .HasKey(i => new { i.idUtensilio, i.idReceita });
            modelBuilder.Entity<UtensilioReceita>()
                    .HasOne<Receita>(ur => ur.Receita)
                    .WithMany(r => r.UtensilioReceitas)
                    .HasForeignKey(ur => ur.idReceita);
            modelBuilder.Entity<UtensilioReceita>()
                    .HasOne<Utensilio>(ur => ur.Utensilio)
                    .WithMany(u => u.UtensilioReceitas)
                    .HasForeignKey(ur => ur.idUtensilio);

            // * Passo, * Ingrediente
            modelBuilder.Entity<IngredientePasso>()
                    .HasKey(ip => new { ip.idPasso, ip.idIngrediente });
            modelBuilder.Entity<IngredientePasso>()
                    .HasOne<Passo>(ip => ip.Passo)
                    .WithMany(p => p.IngredientePassos)
                    .HasForeignKey(ip => ip.idPasso);
            modelBuilder.Entity<IngredientePasso>()
                    .HasOne<Ingrediente>(ip => ip.Ingrediente)
                    .WithMany(i => i.IngredientePassos)
                    .HasForeignKey(ip => ip.idIngrediente);

            // * Passo, * Recurso
            modelBuilder.Entity<RecursoPasso>()
                    .HasKey(rp => new { rp.idPasso, rp.idRecurso });
            modelBuilder.Entity<RecursoPasso>()
                    .HasOne<Passo>(rp => rp.Passo)
                    .WithMany(p => p.RecursoPassos)
                    .HasForeignKey(rp => rp.idPasso);
            modelBuilder.Entity<RecursoPasso>()
                    .HasOne<Recurso>(rp => rp.Recurso)
                    .WithMany(i => i.RecursoPassos)
                    .HasForeignKey(rp => rp.idRecurso);

            // * Utilizador, * Categoria (preferências)
            modelBuilder.Entity<UtilizadorCategoria>()
                    .HasKey(uc => new { uc.idUtilizador, uc.idCategoria });
            modelBuilder.Entity<UtilizadorCategoria>()
                    .HasOne<Utilizador>(uc => uc.Utilizador)
                    .WithMany(p => p.UtilizadorCategorias)
                    .HasForeignKey(uc => uc.idUtilizador);
            modelBuilder.Entity<UtilizadorCategoria>()
                    .HasOne<Categoria>(uc => uc.Categoria)
                    .WithMany(i => i.UtilizadorCategorias)
                    .HasForeignKey(uc => uc.idCategoria);

            // * Utilizador, * Ingrediente (preferências)
            modelBuilder.Entity<UtilizadorIngrediente>()
                    .HasKey(ui => new { ui.idUtilizador, ui.idIngrediente });
            modelBuilder.Entity<UtilizadorIngrediente>()
                    .HasOne<Utilizador>(ui => ui.Utilizador)
                    .WithMany(p => p.UtilizadorIngredientes)
                    .HasForeignKey(ui => ui.idUtilizador);
            modelBuilder.Entity<UtilizadorIngrediente>()
                    .HasOne<Ingrediente>(ui => ui.Ingrediente)
                    .WithMany(i => i.UtilizadorIngredientes)
                    .HasForeignKey(ui => ui.idIngrediente);

            // * Utilizador, * Receita (favoritas)
            modelBuilder.Entity<UtilizadorReceita>()
                    .HasKey(ur => new { ur.idUtilizador, ur.idReceita });
            modelBuilder.Entity<UtilizadorReceita>()
                    .HasOne<Utilizador>(ur => ur.Utilizador)
                    .WithMany(p => p.UtilizadorReceitas)
                    .HasForeignKey(ur => ur.idUtilizador);
            modelBuilder.Entity<UtilizadorReceita>()
                    .HasOne<Receita>(ur => ur.Receita)
                    .WithMany(i => i.UtilizadorReceitas)
                    .HasForeignKey(ur => ur.idReceita);

            // * Receita, * Recurso
            modelBuilder.Entity<RecursoReceita>()
                    .HasKey(rp => new { rp.idReceita, rp.idRecurso });
            modelBuilder.Entity<RecursoReceita>()
                    .HasOne<Receita>(rp => rp.Receita)
                    .WithMany(p => p.RecursoReceitas)
                    .HasForeignKey(rp => rp.idReceita);
            modelBuilder.Entity<RecursoReceita>()
                    .HasOne<Recurso>(rp => rp.Recurso)
                    .WithMany(i => i.RecursoReceitas)
                    .HasForeignKey(rp => rp.idRecurso);

            // * Termo, * Recurso
            modelBuilder.Entity<RecursoTermo>()
                    .HasKey(rp => new { rp.idTermo, rp.idRecurso });
            modelBuilder.Entity<RecursoTermo>()
                    .HasOne<Termo>(rp => rp.Termo)
                    .WithMany(p => p.RecursoTermos)
                    .HasForeignKey(rp => rp.idTermo);
            modelBuilder.Entity<RecursoTermo>()
                    .HasOne<Termo>(rp => rp.Termo)
                    .WithMany(i => i.RecursoTermos)
                    .HasForeignKey(rp => rp.idTermo);

        }

        public Utilizador registerUser { get; set; }

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

        public DbSet<Task>     task { get; set; }
    }
}
