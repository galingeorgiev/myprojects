using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.ViewModels
{
    public class CategoryWithBooksViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category must be between 3-50 characters!")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public virtual IEnumerable<BooksViewModel> Books { get; set; }
    }
}