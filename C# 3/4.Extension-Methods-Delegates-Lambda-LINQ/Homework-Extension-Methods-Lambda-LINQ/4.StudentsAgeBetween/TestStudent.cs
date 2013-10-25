/*Write a LINQ query that finds the first name and
 *last name of all students with age between 18 and 24.*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.StudentsAgeBetween
{
    public static class ExtensionStudent
    {
        public static List<string> GetName(this List<Student> names)
        {
            var studentsNames = from name in names
                                                 where (name.Age >= 18 && name.Age <= 24)
                                                 select string.Format("{0} {1}",name.FirstName, name.LastName);

            return studentsNames.ToList();
        }
    }

    class TestStudent
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Georgi", "Georgiev", 18),
                new Student("Ivan","Ivanov",20),
                new Student("Ivan","Andonov",23),
                new Student("Anton","Ivanov",32),
                new Student("Svetlin","Nakov",19),
                new Student("Nikolay","Kostov",24),
                new Student("a","b", 40),
                new Student("b","a",30)
            };

            List<string> resultStudents = new List<string>();
            resultStudents = students.GetName();
            foreach (var student in resultStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
