using System.Data.Entity;
namespace CarStore.Data
{
    using CarStore.Model;

    public class CarStoreContext : DbContext
    {
        public CarStoreContext()
            : base("CarStoreDb")
        {
            var connectionString =
                System.Configuration.ConfigurationManager.AppSettings["SQLSERVER_CONNECTION_STRING"];
            this.Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customization> Customizations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(usr => usr.SessionKey)
                .IsFixedLength()
                .HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }
    }
}
