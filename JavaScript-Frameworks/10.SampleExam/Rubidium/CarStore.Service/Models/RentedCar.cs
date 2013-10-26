using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CarStore.Service.Models
{
    [DataContract]
    public class RentedCar
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "pickUpDate")]
        public DateTime PickUpDate { get; set; }

        [DataMember(Name = "dropOffDate")]
        public DateTime DropOffDate { get; set; }
    }
}