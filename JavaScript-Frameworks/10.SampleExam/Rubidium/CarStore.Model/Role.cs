namespace CarStore.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract]
    public class Role
    {
        [Key]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "permission")]
        public string Permission { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            this.Users = new HashSet<User>();
        }
    }
}
