namespace _04.SampleConsoleApp
{
    using _02.EntityFramework.Model;
    using _03.EntityFramework.Data;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public static class PdfGenerator
    {
        public static void GenerateReport()
        {
            Document pdfDocument = new Document(PageSize.A4, 10, 10, 10, 10);
            PdfWriter writer = PdfWriter.GetInstance(pdfDocument, new FileStream("../../../GeneratedReports/TestPdf.pdf", FileMode.Create));
            pdfDocument.Open();

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font fontStyle = new Font(bfTimes, 10, Font.NORMAL, BaseColor.BLACK);

            PdfPTable table = new PdfPTable(5);
            table.SetWidths(new int[] { 50, 30, 30, 80, 20 });
            var header = new PdfPCell(new Phrase("Aggregated Sales Report", fontStyle));
            header.Colspan = 5;
            header.HorizontalAlignment = Element.ALIGN_CENTER;
            header.VerticalAlignment = Element.ALIGN_MIDDLE;
            header.FixedHeight = 30f;
            table.AddCell(header);



            using (var db = new NewEntitiesModel())
            {
                var uniqueDates = (from dateReports in db.Reports
                                   select dateReports.Date).Distinct().ToList();

                foreach (var date in uniqueDates)
                {
                    var dailyReport = (from report in db.Reports
                                      join product in db.Products
                                      on report.ProductId equals product.Id
                                      join measures in db.Measures
                                      on product.MeasureId equals measures.Id
                                      join supermarket in db.Supermarkets
                                      on report.SupermarketId equals supermarket.Id
                                      where report.Date == date.Value
                                      select new
                                      {
                                          ProductName = product.ProductName,
                                          Quantity = report.Quantity,
                                          MeasureName = measures.MeasureName,
                                          UnitPrice = report.UnitPrice,
                                          Location = supermarket.SupermarketName,
                                          Sum = report.Sum
                                      }).ToList();

                    AddTableHeader(table, DateTime.Parse(date.ToString()), fontStyle);

                    foreach (var reportRow in dailyReport)
                    {
                        table.AddCell(new Phrase(reportRow.ProductName, fontStyle));

                        table.AddCell(
                            new Phrase(
                                (string.Format("{0:f0}", double.Parse(reportRow.Quantity.ToString()) + " " + reportRow.MeasureName)),
                                fontStyle));

                        table.AddCell(
                            new Phrase((string.Format("{0:f2}", double.Parse(reportRow.UnitPrice.ToString()))),
                                fontStyle));

                        table.AddCell(new Phrase(reportRow.Location, fontStyle));

                        var c5 = new PdfPCell(new Phrase((string.Format("{0:f2}", double.Parse(reportRow.Sum.ToString()))), fontStyle));
                        c5.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(c5);
                    }

                    AddTableFooter(table, DateTime.Parse(date.ToString()), fontStyle, db);
                }

                pdfDocument.Add(table);
                pdfDocument.Close();
                writer.Close();
            }
        }

        private static void AddTableHeader(PdfPTable table, DateTime date, Font fontStyle)
        {
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font boldFontStyle = new Font(bfTimes, 10, Font.BOLD, BaseColor.BLACK);

            var subHeader = new PdfPCell(new Phrase("Date: " + date.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture), fontStyle));
            subHeader.Colspan = 5;
            subHeader.HorizontalAlignment = Element.ALIGN_LEFT;
            subHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            subHeader.FixedHeight = 20f;
            subHeader.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(subHeader);

            var c1 = new PdfPCell(new Phrase("Product", boldFontStyle));
            c1.BackgroundColor = BaseColor.LIGHT_GRAY;
            c1.VerticalAlignment = Element.ALIGN_MIDDLE;
            c1.Padding = 10f;
            table.AddCell(c1);

            var c2 = new PdfPCell(new Phrase("Quantity", boldFontStyle));
            c2.BackgroundColor = BaseColor.LIGHT_GRAY;
            c2.VerticalAlignment = Element.ALIGN_MIDDLE;
            c2.Padding = 10f;
            table.AddCell(c2);

            var c3 = new PdfPCell(new Phrase("Unit Price", boldFontStyle));
            c3.BackgroundColor = BaseColor.LIGHT_GRAY;
            c3.VerticalAlignment = Element.ALIGN_MIDDLE;
            c3.Padding = 10f;
            table.AddCell(c3);

            var c4 = new PdfPCell(new Phrase("Location", boldFontStyle));
            c4.BackgroundColor = BaseColor.LIGHT_GRAY;
            c4.VerticalAlignment = Element.ALIGN_MIDDLE;
            c4.Padding = 10f;
            table.AddCell(c4);

            var c5 = new PdfPCell(new Phrase("Sum", boldFontStyle));
            c5.BackgroundColor = BaseColor.LIGHT_GRAY;
            c5.VerticalAlignment = Element.ALIGN_MIDDLE;
            c5.Padding = 10f;
            table.AddCell(c5);
        }

        private static void AddTableFooter(PdfPTable table, DateTime date, Font fontStyle, NewEntitiesModel db)
        {
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font boldFontStyle = new Font(bfTimes, 10, Font.BOLD, BaseColor.BLACK);

            var footer = new PdfPCell(new Phrase("Total sum for " +
                date.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture) +
                ": ", fontStyle));

            footer.Colspan = 4;
            footer.HorizontalAlignment = Element.ALIGN_RIGHT;
            footer.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(footer);

            var dailySum = (from reports in db.Reports
                            where reports.Date == date
                            select reports.Sum).Sum();

            var totalSum = new PdfPCell(
                new Phrase((string.Format("{0:f2}", double.Parse(dailySum.ToString()))),
                    boldFontStyle));
            totalSum.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(totalSum);
        }
    }
}
