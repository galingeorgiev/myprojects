namespace Northwind.Client
{
    using Northwind.Model;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using Telerik.OpenAccess;

    internal class OpenAccessDemo
    {
        private static void Main()
        {
            //Shipper newShipper = new Shipper();
            //newShipper.CompanyName = "Tartalety";
            //newShipper.Phone = "(503) 232-9631";
            //using (var emtity = new NorthwindModel())
            //{
            //    emtity.Add(newShipper);
            //    emtity.SaveChanges();
            //}

            // Task 2
            //SerializeDeserialize("BOLID");

            // Task 3
            //BulkInsert(new EntitiesModel());

            long memoryUsed = GC.GetTotalMemory(true);

            Console.WriteLine("Memory used: {0} MB", memoryUsed / Math.Pow(2, 20));

            //BulkDelete(new EntitiesModel());

            SlowDelete(new NorthwindModel());

            memoryUsed = GC.GetTotalMemory(true);

            Console.WriteLine("Memory used: {0} MB", memoryUsed / Math.Pow(2, 20));
        }

        private static void SerializeDeserialize(string customerId)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = SerializeToBinaryStream(customerId);
            stream.Seek(0, SeekOrigin.Begin);

            Customer customer = formatter.Deserialize(stream) as Customer;

            Console.WriteLine("Country: {0}", customer.Country);
        }

        private static MemoryStream SerializeToBinaryStream(string customerId)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();
            using (NorthwindModel dbContext = new NorthwindModel())
            {
                Customer customer = dbContext.Customers.Where(c => c.CustomerID == customerId).First();
                formatter.Serialize(stream, customer);
            }

            return stream;
        }

        private static void BulkInsert(NorthwindModel context)
        {
            List<Product> products = new List<Product>(50000);

            for (int i = 0; i < 30000; i++)
            {
                Product product = new Product() { ProductName = "Lexus" + i, SupplierID = 5, CategoryID = 5, UnitPrice = 1000m, QuantityPerUnit = "1 piece" };
                products.Add(product);
            }

            context.Add(products);

            context.SaveChanges();
        }

        private static void BulkDelete(NorthwindModel context)
        {
            context.Log = null;

            var query = context.GetAll<Product>().Where(p => p.ProductID % 7 == 1);
            int deleted = query.DeleteAll();

            Console.WriteLine("Deleted products: {0}", deleted);
        }

        private static void SlowDelete(NorthwindModel context)
        {
            context.Delete(context.Products.Where(p => p.ProductID % 7 == 2));
            context.SaveChanges();
        }

        private static void TestOpenAccessDelete()
        {
            var context = new NorthwindModel();
            try
            {
                var products = context.Products.Count();

                Console.WriteLine(products);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.InnerException);
            }

            BulkInsert(context);

            //BulkDelete(context);

            //SlowDelete(context);

        }
    }
}