using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;
using System.Text.RegularExpressions;

namespace CookMate.Controllers {

    public class AddUtensilioController : Controller
    {
        private readonly UtilizadorContext _context;

        public AddUtensilioController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Voltar() {
            return View("~/Views/Home/intermedio.cshtml");
        }

        [HttpPost]
        public IActionResult Initial(UtensilioModel model) {

            int idReceita = (int)HttpContext.Session.GetInt32("idReceita");

            if (model.utensilio == null)
            {
                ViewData["id"] = HttpContext.Session.GetInt32("id");
                ViewData["username"] = HttpContext.Session.GetString("username");
                return View("~/Views/Home/intermedio.cshtml");
            }
            var utensilio = _context.Utensilio.Where(u => u.nome == model.utensilio).FirstOrDefault();

            if (utensilio == null)
            {
                utensilio = new Utensilio
                {
                    id = 0,
                    nome = model.utensilio
                };
                _context.Utensilio.Add(utensilio);
                _context.SaveChanges();
            }

            var existe = false;
            var lista = _context.Utensilio.Where(u => u.id == utensilio.id).SelectMany(r => r.UtensilioReceitas);
            foreach (var ur in lista)
            {
                var r = _context.Receita.Find(ur.idReceita);
                if (ur.idReceita != r.id) {
                    Console.WriteLine("\n\n\nAQUI 1\n\n\n");
                    existe = true;
                    break;
                }  
            }
            Console.WriteLine("\n\n\nAQUI 2\n\n\n");
            if (existe == false)
            {
                var utensilioReceita = new UtensilioReceita
                {
                    idReceita = idReceita,
                    idUtensilio = utensilio.id
                };
                _context.AddRange(utensilioReceita);
                _context.SaveChanges();
            }

            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");
            return View("~/Views/Home/intermedio.cshtml");
        }       
    }

    public class UtensilioModel {

        public string utensilio { get; set; }
    }
}
