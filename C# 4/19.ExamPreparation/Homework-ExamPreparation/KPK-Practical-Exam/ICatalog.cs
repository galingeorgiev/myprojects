namespace CatalogOfFreeContent
{
    using System.Collections.Generic;

    public interface ICatalog
    {
        /// <summary>
        /// Add new item of type IContent.
        /// </summary>
        /// <param name="content">Item that will be added.</param>
        void Add(IContent content);

        /// <summary>
        /// Get list of IContent items that have searched Title.
        /// </summary>
        /// <param name="title">Title of IContent item. Title will be used as search criteria.</param>
        /// <param name="numberOfContentElementsToList">Number of results that you want to get.</param>
        /// <returns>List with IContent items that covered searchin criteria.</returns>
        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        /// <summary>
        /// Change IContent items URL.
        /// </summary>
        /// <param name="oldUrl">Old URL that must be changed.</param>
        /// <param name="newUrl">New URL that replace old one.</param>
        /// <returns>Number of replaced URLs.</returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
