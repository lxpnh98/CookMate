using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CookMate.Models;
using CookMate.Controllers;
using CookMate.shared;

namespace CookMate.shared {

    public class UserHandling {

        private readonly UtilizadorContext _context;

        public UserHandling(UtilizadorContext context) {
            _context = context;
        }

        public Utilizador[] getUsers() {
            return _context.Utilizador.ToArray();
        }

        public bool validateUser(Utilizador user) {
            user.password = MyHelpers.HashPassword(user.password);
            var returnedUser = _context.Utilizador.Where(b => b.username == user.username && b.password == user.password).FirstOrDefault();

            if (returnedUser == null) {
                return false;
            }
            return true;
        }

        public bool registerUser(Utilizador user) {
            user.password = MyHelpers.HashPassword(user.password);
            _context.Utilizador.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
