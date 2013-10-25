using System;

namespace _4.StudentsAgeBetween
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;

        public Student(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.FirstName, this.LastName, this.age);
        }
    }
}