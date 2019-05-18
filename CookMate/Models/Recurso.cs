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

    public class Recurso {

        [Key]
        public int id {
            set;
            get;
        }

        [Required]
        public int tipo {
            set;
            get;
        }

        [Required]
        public int idVideo {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Video Video {
            set;
            get;
        }

        [Required]
        public int idImagem {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Imagem Imagem {
            set;
            get;
        }

        [Required]
        public int idDescricao {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Descricao Descricao {
            set;
            get;
        }

        [Required]
        public int idHiperligacao {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Hiperligacao Hiperligacao {
            set;
            get;
        }

    }
}
