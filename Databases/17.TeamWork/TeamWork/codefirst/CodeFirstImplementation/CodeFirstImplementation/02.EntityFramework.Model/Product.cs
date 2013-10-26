using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EntityFramework.Model
{
    public class Product
    {
        public Product()
        {
            this.Reports = new HashSet<Report>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string ProductName { get; set; }
        public Nullable<decimal> BasePrice { get; set; }
        public Nullable<int> VendorId { get; set; }
        public Nullable<int> MeasureId { get; set; }

        public virtual Measure Measure { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
