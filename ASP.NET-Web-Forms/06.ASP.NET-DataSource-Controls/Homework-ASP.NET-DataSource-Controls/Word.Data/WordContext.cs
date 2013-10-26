using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word.Model;

namespace Word.Data
{
    public class WordContext : DbContext
    {
        public WordContext() : base("WordDBContext")
        {

        }

        public DbSet<Continent> Continents { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Town> Towns { get; set; }
    }
}
