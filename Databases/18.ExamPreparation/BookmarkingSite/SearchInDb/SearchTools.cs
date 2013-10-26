using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BookmarkingSite.Data;

namespace SearchInDb
{
    public static class SearchTools
    {
        public static void SearchByUsernameAndTag()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../SearchInDb/simple-query.xml");

            var queries = xmlDoc.SelectNodes("/query");

            using (var db = new BookmarksDBEntities())
            {
                foreach (XmlNode query in queries)
                {
                    string username = query["username"].InnerText;
                    string tag = query["tag"].InnerText;

                    SearchByUserAndTag(db, username, tag);
                }
            }
        }

        private static void SearchByUserAndTag(BookmarksDBEntities db, string username, string tag)
        {
            var resultsBytag = from user in db.Users
                               join bookmark in db.Bookmarks on user.UserID equals bookmark.UserId
                               where bookmark.Tags.Any(t => t.TagName == tag)
                               orderby bookmark.URL
                               select new { User = user.Username, bookmark.URL };

            if (username != null)
            {
                resultsBytag = from res in resultsBytag
                               where res.User == username
                               select res;
            }

            if (resultsBytag == null)
            {
                Console.WriteLine("Nothing found");
            }
            else
            {
                foreach (var url in resultsBytag)
                {
                    Console.WriteLine(url.URL);
                }
            }
        }

        public static void ComplexSearch()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../SearchInDb/complex-query.xml");

            var queries = xmlDoc.DocumentElement.ChildNodes;

            using (XmlTextWriter writer = new XmlTextWriter("../../../SearchInDb/search-results.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                foreach (XmlNode query in queries)
                {
                    string username = null;
                    string[] tags = { };
                    var maxCount = query.Attributes["max-results"].Value;

                    if (query.SelectSingleNode("username") != null)
                    {
                        Console.WriteLine(query["username"].InnerText);
                    }

                    var tagNodes = query.SelectNodes("tag");
                    tags = new string[tagNodes.Count];

                    for (int i = 0; i < tagNodes.Count; i++)
                    {
                        tags[i] = tagNodes[i].InnerText;
                    }

                    int count = 10;

                    if (maxCount != null)
                    {
                        count = int.Parse(maxCount.ToString());
                    }

                    SearchResults(writer, username, tags, count);
                }

                writer.WriteEndDocument();
            }
        }

        private static void SearchResults(XmlTextWriter writer, string username, string[] tags, int maxCount)
        {
            using (var db = new BookmarksDBEntities())
            {
                var queryResult = from user in db.Bookmarks.Include("User").Include("Tags")
                                  select user;

                if (username != null)
                {
                    queryResult = from user in queryResult
                                  where user.User.Username == username
                                  select user;
                }

                foreach (var tag in tags)
                {
                    queryResult = from ta in queryResult
                                  where ta.Tags.Any(t => t.TagName == tag)
                                  select ta;
                }

                queryResult = queryResult.Take(maxCount);
                var result = queryResult.ToList();

                WriteInXml(result, writer);
            }
        }

        private static void WriteInXml(List<Bookmark> bookmarks, XmlTextWriter writer)
        {
            writer.WriteStartElement("result-set");

            foreach (var bookmark in bookmarks)
            {
                writer.WriteStartElement("bookmark");

                if (bookmark.User.Username != null)
                {
                    writer.WriteElementString("username", bookmark.User.Username);
                }

                if (bookmark.Title != null)
                {
                    writer.WriteElementString("title", bookmark.Title);
                }

                if (bookmark.URL != null)
                {
                    writer.WriteElementString("url", bookmark.URL);
                }

                if (bookmark.Tags != null)
                {
                    writer.WriteElementString("tags", string.Format(", ", bookmark.Tags));
                }

                if (bookmark.Notes != null)
                {
                    writer.WriteElementString("notes", bookmark.Notes);
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}