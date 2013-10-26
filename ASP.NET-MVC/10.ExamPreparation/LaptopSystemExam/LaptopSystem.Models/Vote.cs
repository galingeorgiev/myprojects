using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public string VotedById { get; set; }

        public virtual ApplicationUser VotedBy { get; set; }

        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}
