using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookMate.Models;

namespace CookMate.Controllers {

    public class LoginController : Controller {

        private readonly UtilizadorContext _context;

        public LoginController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Login() {
            return View();
        }

        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model) {
            var user = _context.Utilizador.Where(u => u.username == model.username).SingleOrDefault();

            if (user != null && user.password == model.password) {
                 return View("~/Views/Home/menu.cshtml");
            }
            return View();
        }
    }

    public class LoginModel {

        public string username { get; set; }

        public string password { get; set; }
    }
}