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

    public class RecursoTermo {
        [Required]
        [ForeignKey("Termo")]
        public int idTermo {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Termo Termo {
            set;
            get;
        }

        [Required]
        [ForeignKey("Recurso")]
        public int idRecurso {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Recurso Recurso {
            set;
            get;
        }
    }
}
