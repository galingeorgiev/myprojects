/* Define a class Student, which contains data about a student – first,
 * middle and last name, SSN, permanent address, mobile phone e-mail,
 * course, specialty, university, faculty. Use an enumeration for the
 * specialties, universities and faculties. Override the standard methods,
 * inherited by  System.Object: Equals(), ToString(), GetHashCode() and
 * operators == and !=. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _1.Student
{
    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName = "unnamed";
        private string lastName;
        private int ssn; // Social Security Number
        private string permanentAddress = "missing";
        private int mobilePhone;
        private string email = "missing";
        private byte course;
        private Speciality speciality;
        private University university;
        private Faculty faculty;

        //Define constructors
        public Student()
        {
        }

        public Student(string firstName, string lastName, int ssn, University university, byte course)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.ssn = ssn;
            this.university = university;
            this.course = course;
        }

        //Define properties
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public int Ssn
        {
            get { return this.ssn; }
            set { this.ssn = value; }
        }

        public University University
        {
            get { return this.university; }
            set { this.university = value; }
        }

        public byte Course
        {
            get { return this.course; }
            set { this.course = value; }
        }

        //Override methods
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (this.ssn == student.ssn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - University: {2}, Course: {3}, SSN: {4}",
                this.firstName, this.lastName, this.university, this.course, this.ssn);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < this.firstName.Length; i++)
            {
                hashCode = hashCode + (int)this.firstName[i];
            }
            hashCode = hashCode + this.ssn + this.course;
            return hashCode;
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.ssn == secondStudent.ssn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.ssn != secondStudent.ssn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Add implementations of the ICloneable interface. The Clone() method
         * should deeply copy all object's fields into a new object of type Student.*/
        public object Clone()
        {
            Student newStudent = new Student();

            newStudent.firstName = DeepClone<string>(this.firstName);
            newStudent.middleName = DeepClone<string>(this.middleName);
            newStudent.lastName = DeepClone<string>(this.lastName);
            newStudent.ssn = DeepClone<int>(this.ssn);
            newStudent.permanentAddress = DeepClone<string>(this.permanentAddress);
            newStudent.mobilePhone = DeepClone<int>(this.mobilePhone);
            newStudent.email = DeepClone<string>(this.email);
            newStudent.course = DeepClone<byte>(this.course);
            newStudent.speciality = DeepClone<Speciality>(this.speciality);
            newStudent.university = DeepClone<University>(this.university);
            newStudent.faculty = DeepClone<Faculty>(this.faculty);

            return newStudent;
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        /* Implement the  IComparable<Student> interface to compare students by names
         * (as first criteria, in lexicographic order) and by social security number
         * (as second criteria, in increasing order).*/
        public int CompareTo(Student student)
        {
            if (this.firstName.CompareTo(student.firstName) < 0)
            {
                return -1;
            }
            else if (this.firstName.CompareTo(student.firstName) > 0)
            {
                return 1;
            }
            else if (this.middleName.CompareTo(student.middleName) < 0)
            {
                return -1;
            }
            else if (this.middleName.CompareTo(student.middleName) > 0)
            {
                return 1;
            }
            else if (this.lastName.CompareTo(student.lastName) < 0)
            {
                return -1;
            }
            else if (this.lastName.CompareTo(student.lastName) > 0)
            {
                return 1;
            }
            else if (this.ssn < student.ssn)
            {
                return -1;
            }
            else if (this.ssn > student.ssn)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
