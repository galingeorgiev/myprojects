using System.Collections.Generic;

namespace SchoolsHierarchy
{
    public class School
    {
        private string schoolName;
        private List<int> studentsID = new List<int>();

        public string SchoolName
        {
            get
            {
                return this.schoolName;
            }

            set
            {
                this.schoolName = value;
            }
        }

        public List<int> StudentsID
        {
            get
            {
                return this.studentsID;
            }
        }

        public bool CheckStudentIDIsUsed(int studentID)
        {
            bool containsStudentID = this.studentsID.Contains(studentID);
            return containsStudentID;
        }

        internal void AddStudentsID(int studentID)
        {
            this.studentsID.Add(studentID);
        }
    }
}
