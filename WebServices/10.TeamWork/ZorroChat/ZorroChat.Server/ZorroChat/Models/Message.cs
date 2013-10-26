using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ZorroChat.Models
{
    [DataContract(IsReference = true)]
    public class Message
    {
        [Key]
        [DataMember]
        public int MessageId { get; set; }

        [DataMember]
        public User Owner { get; set; }

        [DataMember]
        public User Recepient { get; set; }

        [DataMember]
        public Chat Chat { get; set; }

        [DataMember]
        public string MessageText { get; set; }
    }
}