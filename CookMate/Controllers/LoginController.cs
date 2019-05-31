using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CookMate.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserLogin(string username, string password)
        {
            if (username == "1") return NoContent();
            Console.WriteLine("Hello");
            Console.WriteLine(ModelState.ToString());
            return View();
        }
    }
}