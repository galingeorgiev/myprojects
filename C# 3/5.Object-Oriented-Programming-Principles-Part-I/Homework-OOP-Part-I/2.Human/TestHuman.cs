/*Define abstract class Human with first name and last name. Define new class Student
 *which is derived from Human and has new field – grade. Define class Worker derived
 *from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour()
 *that returns money earned by hour by the worker. Define the proper constructors and
 *properties for this hierarchy. Initialize a list of 10 students and sort them by grade
 *in ascending order (use LINQ or OrderBy() extension method). Initialize a list of 10
 *workers and sort them by money per hour in descending order. Merge the lists and sort
 *them by first name and last name.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Human
{
    class TestHuman
    {
        static void Main()
        {
            //Create list of students
            List<Student> studentsList = new List<Student>() {
            new Student("Svetlin","Nakov",6),
            new Student("Nikolay","Kostov",5),
            new Student("Pavel","Kolev",4),
            new Student("Doncho","Minkov",3),
            new Student("Georgi","Georgiev",2),
            new Student("Lionel","Messi",1),
            new Student("Cristiano","Ronaldo",0),
            new Student("Zinedin","Zidan",6),
            new Student("Ivan","Ivanov",3),
            new Student("a","b",2)};

            //Order students by grade
            var orderStudentsByName = from student in studentsList
                                      orderby student.Grade
                                      select student;

            Console.WriteLine("----- Sorted students by grade -----");
            foreach (var student in orderStudentsByName)
            {
                Console.WriteLine(student);
            }

            //Create list of workers
            List<Worker> workerList = new List<Worker>() {
            new Worker("Svetlin","Nakov",600,8),
            new Worker("Stoqn","Kostov",500,6),
            new Worker("Pavel","Dimitrov",456,4),
            new Worker("Doncho","Donchev",345,10),
            new Worker("Georgi","Andonov",299,12),
            new Worker("Dimityr","Dimitrov",143,9),
            new Worker("Petyr","Petrov",990,5),
            new Worker("Yordan","Yordanov",236,7),
            new Worker("Ivan","Ivanov",367,8),
            new Worker("b","a",256,4)};

            //Order workers by money per hour
            var sortedWorkersByMoneyPerHour = from worker in workerList
                                              orderby worker.MoneyPerHour() descending
                                              select worker;

            Console.WriteLine("\n----- Sorted workers by money per hour -----");
            foreach (var worker in sortedWorkersByMoneyPerHour)
            {
                Console.WriteLine(worker);
            }

            //Get students names and store tham in anonimous class
            var studentsNames = from student in studentsList
                                  select new{student.FirstName, student.LastName};

            //Get workers names and store tham in anonimous class
            var workersNames = from student in workerList
                                  select new { student.FirstName, student.LastName };

            //Concat keep human with same names
            var mergedList = studentsNames.Concat(workersNames); 
            //Sort students and workers by name and print sorted names in console
            var sortedMergedList = from human in mergedList
                                   orderby human.FirstName, human.LastName
                                   select human;
            Console.WriteLine("\n----- Sorted workers and students by first and last name -----");
            foreach (var human in sortedMergedList)
            {
                Console.WriteLine("{0} {1}",human.FirstName, human.LastName);
            }
            Console.WriteLine();
        }
    }
}
