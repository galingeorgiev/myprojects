using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.EntityFramework.Model;
using _03.EntityFramework.Data;

namespace _04.SampleConsoleApp
{
    public static class JSONWriter
    {
        public static void WriteJSON(NewEntitiesModel context)
        {
           /*var productVendors = from product in context.Products.Include("Vendor")
                                 join vendor in context.Vendors
                                 on product.VendorId equals vendor.Id
                                 select new
                                 {
                                     ProductId = product.Id,
                                     ProductName = product.ProductName,
                                     VendorName = vendor.VendorName
                                 };

            var productReports = from product in productVendors
                                 join report in context.Reports
                                 on product.ProductId equals report.ProductId
                                 select new
                                 {
                                     ProductId = product.ProductId,
                                     ProductName = product.ProductName,
                                     VendorName = product.VendorName,
                                     Quantity = report.Quantity,
                                     Sum = report.Sum
                                 } into anon
                                 orderby anon.ProductId
                                 select anon;

            foreach (var product in productReports)
            {
                Console.WriteLine("{0}.{1} by {2} sold {3} for {4}", product.ProductId, product.ProductName, product.VendorName,
                    product.Quantity, product.Sum);
            }*/

            /*foreach (var product in context.Products.Include("Vendor").Include("Reports"))
            {
                int productId = product.Id;
                string vendorName = product.Vendor.VendorName;
                string productName = product.ProductName;
                decimal quantity = 0;
                decimal sum = 0;
                foreach (var report in product.Reports)
                {
                    quantity += report.Quantity.Value;
                    sum += report.Sum.Value;
                }

                Console.WriteLine(productId + " : " + vendorName + " : " + productName + " : " + quantity + " : " + sum);
            }*/
        }
    }
}
