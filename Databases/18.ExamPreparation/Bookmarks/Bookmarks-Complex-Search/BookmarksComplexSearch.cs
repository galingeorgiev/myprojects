using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Bookmarks.Data;

static class BookmarksComplexSearch
{
	static void Main()
	{
		string fileName = "../../search-results.xml";
		using (XmlTextWriter writer = 
			new XmlTextWriter(fileName, Encoding.UTF8))
		{
			writer.Formatting = Formatting.Indented;
			writer.IndentChar = '\t';
			writer.Indentation = 1;

			writer.WriteStartDocument();
			writer.WriteStartElement("search-results");

			ProcessSearchQueries(writer);

			writer.WriteEndDocument();
		}		
	}

	private static void ProcessSearchQueries(XmlTextWriter writer)
	{
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load("../../complex-query.xml");
		foreach (XmlNode query in xmlDoc.SelectNodes("/queries/query"))
		{
			string username = query.GetChildText("username");
			int maxResults = 10;
			var maxResultsAttrib = query.Attributes["max-results"];
			if (maxResultsAttrib != null)
			{
				maxResults = int.Parse(maxResultsAttrib.Value);
			}
			List<string> tags = new List<string>();
			foreach (XmlNode tag in query.SelectNodes("tag"))
			{
				tags.Add(tag.InnerText.Trim());
			}

			var bookmarks =
				BookmarksDAL.FindBookmarks(username, tags, maxResults);

			WriteBookmarks(writer, bookmarks);
		}		
	}

	private static void WriteBookmarks(
		XmlTextWriter writer, IList<Bookmark> bookmarks)
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
			if (bookmark.Tags.Count > 0)
			{
				string tags = string.Join(", ",
					bookmark.Tags.Select(t => t.Name).OrderBy(t => t));
				writer.WriteElementString("tags", tags);
			}
			if (bookmark.Notes != null)
			{
				writer.WriteElementString("notes", bookmark.Notes);
			}
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
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

