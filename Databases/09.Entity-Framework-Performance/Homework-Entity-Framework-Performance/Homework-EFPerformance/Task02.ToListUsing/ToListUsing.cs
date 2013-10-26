/* Using Entity Framework write a query that selects all
 * employees from the Telerik Academy database, then 
 * invokes ToList(), then selects their addresses, then 
 * invokes ToList(), then selects their towns, then invokes
 * ToList() and finally checks whether the town is "Sofia".
 * Rewrite the same in more optimized way and compare the 
 * performance.
 */

namespace Task02.ToListUsing
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using TelerikAcademy.Model;

    class ToListUsing
    {
        static void Main()
        {
            using (var db = new TelerikAcademyEntities())
            {
                var sw = new Stopwatch();
                Console.WriteLine("Slow option");
                sw.Start();

                var employeesSlowSelect = (from e in db.Employees
                                select e).ToList()
                                .Select(e => e.Address).ToList()
                                .Select(a => a.Town)
                                .Where(t => t.Name == "Sofia");

                sw.Stop();
                Console.WriteLine("Needed milliseconds: {0}", sw.Elapsed);

                foreach (var employee in employeesSlowSelect)
                {
                    Console.WriteLine(employee.Name);
                }

                sw.Reset();
                sw.Start();
                Console.WriteLine("\nFaster option");
                var employeesFastSelect = from e in db.Employees
                                          join a in db.Addresses
                                          on e.AddressID equals a.AddressID
                                          join t in db.Towns
                                          on a.TownID equals t.TownID
                                          where t.Name == "Sofia"
                                          select new { Name = e.FirstName, Town = t.Name };

                sw.Stop();
                Console.WriteLine("Needed milliseconds: {0}", sw.Elapsed);
                foreach (var employee in employeesFastSelect)
                {
                    Console.WriteLine("{0} {1}", employee.Name, employee.Town);
                }
            }
        }
    }
}
