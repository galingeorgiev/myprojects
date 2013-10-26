namespace MusicLibrary.Controllers
{
    using AttributeRouting;
    using MusicLibrary.Context;
    using MusicLibrary.Models;
    using MusicLibrary.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api/artists")]
    public class ArtistsController : ApiController
    {
        private readonly IRepository<Artist> data;

        public ArtistsController()
        {
            this.data = new EfRepository<Artist>(new MusicLibraryDbContext());
        }

        public ArtistsController(IRepository<Artist> data)
        {
            this.data = data;
        }

        // GET api/artists
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return this.data.All();
        }

        // GET api/artists/5
        [HttpGet]
        public Artist Get([FromUri]int id)
        {
            return this.data.Get(id);
        }

        // POST api/artists
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Artist artist)
        {
            if (ModelState.IsValid)
            {
                this.data.Add(artist);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.ArtistId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/artists/5
        [HttpPut]
        public HttpResponseMessage Put([FromUri]int id, [FromBody]Artist artist)
        {
            if (ModelState.IsValid && id == artist.ArtistId)
            {
                try
                {
                    this.data.Update(id, artist);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/artists/5
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri]int id)
        {
            Artist artist = this.Get(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this.data.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }
    }
}
