using System;
using System.Collections.Generic;

/* Redesign the classes and refactor the code from the solution "Inheritance-and-Polymorphism" to
 * follow the best practices in high-quality classes. Extract abstract base class and move all
 * common properties in it. Encapsulate the fields and make sure required fields are not left
 * without a value. Reuse the repeating code though base methods. */

namespace InheritanceAndPolymorphism
{
    internal class CoursesExamples
    {
        private static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);

            localCourse.Students = new List<string>() { "Peter", "Maria" };
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development",
                "Mario Peshev", 
                new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);
        }
    }
}
