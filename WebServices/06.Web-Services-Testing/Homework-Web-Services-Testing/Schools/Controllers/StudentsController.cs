namespace Schools.Controllers
{
    using AttributeRouting;
    using Schools.Context;
    using Schools.Models;
    using Schools.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private readonly IRepository<Student> data;

        public StudentsController()
        {
            this.data = new EfRepository<Student>(new SchoolDbContext());
        }

        public StudentsController(IRepository<Student> data)
        {
            this.data = data;
        }

        // GET api/students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return this.data.All();
        }

        // GET api/students/5
        [HttpGet]
        public Student Get([FromUri]int id)
        {
            return this.data.Get(id);
        }

        // GET api/students?subject=math&value=5.00
        [HttpGet]
        public IEnumerable<Student> Get([FromUri]string subject, [FromUri]double value)
        {
            var students = this.data.All()
                .Where(s => s.Marks.Any(m => m.Subject == subject && m.Value >= value))
                .Select(st => st).ToList();

            return students;
        }

        // POST api/students
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Student student)
        {
            if (ModelState.IsValid)
            {
                this.data.Add(student);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, student);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = student.StudentId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/students/5
        [HttpPut]
        public void Put([FromUri]int id, [FromBody]string value)
        {
        }

        // DELETE api/students/5
        [HttpDelete]
        public void Delete([FromUri]int id)
        {
        }
    }
}
