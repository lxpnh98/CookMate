using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class MenuController : Controller {

        private readonly UtilizadorContext _context;

        public MenuController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Logout() {
            return View("_Login");
        }

    }
}