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

    public class Ciclo {

        [Key]
        public int id {
            set;
            get;
        }

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
        [ForeignKey("Passo")]
        public int primeiroPasso {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Passo PrimeiroPasso {
            set;
            get;
        }

        [Required]
        [ForeignKey("Passo")]
        public int ultimoPasso {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Passo UltimoPasso {
            set;
            get;
        }
    }
}
