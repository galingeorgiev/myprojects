using BookStore.Data;
using Logs.Client;
using Logs.Data;
using Logs.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;

namespace WriteXmlFile
{
    public class WriteXmlFile
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LogContext, Configuration>());
            ProcessQueries();
        }

        private static void ProcessQueries()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../reviews-queries.xml");

            var queries = xmlDoc.DocumentElement.ChildNodes;

            using (XmlTextWriter writer = new XmlTextWriter("../../search-results.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                using (var db = new BookStoreDBEntities())
                {
                    foreach (XmlNode query in queries)
                    {
                        writer.WriteStartElement("result-set");

                        var queryType = query.Attributes["type"].Value.Trim();

                        if (queryType == "by-period")
                        {
                            DateTime startDate = DateTime.Parse(query["start-date"].InnerText.Trim().ToString());
                            DateTime endDate = DateTime.Parse(query["end-date"].InnerText.Trim());
                            AddInXmlSearchsByDate(db, writer, startDate, endDate);
                        }
                        else if (queryType == "by-author")
                        {
                            string author = query["author-name"].InnerText.Trim();
                            AddInXmlSearchByAuthor(db, writer, author);
                        }

                        writer.WriteEndElement();

                        // Write log in Db
                        LogsWriter.Writer(query.OuterXml);
                    }

                    writer.WriteEndElement();
                }
            }
        }

        private static void AddInXmlSearchByAuthor(BookStoreDBEntities db, XmlTextWriter writer, string author)
        {
            var searchResults = (from rev in db.Rewiews.Include("Author").Include("Books")
                                where rev.Author.AuthorName == author
                                orderby rev.RewiewDate
                                select rev).ToList();

            XmlWriter(writer, searchResults);
        }

        private static void AddInXmlSearchsByDate(BookStoreDBEntities db, XmlTextWriter writer, DateTime startDate, DateTime endDate)
        {
            var searchResults = (from rev in db.Rewiews.Include("Author").Include("Books")
                               where rev.RewiewDate >= startDate && rev.RewiewDate <= endDate
                               select rev).ToList();

            XmlWriter(writer, searchResults);
        }

        private static void XmlWriter(XmlTextWriter writer, List<Rewiew> searchResults)
        {
            CultureInfo culture = new CultureInfo("en-US");

            foreach (var review in searchResults)
            {
                writer.WriteStartElement("review");

                if (review.RewiewDate != null)
                {
                    writer.WriteElementString("date", string.Format(culture, "{0: dd-MMM-yyyy}", review.RewiewDate, CultureInfo.InvariantCulture));
                }

                if (review.RewiewText != null)
                {
                    writer.WriteElementString("content", review.RewiewText);
                }

                writer.WriteStartElement("book");

                if (review.Books.Count() != 0)
                {
                    foreach (var book in review.Books)
                    {
                        if (book.BookTitle != null)
                        {
                            writer.WriteElementString("title", book.BookTitle);
                        }

                        if (book.Authors.Count() != 0)
                        {
                            IEnumerable<Author> orderedResults = book.Authors.OrderBy(a => a.AuthorName).ToList();

                            StringBuilder resultStr = new StringBuilder();
                            foreach (var authorName in orderedResults)
                            {
                                resultStr.Append(authorName.AuthorName);
                                resultStr.Append(", ");
                            }

                            resultStr.Length = resultStr.Length - 2;

                            writer.WriteElementString("authors", resultStr.ToString());
                        }

                        if (book.ISBN != null)
                        {
                            writer.WriteElementString("isbn", book.ISBN);
                        }

                        if (book.WebSite != null)
                        {
                            writer.WriteElementString("url", book.WebSite);
                        }
                    }
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }
}