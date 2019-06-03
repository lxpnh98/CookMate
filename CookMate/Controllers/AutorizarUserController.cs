using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class AutorizarUserController : Controller {

        private readonly UtilizadorContext _context;

        public AutorizarUserController(UtilizadorContext context) {
            _context = context;
        }

        [HttpPost]
        public IActionResult AutorizarUser(AutorizarModel model) {
            var user = _context.Utilizador.Where(u => u.username == model.username).SingleOrDefault();

            if (user != null) {
                user.podeAdicionarReceita = true;
                _context.Utilizador.Update(user);
                _context.SaveChanges();
                return View("~/Views/Admin/menuAdmin.cshtml");
            } else {
                ModelState.AddModelError("WrongUsername", "The username provided is incorrect.");
                return View("~/Views/Admin/autorizarUser.cshtml");
            }
        }
    }

    public class AutorizarModel {
        public string username { get; set; }
    }
}