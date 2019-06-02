using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookMate.Models;

namespace CookMate.Controllers {

    public class AdminChooseController : Controller {

        public IActionResult Menu() {
            return View("~/View/Home/menu.cshtml");
        }

        public IActionResult Admin() {
            return View();
        }
    }
}
