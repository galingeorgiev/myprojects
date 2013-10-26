/* Try to open two different data contexts and perform 
 * concurrent changes on the same records. What 
 * will happen at SaveChanges()? How to deal with it?
 * 
 * To check added customer use query below:
 * use NORTHWND
 * select *
 * from Customers c
 * where c.CompanyName like 'Telerik%'
 */

namespace Task07.ConcurrentChanges
{
    using NorthwindEFModel;
    using System;
    using System.Linq;

    public class ConcurrentChanges
    {
        public static void Main()
        {
            using (var db = new NORTHWNDEntities())
            {
                string companyName = "Telerik";

                var telerikCustomers = from c in db.Customers
                                       where c.CompanyName == companyName
                                       select c;

                foreach (var customer in telerikCustomers)
                {
                    db.Customers.Remove(customer);
                }

                db.SaveChanges();

                // Create and add customer in NORTHWND database
                Customer testCustomer = new Customer()
                {
                    CompanyName = companyName,
                    CustomerID = "ABC42"
                };

                Console.WriteLine("First customer is added");
                db.Customers.Add(testCustomer);
                Console.WriteLine("Changes saved");
                db.SaveChanges();

                // Create two other customers and try to add them in NORTHWND database
                // If we try to add 'incorrectTestCustomer' SaveChanges will rollback operation (no customers added)
                // If we comment adding 'incorrectTestCustomer' this will work correct (will commit changes)
                Customer secondTestCustomer = new Customer()
                {
                    CompanyName = companyName,
                    CustomerID = "ABC98"
                };

                Customer incorrectTestCustomer = new Customer()
                {
                    CompanyName = companyName,
                    CustomerID = "ABC98"
                };

                Console.WriteLine("Second customer is added");
                db.Customers.Add(secondTestCustomer);

                Console.WriteLine("Adding incorrect Customer");
                // Uncomment line below. This will trow exception and call rollback.
                //db.Customers.Add(incorrectTestCustomer);
                //Console.WriteLine("Trying to save changes. This will throw exception");

                db.SaveChanges();
            }
        }
    }
}