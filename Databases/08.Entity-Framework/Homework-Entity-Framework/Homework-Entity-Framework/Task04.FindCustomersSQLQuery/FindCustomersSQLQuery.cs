/* Write a method that finds all customers who have 
 * orders made in 1997 and shipped to Canada.
 * 
 * Implement previous by using native SQL query
 * and executing it through the DbContext.
 */

namespace Task04.FindCustomersSQLQuery
{
    using NorthwindEFModel;
    using System;

    public class FindCustomersSQLQuery
    {
        public static void Main()
        {
            DateTime startDate = new DateTime(1997, 1, 1);
            DateTime endDate = new DateTime(1997, 12, 31);
            string country = "Canada";
            var northwinthEntities = new NORTHWNDEntities();

            string nativeSQLQuery = "use NORTHWND" +
                                    " select c.ContactName, o.ShippedDate, o.ShipCountry" +
                                    " from Orders o" +
                                    " join Customers c" +
                                    " on o.CustomerID = c.CustomerID" +
                                    " where o.ShipCountry = {0} and (o.ShippedDate between {1} and {2})";
            object[] parametars = { country, startDate, endDate };

            var customers = northwinthEntities.Database.SqlQuery<CustomersInfo>(nativeSQLQuery, parametars);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}