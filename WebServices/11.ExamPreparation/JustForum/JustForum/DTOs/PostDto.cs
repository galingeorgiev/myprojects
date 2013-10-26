namespace JustForum.DTOs
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name="posts")]
    public class PostDto
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }
    }
}