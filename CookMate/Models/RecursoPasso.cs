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

    public class RecursoPasso {
        [Required]
        [ForeignKey("Passo")]
        public int idPasso {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Passo Passo {
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
