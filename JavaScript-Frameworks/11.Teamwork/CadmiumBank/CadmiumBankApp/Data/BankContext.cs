namespace CadmiumBankApp.Data
{
    using CadmiumBankApp.Models;
    using System.Data.Entity;

    public class BankContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<TransactionLog> TransactionLogs { get; set; }

        public DbSet<User> Users { get; set; }

        public BankContext()
            : base("BankSystem")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().Property(x => x.Iban).IsRequired().IsFixedLength().HasMaxLength(22);

            modelBuilder.Entity<Currency>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<AccountType>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Role>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<TransactionLog>().Property(x => x.Amount).IsRequired();
            modelBuilder.Entity<TransactionLog>().Property(x => x.Timestamp).IsRequired();

            modelBuilder.Entity<User>().Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(x => x.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired().IsFixedLength().HasMaxLength(40);
            modelBuilder.Entity<User>().Property(x => x.Username).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(x => x.SessionKey).IsFixedLength().HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }
    }
}