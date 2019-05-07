using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CookMate.Models;
using CookMate.Controllers;
using CookMate.shared;

namespace CookMate.Controllers {

    [Route("[controller]/[action]")]
    public class UtilizadorViewController : Controller {

        private UserHandling userHandling;

        public UtilizadorViewController(UserContext context) {
            userHandling = new UserHandling(context);
        }

        [Authorize]
        public IActionResult getUsers() {
            Utilizador[] users = userHandling.getUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult RegisterUser() {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser([Bind] Utilizador user) {
            if (ModelState.IsValid) {

                bool RegistrationStatus = this.userHandling.registerUser(user);

                if (RegistrationStatus) {
                    ModelState.Clear();
                    TempData["Success"] = "Registration Successful!";
                } else {
                    TempData["Fail"] = "This User ID already exists. Registration Failed.";
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Utilizador user) {
            var users = new List<Utilizador>();
            users.Add(user);
            return new CreatedResult($"/api/user/{user.id}", user);
        }

        [HttpGet]
        public IActionResult UserLogin() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin([Bind] Utilizador user) {
            ModelState.Remove("nome");
            ModelState.Remove("email");

            if (ModelState.IsValid) {
                var LoginStatus = this.userHandling.validateUser(user);
                if (LoginStatus) {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.username)
                    };

                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("getUsers", "UserView");
                } else {
                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
    }
}