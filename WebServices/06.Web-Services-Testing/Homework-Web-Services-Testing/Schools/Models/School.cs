//Schools have a name, location and a set of students

namespace Schools.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class School
    {
        [DataMember]
        public int SchoolId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        private ICollection<Student> students;

        public School()
        {
            this.students = new HashSet<Student>();
        }

        public ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
        
    }
}