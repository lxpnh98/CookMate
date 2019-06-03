using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class AdminChooseController : Controller {

        private readonly UtilizadorContext _context;

        public AdminChooseController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult MenuUser() {
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["receitas"] = _context.Receita.ToArray();
            return View("~/Views/Menu/menu.cshtml");
        }

        public IActionResult MenuAdmin() {
           return View("~/Views/Admin/menuAdmin.cshtml");
        }
    }
}
