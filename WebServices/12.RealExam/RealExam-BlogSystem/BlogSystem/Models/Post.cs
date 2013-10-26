using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSystem.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Post()
        {
            this.Tags = new HashSet<Tag>();
            this.Comments = new HashSet<Comment>();
        }
    }
}