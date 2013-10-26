namespace JustForum.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public int Value { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}