using BookStore.Data;
using System;
using System.Linq;
using System.Xml;

namespace SearchInDb
{
    public class SearchInDb
    {
        public static void Main()
        {
            ProcessQuery();
        }

        private static void ProcessQuery()
        {
            XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("../../simple-query.xml");
            xmlDoc.Load("../../simple-query-one.xml");

            var queries = xmlDoc.SelectNodes("/query");

            using (var db = new BookStoreDBEntities())
            {
                foreach (XmlNode query in queries)
                {
                    string title = null;
                    if (query["title"] != null)
                    {
                        title = query["title"].InnerText.Trim();
                    }

                    string author = null;
                    if (query["author"] != null)
                    {
                        author = query["author"].InnerText.Trim();
                    }

                    string isbn = null;
                    if (query["isbn"] != null)
                    {
                        isbn = query["isbn"].InnerText.Trim();
                    }

                    SimpleSearch(db, title, author, isbn);
                }
            }
        }

        private static void SimpleSearch(BookStoreDBEntities db, string title, string author, string isbn)
        {
            var queryResults = from book in db.Books.Include("Authors")
                               select book;

            if (title != null)
            {
                queryResults = from b in queryResults
                               where b.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase)
                               select b;
            }

            if (author != null)
            {
                queryResults = from b in queryResults
                               where b.Authors.Any(a => a.AuthorName.Equals(author, StringComparison.OrdinalIgnoreCase))
                               select b;
            }

            if (isbn != null)
            {
                queryResults = from b in queryResults
                               where b.ISBN == isbn
                               select b;
            }

            if (queryResults.Count() == 0)
            {
                Console.WriteLine("Nothing found");
                return;
            }

            if (title == null && author == null && isbn == null)
            {
                Console.WriteLine("Nothing found");
                return;
            }

            queryResults = from b in queryResults
                           orderby b.BookTitle
                           select b;

            Console.WriteLine("{0} books found:", queryResults.Count());
            foreach (var book in queryResults)
            {
                string numberOfReviews = "No";

                if (book.Rewiews.Count() != 0)
                {
                    numberOfReviews = book.Rewiews.Count().ToString();
                }
                Console.WriteLine("{0} --> {1} reviews", book.BookTitle, numberOfReviews);
            }
        }
    }
}