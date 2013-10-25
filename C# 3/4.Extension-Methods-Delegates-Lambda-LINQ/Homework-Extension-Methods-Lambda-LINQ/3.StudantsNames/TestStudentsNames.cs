/*Write a method that from a given array of students finds
 *all students whose first name is before its last name
 *alphabetically. Use LINQ query operators.*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.StudantsNames
{
    public static class ExtensionStudent
    {
        public static List<Student> GetName(this List<Student> names)
        {
            IEnumerable<Student> studentsNames = from name in names
                                where (name.FirstName.CompareTo(name.LastName) < 0)
                                select name;

            return studentsNames.ToList();
        }
    }
    class TestStudentsNames
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Georgi", "Georgiev"),
                new Student("Ivan","Ivanov"),
                new Student("Ivan","Andonov"),
                new Student("Anton","Ivanov"),
                new Student("Svetlin","Nakov"),
                new Student("Nikolay","Kostov"),
                new Student("a","b"),
                new Student("b","a")
            };

            List<Student> resultStudents = new List<Student>();
            resultStudents = students.GetName();
            foreach (var student in resultStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
