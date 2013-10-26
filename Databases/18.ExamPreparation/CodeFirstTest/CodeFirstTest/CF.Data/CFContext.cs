using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CF.Model;

namespace CF.Data
{
    public class CFContext : DbContext
    {
        public DbSet<StudentsCFTest> Students { get; set; }
        public DbSet<UniversityCFTest> Universities { get; set; }

        public CFContext()
            : base("CFContext")
        {
        }
    }
}
