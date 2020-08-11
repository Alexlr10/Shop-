using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories {
    public static class UserRepository {
        public static User Get(string username, string password) {
            var users = new List<User>();

            users.Add(new User { id = 1, Username = "batman", Password = "batman", Role = "manager" });
            users.Add(new User { id = 2, Username = "robin", Password = "robin", Role = "manager" });

            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
