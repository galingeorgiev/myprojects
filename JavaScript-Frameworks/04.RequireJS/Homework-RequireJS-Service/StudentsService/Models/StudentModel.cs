namespace StudentsService.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StudentModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "grade")]
        public int Grade { get; set; }
    }
}