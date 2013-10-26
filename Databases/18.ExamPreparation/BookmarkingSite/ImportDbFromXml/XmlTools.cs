using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BookmarkingSite.Data;
using System.Transactions;

namespace ImportDbFromXml
{
    public static class XmlTools
    {
        public static void ImportToDb()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../ImportDbFromXml/bookmarks.xml");

            var bookmarks = xmlDoc.DocumentElement.ChildNodes;

            TransactionScope tran =	new TransactionScope(
			TransactionScopeOption.Required,
				new TransactionOptions() {
					IsolationLevel = IsolationLevel.RepeatableRead });
            using (tran)
            {
                using (var db = new BookmarksDBEntities())
                {
                    foreach (XmlNode bookmark in bookmarks)
                    {
                        string username = bookmark["username"].InnerText;
                        string title = bookmark["title"].InnerText;
                        string url = bookmark["url"].InnerText;
                        string[] tags = { };
                        if (bookmark.SelectSingleNode("tags") != null)
                        {
                            tags = bookmark["tags"].InnerText.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        }

                        string notes = null;
                        if (bookmark.SelectSingleNode("notes") != null)
                        {
                            notes = bookmark["notes"].InnerText;
                        }

                        AddBookmarksInDb(db, username, title, url, tags, notes);
                    }

                    tran.Complete();
                }
            }
        }

        private static void AddBookmarksInDb(BookmarksDBEntities db, string username, string title, string url, string[] tags, string notes)
        {
            var user = (from users in db.Users
                        where users.Username == username
                        select users).FirstOrDefault();

            if (user == null)
            {
                user = new User() { Username = username };
                db.Users.Add(user);
                db.SaveChanges();
            }

            Tag[] tagsList = { };
            if (tags != null)
            {
                tagsList = new Tag[tags.Length];
                for (int i = 0; i < tags.Length; i++)
                {
                    Tag currentTag = new Tag() { TagName = tags[i] };
                    db.Tags.Add(currentTag);
                    tagsList[i] = currentTag;
                    db.SaveChanges();
                }
            }

            var bookmark = new Bookmark() { User = user, Title = title, URL = url, Notes = notes, Tags = tagsList };
            db.Bookmarks.Add(bookmark);
            db.SaveChanges();
        }
    }
}