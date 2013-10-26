using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EntityFramework.Model
{
    public class MonthlyExpenseReport
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public Nullable<int> VendorId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> Expenses { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
