using System;
using System.Linq;
using System.Xml;
using Bookmarks.Data;

static class BookmarkSearch
{
	static void Main()
	{
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load("../../simple-query.xml");
		string username = xmlDoc.GetChildText("/query/username");
		string tag = xmlDoc.GetChildText("/query/tag");
		var bookmarks = 
			BookmarksDAL.FindBookmarksByUsernameAndTag(
				username, tag);
		if (bookmarks.Count > 0)
		{
			foreach (var bookmark in bookmarks)
			{
				Console.WriteLine(bookmark.URL);
			}
		}
		else
		{
			Console.WriteLine("Nothing found");
		}
	}

	private static string GetChildText(
		this XmlNode node, string xpath)
	{
		XmlNode childNode = node.SelectSingleNode(xpath);
		if (childNode == null)
		{
			return null;
		}
		return childNode.InnerText.Trim();
	}
}

