using Newtonsoft.Json;
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

    public class Classificacao {

        [Required]
        public int pontuacao {
            set;
            get;
        }

        [Required]
        [StringLength(300)]
        public string comentario {
            set;
            get;
        }

        [Required]
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
    }
}
