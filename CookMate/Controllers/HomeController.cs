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
            return View("~/Views/Home/classificarAplicacao.cshtml");
        }

        public IActionResult Logout() {
            return View("~/Views/Login/Login.cshtml");
        }

    }
}
