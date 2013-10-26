/* Write a method that adds a new product in the
 * products table in the Northwind database. 
 * Use a parameterized SQL command.
 * 
 * If you using express edition of sql server you 
 * must change connection string in settings file.
 */

namespace AddProduct
{
    using _04.AddProduct;
    using System;
    using System.Data.SqlClient;

    class AddProduct
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(SettingsConnection.Default.DBConnectionString);

            try
            {
                dbCon.Open();
                SqlCommand addProduct = new SqlCommand("use NORTHWND" + 
                    " insert into Products(ProductName, SupplierID, CategoryID, QuantityPerUnit," + 
                    " UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)" +
                    " values (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit," + 
                    " @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)",
                    dbCon);
                addProduct.Parameters.AddWithValue("@ProductName", "TestInsertProduct");
                addProduct.Parameters.AddWithValue("@SupplierID", 1);
                addProduct.Parameters.AddWithValue("@CategoryID", 1);
                addProduct.Parameters.AddWithValue("@QuantityPerUnit", "10 boxes x 10 bags");
                addProduct.Parameters.AddWithValue("@UnitPrice", 10);
                addProduct.Parameters.AddWithValue("@UnitsInStock", 100);
                addProduct.Parameters.AddWithValue("@UnitsOnOrder", 0);
                addProduct.Parameters.AddWithValue("@ReorderLevel", 0);
                addProduct.Parameters.AddWithValue("@Discontinued", false);

                addProduct.ExecuteNonQuery();

                Console.WriteLine("(1 row(s) affected)");

                /* You cat test that row added in DB with whis query
                 * use NORTHWND
                 * select * from Products
                 * where ProductName = 'TestInsertProduct'
                 */
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
