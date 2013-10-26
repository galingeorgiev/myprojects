using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStore.Service.Models
{
    public class UserFullModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public string AuthCode { get; set; }

        public string SessionKey { get; set; }

        public string Permission { get; set; }

        public decimal? Amount { get; set; }

        public IEnumerable<CarModel> Cars { get; set; }
    }
}