namespace Budgeter.Migrations
{
    using efinley_budgeter.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    

    internal sealed class Configuration : DbMigrationsConfiguration<efinley_budgeter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(efinley_budgeter.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Household Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Household Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Household User"))
            {
                roleManager.Create(new IdentityRole { Name = "Household User" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "efinley@clemson.edu"))
            {
                userManager.Create(new ApplicationUser
                {
                    FirstName = "Evan",
                    LastName = "Finley",
                    DisplayName = "Evan Finley",
                    PhoneNumber = "(000) 000-0000",
                    UserName = "efinley@clemson.edu",
                    Email = "efinley@clemson.edu",
                }, "password");
            }

            if (!context.Users.Any(u => u.Email == "evan.finley126@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    FirstName = "Max",
                    LastName = "Blaxilin",
                    DisplayName = "Max B",
                    PhoneNumber = "(704) 000-0000",
                    UserName = "evan.finley126@gmail.com",
                    Email = "evan.finley126@gmail.com",
                }, "password");
            }

            if (!context.Users.Any(u => u.Email == "Member@household.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    FirstName = "Rachel",
                    LastName = "Gray",
                    DisplayName = "Rachel Gray",
                    PhoneNumber = "(704) 000-0000",
                    UserName = "Member@household.com",
                    Email = "Member@household.com",
                }, "password");
            }

            

            var userIdAdmin = userManager.FindByEmail("efinley@clemson.edu").Id;
            userManager.AddToRole(userIdAdmin, "Admin");

            var userIdHAdmin = userManager.FindByEmail("evan.finley126@gmail.com").Id;
            userManager.AddToRole(userIdHAdmin, "Household Admin");

            var userIdUser = userManager.FindByEmail("Member@household.com").Id;
            userManager.AddToRole(userIdUser, "Household User");


            context.Types.AddOrUpdate(t => t.Id,
                new efinley_budgeter.Models.Type() { Id = 1, Name = "Income" },
                new efinley_budgeter.Models.Type() { Id = 2, Name = "Expense" }
                );

            context.Categories.AddOrUpdate(c => c.Id,
                new efinley_budgeter.Models.Category() { Id = 1, Name = "Rent/Utilities" },
                new efinley_budgeter.Models.Category() { Id = 1, Name = "Food" },
                new efinley_budgeter.Models.Category() { Id = 1, Name = "Entertainment" },
                new efinley_budgeter.Models.Category() { Id = 1, Name = "Travel" },
                new efinley_budgeter.Models.Category() { Id = 1, Name = "Commuting Cost" },
                new efinley_budgeter.Models.Category() { Id = 1, Name = "Miscellaneous" }
                
            );


        }
    }
}
