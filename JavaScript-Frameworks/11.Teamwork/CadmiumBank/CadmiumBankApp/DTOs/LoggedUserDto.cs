using CadmiumBankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CadmiumBankApp.DTOs
{
    [DataContract(Name = "user")]
    public class LoggedUserDto
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        [DataMember(Name = "role")]
        public Role Role { get; set; }
    }
}