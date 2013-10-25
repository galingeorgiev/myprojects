namespace ReadFileAndPrintSortedInformation
{
    using System;

    public class Student : IComparable<Student>
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.FirtsName = firstName;
            this.LastName = lastName;
        }

        public string FirtsName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public int CompareTo(Student that)
        {
            if (this.LastName.CompareTo(that.LastName) == 1)
            {
                return 1;
            }
            else if (this.LastName.CompareTo(that.LastName) == -1)
            {
                return -1;
            }
            else
            {
                if (this.FirtsName.CompareTo(that.FirtsName) == 1)
                {
                    return 1;
                }
                else if (this.FirtsName.CompareTo(that.FirtsName) == -1)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override string ToString()
        {
            return this.FirtsName + " " + this.LastName;
        }
    }
}
