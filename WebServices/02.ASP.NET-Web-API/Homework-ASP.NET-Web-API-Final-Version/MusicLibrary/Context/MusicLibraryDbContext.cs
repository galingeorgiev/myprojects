namespace MusicLibrary.Context
{
    using MusicLibrary.Models;
    using System.Data.Entity;

    public class MusicLibraryDbContext 
        : DbContext
    {
        public MusicLibraryDbContext()
            : base("MusicLibraryDbContext")
        {
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }
    }
}