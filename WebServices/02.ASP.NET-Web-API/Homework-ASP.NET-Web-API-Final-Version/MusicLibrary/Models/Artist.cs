namespace MusicLibrary.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public class Artist
    {
        [Key]
        [DataMember]
        public int ArtistId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }
    }
}