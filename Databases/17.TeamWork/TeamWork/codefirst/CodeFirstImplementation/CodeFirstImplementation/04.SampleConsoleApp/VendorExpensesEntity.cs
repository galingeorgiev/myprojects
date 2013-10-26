using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SampleConsoleApp
{
    public class VendorExpensesEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string VendorName { get; set; }

        public DateTime Date { get; set; }

        public decimal Expenses { get; set; }

        public override string ToString()
        {
            return this.VendorName + " " + this.Date.ToString() + " " + this.Expenses;
        }
    }
}
