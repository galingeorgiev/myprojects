/* Create a database holding users and groups. Create a 
 * transactional EF based method that creates an user 
 * and puts it in a group "Admins". In case the group 
 * "Admins" do not exist, create the group in the same
 * transaction. If some of the operations fail (e.g. 
 * the username already exist), cancel the entire 
 * transaction.
 */

namespace Task11.UsersAndGroups
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using UsersDB.Model;

    public class UsersAndGroups
    {
        public static void Main()
        {
            // Uncomment line below to create DB
            // Pleace change directiry path in method 'CreateDatabase'
            // and server name in 'CreateAndInitDB' method.
            //CreateAndInitDB();

            using (var db = new UsersDBEntities())
            {
                User adminUser = new User { FullName = "Svetlin Nakov" };

                var getAdminGroup = db.Groups.FirstOrDefault(g => g.GroupName == "Admin");

                if (getAdminGroup != null)
                {
                    adminUser.Group = getAdminGroup;
                    var checkUserExist = db.Users.Where(x => x == adminUser);
                    if (checkUserExist == null)
                    {
                        db.Users.Add(adminUser);
                        db.SaveChanges();
                        Console.WriteLine("User is added to group 'Admin'");
                    }
                }
                else
                {
                    Group adminGroup = new Group { GroupName = "Admin" };
                    db.Groups.Add(adminGroup);
                    db.SaveChanges();
                    Console.WriteLine("Group 'Admin' is created and added to DB.");

                    var adminGroupFromDB = db.Groups.FirstOrDefault(g => g.GroupName == "Admin");
                    adminUser.Group = adminGroupFromDB;

                    var checkUserExist = db.Users.Where(x => x == adminUser);
                    if (checkUserExist == null)
                    {
                        db.Users.Add(adminUser);
                        db.SaveChanges();
                        Console.WriteLine("User is added to group 'Admin'");
                    }
                }
            }
        }

        public static void CreateDatabase(SqlConnection connection)
        {
            string query = "CREATE DATABASE UsersDB ON PRIMARY " +
                           "(NAME = UsersDB, " +
                           @"FILENAME = 'D:\Telerik Academy\Telerik\Databases\08.Entity-Framework\Homework-Entity-Framework\Homework-Entity-Framework\Task11.UsersAndGroups\UsersDB.mdf', " +
                           "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                           "LOG ON (NAME = MyDatabase_Log, " +
                           @"FILENAME = 'D:\Telerik Academy\Telerik\Databases\08.Entity-Framework\Homework-Entity-Framework\Homework-Entity-Framework\Task11.UsersAndGroups\UsersDB.ldf', " +
                           "SIZE = 1MB, " +
                           "MAXSIZE = 5MB, " +
                           "FILEGROWTH = 10%)";

            CommandExecutor(query, connection);
        }

        public static void CreateTables(SqlConnection connection)
        {
            string query = "use UsersDB" +
                           " create table Groups" +
                           " (" +
                           " GroupId int primary key identity(1, 1) not null," +
                           " GroupName nvarchar(50) null" +
                           " )" +
                           " use UsersDB" +
                           " create table Users" +
                           " (" +
                           " UserId int primary key identity(1, 1) not null," +
                           " FullName nvarchar(50) null," +
                           " GroupId int null foreign key (GroupId) references Groups (GroupId)" +
                           " )";

            CommandExecutor(query, connection);
        }

        public static void AddAdminGroup(SqlConnection connection)
        {
            string query = "use UsersDB" +
                           " insert into Groups (GroupName)" +
                           " values ('Admin')";

            CommandExecutor(query, connection);
        }

        public static void CommandExecutor(string query, SqlConnection connection)
        {
            SqlCommand myCommand = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void CreateAndInitDB()
        {
            SqlConnection connection = 
                new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");
            CreateDatabase(connection);
            CreateTables(connection);
            AddAdminGroup(connection);
        }
    }
}

//use UsersDB
//create table Groups
//(
//GroupId int primary key identity(1, 1) not null,
//GroupName nvarchar(50) null
//)

//create table Users
//(
//UserId int primary key identity(1, 1) not null,
//FullName nvarchar(50) null,
//GroupId int null foreign key (GroupId) references Groups (GroupId)
//)
//GO
//insert into Groups (GroupName)
//values (Admin)
//GO