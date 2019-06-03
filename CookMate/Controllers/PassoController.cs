using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookMate.Models;
using CookMate.Controllers;
using CookMate.shared;
using Microsoft.AspNetCore.Mvc;

namespace CookMate.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class PassoController : Controller {

        private readonly UtilizadorContext _context;

        public PassoController(UtilizadorContext context) {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Passo>> Get() {
            return _context.Passo.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id) {
            var passo = _context.Passo.Find(id);
            if (passo == null)
            {
                return NoContent();
            }

            var receita = _context.Receita.Find(passo.idReceita);
            var ingredientes = new List<Ingrediente>();
            var ips = _context.Passo.Where(p => p.id == id).SelectMany(r => r.IngredientePassos);
            foreach (var ip in ips) {
                var i = _context.Ingrediente.Find(ip.idIngrediente);
                ingredientes.Add(i);
            }

            var recursos = new List<Recurso>();
            var rrs = _context.Passo.Where(p => p.id == id).SelectMany(p => p.RecursoPassos).OrderBy(rr => rr.ordem).ToList();
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

            var next = _context.Passo.Where(p => p.idReceita == passo.idReceita && p.ordem == passo.ordem + 1).SingleOrDefault();
            var previous = _context.Passo.Where(p => p.idReceita == passo.idReceita && p.ordem == passo.ordem - 1).SingleOrDefault();

            ViewData["receita"] = receita;
            ViewData["passo"] = passo;
            ViewData["next"] = next;
            ViewData["previous"] = previous;
            ViewData["ingredientes"] = ingredientes;
            ViewData["recursos"] = recursos;
            return View("~/Views/Home/passo.cshtml");
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
        public IActionResult Add([FromBody] Receita receita)
        {
            _context.Receita.Add(receita);
            _context.SaveChanges();
            return new CreatedResult($"/api/receita/{receita.id}", receita);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
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
}
