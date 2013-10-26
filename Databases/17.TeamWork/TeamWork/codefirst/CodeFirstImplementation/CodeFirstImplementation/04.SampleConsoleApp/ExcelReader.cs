using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.EntityFramework.Model;
using _03.EntityFramework.Data;
using Ionic.Zip;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Data.Entity;
using System.Xml.Linq;
using System.Globalization;

namespace _04.SampleConsoleApp
{
    public static class ExcelReader
    {
        private static string zipDirectory = @"../../../TempExtractedFiles";

        public static void ParseZip(string zipPath, NewEntitiesModel context)
        {
            ZipHelper.ExtractEntriesFromZip(zipPath, zipDirectory);
            ParseExcelFiles(zipDirectory, context);
        }

        public static void ParseExcelFiles(string directoryPath, NewEntitiesModel context)
        {
            var directories = Directory.GetDirectories(directoryPath);
            foreach (var directory in directories)
            {
                var files = Directory.GetFiles(directory);
                DateTime date = DateTime.Parse(Path.GetFileName(directory), CultureInfo.InvariantCulture);


                foreach (var file in files)
                {
                    GenerateReportsFromExcel(file, context, date);
                }
            }
        }

        public static void GenerateReportsFromExcel(string excelFilePath, NewEntitiesModel context, DateTime date)
        {
            string excelConnectionString = @"Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + excelFilePath + @";Extended Properties=""Excel 8.0;HDR=YES;IMEX=1""";
            using (OleDbConnection excelConnection = new OleDbConnection(excelConnectionString))
            {
                excelConnection.Open();

                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sales$]", excelConnection);
                OleDbDataReader reader = command.ExecuteReader();

                string[] serviceInfo = new string[5];

                using (reader)
                {
                    int counter = 0;

                    while (reader.Read())
                    {
                        if (counter == 5)
                        {
                            break;
                        }

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (!(reader[i] is DBNull))
                            {
                                serviceInfo[counter] = reader[i].ToString();
                                counter++;
                            }
                        }
                    }

                    int nestedCounter = 0;
                    string[] currentArguments = new string[4];

                    do
                    {
                        nestedCounter = 0;
                        bool isEnd = false;
                        bool isChecked = false;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (!(reader[i] is DBNull))
                            {
                                if (!isChecked)
                                {
                                    isChecked = true;

                                    if (reader[i].ToString().StartsWith("Total sum"))
                                    {
                                        isEnd = true;
                                        break;
                                    }
                                }

                                currentArguments[nestedCounter] = reader[i].ToString();
                                nestedCounter++;

                                if (nestedCounter == 4)
                                {
                                    WriteToDatabase(serviceInfo[0], currentArguments, context, date);
                                }
                            }
                        }

                        if (isEnd)
                        {
                            break;
                        }
                    }
                    while (reader.Read());

                    reader.Close();
                }
            }
        }

        private static void WriteToDatabase(string supermarketName, string[] currentArguments, NewEntitiesModel context, DateTime date)
        {
            Report generatedReport = new Report();

            generatedReport.ProductId = int.Parse(currentArguments[0]);
            generatedReport.Quantity = decimal.Parse(currentArguments[1]);
            generatedReport.UnitPrice = decimal.Parse(currentArguments[2]);
            generatedReport.Sum = decimal.Parse(currentArguments[3]);
            generatedReport.Date = date;

            int reportId = -1;
            if (context.Reports.Count() == 0)
            {
                reportId = 0;
            }
            else
            {
                reportId = context.Reports.Max(r => r.Id);
            }

            reportId++;

            generatedReport.Id = reportId;

            var supermarket = context.Supermarkets.Where(
                                s => s.SupermarketName.Equals(supermarketName))
                                .FirstOrDefault();

            if (supermarket == null)
            {
                supermarket = new Supermarket();
                supermarket.SupermarketName = supermarketName;

                int biggestId = -1;
                if (context.Supermarkets.Count() == 0)
                {
                    biggestId = 0;
                }
                else
                {
                    biggestId = context.Supermarkets.Max(i => i.Id);
                }

                biggestId++;
                supermarket.Id = biggestId;
                context.Supermarkets.Add(supermarket);
                context.SaveChanges();
            }

            generatedReport.SupermarketId = supermarket.Id;
            context.Reports.Add(generatedReport);
            context.SaveChanges();
        }
    }
}
