﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookMate.Models;
using System.Text.RegularExpressions;

namespace CookMate.Controllers {

    public class RegisterController : Controller
    {

        private readonly UtilizadorContext _context;
        private Utilizador user = null;

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
                this.user = new Utilizador
                {
                    nome = model.nome,
                    email = model.email,
                    username = model.username,
                    password = model.password,
                    podeAdicionarReceita = false//,
                  //  pathImage = "",
                   // descricao = ""
                };
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

        private List<String> categorias = new List<string>();
        private List<String> ingredientes = new List<string>();

        [HttpPost]
        public IActionResult RegisterDois(RegisterModel model) {

            if (model.tartes != null && model.tartes == "true") {
                this.categorias.Add("tartes");
            }
            if (model.gelados != null && model.gelados == "true") {
                this.categorias.Add("gelados");
            }
            if (model.bolos != null && model.bolos == "true") {
                this.categorias.Add("bolos");
            }

            if (model.bolachas != null && model.bolachas == "true") {
                this.ingredientes.Add("bolachas");
            }
            if (model.frutos != null && model.frutos == "true") {
                this.ingredientes.Add("frutos");
            }
            if (model.caramelo != null && model.caramelo == "true") {
                this.ingredientes.Add("caramelo");
            }

            return View("Register3");
        }

        [HttpPost]
        public IActionResult RegisterTres(RegisterModel model) {

            Console.WriteLine("\n\n\n\n\n\n");
            this.user.pathImage = model.pathImage;

            Console.WriteLine("\n\n\n {0} \n\n\n", model.pathImage);
            this.user.descricao = model.descricao;

            Console.WriteLine("\n\n\n {0} \n\n\n", model.descricao);

            return View("~/Views/Home/menu.cshtml");
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

        public string pathImage { get; set; }

        public string descricao { get; set; }
    }
}
