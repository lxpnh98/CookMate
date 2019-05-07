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
    public class UtilizadorController : ControllerBase {

        private readonly UserContext _context;

        public UtilizadorController(UserContext context) {
            _context = context;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Utilizador>> Get() {
            return new Utilizador[] {
                new Utilizador { id=1, username="lxpnh98", email="lxpnh98@gmail.com"},
                new Utilizador { id=2, username="alice", email="alice@hotmail.com"}
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
