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
        public IActionResult Initial(AddReceitaModel model) {
            int idReceita = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/intermedio.cshtml");
        }       
    }

    public class UtensilioModel {

        public string utensilio { get; set; }
    }
}
