using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthTest.Models {
    public class AuthTestContext : DbContext {
        public DbSet<User> Users { get; set; }
    }
}