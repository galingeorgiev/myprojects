using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bookmarks.Data
{
	public class BookmarksDAL
	{
		public static void AddBookmark(string username,
			string title, string url, string[] tags, string notes)
		{
			BookmarksEntities context = new BookmarksEntities();
			Bookmark newBookmark = new Bookmark();
			newBookmark.User = CreateOrLoadUser(context, username);
			newBookmark.Title = title;
			newBookmark.URL = url;
			newBookmark.Notes = notes;
			foreach (var tagName in tags)
			{
				Tag tag = CreateOrLoadTag(context, tagName);
				newBookmark.Tags.Add(tag);
			}
			string[] titleTags = Regex.Split(title, @"[,'!\. ;?-]+");
			foreach (var titleTagName in titleTags)
			{
				Tag titleTag = CreateOrLoadTag(context, titleTagName);
				newBookmark.Tags.Add(titleTag);
			}
			context.Bookmarks.Add(newBookmark);
			context.SaveChanges();
		}

		private static User CreateOrLoadUser(
			BookmarksEntities context, string username)
		{
			User existingUser =
				(from u in context.Users
				where u.Username.ToLower() == username.ToLower()
				select u).FirstOrDefault();
			if (existingUser != null)
			{
				return existingUser;
			}

			User newUser = new User();
			newUser.Username = username;
			context.Users.Add(newUser);
			context.SaveChanges();

			return newUser;
		}

		private static Tag CreateOrLoadTag(
			BookmarksEntities context, string tagName)
		{
			Tag existingTag =
				(from t in context.Tags
				 where t.Name.ToLower() == tagName.ToLower()
				 select t).FirstOrDefault();
			if (existingTag != null)
			{
				return existingTag;
			}

			Tag newTag = new Tag();
			newTag.Name = tagName.ToLower();
			context.Tags.Add(newTag);
			context.SaveChanges();

			return newTag;
		}

		public static IList<Bookmark> FindBookmarksByUsernameAndTag(
			string username, string tag)
		{
			BookmarksEntities context = new BookmarksEntities();
			var bookmarksQuery =
				from b in context.Bookmarks
				select b;
			if (username != null)
			{
				bookmarksQuery =
					from b in context.Bookmarks
					where b.User.Username == username
					select b;
			}
			if (tag != null)
			{
				bookmarksQuery = bookmarksQuery.Where(
					b => b.Tags.Any(t => t.Name == tag));
			}
			bookmarksQuery = bookmarksQuery.OrderBy(b => b.URL);

			return bookmarksQuery.ToList();
		}

		public static IList<Bookmark> FindBookmarks(
			string username, IList<string> tags, int maxResults)
		{
			BookmarksEntities context = new BookmarksEntities();
			var bookmarksQuery =
				from b in context.Bookmarks.Include("User").Include("Tags")
				select b;
			if (username != null)
			{
				bookmarksQuery = bookmarksQuery.Where(
					b => b.User.Username == username);
			}
			foreach (var tag in tags)
			{
				bookmarksQuery = bookmarksQuery.Where(
					b => b.Tags.Any(t => t.Name == tag));
			}
			bookmarksQuery = bookmarksQuery.OrderBy(b => b.URL);
			bookmarksQuery = bookmarksQuery.Take(maxResults);

			return bookmarksQuery.ToList();
		}
	}
}
