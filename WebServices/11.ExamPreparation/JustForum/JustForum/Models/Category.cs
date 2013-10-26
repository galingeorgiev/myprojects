namespace JustForum.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }

        public Category()
        {
            this.Threads = new HashSet<Thread>();
        }
    }
}