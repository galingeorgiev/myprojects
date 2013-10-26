/* Write a program that retrieves from the Northwind 
 * database all product categories and the names of
 * the products in each category. Can you do this 
 * with a single SQL query (with table join)?
 * 
 * If you using express edition of sql server you 
 * must change connection string in settings file.
 */

namespace CategoryAndProductNames
{
    using _03.CategoryAndProductNames;
    using System;
    using System.Data.SqlClient;

    class CategoryAndProductNames
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(SettingsConnection.Default.DBConnectionString);

            try
            {
                dbCon.Open();
                SqlCommand getRows = new SqlCommand("use NORTHWND select c.CategoryName," +
                    " p.ProductName from Categories c join Products p" + 
                    " on p.CategoryID = c.CategoryID" +
                    " order by c.CategoryName",
                    dbCon);
                SqlDataReader reader = getRows.ExecuteReader();
                using (reader)
                {
                    Console.WriteLine("{0} {1}", "CategoryName".PadRight(15), "ProductName".PadRight(20));
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["ProductName"];
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
