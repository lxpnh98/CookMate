using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookMate.Models;
using CookMate.Controllers;
using CookMate.shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CookMate.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : Controller {

        private readonly UtilizadorContext _context;

        public ReceitaController(UtilizadorContext context) {
            _context = context;
        }

        [Route("~/Menu")]
        public IActionResult Menu() {
            ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["receitas"] = _context.Receita.ToArray();
            return View("~/Views/Menu/menu.cshtml");
        }

        [Route("~/ClassificarReceita")]
        public IActionResult ClassificarReceita() {
            return View("~/Views/Home/classificarReceita.cshtml");
        }

        [Route("~/ReceitaFavorita")]
        public IActionResult ReceitaFavorita([FromQuery] FavoritaModel model)
        {
            var id = (int)HttpContext.Session.GetInt32("id");
            var urs = _context.Utilizador.Where(u => u.id == id).SelectMany(u => u.UtilizadorReceitas);
            var redundant = false;
            foreach (var ur in urs) {
                if (ur.idReceita == model.recipe) {
                    redundant = true;
                    break;
                }
            }

            if (redundant == false) {
                _context.AddRange(
                    new UtilizadorReceita {
                        idUtilizador = id,
                        idReceita = model.recipe 
                    }
                );
            }
            
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["receitas"] = _context.Receita.ToArray();
            return View("~/Views/Menu/menu.cshtml");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("/api/Receita/{id}")]
        public ActionResult Get(int id) {
            var receita = _context.Receita.Find(id);
            if (receita == null)
            {
                return NoContent();
            }

            var ingredientes = new List<Ingrediente>();
            var irs = _context.Receita.Where(r => r.id == id).SelectMany(r => r.IngredienteReceitas);
            foreach (var ir in irs) {
                var i = _context.Ingrediente.Find(ir.idIngrediente);
                ingredientes.Add(i);
            }

            var utensilios = new List<Utensilio>();
            var urs = _context.Receita.Where(r => r.id == id).SelectMany(r => r.UtensilioReceitas);
            foreach (var ur in urs) {
                var u = _context.Utensilio.Find(ur.idUtensilio);
                utensilios.Add(u);
            }

            var recursos = new List<Recurso>();
            var rrs = _context.Receita.Where(r => r.id == id).SelectMany(r => r.RecursoReceitas).OrderBy(rr => rr.ordem).ToList();
            foreach (var rr in rrs) {
                var r = _context.Recurso.Find(rr.idRecurso);
                switch (r.tipo) {
                    case 0:
                        r.Video = _context.Video.Find(r.idVideo);
                        break;
                    case 1:
                        r.Imagem = _context.Imagem.Find(r.idImagem);
                        break;
                    case 2:
                        r.Descricao = _context.Descricao.Find(r.idDescricao);
                        break;
                    case 3:
                        r.Hiperligacao = _context.Hiperligacao.Find(r.idHiperligacao);
                        break;
                }
                recursos.Add(r);
            }

            var passos = _context.Passo.Where(r => r.idReceita == id).OrderBy(o=>o.ordem).ToList();

            ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
            ViewData["receita"] = receita;
            ViewData["ingredientes"] = ingredientes;
            ViewData["utensilios"] = utensilios;
            ViewData["passos"] = passos;
            ViewData["recursos"] = recursos;

            return View("~/Views/Home/receita.cshtml");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }


        [HttpPost]
        public IActionResult Add([FromBody] Receita receita) {
            _context.Receita.Add(receita);
            _context.SaveChanges();
            return new CreatedResult($"/api/receita/{receita.id}", receita);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id) {
            var receita = _context.Receita.Find(id);
            if(receita == null)
            {
                return NotFound();
            }
            _context.Receita.Remove(receita);
            _context.SaveChanges();
            return NoContent();
        }
    }

    public class FavoritaModel {

        public int recipe { get; set; }
    }
    
}
