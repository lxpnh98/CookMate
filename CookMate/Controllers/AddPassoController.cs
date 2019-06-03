using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;
using System.Text.RegularExpressions;

namespace CookMate.Controllers {

    public class AddPassoController : Controller
    {
        private readonly UtilizadorContext _context;

        public AddPassoController (UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Confirm() {
            ViewData["idReceita"] = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/intermedio.cshtml");
        }

        public IActionResult AddRecurso() {
            ViewData["idPasso"] = (int)HttpContext.Session.GetInt32("idPasso");
            return View("~/Views/Home/addRecurso.cshtml");
        }

        [HttpPost]
        public IActionResult Initial(AddPassoModel model) {

            var valid = true;
            if (model.ordem <= 0) {
                valid = false;
                ModelState.AddModelError("OrdemInvalida", "Order must be a positive integer.");
            }
            if (model.descricao == null) {
                valid = false;
                ModelState.AddModelError("DescriptionInvalido", "Description must be non-empty.");
            }
            if (model.time <= 0) {
                valid = false;
                ModelState.AddModelError("TempoInvaliado", "Time must be valid (in minutes).");
            }

            if (valid == true) {
                var passo = new Passo {
                    tempo = model.time,
                    temporizador = false,
                    idReceita = (int)HttpContext.Session.GetInt32("idReceita"),
                    titulo = model.descricao,
                    ordem = model.ordem,
                    idOperacao = 0
                };
                _context.Passo.Add(passo);
                _context.SaveChanges();
                int idPasso = passo.id;
                HttpContext.Session.SetInt32("idPasso", idPasso);
                ViewData["idPasso"] = (int)HttpContext.Session.GetInt32("idPasso");
                return View("~/Views/Home/addRecurso.cshtml");
            }
            return View("~/Views/Home/addPasso.cshtml");
        }
    }

    public class AddPassoModel {

        public int ordem { get; set; }

        public string descricao { get; set; }

        public int time { get; set; }
    }
}
