

namespace MusicLibrary.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public class Song
    {
        [Key]
        [DataMember]
        public int SongId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public virtual Artist Artist { get; set; }
    }
}