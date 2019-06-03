using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;
using System.Text.RegularExpressions;

namespace CookMate.Controllers {

    public class RegisterController : Controller
    {
        private readonly UtilizadorContext _context;

        public RegisterController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Login() {
            return View("~/Views/Login/Login.cshtml");
        }

        public IActionResult Register() {
            return View("~/Views/Register/Register.cshtml");
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            var valid = true;
            if (model.password == null || model.password.Length < 8)
            {
                valid = false;
                ModelState.AddModelError("PasswordTooShort", "Password must be at least 8 characters.");
            } else if (model.password != model.sndPassword)
            {
                valid = false;
                ModelState.AddModelError("NonMatchingPasswords", "Password must be the same.");
            }
            if (model.nome == null)
            {
                valid = false;
                ModelState.AddModelError("EmptyName", "Name field is obligatory.");
            }
            if (model.username == null)
            {
                valid = false;
                ModelState.AddModelError("EmptyUsername", "Username field is obligatory.");
            }
            if (this.emailValido(model.email) == false)
            {
                valid = false;
                ModelState.AddModelError("InvalidEmail", "Email provided is not valid.");
            }
            if (model.ano == 0 || model.mes == 0 || model.dia == 0) {
                valid = false;
                ModelState.AddModelError("InvalidBirthdate", "Date of birth is obligatory.");
            } else if (this.idadeValida(model.ano, model.mes, model.dia) == false)
            {
                valid = false;
                ModelState.AddModelError("InvalidAge", "You must be 16 or older to register.");
            }
            var user = _context.Utilizador.Where(u => u.username == model.username).SingleOrDefault();
            if (user != null)
            {
                valid = false;
                ModelState.AddModelError("UsernameAlreadyExists", "Username already taken.");
            }

            if (valid)
            {
                HttpContext.Session.SetString("nome", model.nome);
                HttpContext.Session.SetString("email", model.email);
                HttpContext.Session.SetString("username", model.username);
                HttpContext.Session.SetString("password", model.password);
                HttpContext.Session.SetString("podeAdicionarReceita", "false");
                return View("Register2");
            }
            else
            {
                return View();
            }
        }

        private bool emailValido(string email)
        {
            // From: www.emailregex.com
            string emailRegex =
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)" +
                @"(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+" +
                @"[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            Regex rx = new Regex(emailRegex,
              RegexOptions.Compiled);

            if (email == null)
            {
                return false;
            }
            MatchCollection matches = rx.Matches(email);
            return matches.Count == 1;
        }

        private bool idadeValida(int ano, int mes, int dia)
        {
            var nascimento = new DateTime(ano, mes, dia);
            var now = DateTime.Now;
            var ageOf16 = nascimento.AddYears(16);

            return ageOf16 <= now;
        }

        [HttpPost]
        public IActionResult RegisterDois(RegisterModel model) {

            var categorias = new List<string>();
            var ingredientes = new List<string>();

            if (model.tartes != null && model.tartes == "true") {
                HttpContext.Session.SetString("tartes", "true");
            } else {
                HttpContext.Session.SetString("tartes", "false");
            }
            if (model.gelados != null && model.gelados == "true") {
                HttpContext.Session.SetString("gelados", "true");
            } else {
                HttpContext.Session.SetString("gelados", "false");
            }
            if (model.bolos != null && model.bolos == "true") {
                HttpContext.Session.SetString("bolos", "true");
            } else {
                HttpContext.Session.SetString("bolos", "false");
            }

            if (model.bolachas != null && model.bolachas == "true") {
                HttpContext.Session.SetString("bolachas", "true");
            } else {
                HttpContext.Session.SetString("bolachas", "false");
            }
            if (model.frutos != null && model.frutos == "true") {
                HttpContext.Session.SetString("frutos", "true");
            } else {
                HttpContext.Session.SetString("frutos", "false");
            }
            if (model.caramelo != null && model.caramelo == "true") {
                HttpContext.Session.SetString("caramelo", "true");
            } else {
                HttpContext.Session.SetString("caramelo", "false");
            }

            return View("Register3");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTres(RegisterModel model) {

            string imagePath;
            string descricao;
            if (model.image != null) {
                imagePath = model.image;
            } else {
                imagePath = "";
            }
            if (model.descricao != null) {
                descricao = model.descricao;
            } else {
                descricao = "";
            }

            var categorias = new List<string>();
            var ingredientes = new List<string>();

            if (HttpContext.Session.GetString("tartes") == "true") {
                categorias.Add("tartes");
            }
            if (HttpContext.Session.GetString("gelados") == "true") {
                categorias.Add("gelados");
            }
            if (HttpContext.Session.GetString("bolos") == "true") {
                categorias.Add("bolos");
            }
            if (HttpContext.Session.GetString("bolachas") == "true") {
                ingredientes.Add("bolachas");
            }
            if (HttpContext.Session.GetString("frutos") == "true") {
                ingredientes.Add("frutos");
            }
            if (HttpContext.Session.GetString("caramelo") == "true") {
                ingredientes.Add("caramelo");
            }

            var user = new Utilizador
            {
                nome = HttpContext.Session.GetString("nome"),
                email = HttpContext.Session.GetString("email"),
                username = HttpContext.Session.GetString("username"),
                password = HttpContext.Session.GetString("password"),
                podeAdicionarReceita = (HttpContext.Session.GetString("podeAdicionarReceita") == "true" ? true : false),
                descricao = descricao,
                imagePath = imagePath,
            };
            _context.Utilizador.Add(user);
            await _context.SaveChangesAsync();
            return View("~/Views/Login/Login.cshtml");
        }
    }

    public class RegisterModel {

        public string email { get; set; }

        public string nome { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string sndPassword { get; set; }

        public int ano { get; set; }

        public int mes { get; set; }

        public int dia { get; set; }

        public string tartes { get; set; }

        public string gelados { get; set; }

        public string bolos { get; set; }

        public string bolachas { get; set; }

        public string frutos { get; set; }

        public string caramelo { get; set; }

        public string image { get; set; }

        public string descricao { get; set; }
    }
}
