using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace RemoteData.Server.Models
{
    [DataContract]
    public class Student
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fname")]
        public string FirstName { get; set; }

        [DataMember(Name = "lname")]
        public string LastName { get; set; }
        
        [DataMember(Name = "marks")]
        public IEnumerable<Mark> Marks { get; set; }
    }
}
