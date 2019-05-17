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

    public class Categoria {

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
    }

    public class CategoriaContext : DbContext {

        public CategoriaContext(DbContextOptions<CategoriaContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //modelBuilder.Entity<Task>()
            //        .HasOne(t => t.User)
            //       .WithMany(u => u.Tasks)
            //      .HasForeignKey(t => t.User_id)
            //     .HasConstraintName("ForeignKey_User_Task");
        }

        public DbSet<Categoria> Categoria {
            get;
            set;
        }
    }
}
