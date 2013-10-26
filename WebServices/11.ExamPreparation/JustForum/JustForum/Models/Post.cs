namespace JustForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public virtual User User { get; set; }

        public virtual Thread Thread { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }
    }
}