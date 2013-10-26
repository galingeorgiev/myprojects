namespace School.Data
{
    using School.Model;
    using System.Data.Entity;

    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> Homeworks { get; set; }

        public SchoolContext()
            : base("SchoolDb")
        {
        }
    }
}
