using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string Title { get; set; }

        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Ticket()
        {
            this.Comments = new HashSet<Comment>();
        }
    }
}
