using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    class Discipline : IComment
    {
        private string disciplineName;
        private int numberOfLectures;
        private int numberOfExercises;

        public Discipline(string disciplineName, int numberOfLectures, int numberOfExercises)
        {
            this.disciplineName = disciplineName;
            this.numberOfLectures = numberOfLectures;
            this.numberOfExercises = numberOfExercises;
        }

        public string DisciplineName
        {
            get
            {
                return this.disciplineName;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
        }

        public void Comment(string comment)
        {
            Console.WriteLine("About discipline: {0}", comment);
        }
    }
}