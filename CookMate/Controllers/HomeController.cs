using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class HomeController : Controller {

        private readonly UtilizadorContext _context;

        public HomeController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult ClassificarApp() {
            Console.WriteLine("\n\n\nPASSEI AQUI 1\n\n\n");
            return View("~/Views/Home/classificarAplicacao.cshtml");
        }
        public IActionResult Logout()
        {
            Console.WriteLine("\n\n\nPASSEI AQUI 2\n\n\n");
            return View("_Login");
        }

    }
}
