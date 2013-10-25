namespace Methods
{
    using System;

    internal class Student
    {
        private string firstName;
        private string lastName;
        private string otherInfo;

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
        
        public string OtherInfo
        {
            get { return this.otherInfo; }
            set { this.otherInfo = value; }
        }

        public bool IsOlderThan(Student other)
        {
            // I thing that information for birth date must be stored in other varible.
            string firstDateAsString = this.OtherInfo.Substring(this.OtherInfo.Length - 10);
            DateTime firstDate;
            if (!DateTime.TryParse(firstDateAsString, out firstDate))
            {
                throw new ArgumentException("Input string isn't in correct format.");
            }

            string secondDateAsString = other.OtherInfo.Substring(other.OtherInfo.Length - 10);
            DateTime secondDate;
            if (!DateTime.TryParse(secondDateAsString, out secondDate))
            {
                throw new ArgumentException("Input string isn't in correct format.");
            }

            bool isOlderThan = firstDate > secondDate;
            return isOlderThan;
        }
    }
}
