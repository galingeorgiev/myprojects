namespace CarStore.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    [DataContract]
    public class Customization
    {

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "airCondition")]
        public bool AirCondition { get; set; }

        [DataMember(Name = "crouseControl")]
        public bool CrouseControl { get; set; }

        [DataMember(Name = "automaticTransmission")]
        public bool AutomaticTransmission { get; set; }

        [DataMember(Name = "powerLock")]
        public bool PowerLock { get; set; }

        [DataMember(Name = "powerWindows")]
        public bool PowerWindows { get; set; }

        [DataMember(Name = "parktronic")]
        public bool Parktronic { get; set; }

        [DataMember(Name = "audioSystem")]
        public bool AudioSystem { get; set; }

        [Required]
        public virtual Car Car { get; set; }
    }
}
