namespace StudentsService.Controllers
{
    using StudentsService.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Web.Http;
    using System.Web.Http.Cors;

    [CollectionDataContract]
    [EnableCors("*", "*", "*")]
    public class StudentsController : ApiController
    {
        // GET api/students
        public IEnumerable<Student> Get()
        {
            var students = new List<Student>() 
            {
            new Student("Doncho", "Minkov", new List<Mark>() {new Mark("Math", 4), new Mark("JavaScript", 6)}, 4, 23),
			new Student("Nikolay", "Kostov", new List<Mark>() {new Mark("MVC", 6), new Mark("JavaScript", 5)}, 5, 21),
			new Student("Ivaylo", "Kendov", new List<Mark>() {new Mark("OOP", 4), new Mark("C#", 6)}, 3, 22),
			new Student("Svetlin", "Nakov", new List<Mark>() {new Mark("Unit Testing", 5), new Mark("WPF", 6)}, 7, 29),
			new Student("Asya", "Georgieva", new List<Mark>() {new Mark("Automation Testing", 6), new Mark("Manual Testing", 4)}, 6, 15)
            };

            return students;
        }
    }
}
