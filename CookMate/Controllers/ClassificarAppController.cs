using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class ClassificarAppController : Controller {

        private readonly UtilizadorContext _context;

        public ClassificarAppController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Menu() {
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["receitas"] = _context.Receita.ToArray();
            return View("~/Views/Home/menu.cshtml");
        }

        [HttpPost]
        public IActionResult ClassificarApp(ClassAppModel model) {

            if (model.classificacao >=1 && model.classificacao <= 5 ) {
                int id = (int)HttpContext.Session.GetInt32("id");

                var aval = _context.Avaliacao.Where(a => a.idUtilizador == id).SingleOrDefault();
                if (aval == null) { 
                    var avaliacao = new Avaliacao
                    {
                        idUtilizador = id,
                        pontuacao = model.classificacao,
                        comentario = model.comentario
                    };
                    _context.Avaliacao.Add(avaliacao);
                    _context.SaveChanges();
                } else {
                    aval.pontuacao = model.classificacao;
                    aval.comentario = model.comentario;
                    _context.Avaliacao.Update(aval);
                    _context.SaveChanges();
                }
                ViewData["id"] = HttpContext.Session.GetInt32("id");
                ViewData["username"] = HttpContext.Session.GetString("username");
                ViewData["receitas"] = _context.Receita.ToArray();
                return View("~/Views/Home/menu.cshtml");
            } else {
                ModelState.AddModelError("MissingClassification", "Classification must be between 1 and 5.");
                return View("~/Views/Home/classificarAplicacao.cshtml");
            }
        }
    }

    public class ClassAppModel {

        public int classificacao { get; set; }

        public string comentario { get; set; }
    }
}