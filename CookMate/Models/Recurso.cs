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
        [ForeignKey("Video")]
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
        [ForeignKey("Imagem")]
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
        [ForeignKey("Descricao")]
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
        [ForeignKey("Hiperligacao")]
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

        public virtual ICollection<RecursoPasso> RecursoPassos {
            get;
            set;
        }

        public virtual ICollection<RecursoReceita> RecursoReceitas {
            get;
            set;
        }

        public virtual ICollection<RecursoTermo> RecursoTermos {
            get;
            set;
        }
    }
}
