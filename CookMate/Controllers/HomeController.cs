using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class HomeController : Controller {

        private readonly UtilizadorContext _context;

        public HomeController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Favorite() {
            var receitas = new List<Receita>();

            int id = (int)HttpContext.Session.GetInt32("id");
            var lista = _context.Utilizador.Where(u => u.id == id).SelectMany(u => u.UtilizadorReceitas);
            foreach(var ur in lista) {
                var r = _context.Receita.Find(ur.idReceita);
                receitas.Add(r);
            }
            ViewData["receitas"] = receitas;
            return View("~/Views/Home/receitasFavoritas.cshtml");
        }

        public IActionResult AddReceita() {
            int id = (int)HttpContext.Session.GetInt32("id");
            var user = _context.Utilizador.Find(id);
            if (user.podeAdicionarReceita) {
                return View("~/Views/Home/addReceita.cshtml");
            } else {
                ModelState.AddModelError("NaoAutorizado", "You don't have permission.");
                ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
                ViewData["username"] = HttpContext.Session.GetString("username");
                ViewData["receitas"] = _context.Receita.ToArray();
                return View("~/Views/Menu/menu.cshtml");
            }   
        }

        public IActionResult ClassificarApp() {
            return View("~/Views/Home/classificarAplicacao.cshtml");
        }

        public IActionResult Logout() {
            return View("~/Views/Login/Login.cshtml");
        }
    }
}
