/* Write a program that retrieves the images for
 * all categories in the Northwind database and
 * stores them as JPG files in the file system.
 * 
 * If you using express edition of sql server you 
 * must change connection string in settings file.
 */

namespace ReadDataFromExcelFile
{
    using _06.ReadDataFromExcelFile;
    using System;
    using System.Data.OleDb;

    class ReadDataFromExcelFile
    {
        static void Main()
        {
            using (OleDbConnection conn = new OleDbConnection(SettingsConnection.Default.DBConnectionString))
            {
                conn.Open();
                string query = "SELECT * from [Sheet1$]";
                OleDbCommand cmdReadData = new OleDbCommand(query, conn);
                try
                {
                    OleDbDataReader dataReader = cmdReadData.ExecuteReader();
                    Console.WriteLine("{0} {1}", "Name".PadRight(20), "Score".PadRight(20));
                    while (dataReader.Read())
                    {
                        string name = (string)dataReader["Name"];
                        double score = (double)dataReader["Score"];
                        Console.WriteLine("{0} {1}", name.PadRight(20), score.ToString().PadRight(20));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("{0}", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
