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

    public class Task {

        [Key]
        public int Codigo {
            set;
            get;
        }

        [Required]
        [StringLength(20)]
        public string Nome {
            set;
            get;
        }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Data {
            set;
            get;
        }

        [Required]
        public int User_id {
            set;
            get;
        }

        [NotMapped]
        [JsonIgnore]
        public Utilizador User {
            set;
            get;
        }
    }
    }