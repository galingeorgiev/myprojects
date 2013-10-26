using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CadmiumBankApp.DTOs
{
    [DataContract(Name = "exchangeRate")]
    public class ExchangeRate
    {
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "rate")]
        public float Rate { get; set; }
    }
}