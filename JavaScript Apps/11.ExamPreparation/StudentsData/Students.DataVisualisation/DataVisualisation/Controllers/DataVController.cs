using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataVisualisation.Controllers
{
    public class DataVController : ApiController
    {
        string students = "[{ fname: 'Ivan', lname: 'Ivanov' },{ fname: 'Petyr', 'fname': 'Petrov' }, { fname: 'Svetlin', lname: 'Nakov' }]";

        [HttpGet]
        [ActionName("getstudents")]
        public string GetStudents()
        {
            return students;
        }

        [HttpPost]
        [ActionName("add")]
        public string PostStudents(string currentStudent)
        {
            students = students + currentStudent;
            return students;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}