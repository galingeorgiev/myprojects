using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    class Teacher : People, IComment
    {
        //private People teacherNames;
        private List<Discipline> discipline;

        public Teacher(string firstName, string lastName, List<Discipline> discipline) : base(firstName, lastName)
        {
        }

        public void Comment(string comment)
        {
            Console.WriteLine("Teacher: {0}",comment);
        }
    }
}
