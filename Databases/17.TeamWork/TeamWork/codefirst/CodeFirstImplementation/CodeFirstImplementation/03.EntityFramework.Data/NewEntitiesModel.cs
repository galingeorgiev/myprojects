using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.EntityFramework.Model;

namespace _03.EntityFramework.Data
{
    public class NewEntitiesModel : DbContext
    {
        public NewEntitiesModel()
            : base("NewEntitiesModel")
        {
        }
    
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Supermarket> Supermarkets { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<MonthlyExpenseReport> MonthlyExpenseReports { get; set; }
    }
}
