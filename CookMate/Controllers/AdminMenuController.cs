using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class AdminMenuController : Controller {

        public IActionResult AddAdmin() {
            return View("~/Views/Admin/promoverUser.cshtml");
        }

        public IActionResult AddReceitas() {
            return View("~/Views/Admin/autorizarUser.cshtml");
        }

        public IActionResult DeleteReceitas() {
            return View("~/Views/Admin/eliminarReceita.cshtml");
        }

        public IActionResult AdminLogout() {
            return View("~/Views/Login/Login.cshtml");
        }

    }
}
