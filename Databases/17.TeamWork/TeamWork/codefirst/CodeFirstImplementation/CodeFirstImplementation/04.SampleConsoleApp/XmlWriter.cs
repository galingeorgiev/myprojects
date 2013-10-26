using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.EntityFramework.Model;
using _03.EntityFramework.Data;
using System.Xml.Linq;
using System.Xml;
using System.Globalization;

namespace _04.SampleConsoleApp
{
    public static class XmlWriter
    {
        // TODO: Change path
        private static string xmlFilePath = @"../../../GeneratedReports/sample.xml";

        private static Encoding encoding = Encoding.GetEncoding("utf-8");

        public static void CreateXmlReport(NewEntitiesModel context)
        {
            var vendorProducts = from vendor in context.Vendors
                                join product in context.Products
                                on vendor.Id equals product.VendorId
                                select new
                                {
                                    ProductId = product.Id,
                                    VendorName = vendor.VendorName
                                };

            var vendorReports = from vendor in vendorProducts
                                join report in context.Reports
                                on vendor.ProductId equals report.ProductId
                                select new
                                {
                                    VendorName = vendor.VendorName,
                                    date = report.Date,
                                    sum = report.Sum
                                } into anon
                                orderby anon.VendorName, anon.date
                                select anon;

            /*foreach (var report in vendorReports)
            {
                Console.WriteLine("{0} : {1} : {2}", report.VendorName, report.date, report.sum);
            }*/

            using (XmlTextWriter writer = new XmlTextWriter(xmlFilePath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("Sales");

                string currentVendor = string.Empty;
                DateTime currentDate = new DateTime(1950, 11, 11);
                bool isStartedDocumentGlobal = false;
                decimal currentSum = 0;

                foreach (var report in vendorReports)
                {
                    if (report.VendorName != currentVendor)
                    {
                        if (isStartedDocumentGlobal)
                        {
                            writer.WriteStartElement("summary");
                            string dateString = currentDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                            writer.WriteAttributeString("date", dateString);
                            writer.WriteAttributeString("total-sum", string.Format("{0:0.00}", currentSum));
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                        else
                        {
                            isStartedDocumentGlobal = true;
                        }

                        writer.WriteStartElement("sale");
                        writer.WriteAttributeString("vendor", report.VendorName);
                        currentVendor = report.VendorName;
                        currentSum = 0;
                        currentDate = report.date.Value;
                    }

                    if ((currentDate.Year != report.date.Value.Year) || (currentDate.Month != report.date.Value.Month)
                        || (currentDate.Day != report.date.Value.Day))
                    {
                        writer.WriteStartElement("summary");
                        string dateString = currentDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                        writer.WriteAttributeString("date", dateString);
                        writer.WriteAttributeString("total-sum", string.Format("{0:0.00}", currentSum));
                        writer.WriteEndElement();

                        currentSum = report.sum.Value;
                        currentDate = report.date.Value;
                    }
                    else
                    {
                        currentSum += report.sum.Value;
                    }
                }

                writer.WriteStartElement("summary");
                string dataString = currentDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                writer.WriteAttributeString("date", dataString);
                writer.WriteAttributeString("total-sum", string.Format("{0:0.00}", currentSum));
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Close();
            }
        }
    }
}