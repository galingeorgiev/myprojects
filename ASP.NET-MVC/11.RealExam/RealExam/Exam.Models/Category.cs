using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public Category()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    }
}
