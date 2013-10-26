/* Create a stored procedures in the Northwind database
 * for finding the total incomes for given supplier 
 * name and period (start date, end date). Implement 
 * a C# method that calls the stored procedure and 
 * returns the retuned record set.
 * 
 * Craete procedure with code below:
 * 
 * use NORTHWND
 * 
 * GO
 * 
 * create procedure uspTotalIncomesForPeriod
 * 	@FullName nvarchar(50),
 * 	@StartDate date,
 * 	@EndDate date
 * as
 * select sum(od.UnitPrice * od.Quantity) as 'TotalIncomesForPeriod'
 * from Suppliers s
 * join Products p
 * on s.SupplierID = p.SupplierID
 * join [Order Details] od
 * on p.ProductID = od.ProductID
 * join Orders o
 * on o.OrderID = od.OrderID
 * join Employees e
 * on e.EmployeeID = o.EmployeeID
 * where e.FirstName + ' ' + e.LastName = @FullName and
 * 	(o.ShippedDate between @StartDate and @EndDate)
 * 
 * GO
 * 
 * Test with:
 * 
 * exec uspTotalIncomesForPeriod 'Steven Buchanan', '1995-01-01', '1996-08-01'
 * 
 * Test result: 1065.20
 */

namespace Task10.CallStoredProcedure
{
    using NorthwindEFModel;
    using System;
    using System.Linq;

    public class CallStoredProcedure
    {
        public static void Main()
        {
            using (var db = new NORTHWNDEntities())
            {
                string supplierFullName = "Steven Buchanan";
                DateTime startDate = new DateTime(1995, 1, 1);
                DateTime endDate = new DateTime(1996, 8, 1);

                // After creating stored procedure in Managment studio
                // you should add this procedure and after that update model from DB.
                var result = db.uspTotalIncomesForPeriod(supplierFullName, startDate, endDate);
                Console.WriteLine(result.FirstOrDefault());
            }
        }
    }
}
