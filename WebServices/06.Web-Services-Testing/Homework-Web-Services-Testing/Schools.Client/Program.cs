namespace Schools.Client
{
    using Schools.Models;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:51058/") };

        public static void Main()
        {
            // Used in development process.
            var school = new School() { Name = "Telerik Academy", Location = "Sofia" };

            var firstMark = new Mark() { Subject = "math", Value = 5.00 };
            var secondMark = new Mark() { Subject = "math", Value = 6.00 };
            var thirdMark = new Mark() { Subject = "math", Value = 4.00 };
            var fourthMark = new Mark() { Subject = "c#", Value = 6.00 };
            var fifthMark = new Mark() { Subject = "js", Value = 5.00 };
            var sixthMark = new Mark() { Subject = "css", Value = 4.00 };

            var firstStudent = new Student()
            {
                FirstName = "Nikolay",
                LastName = "Kostov",
                Age = 21,
                School = school,
                Grade = 12,
                Marks = new List<Mark>() { secondMark, fourthMark }
            };

            var secondStudent = new Student()
            {
                FirstName = "Doncho",
                LastName = "Minkov",
                Age = 24,
                School = school,
                Grade = 11,
                Marks = new List<Mark>() { firstMark, fifthMark }
            };

            var thirdStudent = new Student()
            {
                FirstName = "Georgi",
                LastName = "Georgiev",
                Age = 25,
                School = school,
                Grade = 10,
                Marks = new List<Mark>() { thirdMark, sixthMark }
            };

            //AddStudent(thirdStudent);
            //AddSchool(school);

            //var students = Client.GetAsync("api/students?subject=math&value=5.00").Result.Content.ReadAsAsync<IEnumerable<Student>>().Result;

            //foreach (var student in students)
            //{
            //    Console.WriteLine(student.FirstName);
            //}
        }

        public static void AddStudent(Student student)
        {
            var response = Client.PostAsJsonAsync("api/students", student).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Student \"{0}\" added!", student.FirstName);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void AddSchool(School school)
        {
            var response = Client.PostAsJsonAsync("api/schools", school).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("School \"{0}\" added!", school.Name);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
