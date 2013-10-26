namespace MusicLibrary.Controllers
{
    using AttributeRouting;
    using AttributeRouting.Web.Http;
    using MusicLibrary.DTOs;
    using MusicLibrary.Context;
    using MusicLibrary.Models;
    using MusicLibrary.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Linq;

    [RoutePrefix("api/songs")]
    public class SongsController : ApiController
    {
        private readonly IRepository<Song> data;

        public SongsController()
        {
            this.data = new EfRepository<Song>(new MusicLibraryDbContext());
        }

        public SongsController(IRepository<Song> data)
        {
            this.data = data;
        }

        // GET api/songs
        [HttpGet]
        public IEnumerable<SongDto> Get()
        {
            var songs = this.data.All();

            var songsDto = from s in songs
                           select new SongDto { 
                               Id = s.SongId,
                               Title = s.Title, 
                               Year = s.Year, 
                               Genre = s.Genre,
                               ArtistName = s.Artist.Name };

            return songsDto;
        }

        // GET api/songs/5
        [HttpGet]
        public SongDto Get([FromUri]int id)
        {
            var song = this.data.Get(id);

            var songDto = ConvertSongs(song);

            return songDto;
        }

        // POST api/songs
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Song song)
        {
            if (ModelState.IsValid)
            {
                this.data.Add(song);

                var songDto = ConvertSongs(song);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, songDto);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.SongId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/songs/5
        [HttpPut]
        public HttpResponseMessage Put([FromUri]int id, [FromBody]Song song)
        {
            if (ModelState.IsValid && id == song.SongId)
            {
                try
                {
                    this.data.Update(id, song);
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

        // DELETE api/songs/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Song song = this.data.Get(id);
            if (song == null)
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

            var songDto = ConvertSongs(song);

            return Request.CreateResponse(HttpStatusCode.OK, songDto);
        }

        protected static SongDto ConvertSongs(Song song)
        {
            var songDto = new SongDto()
            {
                Id = song.SongId
            };

            if (song.Title != null)
            {
                songDto.Title = song.Title;
            }

            if (song.Year != 0)
            {
                songDto.Year = song.Year;
            }

            if (song.Genre != null)
            {
                songDto.Genre = song.Genre;
            }

            if (song.Artist != null)
            {
                songDto.ArtistName = song.Artist.Name;
            }

            return songDto;
        }
    }
}
