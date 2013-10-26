using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Transactions;
using System.Xml;

namespace ImportFromXmlToDb
{
    public class ImportFromXmlToDb
    {
        public static void Main()
        {
            ParseXml();
            ParseComplexXml();
        }

        private static void ParseXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-books.xml");

            var books = xmlDoc.DocumentElement.ChildNodes;

            TransactionScope tran = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.RepeatableRead
                });
            using (tran)
            {
                using (var db = new BookStoreDBEntities())
                {
                    foreach (XmlNode book in books)
                    {
                        string author = book["author"].InnerText.Trim();

                        string title = book["title"].InnerText.Trim();

                        string isbn = null;

                        if (book.SelectSingleNode("isbn") != null)
                        {
                            isbn = book["isbn"].InnerText.Trim();
                        }

                        decimal price = 0m;

                        if (book.SelectSingleNode("price") != null)
                        {
                            price = decimal.Parse(book["price"].InnerText.Trim(), CultureInfo.InvariantCulture);
                        }

                        string webSite = null;

                        if (book.SelectSingleNode("web-site") != null)
                        {
                            webSite = book["web-site"].InnerText.Trim();
                        }

                        CreateAndAddBookInDb(db, author, title, isbn, price, webSite);
                    }
                }

                tran.Complete();
            }
        }

        private static void CreateAndAddBookInDb(
            BookStoreDBEntities db, string author, string title, string isbn, decimal price, string webSite)
        {
            ICollection<Author> bookAuthors = new List<Author>();

            // Check is title exist
            var titleInDb = (from bookDb in db.Books
                             where bookDb.BookTitle == title
                             select bookDb).FirstOrDefault();

            var authorInDb = (from authorDb in db.Authors
                              where authorDb.AuthorName == author
                              select authorDb).FirstOrDefault();

            if (titleInDb != null && authorInDb != null)
            {
                return;
            }

            if (authorInDb == null)
            {
                Author newAuthor = new Author() { AuthorName = author };
                db.Authors.Add(newAuthor);
                db.SaveChanges();
                bookAuthors.Add(newAuthor);

                if (titleInDb != null)
                {
                    titleInDb.Authors.Add(newAuthor);
                }
            }

            Book newBook = new Book() { Authors = bookAuthors, BookTitle = title };

            if (isbn != null)
            {
                newBook.ISBN = isbn;

                var isbnInDb = (from b in db.Books
                                where b.ISBN == isbn
                                select b).FirstOrDefault();

                if (isbnInDb != null)
                {
                    throw new ApplicationException("Duplicated ISBN");
                }
            }

            if (price != 0m)
            {
                newBook.Price = price;
            }

            if (webSite != null)
            {
                newBook.WebSite = webSite;
            }

            db.Books.Add(newBook);
            db.SaveChanges();
        }

        private static void ParseComplexXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../complex-books.xml");

            var books = xmlDoc.DocumentElement.ChildNodes;
            
            using (var db = new BookStoreDBEntities())
            {
                foreach (XmlNode book in books)
                {
                    TransactionScope tran = new TransactionScope(
                        TransactionScopeOption.Required,
                        new TransactionOptions()
                        {
                            IsolationLevel = IsolationLevel.RepeatableRead
                        });
                    using (tran)
                    {
                        string title = book["title"].InnerText.Trim();

                        ICollection<Author> authors = null;
                        if (book.SelectSingleNode("authors") != null)
                        {
                            authors = new List<Author>();

                            foreach (XmlNode author in book.SelectSingleNode("authors").ChildNodes)
                            {
                                string authorName = null;

                                if (author.InnerText != null)
                                {
                                    authorName = author.InnerText.Trim();
                                }

                                var authorInDb = (from a in db.Authors
                                                  where a.AuthorName == authorName
                                                  select a).FirstOrDefault();

                                if (authorInDb == null && authorName != null)
                                {
                                    Author newAuthor = new Author() { AuthorName = authorName };
                                    db.Authors.Add(newAuthor);
                                    db.SaveChanges();
                                    authors.Add(newAuthor);
                                }
                            }
                        }

                        string webSite = null;

                        if (book.SelectSingleNode("web-site") != null)
                        {
                            webSite = book["web-site"].InnerText.Trim();
                        }

                        ICollection<Rewiew> reviews = null;
                        if (book.SelectSingleNode("reviews") != null)
                        {
                            reviews = new List<Rewiew>();

                            foreach (XmlNode review in book.SelectSingleNode("reviews").ChildNodes)
                            {
                                Rewiew currentReview = new Rewiew();

                                string reviewText = null;

                                if (review.InnerText != null)
                                {
                                    reviewText = review.InnerText.Trim();
                                    currentReview.RewiewText = reviewText;
                                }

                                string authorName = null;
                                if (review.Attributes["author"] != null)
                                {
                                    authorName = review.Attributes["author"].Value;
                                }

                                if (authorName != null)
                                {
                                    authorName = authorName.Trim();
                                    var authorInDb = (from a in db.Authors
                                                      where a.AuthorName == authorName
                                                      select a).FirstOrDefault();

                                    if (authorInDb == null)
                                    {
                                        Author newAuthor = new Author() { AuthorName = authorName };
                                        db.Authors.Add(newAuthor);
                                        db.SaveChanges();
                                        currentReview.Author = newAuthor;
                                    }
                                    else
                                    {
                                        currentReview.Author = authorInDb;
                                    }
                                }

                                DateTime reviewDate = DateTime.Now;

                                if (review.Attributes["date"] != null)
                                {
                                    reviewDate = DateTime.Parse(review.Attributes["date"].Value);
                                }

                                currentReview.RewiewDate = reviewDate;

                                reviews.Add(currentReview);
                            }
                        }

                        string isbn = null;

                        if (book.SelectSingleNode("isbn") != null)
                        {
                            isbn = book["isbn"].InnerText.Trim();
                        }

                        decimal price = 0m;

                        if (book.SelectSingleNode("price") != null)
                        {
                            price = decimal.Parse(book["price"].InnerText.Trim(), CultureInfo.InvariantCulture);
                        }

                        CreateAndAddReviewInDb(db, authors, reviews, title, isbn, price, webSite);

                        tran.Complete();
                    }
                }
            }
        }

        private static void CreateAndAddReviewInDb(
            BookStoreDBEntities db, ICollection<Author> authors, ICollection<Rewiew> reviews,
            string title, string isbn, decimal price, string webSite)
        {
            var bookInDb = (from b in db.Books
                            where b.BookTitle == title
                            select b).FirstOrDefault();

            if (bookInDb == null)
            {
                foreach (var a in authors)
                {
                    CreateAndAddBookInDb(db, a.AuthorName, title, isbn, price, webSite);
                }
            }

            bookInDb = (from b in db.Books
                        where b.BookTitle == title
                        select b).FirstOrDefault();

            if (authors != null)
            {
                foreach (var a in authors)
                {
                    bookInDb.Authors.Add(a);
                    db.SaveChanges();
                }
            }

            if (reviews != null)
            {
                foreach (var review in reviews)
                {
                    bookInDb.Rewiews.Add(review);
                    db.Rewiews.Add(review);
                    db.SaveChanges();
                }
            }
        }
    }
}