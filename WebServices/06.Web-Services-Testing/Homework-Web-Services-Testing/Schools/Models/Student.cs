//Students have first and last names, age, grade, a set of marks and a school
//Each student can be only in a single school

namespace Schools.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Student
    {
        [DataMember]
        public int StudentId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public int Grade { get; set; }

        [DataMember]
        public School School { get; set; }

        [DataMember]
        private ICollection<Mark> marks;

        public Student()
        {
            this.marks = new HashSet<Mark>();
        }

        public ICollection<Mark> Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }
    }
}