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

    public class Passo {

        [Key]
        public int id {
            set;
            get;
        }

        [Required]
        public int tempo {
            set;
            get;
        }

        [Required]
        public bool temporizador {
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

        [Required]
        public string titulo {
            set;
            get;
        }

        [Required]
        public int ordem {
            set;
            get;
        }

        [Required]
        [ForeignKey("Operacao")]
        public int idOperacao {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Operacao Operacao {
            set;
            get;
        }

        public virtual ICollection<IngredientePasso> IngredientePassos {
            get;
            set;
        }

        public virtual ICollection<RecursoPasso> RecursoPassos {
            get;
            set;
        }
    }
}
