using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStore.Service.Models
{
    public class StoreFullModel:StoreModel
    {
        public IEnumerable<CarModel> Cars { get; set; }
    }
}