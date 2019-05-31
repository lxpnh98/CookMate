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

    public class Receita {

        [Key]
        public int id { 
            set;
            get;
        }

        [Required]
        [StringLength(150)]
        public string titulo {
            set;
            get;
        }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan tempo {
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

        public virtual ICollection<Passo> Passos {
            get;
            set;
        }

        public virtual ICollection<Ciclo> Ciclos {
            get;
            set;
        }

        public virtual ICollection<Classificacao> Classificacoes {
            get;
            set;
        }

        public virtual ICollection<IngredienteReceita> IngredienteReceitas {
            get;
            set;
        }

        public virtual ICollection<UtensilioReceita> UtensilioReceitas {
            get;
            set;
        }

        public virtual ICollection<UtilizadorReceita> UtilizadorReceitas {
            get;
            set;
        }

        public virtual ICollection<RecursoReceita> RecursoReceitas {
            get;
            set;
        }
    }
}
