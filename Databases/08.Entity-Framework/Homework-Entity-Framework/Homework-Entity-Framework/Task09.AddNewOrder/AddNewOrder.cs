/* Create a method that places a new order in the 
* Northwind database. The order should contain 
* several order items. Use transaction to ensure
* the data consistency.
*/

namespace Task09.AddNewOrder
{
    using NorthwindEFModel;
    using System.Transactions;

    public class AddNewOrder
    {
        public static void Main()
        {
            using (var db = new NORTHWNDEntities())
            {
                Order firstOrder = new Order() { CustomerID = "VINET", EmployeeID = 5, ShipVia = 3 };
                Order secondOrder = new Order() { CustomerID = "VINET", EmployeeID = 5, ShipVia = 3 };
                Order thirdOrder = new Order() { CustomerID = "VINET", EmployeeID = 5, ShipVia = 3 };
                //Order orderWithDuplicatedPrimaryKey = new Order() { CustomerID = "INVAL", EmployeeID = 5, ShipVia = 3 };

                db.Orders.Add(firstOrder);
                db.SaveChanges();
                db.Orders.Add(secondOrder);
                db.SaveChanges();
                db.Orders.Add(thirdOrder);
                db.SaveChanges();
                //db.Orders.Add(orderWithDuplicatedPrimaryKey);
                //db.SaveChanges();
            }
        }
    }
}