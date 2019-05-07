﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class UserContext : DbContext {

        public UserContext(DbContextOptions<UserContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Task>()
                    .HasOne(t => t.user)
                    .WithMany(u => u.Tasks)
                    .HasForeignKey(t => t.user_id)
                    .HasConstraintName("ForeignKey_User_Task");
        }

        public DbSet<Utilizador> user {
            get;
            set;
        }

        public DbSet<Models.Task> task {
            get;
            set;
        }
    }
}