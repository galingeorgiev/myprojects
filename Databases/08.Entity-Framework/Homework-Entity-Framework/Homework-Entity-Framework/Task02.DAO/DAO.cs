/* Create a DAO class with static methods which
 * provide functionality for inserting, modifying
 * and deleting customers. Write a testing class.
 */

namespace Task02.DAO
{
    using NorthwindEFModel;
    using System.Linq;

    public class DAO
    {
        public static void Main()
        {
            using (var db = new NORTHWNDEntities())
            {
                Customer testCustomer = new Customer() 
                {
                    CompanyName = "Telerik",
                    CustomerID = "ABC12"
                };

                CustomerOperations.AddCustomer(testCustomer);
                //CustomerOperations.DeleteCustomer(testCustomer);
                //CustomerOperations.ModifyCustomerCompanyName(testCustomer, "Telerik Academy");
            }
        }
    }
}
