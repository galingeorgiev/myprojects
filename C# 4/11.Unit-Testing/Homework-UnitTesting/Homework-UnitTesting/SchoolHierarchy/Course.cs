using System;
using System.Collections.Generic;

namespace SchoolsHierarchy
{
    public class Course
    {
        private IList<Student> courseStudents = new List<Student>();

        public IList<Student> CourseStudents
        {
            get
            {
                return this.courseStudents;
            }
        }

        public void JoinToCourse(Student student)
        {
            if (this.courseStudents.Count >= 30)
            {
                throw new ArgumentException("Course cannot contains more from 30 students.");
            }

            this.courseStudents.Add(student);
        }

        public void LeaveCourse(Student student)
        {
            this.courseStudents.Remove(student);
        }
    }
}
