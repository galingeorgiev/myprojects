namespace Task02.DAO.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NorthwindEFModel;
    using System.Linq;

    [TestClass]
    public class CustomerOperationsTests
    {
        [TestMethod]
        public void AddCustomer_TestIsCustomerAdded()
        {
            using (var db = new NORTHWNDEntities())
            {
                string companyName = "Telerik";

                // Using ToList() to force execution
                var numberOfCustomersBeforeAdding = (from c in db.Customers
                                                     where c.CompanyName == companyName
                                                     select c).ToList();

                Customer testCustomer = new Customer()
                {
                    CompanyName = companyName,
                    CustomerID = "ABC12"
                };

                CustomerOperations.AddCustomer(testCustomer);

                var numberOfCustomersAfterOneElementAdding = (from c in db.Customers
                                                              where c.CompanyName == companyName
                                                              select c).ToList();

                Assert.AreEqual(numberOfCustomersBeforeAdding.Count() + 1,
                    numberOfCustomersAfterOneElementAdding.Count(),
                    "Check is element added correct");

                // Delete customer added for test
                CustomerOperations.DeleteCustomer(testCustomer);
            }
        }

        [TestMethod]
        public void AddCustomer_CheckIsFieldsCorrectAdded()
        {
            using (var db = new NORTHWNDEntities())
            {
                string companyName = "Telerik";
                string customerID = "ABC12";

                Customer testCustomer = new Customer()
                {
                    CompanyName = companyName,
                    CustomerID = customerID
                };

                CustomerOperations.AddCustomer(testCustomer);

                var getAddedCustomer = (from c in db.Customers
                                        where c.CompanyName == companyName
                                        select c).ToList();

                Assert.AreEqual(getAddedCustomer.FirstOrDefault().CompanyName, companyName, "Company name is incorect.");
                Assert.AreEqual(getAddedCustomer.FirstOrDefault().CustomerID, customerID, "CustomerID is incorect");

                // Delete customer added for test
                CustomerOperations.DeleteCustomer(testCustomer);
            }
        }

        [TestMethod]
        public void DeleteCustomer_TestIsCustomerDeleted()
        {
            using (var db = new NORTHWNDEntities())
            {
                string companyName = "Telerik";

                Customer testCustomer = new Customer()
                {
                    CompanyName = companyName,
                    CustomerID = "ABC12"
                };

                CustomerOperations.AddCustomer(testCustomer);

                // Using ToList() to force execution
                var numberOfCustomersAfterAdding = (from c in db.Customers
                                                    where c.CompanyName == companyName
                                                    select c).ToList();

                // Delete customer added for test
                CustomerOperations.DeleteCustomer(testCustomer);
                
                var numberOfCustomersAfterDeleting = (from c in db.Customers
                                                      where c.CompanyName == companyName
                                                      select c).ToList();

                Assert.AreEqual(numberOfCustomersAfterAdding.Count(),
                    numberOfCustomersAfterDeleting.Count() + 1,
                    "Check is customer deleted");
            }
        }

        [TestMethod]
        public void ModifyCustomerCompanyName_TestIsCompanyNameModified()
        {
            using (var db = new NORTHWNDEntities())
            {
                string companyName = "Telerik";
                string companyNewName = "Telerik Academy";

                Customer testCustomer = new Customer()
                {
                    CompanyName = companyName,
                    CustomerID = "ABC12"
                };

                CustomerOperations.AddCustomer(testCustomer);

                CustomerOperations.ModifyCustomerCompanyName(testCustomer, companyNewName);

                var getModifiedCustomer = (from c in db.Customers
                                           where c.CompanyName == companyNewName
                                           select c).ToList();

                // Delete customer added for test
                CustomerOperations.DeleteCustomer(testCustomer);

                Assert.AreEqual(companyNewName, getModifiedCustomer.FirstOrDefault().CompanyName, "Company name is not modified");
            }
        }
    }
}