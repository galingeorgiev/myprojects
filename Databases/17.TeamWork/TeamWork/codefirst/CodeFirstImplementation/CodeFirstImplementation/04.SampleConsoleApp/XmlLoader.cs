using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.EntityFramework.Model;
using _03.EntityFramework.Data;
using System.Xml.Linq;
using System.Globalization;

namespace _04.SampleConsoleApp
{
    public class XmlLoader
    {
        public static void ParseIntoMongo(VendorExpensesEntity entity)
        {
            var db = new MongoHelper<VendorExpensesEntity>();
            db.InsertData(entity);
        }

        public static void ParseIntoSqlServer(VendorExpensesEntity entity, NewEntitiesModel context)
        {
            MonthlyExpenseReport report = new MonthlyExpenseReport();
            report.Date = entity.Date;
            report.Expenses = entity.Expenses;

            int reportId = -1;
            if (context.MonthlyExpenseReports.Count() == 0)
            {
                reportId = 0;
            }
            else
            {
                reportId = context.MonthlyExpenseReports.Max(r => r.Id);
            }

            reportId++;
            report.Id = reportId;

            var vendor = context.Vendors.Where(
                                s => s.VendorName.Equals(entity.VendorName))
                                .FirstOrDefault();

            if (vendor == null)
            {
                vendor = new Vendor();
                vendor.VendorName = entity.VendorName;

                int biggestId = -1;
                if (context.Vendors.Count() == 0)
                {
                    biggestId = 0;
                }
                else
                {
                    biggestId = context.Vendors.Max(i => i.Id);
                }

                biggestId++;
                vendor.Id = biggestId;
                context.Vendors.Add(vendor);
                context.SaveChanges();
            }

            report.VendorId = vendor.Id;
            context.MonthlyExpenseReports.Add(report);
            context.SaveChanges();
        }

        public static void LoadDataFromXml(string xmlFilePath, NewEntitiesModel context)
        {
            XDocument document = XDocument.Load(xmlFilePath);
            var vendorSales = from sales in document.Descendants("sale")
                              select sales;

            foreach (var sale in vendorSales)
            {
                string vendorName = sale.Attribute("vendor").Value;
                var expenses = from expense in sale.Descendants("expenses")
                               select expense;

                foreach (var expense in expenses)
                {
                    VendorExpensesEntity entity = new VendorExpensesEntity();
                    entity.Expenses = decimal.Parse(expense.Value, CultureInfo.InvariantCulture);
                    entity.VendorName = vendorName;
                    string date = expense.Attribute("month").Value;
                    entity.Date = DateTime.Parse(date);
                    ParseIntoSqlServer(entity, context);
                    ParseIntoMongo(entity);
                }
            }
        }
    }
}
