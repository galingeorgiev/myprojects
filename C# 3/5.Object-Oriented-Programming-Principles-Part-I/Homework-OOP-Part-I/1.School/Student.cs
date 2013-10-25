using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    class Student : People, IComment
    {
        private int uniqueStudentNumber;

        public Student(string firstName, string lastName, int uniqueStudentNumber) : base(firstName, lastName)
        {
            this.uniqueStudentNumber = uniqueStudentNumber;
        }

        public int UniqueStudentNumber
        {
            get { return this.uniqueStudentNumber; }
        }

        public void Comment(string comment)
        {
            Console.WriteLine("Student: {0}",comment);
        }
    }
}
