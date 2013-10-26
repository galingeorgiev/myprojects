using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EntityFramework.Model
{
    public class Measure
    {
        public Measure()
        {
            this.Products = new HashSet<Product>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string MeasureName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
