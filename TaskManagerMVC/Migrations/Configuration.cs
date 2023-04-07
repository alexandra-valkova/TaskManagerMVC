namespace TaskManagerMVC.Migrations
{
    using DataAccess.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(
                u => u.ID,
                new User
                {
                    ID = 1,
                    FirstName = "Admin",
                    LastName = "Adminov",
                    Username = "admin",
                    Password = "password",
                    IsAdmin = true
                }
            );
        }
    }
}
