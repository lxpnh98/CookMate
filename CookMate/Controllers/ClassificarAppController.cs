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

        [HttpPost]
        public IActionResult ClassicarApp(ClassAppModel model) {

            if (model.classificao != null) {
                var avaliacao = new Avaliacao {
                    idUtilizador = HttpContext.Session.GetInt32("id");
                    pontuacao = model.classificao;
                    comentario = model.comentario;
                }
                _context.Avaliacao.Add(avaliacao);
                _context.SaveChanges();
                return View("~/Views/Home/menu.cshtml");
            } else {
                ModelState.AddModelError("MissingClassification", "Classification field is empty.");
                return View("~/Views/Home/classificarAplicacao.cshtml");
            }
        }
    }

    public class ClassAppModel {

        public int classficacao { get; set; }

        public string comentario { get; set; }
    }
}