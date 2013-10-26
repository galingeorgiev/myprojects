namespace CadmiumBankApp.Migrations
{
    using CadmiumBankApp.Data;
    using CadmiumBankApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BankContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            //this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BankContext context)
        {
            context.Database.ExecuteSqlCommand("IF OBJECT_ID('uc_Users_Username', 'UQ') IS NULL ALTER TABLE Users ADD CONSTRAINT uc_Users_Username UNIQUE(Username)");

            if (!context.Currencies.Any())
            {
                context.Currencies.AddOrUpdate(
                new Currency() { Name = "BGN" },
                new Currency() { Name = "EUR" },
                new Currency() { Name = "USD" });
            }

            if (!context.Accounts.Any())
            {
                context.AccountTypes.AddOrUpdate(
                new AccountType() { Name = "Loan" },
                new AccountType() { Name = "Mortgage loan" },
                new AccountType() { Name = "Savings" },
                new AccountType() { Name = "Deposit" },
                new AccountType() { Name = "Transactional" },
                new AccountType() { Name = "Current" });
            }

            if (!context.Roles.Any())
            {
                context.Roles.AddOrUpdate(
                new Role() { Name = "Admin" },
                new Role() { Name = "Corporate" },
                new Role() { Name = "Private" });
            }

            //if (!context.Users.Any())
            //{
            //    context.Users.AddOrUpdate(
            //    new User() { FirstName = "Pesho", LastName = "Petrov", Password = "123456", Role = new Role() { Name = "Admin" }, Username = "Peshooo" });
            //}

            context.SaveChanges();
        }
    }
}
