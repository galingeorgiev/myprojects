using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ZorroChat.Models
{
    [DataContract(IsReference = true)]
    public class User
    {
        [Key]
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string SessionKey { get; set; }

        public User()
        {
            this.Chats = new HashSet<Chat>();
        }

        [DataMember]
        public IEnumerable<Chat> Chats { get; set; }
    }
}