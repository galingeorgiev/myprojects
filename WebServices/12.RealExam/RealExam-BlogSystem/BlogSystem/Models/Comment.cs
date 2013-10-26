namespace BlogSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public DateTime CommentDate { get; set; }

        public virtual User User { get; set; }
    }
}