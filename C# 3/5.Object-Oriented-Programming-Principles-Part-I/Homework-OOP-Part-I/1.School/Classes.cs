using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    class Classes : IComment
    {
        private string uniqueIdentifier;
        private List<Teacher> teachers;
        private List<Student> students;

        public Classes(string uniqueIdentifier, List<Teacher> teachers, List<Student> students)
        {
            this.uniqueIdentifier = uniqueIdentifier;
            this.teachers = teachers;
            this.students = students;
        }

        public string UniqueIdentifier
        {
            get { return this.uniqueIdentifier; }
        }

        public List<Teacher> Teachers
        {
            get { return this.teachers; }
        }

        public List<Student> Students
        {
            get { return this.students; }
        }

        public void Comment(string comment)
        {
            Console.WriteLine("About class: {0}",comment);
        }
    }
}
