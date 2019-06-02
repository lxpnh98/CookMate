using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookMate.Models;

namespace CookMate.Controllers {

    public class AdminChooseController : Controller {

        public IActionResult MenuUser() {
            return View("~/Views/Home/menu.cshtml");
        }

        public IActionResult MenuAdmin() {
            return View("~/Views/Home/menuAdmin.cshtml");
        }
    }
}
