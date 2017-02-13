namespace AuthTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthTest.Models.AuthTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthTest.Models.AuthTestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            context.Users.AddOrUpdate(new Models.User {
                UserEmail = "norton.heberle@gmail.com",
                UserLogin = "norton",
                UserName = "Norton",
                UserPassword = "q1w2e3r4"
            });
        }
    }
}
