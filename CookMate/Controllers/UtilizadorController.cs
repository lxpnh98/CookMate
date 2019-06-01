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
    public class UtilizadorController : Controller {

        private readonly UtilizadorContext _context;

        public UtilizadorController(UtilizadorContext context) {
            _context = context;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Utilizador>> Get() {
            return _context.Utilizador.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var utilizador = _context.Utilizador.Find(id);
            if (utilizador == null)
            {
                return NoContent();
            }
            ViewData["user"] = utilizador;
            return View("~/Views/Home/profile.cshtml");
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
        public IActionResult Add([FromBody] Utilizador utilizador)
        {
            _context.Utilizador.Add(utilizador);
            _context.SaveChanges();
            return new CreatedResult($"/api/utilizador/{utilizador.id}", utilizador);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            var user = _context.Utilizador.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            _context.Utilizador.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
