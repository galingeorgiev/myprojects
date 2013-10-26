/* Write a program that reads a string from the 
 * console and finds all products that contain 
 * this string. Ensure you handle correctly 
 * characters like ', %, ", \ and _.
 * 
 * If you using express edition of sql server you 
 * must change connection string in settings file.
 */

namespace SearchProductsByName
{
    using _08.SearchProductsByName;
    using System;
    using System.Data.SqlClient;

    class SearchProductsByName
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(SettingsConnection.Default.DBConnectionString);

            try
            {
                dbCon.Open();
                SqlCommand getRows = new SqlCommand("use NORTHWND" + 
                    " select ProductName" + 
                    " from Products p" + 
                    " where p.ProductName like @patern",
                    dbCon);

                Console.WriteLine("Enter serching criteria: ");
                string searchingCriteria = Console.ReadLine();
                searchingCriteria = searchingCriteria.Replace("\\", "\\\\");
                searchingCriteria = searchingCriteria.Replace("%", "\\%");
                searchingCriteria = searchingCriteria.Replace("_", "\\_");
                searchingCriteria = searchingCriteria.Replace("'", "\\'");
                searchingCriteria = searchingCriteria.Replace("\"", "\\\"");

                string patern = "%" + searchingCriteria + "%";

                getRows.Parameters.AddWithValue("@patern", patern);

                SqlDataReader reader = getRows.ExecuteReader();
                using (reader)
                {
                    Console.WriteLine("\n{0}", "ProductName".PadRight(20));
                    while (reader.Read())
                    {
                        string name = (string)reader["ProductName"];
                        Console.WriteLine("{0}", name.PadRight(15));
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
