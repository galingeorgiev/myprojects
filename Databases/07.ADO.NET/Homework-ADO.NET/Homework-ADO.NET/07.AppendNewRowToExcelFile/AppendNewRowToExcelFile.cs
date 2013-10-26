/* Implement appending new rows to the Excel file.
 * 
 * If you using express edition of sql server you 
 * must change connection string in settings file.
 */

namespace AppendNewRowToExcelFile
{
    using _07.AppendNewRowToExcelFile;
    using System;
    using System.Data.OleDb;
    
    class AppendNewRowToExcelFile
    {
        static void Main()
        {
            using (OleDbConnection conn = new OleDbConnection(SettingsConnection.Default.DBConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = "insert into [Sheet1$] (Name, Score) values (@Name, @Score)";
                    OleDbCommand cmdInsertRow = new OleDbCommand(query, conn);
                    cmdInsertRow.Parameters.AddWithValue("@Name", "Gosho Goshov");
                    cmdInsertRow.Parameters.AddWithValue("@Score", "50");

                    cmdInsertRow.ExecuteNonQuery();

                    Console.WriteLine("(1 row(s) affected)");
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
