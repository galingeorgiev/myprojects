using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CarStore.Service.Models
{
    [DataContract]
    public class RentedCarsUser :RentedCar
    {
        [DataMember(Name = "make")]
        public string Make { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "pictureUrl")]
        public string PictureUrl { get; set; }
    }
}