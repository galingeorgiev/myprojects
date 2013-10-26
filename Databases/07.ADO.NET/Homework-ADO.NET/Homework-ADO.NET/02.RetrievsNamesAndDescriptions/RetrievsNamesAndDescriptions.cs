/* Write a program that retrieves the name and
 * description of all categories in the Northwind DB.
 * 
 * If you using express edition of sql server you 
 * must change connection string in settings file.
 */

namespace RetrievsNamesAndDescriptions
{
    using _02.RetrievsNamesAndDescriptions;
    using System;
    using System.Data.SqlClient;

    class RetrievsNamesAndDescriptions
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(SettingsConnection.Default.DBConnectionString);

            try
            {
                dbCon.Open();
                SqlCommand getRows = new SqlCommand("use NORTHWND select CategoryName, Description from Categories", dbCon);
                SqlDataReader reader = getRows.ExecuteReader();
                using (reader)
                {
                    Console.WriteLine("{0} {1}", "CategoryName".PadRight(15), "Description".PadRight(20));
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0} {1}", name.PadRight(15), description.PadRight(20));
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
