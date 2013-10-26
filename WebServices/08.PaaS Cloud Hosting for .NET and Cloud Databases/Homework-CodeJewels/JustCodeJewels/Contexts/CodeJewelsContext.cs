//using JustCodeJewels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JustCodeJewels.Contexts
{
    public class CodeJewelsContext : DbContext
    {
        public CodeJewelsContext()
            : base("CodeJewelsContext")
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}