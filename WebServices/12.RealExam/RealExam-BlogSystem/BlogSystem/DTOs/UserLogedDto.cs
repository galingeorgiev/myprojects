namespace BlogSystem.DTOs
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserLogedDto
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
    }
}