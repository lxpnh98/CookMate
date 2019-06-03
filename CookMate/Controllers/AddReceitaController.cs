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
            ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["receitas"] = _context.Receita.ToArray();
            return View("~/Views/Menu/menu.cshtml");
        }

        [HttpPost]
        public IActionResult Initial(AddReceitaModel model) {

            var valid = true;
            if (model.titulo == null) {
                valid = false;
                ModelState.AddModelError("TituloInvalido", "Title must be non-empty.");
            }
            if (model.dificuldade < 1 || model.dificuldade > 5) {
                valid = false;
                ModelState.AddModelError("DificuldadeInvalida", "Difficulty must be between 1 and 5.");
            }
            if (model.valorEnergetico < 0) {
                valid = false;
                ModelState.AddModelError("ValorEnergeticoInvalida", "Energetic value must be a positive integer.");
            }
            if (model.categoria == null) {
                valid = false;
                ModelState.AddModelError("CategoriaInvalida", "Category must be non-empty.");
            }

            if (valid == true) {
                var categoria = _context.Categoria.Where(c => c.nome == model.categoria).FirstOrDefault();

                if (categoria == null)
                {
                    categoria = new Categoria {
                        id = 0,
                        nome = model.categoria
                    };
                    _context.Categoria.Add(categoria);
                    _context.SaveChanges();
                }
                var receita = new Receita {
                    titulo = model.titulo,
                    dificuldade = model.dificuldade,
                    tempo = new TimeSpan(0,0,0),
                    valorEnergetico = model.valorEnergetico,
                    idCategoria = categoria.id,
                    imagem = " "
                };
                _context.Receita.Add(receita);
                _context.SaveChanges();
                int idReceita = receita.id;
                Console.WriteLine("\n\n\n{0}\n\n\n",idReceita);
                HttpContext.Session.SetInt32("idReceita", idReceita);
                ViewData["idReceita"] = (int)HttpContext.Session.GetInt32("idReceita");
                return View("~/Views/Home/intermedio.cshtml");
            }
            return View("~/Views/Home/addReceita.cshtml");
        }
    }

    public class AddReceitaModel {
    
        public string titulo { get; set; }

        public int dificuldade { get; set; }
        
        public int valorEnergetico { get; set; }

        public string categoria { get; set; }    
    }
}
