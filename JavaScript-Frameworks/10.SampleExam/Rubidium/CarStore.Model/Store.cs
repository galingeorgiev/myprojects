namespace CarStore.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;


    [DataContract]
    public class Store
    {
        [Key]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [Required]
        [DataMember(Name = "city")]
        public string City { get; set; }

        [Required]
        [DataMember(Name = "adress")]
        public string Adress { get; set; }

        [DataMember(Name = "longitute")]
        public decimal Longitute { get; set; }

        [DataMember(Name = "latitude")]
        public decimal Latitude { get; set; }

        [DataMember(Name = "cars")]
        public virtual ICollection<Car> Cars { get; set; }

        public Store()
        {
            this.Cars = new HashSet<Car>();
        }
    }
}
