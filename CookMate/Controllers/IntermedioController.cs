using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;
using System.Text.RegularExpressions;

namespace CookMate.Controllers {

    public class IntermedioController : Controller
    {
        private readonly UtilizadorContext _context;

        public IntermedioController (UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Passo() {
            ViewData["idReceita"] = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/addPasso.cshtml");
        }

        public IActionResult Utensilio() {
            ViewData["idReceita"] = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/addUtensilio.cshtml");
        }

        public IActionResult Ingrediente() {
            ViewData["idReceita"] = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/addIngrediente.cshtml");
        }       

        public IActionResult Confirm() {
            int idReceita = (int)HttpContext.Session.GetInt32("idReceita");
            var lista = _context.Passo.Where(r => r.idReceita == idReceita);
            int total = 0;
            foreach (var p in lista) {
                total += p.tempo;
            }

            var receita = _context.Receita.Find(idReceita);
            double total2 = (double)total;
            receita.tempo = TimeSpan.FromMinutes(total2);

            _context.Receita.Update(receita);
            _context.SaveChanges();

            ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["receitas"] = _context.Receita.ToArray();
            return View("~/Views/Menu/menu.cshtml");
        }
    }
}
