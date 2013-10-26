namespace CarStore.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;


    [DataContract]
    public class Car
    {

        [Key]
        [DataMember(Name = "id")]
        public int CarId { get; set; }

        [Required]
        [DataMember(Name = "model")]
        public string Model { get; set; }

        [Required]
        [DataMember(Name = "make")]
        public string Make { get; set; }

        [DataMember(Name = "pickUpDate")]
        public DateTime? PickUpDate { get; set; }

        [DataMember(Name = "dropOffDate")]
        public DateTime? DropOffDate { get; set; }

        [DataMember(Name = "isTaken")]
        public bool IsTaken { get; set; }

        [DataMember(Name = "yearOfProduction")]
        public int Year { get; set; }

        [Required]
        [DataMember(Name = "engine")]
        public string Engine { get; set; }

        [Required]
        [DataMember(Name = "seats")]
        public byte Seats { get; set; }

        [Required]
        [DataMember(Name = "doors")]
        public byte Doors { get; set; }

        [DataMember(Name = "pricePerDay")]
        public decimal PricePerDay { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "pictureUrl")]
        public string PictureUrl { get; set; }

        [DataMember(Name = "power")]
        public int Power { get; set; }

        [DataMember(Name = "extras")]
        public virtual Customization Extras { get; set; }

        [DataMember(Name = "rentedBy")]
        public virtual User RentedBy { get; set; }
    }
}
