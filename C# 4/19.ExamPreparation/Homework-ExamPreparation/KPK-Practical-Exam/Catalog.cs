namespace CatalogOfFreeContent
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from c in this.title[title] select c;

            return contentToList.Take(numberOfContentElementsToList);
        }

        // I make it this method a little bit faster but not enough.
        public int UpdateContent(string old, string newUrl)
        {
            int theElements = this.url[old].Count;
            ICollection<IContent> contentToList = this.url[old];

            for (int i = 0; i < theElements; i++)
            {
                this.title.Remove(contentToList.ElementAt(i).Title);
                contentToList.ElementAt(i).URL = newUrl;
                this.title.Add(contentToList.ElementAt(i).Title, contentToList.ElementAt(i));
                this.url.Add(contentToList.ElementAt(i).URL, contentToList.ElementAt(i));
            }

            this.url.Remove(old);

            return theElements;
        }
    }
}