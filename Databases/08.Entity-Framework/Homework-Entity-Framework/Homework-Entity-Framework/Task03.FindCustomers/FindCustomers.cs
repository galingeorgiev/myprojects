/* Write a method that finds all customers who have 
 * orders made in 1997 and shipped to Canada.
 */

namespace Task03.FindCustomers
{
    using NorthwindEFModel;
    using System;
    using System.Linq;

    public class FindCustomers
    {
        public static void Main()
        {
            FindCustomersByYearAndCountry();
        }

        public static void FindCustomersByYearAndCountry()
        {
            DateTime startDate = new DateTime(1997, 1, 1);
            DateTime endDate = new DateTime(1997, 12, 31);
            string country = "Canada";

            using (var db = new NORTHWNDEntities())
            {
                var customers = from o in db.Orders
                                join c in db.Customers
                                on o.CustomerID equals c.CustomerID
                                where o.ShipCountry == country &&
                                (o.ShippedDate >= startDate && o.ShippedDate <= endDate)
                                select new { c.ContactName, o.ShippedDate, o.ShipCountry };

                foreach (var customer in customers)
                {
                    Console.WriteLine("Name: {0} Shipped date: {1} Country: {2}",
                        customer.ContactName.PadRight(20), customer.ShippedDate.ToString().PadRight(25), customer.ShipCountry);
                }
            }
        }
    }
}
