using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Student
{
    class TestStudent
    {
        static void Main()
        {
            //Create new student and print content
            Student nakov = new Student("Svetlin", "Nakov", 123456789, University.Telerik, 5);
            Console.WriteLine("----- Original instance -----");
            Console.WriteLine(nakov);
            Console.WriteLine();

            //Clone 'nakov' in 'nakovCopy' and print 'nakovCopy'
            Student nakovCopy = (Student)nakov.Clone();
            Console.WriteLine("----- Cloned instance -----");
            Console.WriteLine(nakovCopy);
            Console.WriteLine();

            //Change 'nakov' first name and course
            nakov.FirstName = "Nikolay";
            nakov.Course = 9;
            //print 'nakov' and 'nakovCopy'
            Console.WriteLine("----- Original and cloned instance with some changes in original -----");
            Console.WriteLine(nakov);
            Console.WriteLine(nakovCopy);
            Console.WriteLine();

            //Create 'nakovSecondCopy' and change ssn
            Student nakovSecondCopy = (Student)nakov.Clone();
            nakovSecondCopy.Ssn = 987654321;

            //Create list of students and soth them
            List<Student> students = new List<Student> {
            nakov,
            nakovCopy,
            nakovSecondCopy };
            students.Sort();
            //Print sorted students
            Console.WriteLine("----- Sorted students by names and ssn -----");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
