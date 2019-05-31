using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CookMate.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin()
        {
            Console.WriteLine("Hello");
            Console.WriteLine(ModelState.ToString());
            return View();
        }
    }

    public class LoginModel {

        public string username;
        public string password;


    }
}