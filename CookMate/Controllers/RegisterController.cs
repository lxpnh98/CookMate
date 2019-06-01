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
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var valid = true;
            if (model.password != model.sndPassword)
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
            if (this.idadeValida(model.ano, model.mes, model.dia) == false)
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
                user = new Utilizador
                {
                    nome = model.nome,
                    email = model.email,
                    username = model.username,
                    password = model.password,
                    podeAdicionarReceita = false,
                    descricao = "",
                    imagePath = ""
                };
                _context.Utilizador.Add(user);
                await _context.SaveChangesAsync();
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
                categorias.Add("tartes");
            }
            if (model.gelados != null && model.gelados == "true") {
                categorias.Add("gelados");
            }
            if (model.bolos != null && model.bolos == "true") {
                categorias.Add("bolos");
            }

            if (model.bolachas != null && model.bolachas == "true") {
                ingredientes.Add("bolachas");
            }
            if (model.frutos != null && model.frutos == "true") {
                ingredientes.Add("frutos");
            }
            if (model.caramelo != null && model.caramelo == "true") {
                ingredientes.Add("caramelo");
            }

            return View("Register3");
        }

        [HttpPost]
        public IActionResult RegisterTres(RegisterModel model) {

            string imagePath;
            if (model.image != null) {
                imagePath = model.image.Name;
            } else {
                imagePath = "";
            }
            var descricao = model.descricao;

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

        public IFormFile image { get; set; }

        public string descricao { get; set; }
    }
}
