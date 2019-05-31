using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookMate.Models;

namespace CookMate.Controllers {

    public class RegisterController : Controller {

        private readonly UtilizadorContext _context;
        private Utilizador user = null;

        public RegisterController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Login() {
            return View("~/Views/Login/Login.cshtml");
        }
        
        public IActionResult Register() {
            return View("~/Views/Register/Register.cshtml");
        }
    
        [HttpPost]
        public IActionResult Register(RegisterModel model) {
            user = new Utilizador {
                        nome = model.nome,
                        email = model.email,
                        username = model.username,
                        password = model.password,
                        podeAdicionarReceita = false
            };
            return View("Register2");
        }
    }

    public class RegisterModel {

        public string email { get; set; }

        public string nome { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string sndPassword { get; set; }

        public int ano { get; set; }

        public int mes { get; set; }

        public int dia { get; set; }
    }
}
