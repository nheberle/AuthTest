using AuthTest.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AuthTest.DbService {
    public class UserStoreService : IDisposable {
        AuthTestContext context = new AuthTestContext();

        public async Task<User> Authenticate(string userName, string userPassword) {
            User user = 
                await context.Users.Where(
                    apu => apu.UserName == userName
                    && apu.UserPassword == userPassword)
                .FirstOrDefaultAsync();

            return user;
        }

        public void Dispose() {
            context.Dispose();
        }
    }
}