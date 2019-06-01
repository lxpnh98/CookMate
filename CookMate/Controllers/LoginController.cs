﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;

namespace CookMate.Controllers {

    public class LoginController : Controller {

        private readonly UtilizadorContext _context;

        public LoginController(UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Login() {
            return View();
        }

        public IActionResult Register() {
            return View("~/Views/Register/Register.cshtml");
        }

        [HttpPost]
        public IActionResult Login(LoginModel model) {
            var user = _context.Utilizador.Where(u => u.username == model.username).SingleOrDefault();

            if (user != null && user.password == model.password) {
                HttpContext.Session.SetInt32("id", user.id);
                HttpContext.Session.SetString("username", user.username);
                ViewData["id"] = HttpContext.Session.GetInt32("id");
                ViewData["username"] = HttpContext.Session.GetString("username");
                return View("~/Views/Home/menu.cshtml");
            }
            ModelState.AddModelError("WrongLoginData", "The username or password provided is incorrect.");
            return View();
        }
    }

    public class LoginModel {

        public string username { get; set; }

        public string password { get; set; }
    }
}