namespace BlogSystem.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name="post")]
    public class PostDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "text")]
        public string Content { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public virtual IEnumerable<CommentDto> Comments { get; set; }

        public PostDto()
        {
            this.Tags = new HashSet<string>();
            this.Comments = new HashSet<CommentDto>();
        }
    }
}
//[{ "id" : 1,
//   "title" : "I want more homework",
//   "postedBy" : "Ivan Ivanov",
//   "postDate" : "2013-08-17T10:16:34",
//   "text" : "I think that the homework that the trainers are giving us is too little for our capabilities",
//   "tags" : ["homework", "домашна", "i", "want", "more", "homework"],
//   "comments" : [{
//       "text" : "I fully agree with you!",
//       "commentedBy" : "Tedko the Server",
//       "postDate" : "2013-08-17T10:18:00"
//      }, {
//       "text" : "More! More! More! MOREEEEEE!",
//       "commentedBy" : "Stamo Stamov",
//       "postDate" : "2013-08-16T10:20:24.9550631+03:00"
//      } ]
// }, 
