using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlogSystem.Service.Models
{
    [DataContract]
    public class Category
    {
        [Key]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}