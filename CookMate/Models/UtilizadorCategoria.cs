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

    public class UtilizadorCategoria {
        [Required]
        [ForeignKey("Utilizador")]
        public int idUtilizador {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Utilizador Utilizador {
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
        public Categoria Categoria {
            set;
            get;
        }
    }
}
