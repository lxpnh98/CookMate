using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookMate.Models;

namespace CookMate.Controllers {

    public class AdminChooseController : Controller {
 
        private readonly UtilizadorContext _context;

        public AdminChooseController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult MenuUser() {
            return View("~/Views/Home/menu.cshtml");
        }

        public IActionResult MenuAdmin() {
           return View("~/Views/Admin/menuAdmin.cshtml");
        }
    }
}
