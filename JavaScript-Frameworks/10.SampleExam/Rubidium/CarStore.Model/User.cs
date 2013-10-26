namespace CarStore.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    [DataContract]
    public class User
    {
        [Key]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [Required]
        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        [DataMember(Name = "role")]
        public virtual Role Role { get; set; }

        [DataMember(Name = "amount")]
        public decimal? Amount { get; set; }

        [DataMember(Name = "cars")]
        public virtual ICollection<Car> Cars { get; set; }

        public User()
        {
            this.Cars = new HashSet<Car>();
        }
    }
}
