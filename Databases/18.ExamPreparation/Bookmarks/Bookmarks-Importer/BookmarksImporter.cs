using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Xml;
using Bookmarks.Data;

static class BookmarksImporter
{
	static void Main()
	{
		TransactionScope tran =	new TransactionScope(
			TransactionScopeOption.Required,
				new TransactionOptions() {
					IsolationLevel = IsolationLevel.RepeatableRead });
		using (tran)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load("../../bookmarks.xml");
			string xPathQuery = "/bookmarks/bookmark";

			XmlNodeList bookmarksList = xmlDoc.SelectNodes(xPathQuery);
			foreach (XmlNode bookmarkNode in bookmarksList)
			{
				string username = bookmarkNode.GetChildText("username");
				string title = bookmarkNode.GetChildText("title");
				string url = bookmarkNode.GetChildText("url");
				string notes = bookmarkNode.GetChildText("notes");
				string allTags = bookmarkNode.GetChildText("tags");
				string[] tags = { };
				if (allTags != null)
				{
					tags = allTags.Split(',');
					for (int i = 0; i < tags.Length; i++)
					{
						tags[i] = tags[i].Trim();
					}
				}
				BookmarksDAL.AddBookmark(username, title, url, tags, notes);
				Thread.Sleep(500);
			}
			tran.Complete();
		}
	}

	private static string GetChildText(this XmlNode node, string tagName)
	{
		XmlNode childNode = node.SelectSingleNode(tagName);
		if (childNode == null)
		{
			return null;
		}
		return childNode.InnerText.Trim();
	}

	//private static void AddBookmark(string username, 
	//	string title, string url, string[] tags, string notes)
	//{
	//	Console.WriteLine("{0} {1} {2} {3} {4}",
	//		username, title, url, string.Join(", ", tags), notes);
	//}
}
