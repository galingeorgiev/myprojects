using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name) 
            : base(name)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town
        {
            get { return this.town; }
            set { this.town = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            return base.ToString() + result.ToString();
        }
    }
}
