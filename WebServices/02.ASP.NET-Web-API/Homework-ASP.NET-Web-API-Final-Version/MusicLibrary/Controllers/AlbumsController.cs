namespace MusicLibrary.Controllers
{
    using MusicLibrary.Context;
    using MusicLibrary.DTOs;
    using MusicLibrary.Models;
    using MusicLibrary.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Linq;
    using AttributeRouting.Web.Http;
    using AttributeRouting;

    [RoutePrefix("api/albums")]
    public class AlbumsController : ApiController
    {
        private readonly IRepository<Album> data;

        public AlbumsController()
        {
            this.data = new EfRepository<Album>(new MusicLibraryDbContext());
        }

        public AlbumsController(IRepository<Album> data)
        {
            this.data = data;
        }

        // GET api/albums
        [HttpGet]
        public IEnumerable<AlbumDto> Get()
        {
            var albums = this.data.All();

            var albumsMainDto = from a in albums
                                select new AlbumDto() { 
                                    Id = a.AlbumId, 
                                    Title = a.Title, 
                                    Year = a.Year, 
                                    Producer = a.Producer };

            return albumsMainDto;
        }

        // GET api/albums/5
        [HttpGet]
        public AlbumDto Get([FromUri]int id)
        {
            var album = this.data.Get(id);

            var albumMainDto = ConvertAlbumToMainDto(album);

            return albumMainDto;
        }

        // GET api/albums/5/songs
        [GET("{id}/songs")]
        public IEnumerable<SongDto> GetAlbumSongs([FromUri]int id)
        {
            var album = this.data.Get(id);
            IEnumerable<SongDto> songsDto = null;

            if (album != null)
            {
                var songs = album.Songs;

                songsDto = from s in songs
                               select new SongDto
                               {
                                   Id = s.SongId,
                                   Title = s.Title,
                                   Year = s.Year,
                                   Genre = s.Genre,
                                   ArtistName = s.Artist.Name
                               };
            }

            return songsDto;
        }

        // GET api/albums/5/artists
        [GET("{id}/artists")]
        public IEnumerable<Artist> GetAlbumArtists([FromUri]int id)
        {
            var album = this.data.Get(id);
            IEnumerable<Artist> artists = null;

            if (album != null)
            {
                artists = album.Artists;
            }

            return artists;
        }

        // POST api/albums
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Album album)
        {
            if (ModelState.IsValid)
            {
                this.data.Add(album);

                var albumMainDto = ConvertAlbumToMainDto(album);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, albumMainDto);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.AlbumId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/albums/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Album album)
        {
            if (ModelState.IsValid && id == album.AlbumId)
            {
                try
                {
                    this.data.Update(id, album);
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

        // DELETE api/albums/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Album album = this.data.Get(id);
            if (album == null)
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

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected static AlbumDto ConvertAlbumToMainDto(Album album)
        {
            var albumDto = new AlbumDto()
            {
                Id = album.AlbumId
            };

            if (album.Title != null)
            {
                albumDto.Title = album.Title;
            }

            if (album.Year != 0)
            {
                albumDto.Year = album.Year;
            }

            if (album.Producer != null)
            {
                albumDto.Producer = album.Producer;
            }

            return albumDto;
        }
    }
}
