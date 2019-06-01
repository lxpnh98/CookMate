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
    public class ReceitaController : Controller {

        private readonly UtilizadorContext _context;

        public ReceitaController(UtilizadorContext context) {
            _context = context;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Receita>> Get() {
            return _context.Receita.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Receita> Get(int id) {
            var receita = _context.Receita.Find(id);
            if (receita == null)
            {
                return NotFound();
            }
            return Ok(receita);
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
