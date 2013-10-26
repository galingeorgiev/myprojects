/* 1. Using code first approach, create database 
 * for student system with the following tables:
 *  - Students (with Id, Name, Number, etc.)
 *  - Courses (Name, Description, Materials, etc.)
 *  - StudentsInCourses (many-to-many relationship)
 *  - Homework (one-to-many relationship with students 
 *    and courses), fields: Content, TimeSent
 *  - Annotate the data models with the appropriate 
 *    attributes and enable code first migrations
 * 2. Write a console application that uses the data
 * 3. Seed the data with random values
 * 
 * Pleace change conection string if use SQLEXPRESS
 */

namespace School.Client
{
    using School.Data;
    using School.Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion <SchoolContext, Configuration>());

            using (var db = new SchoolContext())
            {
                var getStudents = from s in db.Students
                                  select s.Name;

                foreach (var student in getStudents)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
