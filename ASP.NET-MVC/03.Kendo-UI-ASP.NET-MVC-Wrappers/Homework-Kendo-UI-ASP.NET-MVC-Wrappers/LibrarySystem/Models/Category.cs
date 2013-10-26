using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category must be between 3-50 characters!")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<Book> Books { get; set; }

        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}