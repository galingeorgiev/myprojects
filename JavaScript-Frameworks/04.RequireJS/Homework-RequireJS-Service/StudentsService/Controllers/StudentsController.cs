namespace StudentsService.Controllers
{
    using StudentsService.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Linq;

    [CollectionDataContract]
    [EnableCors("*", "*", "*")]
    public class StudentsController : ApiController
    {
        private static List<Student> students = new List<Student>() 
            {
            new Student(1, "Doncho Minkov", new List<Mark>() {new Mark("Math", 4), new Mark("JavaScript", 6)}, 4),
			new Student(2, "Nikolay Kostov", new List<Mark>() {new Mark("MVC", 6), new Mark("JavaScript", 5)}, 5),
			new Student(3, "Ivaylo Kendov", new List<Mark>() {new Mark("OOP", 4), new Mark("C#", 6)}, 3),
			new Student(4, "Svetlin Nakov", new List<Mark>() {new Mark("Unit Testing", 5), new Mark("WPF", 6)}, 7),
			new Student(5, "Asya Georgieva", new List<Mark>() {new Mark("Automation Testing", 6), new Mark("Manual Testing", 4)}, 6)
            };

        // GET api/students
        [HttpGet]
        public IEnumerable<StudentModel> Get()
        {
            var studentsModel = from s in students
                                select new StudentModel()
                                {
                                    Id = s.Id,
                                    Name = s.Name,
                                    Grade = s.Grade
                                };

            return studentsModel;
        }

        [HttpGet]
        [ActionName("marks")]
        public IEnumerable<Mark> Get(int studentId)
        {
            var marks = (from s in students
                        where s.Id == studentId
                        select s.Marks).FirstOrDefault();

            return marks;
        }
    }
}
