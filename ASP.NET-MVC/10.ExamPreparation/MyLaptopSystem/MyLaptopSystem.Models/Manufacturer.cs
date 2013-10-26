using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLaptopSystem.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Laptops = new HashSet<Laptop>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops { get; set; }
    }
}
