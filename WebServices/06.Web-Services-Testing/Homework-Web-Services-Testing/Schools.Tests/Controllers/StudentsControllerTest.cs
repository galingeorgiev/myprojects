/* Write unit tests for:
 * The StudentsController
 */

namespace Schools.Tests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Schools.Controllers;
    using Schools.Models;
    using Schools.Tests.Fakes;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;

    [TestClass]
    public class StudentsControllerTest
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/categories");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "categories");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void Add_ValidStudent_CheckIsAdded()
        {
            var repository = new FakeRepository<Student>();

            string firstName = "Nikolay";
            string lastName = "Kostov";
            var student = MakeSimpleStudent(firstName, lastName);

            repository.Entities.Add(student);

            var controller = new StudentsController(repository);

            var students = controller.Get();

            int count = 0;
            string firstNameInMemory = null;
            foreach (var st in students)
            {
                count++;
                firstNameInMemory = st.FirstName;
            }

            Assert.IsTrue(count == 1);
            Assert.AreEqual(firstName, firstNameInMemory);
        }

        [TestMethod]
        public void Add_ValidStudent_GetStudentById_CheckIsStudentCorrect()
        {
            var repository = new FakeRepository<Student>();

            string firstName = "Nikolay";
            string lastName = "Kostov";
            var student = MakeSimpleStudent(firstName, lastName);

            repository.Entities.Add(student);

            var controller = new StudentsController(repository);

            var allStudents = controller.Get();
            int studentId = 0;
            foreach (var st in allStudents)
            {
                studentId = st.StudentId;
            }

            var studentById = controller.Get(studentId);

            Assert.AreEqual(studentId, studentById.StudentId);
            Assert.AreEqual(firstName, studentById.FirstName);
            Assert.AreEqual(lastName, studentById.LastName);
        }

        private static Student MakeSimpleStudent(string firstName, string lastName)
        {
            var school = new School() { Name = "Telerik Academy", Location = "Sofia" };

            var firstMark = new Mark() { Subject = "math", Value = 5.00 };
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