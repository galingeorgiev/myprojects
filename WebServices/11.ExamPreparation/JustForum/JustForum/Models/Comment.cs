namespace JustForum.Models
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

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public DateTime CommentDate { get; set; }
    }
}