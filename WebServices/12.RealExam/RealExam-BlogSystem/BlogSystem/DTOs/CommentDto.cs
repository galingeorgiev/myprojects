namespace BlogSystem.DTOs
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name = "comments")]
    public class CommentDto
    {
        public int Id { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "commentedBy")]
        public string CommentedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }
    }
}