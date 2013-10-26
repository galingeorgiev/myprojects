namespace MusicLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public class Album
    {
        [Key]
        [DataMember]
        public int AlbumId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Producer { get; set; }

        [DataMember]
        private ICollection<Artist> artists;

        [DataMember]
        private ICollection<Song> songs;

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }

        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }
    }
}