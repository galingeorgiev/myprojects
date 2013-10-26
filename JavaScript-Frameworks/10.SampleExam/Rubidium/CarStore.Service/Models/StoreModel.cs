namespace CarStore.Service.Models
{
    using CarStore.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using System.Web;

    [DataContract]
        public class StoreModel
    {

        [DataMember(Name = "id")]
        public int Id { get; set; }


        [DataMember(Name = "name")]
        public string Name { get; set; }


        [DataMember(Name = "city")]
        public string City { get; set; }


        [DataMember(Name = "adress")]
        public string Adress { get; set; }

        [DataMember(Name = "longitute")]
        public decimal Longitute { get; set; }

        [DataMember(Name = "latitude")]
        public decimal Latitude { get; set; }

        public static Expression<Func<Store, StoreModel>> FromStore
        {
            get
            {
                return store =>
                new StoreModel()
                {
                    Id = store.Id,
                    Name = store.Name,
                    City = store.City,
                    Adress = store.Adress,
                    Longitute = store.Longitute,
                    Latitude = store.Latitude
                };
            }
        }
    }
}