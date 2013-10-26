using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.OpenAccessDatabase;
using SqlServer = _02.EntityFramework.Model;
using _03.EntityFramework.Data;

namespace _04.SampleConsoleApp
{
    public static class DatabaseMover
    {
        public static void MoveDatabase()
        {
            using (OldEntitiesModel context = new OldEntitiesModel())
            {
                using (NewEntitiesModel newContext = new NewEntitiesModel())
                {
                    foreach (var product in context.Products)
                    {
                        SqlServer.Product newProduct = new SqlServer.Product();
                        newProduct.Id = product.Id;
                        newProduct.BasePrice = product.BasePrice;
                        newProduct.ProductName = product.ProductName;
                        newContext.Products.Add(newProduct);
                        newContext.SaveChanges();
                    }

                    foreach (var vendor in context.Vendors)
                    {
                        SqlServer.Vendor newVendor = new SqlServer.Vendor();
                        newVendor.Id = vendor.Id;
                        newVendor.VendorName = vendor.VendorName;
                        foreach (var product in vendor.Products)
                        {
                            var productToAdd = newContext.Products.Where(
                                p => p.Id.Equals(product.Id))
                                .FirstOrDefault();
                            if (productToAdd != null)
                            {
                                newVendor.Products.Add(productToAdd);
                            }
                        }

                        newContext.Vendors.Add(newVendor);
                        newContext.SaveChanges();
                    }

                    foreach (var measure in context.Measures)
                    {
                        SqlServer.Measure newMeasure = new SqlServer.Measure();
                        newMeasure.Id = measure.Id;
                        newMeasure.MeasureName = measure.MeasureName;
                        foreach (var product in measure.Products)
                        {
                            var productToAdd = newContext.Products.Where(
                                p => p.Id.Equals(product.Id))
                                .FirstOrDefault();
                            if (productToAdd != null)
                            {
                                newMeasure.Products.Add(productToAdd);
                            }
                        }

                        newContext.Measures.Add(newMeasure);
                        newContext.SaveChanges();
                    }
                }
            }
        }
    }
}
