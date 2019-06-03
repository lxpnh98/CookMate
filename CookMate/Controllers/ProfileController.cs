using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class ProfileController : Controller {

        private readonly UtilizadorContext _context;

        public ProfileController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Menu() {
            ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["receitas"] = _context.Receita.ToArray();
            return View("~/Views/Menu/menu.cshtml");
        }

        public IActionResult Delete(DeleteModel model) {
            int id = (int)HttpContext.Session.GetInt32("id");
            var user = _context.Utilizador.Find(id);
            if (user.password == model.password) {
                _context.Utilizador.Remove(user);
                _context.SaveChanges();
                return View("~/Views/Login/Login.cshtml");
            } else {
                ModelState.AddModelError("WrongLoginData", "The password provided is incorrect.");
                ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
                ViewData["user"] = user;
                return View("~/Views/Home/profile.cshtml");
            }   
        }
    }

    public class DeleteModel {

        public string password { get; set; }
    }
}
