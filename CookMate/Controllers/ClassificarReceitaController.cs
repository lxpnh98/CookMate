using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class ClassificarReceitaController : Controller {

        private readonly UtilizadorContext _context;

        public ClassificarReceitaController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Menu() {
            ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["receitas"] = _context.Receita.ToArray();
            return View("~/Views/Menu/menu.cshtml");
        }

        [HttpPost]
        public IActionResult ClassificarReceita(ClassAppModel model) {

            if (model.classificacao >=1 && model.classificacao <= 5 ) {
                int id = (int)HttpContext.Session.GetInt32("id");
                int idR = 1;

                var clas = _context.Classificao.Where(c => c.idUtilizador == id).SingleOrDefault();
                if (clas == null) { 
                    var classificao = new Classificacao
                    {
                        idUtilizador = id,
                        idReceita = idR,
                        pontuacao = model.classificacao,
                        comentario = model.comentario
                    };
                    _context.Classificao.Add(classificao);
                    _context.SaveChanges();
                } else {
                    clas.pontuacao = model.classificacao;
                    clas.comentario = model.comentario;
                    _context.Classificao.Update(clas);
                    _context.SaveChanges();
                }
                ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
                ViewData["username"] = HttpContext.Session.GetString("username");
                ViewData["receitas"] = _context.Receita.ToArray();
                return View("~/Views/Menu/menu.cshtml");
            } else {
                ModelState.AddModelError("MissingClassification", "Classification must be between 1 and 5.");
                return View("~/Views/Home/ClassificarReceita.cshtml");
            }
        }
    }

    public class ClassReceitaModel {

        public int classificacao { get; set; }

        public string comentario { get; set; }
    }
}