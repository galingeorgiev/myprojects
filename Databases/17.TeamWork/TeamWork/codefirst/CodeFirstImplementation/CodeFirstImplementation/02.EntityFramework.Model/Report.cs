using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EntityFramework.Model
{
    public class Report
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public Nullable<int> ProductId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public Nullable<int> SupermarketId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        public virtual Product Product { get; set; }
        public virtual Supermarket Supermarket { get; set; }
    }
}
