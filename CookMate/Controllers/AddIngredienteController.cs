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

        public IActionResult Confirm()
        {
            ViewData["idReceita"] = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/intermedio.cshtml");
        }

        [HttpPost]
        public IActionResult Initial(IngredienteModel model) {

            int idReceita = (int)HttpContext.Session.GetInt32("idReceita");
            var valid = true;

            if (model.ingrediente == null)
            {
                valid = false;
                ModelState.AddModelError("IngredienteInvalido", "Ingredient must be not null.");
            } else if (model.quantidade <= 0)
            {
                valid = false;
                ModelState.AddModelError("QuantidadeInvaliado", "Quantity must be greater than 0.");
            } else if (model.unidade == null)
            {
                valid = false;
                ModelState.AddModelError("UnidadeInvaliado", "Unity must be not null.");
            }

            if (valid == true)
            {
                var ingrediente = _context.Ingrediente.Where(i => i.nome == model.ingrediente).FirstOrDefault();

                if (ingrediente == null)
                {
                    ingrediente = new Ingrediente
                    {
                        id = 0,
                        nome = model.ingrediente,
                        valor = model.quantidade,
                        unidade = model.unidade
                    };
                    _context.Ingrediente.Add(ingrediente);
                    _context.SaveChanges();
                }

                var existe = false;
                var lista = _context.Ingrediente.Where(i => i.id == ingrediente.id).SelectMany(r => r.IngredienteReceitas);
                foreach (var ur in lista)
                {
                    var r = _context.Receita.Find(ur.idReceita);
                    if (ur.idReceita == r.id)
                    {
                        existe = true;
                        break;
                    }
                }

                if (existe == false)
                {
                    var ingredienteReceita = new IngredienteReceita
                    {
                        idReceita = idReceita,
                        idIngrediente = ingrediente.id
                    };
                    _context.AddRange(ingredienteReceita);
                    _context.SaveChanges();
                }
            }
            
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            return View("~/Views/Home/addIngrediente.cshtml");
        }       
    }

    public class IngredienteModel {

        public string ingrediente { get; set; }

        public int quantidade { get; set; }

        public string unidade { get; set; }
    }
}
