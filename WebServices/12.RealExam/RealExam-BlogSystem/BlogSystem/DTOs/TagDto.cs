namespace BlogSystem.DTOs
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TagDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "posts")]
        public int Posts { get; set; }
    }
}