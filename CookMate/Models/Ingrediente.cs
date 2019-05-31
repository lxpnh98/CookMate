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

    public class Ingrediente {

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
        public int valor {
            set;
            get;
        }

        [Required]
        [StringLength(25)]
        public string unidade {
            set;
            get;
        }

        public virtual ICollection<IngredienteReceita> IngredienteReceitas {
            get;
            set;
        }

        public virtual ICollection<IngredientePasso> IngredientePassos {
            get;
            set;
        }
    }
}
