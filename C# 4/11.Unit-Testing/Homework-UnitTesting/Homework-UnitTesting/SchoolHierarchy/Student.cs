using System;

namespace SchoolsHierarchy
{
    public class Student
    {
        private string name;
        private int studentID;
        private School school;

        public Student(string name, int studentID, School school)
        {
            this.School = school;
            this.Name = name;
            this.StudentID = studentID;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentException("Student name can not empty.");
                }

                this.name = value;
            }
        }

        public int StudentID
        {
            get
            {
                return this.studentID;
            }

            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentException("Student ID must be in range 10000 - 99999.");
                }

                if (this.school.StudentsID != null && this.school.CheckStudentIDIsUsed(value))
                {
                    throw new ArgumentException("Duplicated students ID.");
                }

                this.studentID = value;
                this.school.AddStudentsID(value);
            }
        }

        public School School
        {
            get
            {
                return this.school;
            }

            set
            {
                this.school = value;
            }
        }

        public override string ToString()
        {
            return "Student name: " + this.Name + "; " + "Student ID: " + this.StudentID;
        }
    }
}
