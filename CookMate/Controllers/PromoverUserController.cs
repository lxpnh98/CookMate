using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class PromoverUserController : Controller {

        private readonly UtilizadorContext _context;

        public PromoverUserController(UtilizadorContext context) {
            _context = context;
        }
        
        public IActionResult promoverUser() {

            return View("~/Views/Admin/menuAdmin.cshtml");
        }


    }
}