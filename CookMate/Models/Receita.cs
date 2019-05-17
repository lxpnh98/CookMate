using Newtonsoft.Json;
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

    public class Receita {

        [Key]
        public int id { 
            set;
            get;
        }

        [Required]
        [StringLength(150)]
        public string titulo {
            set;
            get;
        }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan tempo {
            set;
            get;
        }

        [Required]
        [ForeignKey("Categoria")]
        public int idCategoria {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Categoria categoria {
            set;
            get;
        }

    }

    public class ReceitaContext : DbContext {

        public ReceitaContext(DbContextOptions<ReceitaContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //modelBuilder.Entity<Receita>()
            //        .HasOne(r => r.categoria)
            //        .HasForeignKey(r => r.idCategoria)
            //        .HasConstraintName("idCategoria1");
        }

        public DbSet<Receita> Receita {
            get;
            set;
        }

        public DbSet<Models.Task> task {
            get;
            set;
        }
    }
}
