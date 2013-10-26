namespace Schools.Controllers
{
    using AttributeRouting;
    using Schools.Context;
    using Schools.DTOs;
    using Schools.Models;
    using Schools.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api/schools")]
    public class SchoolsController : ApiController
    {
        private readonly IRepository<School> data;

        public SchoolsController()
        {
            this.data = new EfRepository<School>(new SchoolDbContext());
        }

        public SchoolsController(IRepository<School> data)
        {
            this.data = data;
        }

        // GET api/schools
        [HttpGet]
        public IEnumerable<SchoolDto> Get()
        {
            var schools = this.data.All();

            var schoolsDto = new List<SchoolDto>();

            foreach (var school in schools)
            {
                schoolsDto.Add(ConvertSchoolToDto(school));
            }

            return schoolsDto;
        }

        // GET api/schools/5
        [HttpGet]
        public SchoolDto Get([FromUri]int id)
        {
            var school = this.data.Get(id);

            var schoolDto = ConvertSchoolToDto(school);

            return schoolDto;
        }

        // POST api/schools
        [HttpPost]
        public HttpResponseMessage Post([FromBody]School school)
        {
            if (ModelState.IsValid)
            {
                this.data.Add(school);

                var schoolDto = ConvertSchoolToDto(school);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, schoolDto);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = school.SchoolId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/schools/5
        [HttpPut]
        public void Put([FromUri]int id, [FromBody]string value)
        {
        }

        // DELETE api/schools/5
        [HttpDelete]
        public void Delete([FromUri]int id)
        {
        }

        protected static SchoolDto ConvertSchoolToDto(School school)
        {
            var schoolDto = new SchoolDto();

            if (school != null)
            {
                if (school.SchoolId != 0)
                {
                    schoolDto.SchoolId = school.SchoolId;
                }

                if (school.Name != null)
                {
                    schoolDto.Name = school.Name;
                }

                if (school.Location != null)
                {
                    schoolDto.Location = school.Location;
                }
            }

            return schoolDto;
        }
    }
}
