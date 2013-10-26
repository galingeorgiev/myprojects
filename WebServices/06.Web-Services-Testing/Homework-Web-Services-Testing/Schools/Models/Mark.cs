//Marks have subject and value

namespace Schools.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Mark
    {
        [DataMember]
        public int MarkId { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public double Value { get; set; }
    }
}