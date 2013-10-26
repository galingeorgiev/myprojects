using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.EntityFramework.Model;
using _03.EntityFramework.Data;
using System.Globalization;

namespace _04.SampleConsoleApp
{
    public class ConsoleApp
    {
        static void Main()
        {
            //DatabaseMover.MoveDatabase();

            //using (NewEntitiesModel context = new NewEntitiesModel())
            //{
            //    ExcelReader.ParseZip(@"../../../ZIPs/Sample-Sales-Reports.zip", context);
            //}

            //PdfGenerator.GenerateReport();

            //using (NewEntitiesModel context = new NewEntitiesModel())
            //{
            //    XmlLoader.LoadDataFromXml(@"../../../ZIPs/Vendor-Expenses.xml", context);
            //}

            using (NewEntitiesModel context = new NewEntitiesModel())
            {
                XmlWriter.CreateXmlReport(context);
            }

            ///*DateTime currentDate = DateTime.Now;
            //Console.WriteLine(currentDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)); currentDate.ToString("dd-mm-yyyy", CultureInfo.InvariantCulture);

            //decimal number = 1455.8m;
            //Console.WriteLine(string.Format("{0:0.00}", number));*/

            //using (NewEntitiesModel context = new NewEntitiesModel())
            //{
            //    JSONWriter.WriteJSON(context);
            //}

            
        }
    }
}
