using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Movies.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext()
            : base("MoviesDb")
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }
    }
}