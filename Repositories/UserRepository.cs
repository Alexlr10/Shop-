using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories {
    public static class UserRepository {
        public static User Get(string username, string password) {
            var users = new List<User>();
            //instanciando dois usuarios 
            users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role = "manager" });
            users.Add(new User { Id = 2, Username = "robin", Password = "robin", Role = "employee" });

            //retorna o usuario se o seu username e password forem iguais ao instanciados acima
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
