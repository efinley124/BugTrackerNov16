using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using efinley_budgeter.Models;

namespace efinley_budgeter.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }

        public ApplicationUser()
        {
            this.Households = new HashSet<Household>();
            this.Transactions = new HashSet<Transaction>();
            this.BankAccounts = new HashSet<BankAccount>();
            this.Invites = new HashSet<Invite>();
        }

        public virtual ICollection<Household> Households { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<Invite> Invites { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<efinley_budgeter.Models.Household> Households { get; set; }

        public System.Data.Entity.DbSet<efinley_budgeter.Models.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<efinley_budgeter.Models.BankAccount> BankAccounts { get; set; }

        public System.Data.Entity.DbSet<efinley_budgeter.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<efinley_budgeter.Models.Type> Types { get; set; }

        public System.Data.Entity.DbSet<efinley_budgeter.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<efinley_budgeter.Models.Budget> Budgets { get; set; }

        public System.Data.Entity.DbSet<efinley_budgeter.Models.Invite> Invites { get; set; }
    }
}