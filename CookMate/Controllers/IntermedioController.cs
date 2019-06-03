using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;
using System.Text.RegularExpressions;

namespace CookMate.Controllers {

    public class IntermedioController : Controller
    {
        private readonly UtilizadorContext _context;

        public IntermedioController (UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Passo() {
            Console.WriteLine("\n\n\n{0}\n\n\n",(int)HttpContext.Session.GetInt32("idReceita"));
            ViewData["idReceita"] = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/addPasso.cshtml");
        }

        public IActionResult Utensilio() {
            ViewData["idReceita"] = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/addUtensilio.cshtml");
        }

        public IActionResult Ingrediente() {
            ViewData["idReceita"] = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/addIngredinete.cshtml");
        }       

        public IActionResult Confirm() {
            ViewData["id"] = (int)HttpContext.Session.GetInt32("id");
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["receitas"] = _context.Receita.ToArray();
            return View("~/Views/Menu/menu.cshtml");
        }
    }
}
