/* Download and install MySQL database, MySQL 
 * Connector/Net (.NET Data Provider for MySQL) 
 * + MySQL Workbench GUI administration tool. 
 * Create a MySQL database to store Books 
 * (title, author, publish date and ISBN). Write 
 * methods for listing all books, finding a book
 * by name and adding a book.
 * 
 * Re-implement the previous task with SQLite
 * embedded DB (see http://sqlite.phxsoftware.com).
 */


namespace BooksDBSQLite
{
    using _10.BooksDBSQLite;
    using System;
    using System.Data.SQLite;

    class BooksDBSQLite
    {
        static void Main()
        {
            SQLiteConnection conn = new SQLiteConnection(SettingsConnection.Default.DBConnectionString);

            try
            {
                conn.Open();

                // Comment code below after creating DB 
                string queryCreateDBAndTable = "create table Books" +
                                               "(" +
                                               "ID integer not null," +
                                               "Title varchar(50) not null," +
                                               "Author varchar(50) not null," +
                                               "PublishDate date null," +
                                               "ISBN integer null," +
                                               "primary key (ID)" +
                                               ");";

                SQLiteCommand cmdCreateDBAndTable = new SQLiteCommand(queryCreateDBAndTable, conn);
                cmdCreateDBAndTable.ExecuteNonQuery();

                string queryInsertSomeBooks = "insert into Books (Title, Author, PublishDate, ISBN)" +
                                             " values ('Intro C#', 'Svetlin Nakov', '2013-07-10', 1234567)," +
                                             "('Intro Java', 'Nikolay Kostov', '2013-06-10', 2234567)," +
                                             "('Intro PHP', 'Petyr Petrov', '2013-05-10', 3234567)," +
                                             "('Intro JS', 'Ivan Ivanov', '2013-04-10', 4234567)," +
                                             "('Intro CSS', 'Donhco Minkov', '2013-03-10', 5234567)," +
                                             "('Intro HTML', 'George Georgiev', '2013-02-10', 6234567);";

                SQLiteCommand cmdInsertSomeBooks = new SQLiteCommand(queryInsertSomeBooks, conn);
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

        public static void ListBooks(SQLiteConnection conn)
        {
            SQLiteCommand getRows = new SQLiteCommand("select * from Books;",
                    conn);
            SQLiteDataReader reader = getRows.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("\n{0} {1} {2} {3}",
                    "Title".PadRight(15), "Author".PadRight(15), "Publish Date".PadRight(25), "ISBN".ToString().PadRight(10));
                while (reader.Read())
                {
                    string title = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    long isbn = (long)reader["ISBN"];
                    Console.WriteLine("{0} {1} {2} {3}",
                        title.PadRight(15), author.PadRight(15), publishDate.ToString().PadRight(15), isbn.ToString().PadRight(10));
                }
            }
        }

        public static void FindBook(SQLiteConnection conn, string searchingTitle)
        {
            SQLiteCommand getRows = new SQLiteCommand("select * from Books where Title = @Title;",
                    conn);
            getRows.Parameters.AddWithValue("@Title", searchingTitle);
            SQLiteDataReader reader = getRows.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("\n{0} {1} {2} {3}",
                    "Title".PadRight(15), "Author".PadRight(15), "Publish Date".PadRight(25), "ISBN".ToString().PadRight(10));
                while (reader.Read())
                {
                    string title = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    long isbn = (long)reader["ISBN"];
                    Console.WriteLine("{0} {1} {2} {3}",
                        title.PadRight(15), author.PadRight(15), publishDate.ToString().PadRight(15), isbn.ToString().PadRight(10));
                }
            }
        }

        public static void AddBook(SQLiteConnection conn, string title, string author, DateTime publishDate, int isbn)
        {
            string queryInsertSomeBooks = "insert into Books (Title, Author, PublishDate, ISBN)" +
                                         "values (@Title, @Author, @PublishDate, @ISBN)";

            SQLiteCommand getRows = new SQLiteCommand(queryInsertSomeBooks, conn);
            getRows.Parameters.AddWithValue("@Title", title);
            getRows.Parameters.AddWithValue("@Author", author);
            getRows.Parameters.AddWithValue("@PublishDate", publishDate);
            getRows.Parameters.AddWithValue("@ISBN", isbn);

            getRows.ExecuteNonQuery();

            Console.WriteLine("(1 row(s) affected)");
        }
    }
}
