namespace Task04.FindCustomersSQLQuery
{
    using System;

    public class CustomersInfo
    {
        public string ContactName { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipCountry { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0} Shipped date: {1} Country: {2}",
                        this.ContactName.PadRight(20), this.ShippedDate.ToString().PadRight(25), this.ShipCountry);
        }
    }
}
