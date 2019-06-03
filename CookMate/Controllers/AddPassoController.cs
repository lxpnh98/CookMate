using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;
using System.Text.RegularExpressions;

namespace CookMate.Controllers {

    public class AddPassoController : Controller
    {
        private readonly UtilizadorContext _context;

        public AddPassoController (UtilizadorContext context) {
            _context = context;
        }
        /*
        public IActionResult Voltar() {
            Console.WriteLine("\n\n\n{0}\n\n\n",(int)HttpContext.Session.GetInt32("idReceita"));
            return View("~/Views/Home/intermedio.cshtml");
        }*/

        [HttpPost]
        public IActionResult Initial(AddReceitaModel model) {
            int idReceita = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/intermedio.cshtml");
        }       
    }
}
