using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.Web.Models
{
    public class LaptopSearchViewModel
    {
        public string SearchModel { get; set; }

        public int SearchManufacturer { get; set; }

        public decimal PriceSearch { get; set; }
    }
}