namespace JustForum.Contexts
{
    using JustForum.Models;
    using System.Data.Entity;

    public class ForumContext : DbContext
    {
        public ForumContext() : base("ForumDbContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Thread> Threads { get; set; }

        public DbSet<Vote> Votes { get; set; }
    }
}