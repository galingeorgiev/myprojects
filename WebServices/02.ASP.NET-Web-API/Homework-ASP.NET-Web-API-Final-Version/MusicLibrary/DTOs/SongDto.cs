using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicLibrary.DTOs
{
    public class SongDto
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int Id { get; set; }

        public string ArtistName { get; set; }
    }
}