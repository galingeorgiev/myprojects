namespace Schools.Controllers
{
    using AttributeRouting;
    using Schools.Context;
    using Schools.Models;
    using Schools.Repositories;
    using System.Collections.Generic;
    using System.Web.Http;

    [RoutePrefix("api/marks")]
    public class MarksController : ApiController
    {
        private readonly IRepository<Mark> data;

        public MarksController()
        {
            this.data = new EfRepository<Mark>(new SchoolDbContext());
        }

        public MarksController(IRepository<Mark> data)
        {
            this.data = data;
        }

        // GET api/marks
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/marks/5
        [HttpGet]
        public string Get([FromUri]int id)
        {
            return "value";
        }

        // POST api/marks
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/marks/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/marks/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
