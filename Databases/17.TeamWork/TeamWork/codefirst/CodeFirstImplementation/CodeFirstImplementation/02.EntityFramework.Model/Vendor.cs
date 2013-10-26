using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EntityFramework.Model
{
    public class Vendor
    {
        public Vendor()
        {
            this.Products = new HashSet<Product>();
            this.MonthlyExpenseReports = new HashSet<MonthlyExpenseReport>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string VendorName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<MonthlyExpenseReport> MonthlyExpenseReports { get; set; }
    }
}
