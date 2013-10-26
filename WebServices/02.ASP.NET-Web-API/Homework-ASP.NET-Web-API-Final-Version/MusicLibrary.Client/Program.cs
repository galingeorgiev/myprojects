namespace MusicLibrary.Client
{
    using MusicLibrary.DTOs;
    using MusicLibrary.Models;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:49685/") };

        public static void Main()
        {
            SongsDemo();
            Console.WriteLine("\nTry next requests in your broser:");
            Console.WriteLine("http://localhost:49685/api/albums/{album id}/songs");
            Console.WriteLine("http://localhost:49685/api/albums/{album id}/artists");
            Console.WriteLine("where {album id} is some album id from your database.");
        }

        public static void SongsDemo()
        {
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // Uncomment lines below to work with xml.
            //Client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/xml"));

            Console.WriteLine("Try add data");
            Artist testArtist = new Artist() { Name = "Grafa", DateOfBirth = DateTime.Now, Country = "Bulgaria" };
            Song testSong = new Song() { Artist = testArtist, Genre = "Pop", Title = "Ako ima rai", Year = 2005 };
            Song secondTestSong = new Song() { Genre = "Folk", Title = "Some song title", Year = 2008 };

            Album someAlbum = new Album() { Producer = "Some Producer", Title = "Some Title", Year = 2010 };
            someAlbum.Songs.Add(testSong);
            someAlbum.Songs.Add(secondTestSong);
            someAlbum.Artists.Add(testArtist);

            AddAlbum(someAlbum);

            int lastSongId = 0;
            Console.WriteLine("\nGet all songs and print title.");
            var getSongs = Client.GetAsync("api/Songs").Result.Content.ReadAsAsync<IEnumerable<SongDto>>().Result;
            foreach (var song in getSongs)
            {
                Console.WriteLine(song.Title);
                lastSongId = song.Id;
            }

            Console.WriteLine("\nGet last song by ID");
            var lastSong = Client.GetAsync("api/Songs/" + lastSongId).Result.Content.ReadAsAsync<SongDto>().Result;
            Console.WriteLine(lastSong.Title);

            Console.WriteLine("\nChange last song name from \"{0}\" to \"Other song title\"", lastSong.Title);
            lastSong.Title = "Other song title";
            var update = Client.PutAsJsonAsync("api/Songs/" + lastSong.Id, lastSong).Result;

            Console.WriteLine("\nGet last song by ID with changed name");
            var lastSongWithChangedName = Client.GetAsync("api/Songs/" + lastSongId).Result.Content.ReadAsAsync<Song>().Result;
            Console.WriteLine(lastSongWithChangedName.Title);

            Console.WriteLine("\nDelete last song");
            var delete = Client.DeleteAsync("api/Songs/" + lastSongId).Result;

            Console.WriteLine("\nGet all songs again");
            var getSongsAfterDelete = Client.GetAsync("api/Songs").Result.Content.ReadAsAsync<IEnumerable<Song>>().Result;
            foreach (var song in getSongsAfterDelete)
            {
                Console.WriteLine(song.Title);
                lastSongId = song.SongId;
            }
        }

        public static void AddSong(Song song)
        {
            var response = Client.PostAsJsonAsync("api/Songs", song).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song \"{0}\" added!", song.Title);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void AddAlbum(Album album)
        {
            var response = Client.PostAsJsonAsync("api/albums", album).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album \"{0}\" added!", album.Title);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
