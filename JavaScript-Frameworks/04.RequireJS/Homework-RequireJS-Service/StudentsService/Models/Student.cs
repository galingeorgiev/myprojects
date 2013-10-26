namespace StudentsService.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Student
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "grade")]
        public int Grade { get; set; }

        [DataMember(Name = "marks")]
        public IEnumerable<Mark> Marks { get; set; }

        public Student(int id, string name, List<Mark> marks, int grade)
        {
            this.Id = id;
            this.Name = name;
            this.Marks = marks;
            this.Grade = grade;
        }
    }
}