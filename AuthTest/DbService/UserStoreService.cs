using AuthTest.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AuthTest.DbService {
    public class UserStoreService {
        AuthTestContext context = new AuthTestContext();

        public Task<User> Authenticate(string userName, string userPassword) {
            Task<User> task = 
                context.Users.Where(
                    apu => apu.UserName == userName
                    && apu.UserPassword == userPassword)
                .FirstOrDefaultAsync();

            return task;
        }

    }
}