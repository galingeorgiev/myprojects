namespace JustForum.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name="threads")]
    public class ThreadDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "createdBy")]
        public string CreatedBy { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "categories")]
        public IEnumerable<string> Categories { get; set; }

        [DataMember(Name = "posts")]
        public virtual IEnumerable<PostDto> Posts { get; set; }

        public ThreadDto()
        {
            this.Categories = new HashSet<string>();
            this.Posts = new HashSet<PostDto>();
        }
    }
}