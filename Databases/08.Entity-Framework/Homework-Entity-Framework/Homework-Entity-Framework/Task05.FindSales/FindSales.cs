/* Write a method that finds all the sales by
 * specified region and period (start / end dates).
 */

namespace Task05.FindSales
{
    using NorthwindEFModel;
    using System;
    using System.Linq;

    public class FindSales
    {
        public static void Main()
        {
            FindAllSales("RJ", new DateTime(1997, 1, 1), new DateTime(2008, 1, 1));
        }

        public static void FindAllSales(string region, DateTime startDate, DateTime endDate)
        {
            using (var db = new NORTHWNDEntities())
            {
                var sales = from o in db.Orders
                            join od in db.Order_Details
                            on o.OrderID equals od.OrderID
                            where o.ShipRegion == region &&
                                (o.ShippedDate >= startDate && o.ShippedDate <= endDate)
                            select new { o.ShipName, od.Product.ProductName, od.Quantity };

                foreach (var sale in sales)
                {
                    Console.WriteLine("Ship name: {0} Product name: {1} Quantity: {2}",
                        sale.ShipName.PadRight(20), sale.ProductName.PadRight(35), sale.Quantity);
                }
            }
        }
    }
}
