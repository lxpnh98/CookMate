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

    public class Utilizador {

        [Key]
        public int id { 
            set;
            get;
        }

        [Required]
        [StringLength(50)]
        public string nome {
            set;
            get;
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email {
            set;
            get;
        }

        [Required]
        [Display(Name = "username")]
        public string username {
            get;
            set;
        }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password {
            get;
            set;
        }

        [Required]
        [Display(Name = "Pode adicionar receita")]
        public bool podeAdicionarReceita {
            get;
            set;
        }

        public virtual ICollection<Task> Tasks {
            get;
            set;
        }
    }
}
