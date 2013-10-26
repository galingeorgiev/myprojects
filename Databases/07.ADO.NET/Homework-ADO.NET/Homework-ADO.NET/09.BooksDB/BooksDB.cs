/* Download and install MySQL database, MySQL Connector/Net
 * (.NET Data Provider for MySQL) + MySQL Workbench GUI 
 * administration tool. Create a MySQL database to store 
 * Books (title, author, publish date and ISBN). Write 
 * methods for listing all books, finding a book by name 
 * and adding a book.
 */

namespace BooksDB
{
    using _09.BooksDB;
    using MySql.Data.MySqlClient;
    using System;

    class BooksDB
    {
        static void Main()
        {
            MySqlConnection conn = new MySqlConnection(SettingsConnection.Default.DBConnectionString);

            try
            {
                conn.Open();

                // Comment code below after creating DB 
                // In settings file you should type your password, now password is ????
                string queryCreateDBAndTable = "create database BooksDB;" +
                                               "use BooksDB;" +
                                               "create table Books" +
                                               "(" +
                                               "ID int auto_increment not null," +
                                               "Title varchar(50) not null," +
                                               "Author varchar(50) not null," +
                                               "PublishDate date null," +
                                               "ISBN int null," +
                                               "primary key (ID)" +
                                               ");";

                MySqlCommand cmdCreateDBAndTable = new MySqlCommand(queryCreateDBAndTable, conn);
                cmdCreateDBAndTable.ExecuteNonQuery();

                string queryInsertSomeBooks ="use BooksDB;" +
                                             "insert into Books (Title, Author, PublishDate, ISBN)" +
                                             "values ('Intro C#', 'Svetlin Nakov', '2013-07-10', 1234567)," +
                                             "('Intro Java', 'Nikolay Kostov', '2013-06-10', 2234567)," +
                                             "('Intro PHP', 'Petyr Petrov', '2013-05-10', 3234567)," +
                                             "('Intro JS', 'Ivan Ivanov', '2013-04-10', 4234567)," +
                                             "('Intro CSS', 'Donhco Minkov', '2013-03-10', 5234567)," +
                                             "('Intro HTML', 'George Georgiev', '2013-02-10', 6234567);";

                MySqlCommand cmdInsertSomeBooks = new MySqlCommand(queryInsertSomeBooks, conn);
                cmdInsertSomeBooks.ExecuteNonQuery();
                // Comment to here after creating DB 

                Console.WriteLine("List all books");
                ListBooks(conn);

                Console.WriteLine("\nSearch for book 'Intro C#'");
                FindBook(conn, "Intro C#");

                Console.WriteLine("\nAdd book");
                AddBook(conn, "TestBook", "TestAuthor", new DateTime(2012, 2, 28), 9876543);

                Console.WriteLine("\nList all books again");
                ListBooks(conn);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void ListBooks(MySqlConnection conn)
        {
            MySqlCommand getRows = new MySqlCommand("use BooksDB; select * from Books;",
                    conn);
            MySqlDataReader reader = getRows.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("\n{0} {1} {2} {3}", 
                    "Title".PadRight(15), "Author".PadRight(15), "Publish Date".PadRight(25), "ISBN".ToString().PadRight(10));
                while (reader.Read())
                {
                    string title = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    int isbn = (int)reader["ISBN"];
                    Console.WriteLine("{0} {1} {2} {3}", 
                        title.PadRight(15), author.PadRight(15), publishDate.ToString().PadRight(15), isbn.ToString().PadRight(10));
                }
            }
        }

        public static void FindBook(MySqlConnection conn, string searchingTitle)
        {
            MySqlCommand getRows = new MySqlCommand("use BooksDB; select * from Books where Title = @Title;",
                    conn);
            getRows.Parameters.AddWithValue("@Title", searchingTitle);
            MySqlDataReader reader = getRows.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("\n{0} {1} {2} {3}",
                    "Title".PadRight(15), "Author".PadRight(15), "Publish Date".PadRight(25), "ISBN".ToString().PadRight(10));
                while (reader.Read())
                {
                    string title = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    int isbn = (int)reader["ISBN"];
                    Console.WriteLine("{0} {1} {2} {3}",
                        title.PadRight(15), author.PadRight(15), publishDate.ToString().PadRight(15), isbn.ToString().PadRight(10));
                }
            }
        }

        public static void AddBook(MySqlConnection conn, string title, string author, DateTime publishDate, int isbn)
        {
            string queryInsertSomeBooks ="use BooksDB;" +
                                         "insert into Books (Title, Author, PublishDate, ISBN)" +
                                         "values (@Title, @Author, @PublishDate, @ISBN)";

            MySqlCommand getRows = new MySqlCommand(queryInsertSomeBooks, conn);
            getRows.Parameters.AddWithValue("@Title", title);
            getRows.Parameters.AddWithValue("@Author", author);
            getRows.Parameters.AddWithValue("@PublishDate", publishDate);
            getRows.Parameters.AddWithValue("@ISBN", isbn);

            getRows.ExecuteNonQuery();

            Console.WriteLine("(1 row(s) affected)");
        }
    }
}