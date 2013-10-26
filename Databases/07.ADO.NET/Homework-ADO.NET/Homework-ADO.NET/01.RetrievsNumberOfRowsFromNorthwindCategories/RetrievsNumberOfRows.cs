/* Write a program that retrieves from the Northwind 
 * sample database in MS SQL Server the number of 
 * rows in the Categories table.
 * 
 * If you using express edition of sql server you 
 * must change connection string in settings file.
 */

namespace RetrievsNumberOfRowsFromNorthwindCategories
{
    using _01.RetrievsNumberOfRowsFromNorthwindCategories;
    using System;
    using System.Data.SqlClient;

    class RetrievsNumberOfRows
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(SettingsConnection.Default.DBConnectionString);

            try
            {
                dbCon.Open();
                SqlCommand getNumberOfRows = new SqlCommand("use NORTHWND select count(*) as count from Categories", dbCon);
                SqlDataReader reader = getNumberOfRows.ExecuteReader();
                using (reader)
                {
                    if (reader.Read())
                    {
                        int count = (int)reader["count"];
                        Console.WriteLine("Number of rows in table Categories is {0}", count);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{0}", ex);
            }
            finally
            {
                dbCon.Close();
            }
        }
    }
}
