namespace BlogSystem.DTOs
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PostCreateResponseDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}