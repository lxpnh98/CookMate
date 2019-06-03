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

    public class Utensilio {

        [Key]
        public int id { 
            set;
            get;
        }

        [Required]
        [StringLength(100)]
        public string nome {
            set;
            get;
        }

        public virtual ICollection<UtensilioReceita> UtensilioReceitas {
            get;
            set;
        }
    }
}
