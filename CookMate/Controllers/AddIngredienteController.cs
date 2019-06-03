using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;
using System.Text.RegularExpressions;

namespace CookMate.Controllers {

    public class AddIngredienteController : Controller
    {
        private readonly UtilizadorContext _context;

        public AddIngredienteController(UtilizadorContext context) {
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

    public class IngredienteModel {

        public string ingrediente { get; set; }

        public string quantidade { get; set; }

        public string unidade { get; set; }
    }
}
