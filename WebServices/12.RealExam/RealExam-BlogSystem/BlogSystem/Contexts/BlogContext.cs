namespace BlogSystem.Contexts
{
    using BlogSystem.Models;
    using System.Data.Entity;

    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogDbContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}