/*Using the extension methods OrderBy() and ThenBy()
 *with lambda expressions sort the students by first
 *name and last name in descending order. Rewrite the
 *same with LINQ.*/

using System;
using System.Collections.Generic;
using System.Linq;
using _3.StudantsNames;

namespace _5.SortStudents
{
    class SortStudents
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
            Console.WriteLine("------- Sorted with lambda expresion --------");
            List<Student> sortedStudentsLambda = students.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            foreach (var student in sortedStudentsLambda)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\n------- Sorted with LINQ --------");
            var sortedStudentsLINQ = from student in students
                                               orderby student.FirstName, student.LastName
                                               select student;
            foreach (var student in sortedStudentsLINQ)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }
    }
}
