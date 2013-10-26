using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using CarStore.Model;

namespace CarStore.Service.Models
{

    [DataContract]
    public class CarFullModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "make")]
        public string Make { get; set; }

        [DataMember(Name = "yearOfProduction")]
        public int Year { get; set; }

        [DataMember(Name = "engine")]
        public string Engine { get; set; }

        [DataMember(Name = "seats")]
        public byte Seats { get; set; }

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
    }
}