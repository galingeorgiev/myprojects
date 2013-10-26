using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCounter.Model;

namespace WebCounter.Data
{
    public class WebCounterContext : DbContext
    {
        public WebCounterContext()
            : base("WebCounterContext")
        {

        }

        public DbSet<Counter> Counts { get; set; }
    }
}
