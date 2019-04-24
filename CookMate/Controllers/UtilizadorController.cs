using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookMate.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookMate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadorController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Utilizador>> Get()
        {
            return new Utilizador[] {
                new Utilizador { Id=1, Username="lxpnh98", Email="lxpnh98@gmail.com"},
                new Utilizador { Id=2, Username="alice", Email="alice@hotmail.com"}
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
