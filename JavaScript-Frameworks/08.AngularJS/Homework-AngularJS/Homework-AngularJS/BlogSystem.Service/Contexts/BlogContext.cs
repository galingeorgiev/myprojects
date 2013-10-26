using BlogSystem.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogSystem.Service.Contexts
{
    public class BlogContext : DbContext
    {
        public BlogContext() 
            : base("BlogContext")
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}