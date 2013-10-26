/* Create a database called NorthwindTwin with the 
 * same structure as Northwind using the features 
 * from DbContext. Find for the API for schema 
 * generation in MSDN or in Google.
 */

namespace Task06.CreateNorthwindTwinDB
{
    using NorthwindEFModel;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;

    public class CreateNorthwindTwinDB
    {
        public static void Main()
        {
            IObjectContextAdapter db = new NORTHWNDEntities();
            string cloneNorthwind = db.ObjectContext.CreateDatabaseScript();

            // You can change .mdf and .ldf directory
            string createNorthwindCloneDB = "CREATE DATABASE NorthwindTwin ON PRIMARY " +
            "(NAME = NorthwindTwin, " +
            @"FILENAME = 'D:\Telerik Academy\Telerik\Databases\08.Entity-Framework\Homework-Entity-Framework\Homework-Entity-Framework\Task06.CreateNorthwindTwinDB\NorthwindTwin.mdf', " +
            "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
            "LOG ON (NAME = NorthwindTwinLog, " +
            @"FILENAME = 'D:\Telerik Academy\Telerik\Databases\08.Entity-Framework\Homework-Entity-Framework\Homework-Entity-Framework\Task06.CreateNorthwindTwinDB\NorthwindTwin.ldf', " +
            "SIZE = 1MB, " +
            "MAXSIZE = 5MB, " +
            "FILEGROWTH = 10%)";

            SqlConnection dbConForCreatingDB = new SqlConnection(
                "Server=LOCALHOST; " +
                "Database=master; " +
                "Integrated Security=true");

            dbConForCreatingDB.Open();

            using (dbConForCreatingDB)
            {
                SqlCommand createDB = new SqlCommand(createNorthwindCloneDB, dbConForCreatingDB);
                createDB.ExecuteNonQuery();
            }

            SqlConnection dbConForCloning = new SqlConnection(
                "Server=LOCALHOST; " +
                "Database=NorthwindTwin; " +
                "Integrated Security=true");

            dbConForCloning.Open();

            using (dbConForCloning)
            {
                SqlCommand cloneDB = new SqlCommand(cloneNorthwind, dbConForCloning);
                cloneDB.ExecuteNonQuery();
            }
        }
    }
}
