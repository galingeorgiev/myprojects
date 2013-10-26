/* Create a DAO class with static methods which
 * provide functionality for inserting, modifying
 * and deleting customers. Write a testing class.
 */

namespace Task02.DAO
{
    using NorthwindEFModel;
    using System;
    using System.Linq;

    public static class CustomerOperations
    {
        public static void AddCustomer(Customer customer)
        {
            using (var db = new NORTHWNDEntities())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }

            Console.WriteLine("Customer added.");
        }

        public static void DeleteCustomer(Customer customer)
        {
            using (var db = new NORTHWNDEntities())
            {
                var customerFromDB = db.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
                db.Customers.Remove(customerFromDB);
                db.SaveChanges();
            }

            Console.WriteLine("Customer deleted.");
        }

        public static void ModifyCustomerCompanyName(Customer customer, string newName)
        {
            using (var db = new NORTHWNDEntities())
            {
                var customerFromDB = db.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
                customerFromDB.CompanyName = newName;
                db.SaveChanges();
            }

            Console.WriteLine("Customer updated.");
        }
    }
}
