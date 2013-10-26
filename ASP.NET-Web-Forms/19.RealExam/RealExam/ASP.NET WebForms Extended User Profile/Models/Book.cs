namespace WebFormsTemplate.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3-50 characters!")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Author name must be between 3-50 characters!")]
        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Description { get; set; }

        public string WebSite { get; set; }

        public Category Category { get; set; }
    }
}