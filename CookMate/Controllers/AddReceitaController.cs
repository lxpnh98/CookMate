using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;
using System.Text.RegularExpressions;

namespace CookMate.Controllers {

    public class AddReceitaController : Controller
    {
        private readonly UtilizadorContext _context;

        public AddReceitaController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Menu() {
            return View("~/Views/Home/Menu.cshtml");
        }

        [HttpPost]
        public IActionResult Initial(AddReceitaModel model) {

            var valid = true;
            if (model.titulo == null) {
                valid = false;
                ModelState.AddModelError("TituloInvalido", "Title must be non-empty.");
            }
            if (model.dificuldade >= 1 && model.dificuldade <= 5) {
                valid = false;
                ModelState.AddModelError("DificuldadeInvalida", "Difficulty must be between 1 and 5.");
            }
            if (model.valorEnergetico > 0) {
                valid = false;
                ModelState.AddModelError("ValorEnergeticoInvalida", "Energetic value must be a positive integer.");
            }
            if (model.categoria == null) {
                valid = false;
                ModelState.AddModelError("CategoriaInvalida", "Category must be non-empty.");
            }

            if (valid == true) {
                HttpContext.Session.SetString("titulo", model.titulo);
                HttpContext.Session.SetInt32("dificuldade", model.dificuldade);
                HttpContext.Session.SetInt32("valorEnergetico", model.valorEnergetico);
                HttpContext.Session.SetString("categoria", model.categoria);
            }
            return View("~/Views/Home/addPasso.cshtml");
        }
    }

    public class AddReceitaModel {
    
        public string titulo { get; set; }

        public int dificuldade { get; set; }
        
        public int valorEnergetico { get; set; }

        public string categoria { get; set; }    
    }
}
