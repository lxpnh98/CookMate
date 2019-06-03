using System;
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
        
        public IActionResult ClassificarReceita() {
            Console.WriteLine("\n\n\n Passei aqui \n\n\n");
            return View("~/Views/Home/classificarReceita.cshtml");
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Receita>> Get() {
            return _context.Receita.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
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

            var passos = _context.Passo.Where(r => r.idReceita == id).OrderBy(o=>o.ordem).ToList();

            ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
            ViewData["receita"] = receita;
            ViewData["ingredientes"] = ingredientes;
            ViewData["utensilios"] = utensilios;
            ViewData["passos"] = passos;

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
