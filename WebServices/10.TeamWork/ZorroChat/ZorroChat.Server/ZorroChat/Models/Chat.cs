using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ZorroChat.Models
{
    [DataContract(IsReference = true)]
    public class Chat
    {
        [Key]
        [DataMember]
        public int ChatId { get; set; }

        [DataMember]
        public User BlueUser { get; set; }

        [DataMember]
        public User RedUser { get; set; }

        [DataMember]
        public string Chanel { get; set; }
    }
}