namespace StudentsService.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Student
    {
        [DataMember(Name="fname")]
        public string FirstName { get; set; }

        [DataMember(Name = "lname")]
        public string LastName { get; set; }

        [DataMember(Name = "grade")]
        public int Grade { get; set; }

        [DataMember(Name = "age")]
        public int Age { get; set; }

        [DataMember(Name = "marks")]
        public IEnumerable<Mark> Marks { get; set; }

        public Student(string firstName, string lastName, List<Mark> marks, int grade, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Marks = marks;
            this.Grade = grade;
            this.Age = age;
        }
    }
}