namespace Schools.Context
{
    using Schools.Models;
    using System.Data.Entity;

    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
            : base("SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<School> Schools { get; set; }
    }
}