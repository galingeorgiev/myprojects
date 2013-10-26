using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLaptopSystem.Models
{
    public class Laptop
    {
        public Laptop()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string Model { get; set; }

        public double Monitor { get; set; }

        public int HardDisk { get; set; }

        public int Ram { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
