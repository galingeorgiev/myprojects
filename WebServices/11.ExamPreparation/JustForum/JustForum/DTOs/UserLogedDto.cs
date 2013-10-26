namespace JustForum.DTOs
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserLogedDto
    {
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
    }
}