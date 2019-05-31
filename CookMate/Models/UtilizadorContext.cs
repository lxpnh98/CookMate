﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<Task>     task { get; set; }
    }
}
