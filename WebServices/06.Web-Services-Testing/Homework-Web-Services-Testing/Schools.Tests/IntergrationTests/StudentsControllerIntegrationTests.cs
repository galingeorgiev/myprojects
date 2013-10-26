/*
 * Write integration tests for the StudentsController endpoints
 */

namespace Schools.Tests.IntergrationTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Schools.Models;
    using Schools.Tests.Fakes;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;

    [TestClass]
    public class StudentsControllerIntegrationTests
    {
        [TestMethod]
        public void Add_ValidStudent_ResponseShouldBeOkAndContentNotNull()
        {
            var repository = new FakeRepository<Student>();

            var server = new InMemoryHttpServer<Student>("http://localhost/", repository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Add_ValidStudent_CheckUserNamesAndCount()
        {
            var repository = new FakeRepository<Student>();

            string firstName = "Nikolay";
            string lastName = "Kostov";
            double mathValue = 5.00;
            var student = MakeSimpleStudent(firstName, lastName, mathValue);

            var server = new InMemoryHttpServer<Student>("http://localhost/", repository);

            // Post student
            var request = server.CreatePostRequest("api/students", student);
            
            // Get posted student
            var responseStudent = server.CreateGetRequest("api/students").Content.ReadAsAsync<List<Student>>().Result;

            Assert.AreEqual(1, responseStudent.Count);
            Assert.AreEqual(firstName, responseStudent[0].FirstName);
            Assert.AreEqual(lastName, responseStudent[0].LastName);
        }

        [TestMethod]
        public void AddThreeStudents_GetByMathResult_CheckIsCountCorrect()
        {
            var firstStudent = MakeSimpleStudent("Nikolay", "Kostov", 4.00);
            var secondStudent = MakeSimpleStudent("Svetlin", "Nakov", 5.00);
            var thirdStudent = MakeSimpleStudent("Doncho", "Minkov", 6.00);

            var repository = new FakeRepository<Student>();
            var server = new InMemoryHttpServer<Student>("http://localhost/", repository);

            // Post student
            server.CreatePostRequest("api/students", firstStudent);
            server.CreatePostRequest("api/students", secondStudent);
            server.CreatePostRequest("api/students", thirdStudent);

            // Get all students that have a mark for MATH and it is above 5.00
            var responseStudents = server
                .CreateGetRequest("api/students?subject=math&value=5.00")
                .Content.ReadAsAsync<List<Student>>().Result;

            Assert.AreEqual(2, responseStudents.Count);
        }

        private static Student MakeSimpleStudent(string firstName, string lastName, double mathValue)
        {
            var school = new School() { Name = "Telerik Academy", Location = "Sofia" };

            var firstMark = new Mark() { Subject = "math", Value = mathValue };
            var secondMark = new Mark() { Subject = "c#", Value = 6.00 };
            var thirdMark = new Mark() { Subject = "js", Value = 5.00 };
            var fourthMark = new Mark() { Subject = "css", Value = 4.00 };

            var student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = 21,
                School = school,
                Grade = 12,
                Marks = new List<Mark>() { firstMark, secondMark, thirdMark, fourthMark }
            };

            return student;
        }
    }
}
