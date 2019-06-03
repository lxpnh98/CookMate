using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class EliminarReceitaController : Controller {

        private readonly UtilizadorContext _context;

        public EliminarReceitaController(UtilizadorContext context) {
            _context = context;
        }

        [HttpPost]
        public IActionResult EliminarReceita(EliminarModel model) {

            int id = Int32.Parse(model.id);
            var receita = _context.Receita.Where(r => r.id == id).SingleOrDefault();

            if (receita != null) {
                _context.Receita.Remove(receita);
                _context.SaveChanges();
                return View("~/Views/Admin/menuAdmin.cshtml");
            } else {
                ModelState.AddModelError("WrongId", "The id provided is incorrect.");
                return View("~/Views/Admin/eliminarReceita.cshtml");
            }
        }
    }

    public class EliminarModel {
        public string id { get; set; }
    }
}