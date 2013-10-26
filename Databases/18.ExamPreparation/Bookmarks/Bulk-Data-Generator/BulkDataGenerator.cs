using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bookmarks.Data;

class BulkDataGenerator
{
	public const int MAX_SQL_INSERT_ROWS = 500;
	public const int TAGS_COUNT = 10000;
	public const int BOOKMARKS_COUNT = 200000;

	static void Main()
	{
		ClearTables();
		InsertUsers(30000);
		InsertBookmarks(100);
		InsertDuplicatedBookmarks(BOOKMARKS_COUNT);
		InsertTags(TAGS_COUNT);
		ConnectBookmarksWithTags();
	}

	private static void ClearTables()
	{
		string clearTablesSql =
			@"DELETE FROM Bookmarks_Tags;
			  DELETE FROM Tags;
			  DELETE FROM Bookmarks;
			  DELETE FROM Users;";
		BookmarksEntities context = new BookmarksEntities();
		context.Database.ExecuteSqlCommand(clearTablesSql);
	}

	private static void ConnectBookmarksWithTags()
	{
		BookmarksEntities context = new BookmarksEntities();

		int maxTagId = context.Database.SqlQuery<int>(
			"SELECT MAX(TagID) FROM Tags").First();
		int minTagId = maxTagId - TAGS_COUNT + 1;

		int maxBookmarkId = context.Database.SqlQuery<int>(
			"SELECT MAX(BookmarkID) FROM Bookmarks").First();
		int minBookmarkId = maxBookmarkId - BOOKMARKS_COUNT + 1;

		Random rnd = new Random();
		StringBuilder insertSql = new StringBuilder();
		insertSql.Append(
			"INSERT Into Bookmarks_Tags(BookmarkId, TagId) " +
			"VALUES ");
		int insertCount = 0;
		int tagId = minTagId;

		for (int bookmarkId = minBookmarkId; bookmarkId <= maxBookmarkId; bookmarkId++)
		{
			int tagsCount = rnd.Next(1, 10);
			for (int i = 0; i < tagsCount; i++)
			{
				string valueToInsert = String.Format(
					"({0},{1}),", bookmarkId, tagId);
				insertSql.Append(valueToInsert);
				insertCount++;
				if (insertCount > MAX_SQL_INSERT_ROWS)
				{
					insertSql.Length--;
					context.Database.ExecuteSqlCommand(
						insertSql.ToString());
					insertSql.Clear();
					insertSql.Append(
						"INSERT Into Bookmarks_Tags(BookmarkId, TagId) " +
						"VALUES ");
					insertCount = 0;
				}
				tagId++;
				if (tagId > maxTagId)
				{
					tagId = minTagId;
				}
			}
		}

		insertSql.Length--;
		context.Database.ExecuteSqlCommand(
			insertSql.ToString());
	}

	private static void InsertDuplicatedBookmarks(int minCount)
	{
		BookmarksEntities context = new BookmarksEntities();
		int counter = 1;
		while (true)
		{
			int bookmarksCount = context.Bookmarks.Count();
			if (bookmarksCount > minCount)
			{
				return;
			}
			string command =
				String.Format(
				"INSERT INTO Bookmarks(Title, Url, UserId) " +
				"SELECT Title + '{0}', Url + '{1}', UserId " +
				"FROM Bookmarks", counter, counter * 10);
			context.Database.ExecuteSqlCommand(command);
			counter++;
		}
	}

	private static void InsertBookmarks(int count)
	{
		BookmarksEntities context = new BookmarksEntities();
		var userIDs = 
			context.Users.Select(u => u.UserId).ToList();
		for (int i = 0; i < count; i++)
		{
			Bookmark bookmark = new Bookmark();
			bookmark.Title = "Title" + i;
			bookmark.URL = "http://telerikacademy.com/bookmarks/" + i;
			bookmark.UserId = userIDs[i % userIDs.Count];
			context.Bookmarks.Add(bookmark);
		}

		context.SaveChanges();
	}

	private static void InsertUsers(int count)
	{
		BookmarksEntities context = new BookmarksEntities();
		int usersCount = context.Users.Count();

		StringBuilder insertUsersSql = new StringBuilder();
		insertUsersSql.Append(
			"INSERT Into Users(username) VALUES ");

		int insertCount = 0;
		for (int i = usersCount + 1; i <= usersCount + count; i++)
		{
			string username = "('user" + i + "'),";
			insertUsersSql.Append(username);
			insertCount++;
			if (insertCount > MAX_SQL_INSERT_ROWS)
			{
				insertUsersSql.Length--;
				context.Database.ExecuteSqlCommand(
					insertUsersSql.ToString());
				insertUsersSql.Clear();
				insertUsersSql.Append(
					"INSERT Into Users(username) VALUES ");
				insertCount = 0;
			}
		}
		insertUsersSql.Length--;

		context.Database.ExecuteSqlCommand(
			insertUsersSql.ToString());
	}


	private static void InsertTags(int count)
	{
		BookmarksEntities context = new BookmarksEntities();
		int tagsCount = context.Tags.Count();

		StringBuilder insertTagsSql = new StringBuilder();
		insertTagsSql.Append(
			"INSERT Into Tags(Name) VALUES ");

		int insertCount = 0;
		for (int i = tagsCount + 1; i <= tagsCount + count; i++)
		{
			string tagName = "('tag" + i + "'),";
			insertTagsSql.Append(tagName);
			insertCount++;
			if (insertCount > MAX_SQL_INSERT_ROWS)
			{
				insertTagsSql.Length--;
				context.Database.ExecuteSqlCommand(
					insertTagsSql.ToString());
				insertTagsSql.Clear();
				insertTagsSql.Append(
					"INSERT Into Tags(Name) VALUES ");
				insertCount = 0;
			}
		}
		insertTagsSql.Length--;

		context.Database.ExecuteSqlCommand(
			insertTagsSql.ToString());
	}

}