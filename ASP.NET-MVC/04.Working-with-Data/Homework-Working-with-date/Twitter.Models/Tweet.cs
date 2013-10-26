using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        public TwitterUser User { get; set; }

        public string Content { get; set; }

        public HashSet<Tag> Tags { get; set; }

        public Tweet()
        {
            this.Tags = new HashSet<Tag>();
        }
    }
}
