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

    public class IngredienteReceita {
        [Required]
        [ForeignKey("Receita")]
        public int idReceita {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Receita Receita {
            set;
            get;
        }

        [Required]
        [ForeignKey("Ingrediente")]
        public int idIngrediente {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Ingrediente Ingrediente {
            set;
            get;
        }


    }
}
