/* Using Entity Framework write a SQL query to select all employees 
 * from the Telerik Academy database and later print their name, 
 * department and town. Try the both variants: with and without. 
 * Include(…). Compare the number of executed SQL statements and 
 * the performance.
 */

namespace Task01.PerformanceTests
{
    using System;
    using TelerikAcademy.Model;

    public class PerformanceTests
    {
        public static void Main()
        {
            Console.WriteLine("-------------------- Query without include --------------------");
            Console.WriteLine("This made 300+ queries to server.");
            QueryWithoutInclude();

            Console.WriteLine("-------------------- Query with include --------------------");
            Console.WriteLine("This made 1 query to server.");
            QueryWithInclude();
        }

        public static void QueryWithoutInclude()
        {
            using (var db = new TelerikAcademyEntities())
            {
                foreach (var employee in db.Employees)
                {
                    Console.WriteLine("Employee name: {0} Departmant: {1} Town: {2}",
                        (employee.FirstName + " " + employee.LastName).PadRight(25),
                        employee.Department.Name.PadRight(20), 
                        employee.Address.Town.Name);
                }
            }
        }

        public static void QueryWithInclude()
        {
            using (var db = new TelerikAcademyEntities())
            {
                foreach (var employee in db.Employees.Include("Department").Include("Address.Town"))
                {
                    Console.WriteLine("Employee name: {0} Departmant: {1} Town: {2}",
                        (employee.FirstName + " " + employee.LastName).PadRight(25),
                        employee.Department.Name.PadRight(20),
                        employee.Address.Town.Name);
                }
            }
        }
    }
}
