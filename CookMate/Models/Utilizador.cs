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

    public class Utilizador {

        [Key]
        public int id { 
            set;
            get;
        }

        [Required]
        [StringLength(50)]
        public string nome {
            set;
            get;
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email {
            set;
            get;
        }

        [Required]
        [Display(Name = "username")]
        public string username {
            get;
            set;
        }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password {
            get;
            set;
        }

        public virtual ICollection<Task> Tasks {
            get;
            set;
        }
    }

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

        public DbSet<Utilizador> Utilizador {
            get;
            set;
        }

        public DbSet<Receita> Receita {
            get;
            set;
        }

        public DbSet<Categoria> Categoria {
            get;
            set;
        }

        public DbSet<Ingrediente> Ingrediente {
            get;
            set;
        }

        public DbSet<Operacao> Operacao {
            get;
            set;
        }

        public DbSet<Models.Task> task {
            get;
            set;
        }
    }
}
