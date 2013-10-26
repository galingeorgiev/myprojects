namespace CarStore.Service.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class LoginResponseModel
    {
        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }
    }
}