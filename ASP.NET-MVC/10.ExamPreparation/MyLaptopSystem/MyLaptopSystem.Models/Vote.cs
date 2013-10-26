using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLaptopSystem.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public string VotedById { get; set; }

        public ApplicationUser VotedBy { get; set; }

        [Required]
        public int laptopId { get; set; }

        public Laptop Laptop { get; set; }
    }
}
