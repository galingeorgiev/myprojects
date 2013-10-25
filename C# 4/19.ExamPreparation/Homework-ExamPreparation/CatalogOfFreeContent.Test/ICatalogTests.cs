namespace CatalogOfFreeContent.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class ICatalogTests
    {
        // Some of Add tests covered GetListContent logic.
        [TestMethod]
        [Timeout(100)]
        public void Add_AddOneBookAndGetIt()
        {
            string[] testContentParams = new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testContent = new Content(ContentType.Book, testContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("Intro C#", 2);
            var numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(1, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_AddOneBookWithParamsNull()
        {
            string[] testContentParams = new string[] { null };
            IContent testContent = new Content(ContentType.Book, testContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testContent);
        }

        [TestMethod]
        [Timeout(100)]
        public void Add_AddTwoIndenticalBooksAndGetIt()
        {
            string[] testContentParams = new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testContent = new Content(ContentType.Book, testContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testContent);
            currentCatalog.Add(testContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("Intro C#", 5);
            int numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(2, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        public void Add_AddTwoIndenticalBooksAndGetOne()
        {
            string[] testContentParams = new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testContent = new Content(ContentType.Book, testContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testContent);
            currentCatalog.Add(testContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("Intro C#", 1);
            int numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(1, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        public void Add_AddTwoIndenticalBooksAndThreeOtherItems()
        {
            string[] testBookContentParams = new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testBookContent = new Content(ContentType.Book, testBookContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testBookContent);
            currentCatalog.Add(testBookContent);

            string[] testMovieContentParams = new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" };
            IContent testMovieContent = new Content(ContentType.Book, testMovieContentParams);
            currentCatalog.Add(testMovieContent);

            string[] testApplicationContentParams = new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" };
            IContent testApplicationContent = new Content(ContentType.Book, testApplicationContentParams);
            currentCatalog.Add(testApplicationContent);

            string[] testSongContentParams = new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" };
            IContent testSongContent = new Content(ContentType.Book, testSongContentParams);
            currentCatalog.Add(testSongContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("One", 10);
            int numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(1, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        public void Add_FiveItemsWithIndenticalNamesAndGetCount()
        {
            string[] testBookContentParams = new string[] { "IndenticalTitle", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testBookContent = new Content(ContentType.Book, testBookContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testBookContent);
            currentCatalog.Add(testBookContent);

            string[] testMovieContentParams = new string[] { "IndenticalTitle", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" };
            IContent testMovieContent = new Content(ContentType.Book, testMovieContentParams);
            currentCatalog.Add(testMovieContent);

            string[] testApplicationContentParams = new string[] { "IndenticalTitle", "Mozilla", "16148072", "http://www.mozilla.org" };
            IContent testApplicationContent = new Content(ContentType.Book, testApplicationContentParams);
            currentCatalog.Add(testApplicationContent);

            string[] testSongContentParams = new string[] { "IndenticalTitle", "Metallica", "8771120", "http://goo.gl/dIkth7gs" };
            IContent testSongContent = new Content(ContentType.Book, testSongContentParams);
            currentCatalog.Add(testSongContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("IndenticalTitle", 10);
            int numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(5, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        public void Add_FourItemsWithIndenticalNamesAndOneWithDifrentGetCount()
        {
            string[] testBookContentParams = new string[] { "IndenticalTitle", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testBookContent = new Content(ContentType.Book, testBookContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testBookContent);
            currentCatalog.Add(testBookContent);

            string[] testMovieContentParams = new string[] { "IndenticalTitle", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" };
            IContent testMovieContent = new Content(ContentType.Book, testMovieContentParams);
            currentCatalog.Add(testMovieContent);

            string[] testApplicationContentParams = new string[] { "IndenticalTitle", "Mozilla", "16148072", "http://www.mozilla.org" };
            IContent testApplicationContent = new Content(ContentType.Book, testApplicationContentParams);
            currentCatalog.Add(testApplicationContent);

            string[] testSongContentParams = new string[] { "DifferentTitle", "Metallica", "8771120", "http://goo.gl/dIkth7gs" };
            IContent testSongContent = new Content(ContentType.Book, testSongContentParams);
            currentCatalog.Add(testSongContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("IndenticalTitle", 10);
            int numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(4, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_TryToAddItemWithIncorectParamsCount()
        {
            string[] testBookContentParams = new string[] { "Intro C#" };
            IContent testBookContent = new Content(ContentType.Book, testBookContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testBookContent);
        }

        [TestMethod]
        [Timeout(100)]
        public void GetListContent_AddFiveItemsWithIndenticalTitlesAndGetThree()
        {
            string[] testBookContentParams = new string[] { "IndenticalTitle", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testBookContent = new Content(ContentType.Book, testBookContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testBookContent);
            currentCatalog.Add(testBookContent);

            string[] testMovieContentParams = new string[] { "IndenticalTitle", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" };
            IContent testMovieContent = new Content(ContentType.Book, testMovieContentParams);
            currentCatalog.Add(testMovieContent);

            string[] testApplicationContentParams = new string[] { "IndenticalTitle", "Mozilla", "16148072", "http://www.mozilla.org" };
            IContent testApplicationContent = new Content(ContentType.Book, testApplicationContentParams);
            currentCatalog.Add(testApplicationContent);

            string[] testSongContentParams = new string[] { "IndenticalTitle", "Metallica", "8771120", "http://goo.gl/dIkth7gs" };
            IContent testSongContent = new Content(ContentType.Book, testSongContentParams);
            currentCatalog.Add(testSongContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("IndenticalTitle", 3);
            int numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(3, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        public void GetListContent_AddFiveItemsWithIndenticalTitlesAndGetExactlyFive()
        {
            string[] testBookContentParams = new string[] { "IndenticalTitle", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testBookContent = new Content(ContentType.Book, testBookContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testBookContent);
            currentCatalog.Add(testBookContent);

            string[] testMovieContentParams = new string[] { "IndenticalTitle", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" };
            IContent testMovieContent = new Content(ContentType.Book, testMovieContentParams);
            currentCatalog.Add(testMovieContent);

            string[] testApplicationContentParams = new string[] { "IndenticalTitle", "Mozilla", "16148072", "http://www.mozilla.org" };
            IContent testApplicationContent = new Content(ContentType.Book, testApplicationContentParams);
            currentCatalog.Add(testApplicationContent);

            string[] testSongContentParams = new string[] { "IndenticalTitle", "Metallica", "8771120", "http://goo.gl/dIkth7gs" };
            IContent testSongContent = new Content(ContentType.Book, testSongContentParams);
            currentCatalog.Add(testSongContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("IndenticalTitle", 5);
            int numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(5, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        public void GetListContent_AddFiveItemsWithIndenticalTitlesAndGetZero()
        {
            string[] testBookContentParams = new string[] { "IndenticalTitle", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testBookContent = new Content(ContentType.Book, testBookContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testBookContent);
            currentCatalog.Add(testBookContent);

            string[] testMovieContentParams = new string[] { "IndenticalTitle", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" };
            IContent testMovieContent = new Content(ContentType.Book, testMovieContentParams);
            currentCatalog.Add(testMovieContent);

            string[] testApplicationContentParams = new string[] { "IndenticalTitle", "Mozilla", "16148072", "http://www.mozilla.org" };
            IContent testApplicationContent = new Content(ContentType.Book, testApplicationContentParams);
            currentCatalog.Add(testApplicationContent);

            string[] testSongContentParams = new string[] { "IndenticalTitle", "Metallica", "8771120", "http://goo.gl/dIkth7gs" };
            IContent testSongContent = new Content(ContentType.Book, testSongContentParams);
            currentCatalog.Add(testSongContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("IndenticalTitle", 0);
            int numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(0, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        public void GetListContent_AddFiveItemsWithIndenticalTitlesAndGetTen()
        {
            string[] testBookContentParams = new string[] { "IndenticalTitle", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testBookContent = new Content(ContentType.Book, testBookContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testBookContent);
            currentCatalog.Add(testBookContent);

            string[] testMovieContentParams = new string[] { "IndenticalTitle", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" };
            IContent testMovieContent = new Content(ContentType.Book, testMovieContentParams);
            currentCatalog.Add(testMovieContent);

            string[] testApplicationContentParams = new string[] { "IndenticalTitle", "Mozilla", "16148072", "http://www.mozilla.org" };
            IContent testApplicationContent = new Content(ContentType.Book, testApplicationContentParams);
            currentCatalog.Add(testApplicationContent);

            string[] testSongContentParams = new string[] { "IndenticalTitle", "Metallica", "8771120", "http://goo.gl/dIkth7gs" };
            IContent testSongContent = new Content(ContentType.Book, testSongContentParams);
            currentCatalog.Add(testSongContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("IndenticalTitle", 10);
            int numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(5, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        public void GetListContent_AddFiveItemsWithIndenticalTitlesAndTryToGetNegatiteCount()
        {
            string[] testBookContentParams = new string[] { "IndenticalTitle", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testBookContent = new Content(ContentType.Book, testBookContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testBookContent);
            currentCatalog.Add(testBookContent);

            string[] testMovieContentParams = new string[] { "IndenticalTitle", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" };
            IContent testMovieContent = new Content(ContentType.Book, testMovieContentParams);
            currentCatalog.Add(testMovieContent);

            string[] testApplicationContentParams = new string[] { "IndenticalTitle", "Mozilla", "16148072", "http://www.mozilla.org" };
            IContent testApplicationContent = new Content(ContentType.Book, testApplicationContentParams);
            currentCatalog.Add(testApplicationContent);

            string[] testSongContentParams = new string[] { "IndenticalTitle", "Metallica", "8771120", "http://goo.gl/dIkth7gs" };
            IContent testSongContent = new Content(ContentType.Book, testSongContentParams);
            currentCatalog.Add(testSongContent);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("IndenticalTitle", -1);
            int numberOfRenurnedResults = currentContent.Count();

            Assert.AreEqual(0, numberOfRenurnedResults);
        }

        [TestMethod]
        [Timeout(100)]
        public void UpdateCatalog_AddTwoIndenticalBooksAndUpdateURLs()
        {
            string[] testContentParams = new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testContent = new Content(ContentType.Book, testContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testContent);
            currentCatalog.Add(testContent);

            string oldURL = "http://www.introprogramming.info";
            string newURL = "http://www.introprogramming.com";
            currentCatalog.UpdateContent(oldURL, newURL);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("Intro C#", 1);
            string currentContentNewURL = currentContent.First().URL;

            Assert.AreEqual(newURL, currentContentNewURL);
        }

        [TestMethod]
        [Timeout(100)]
        public void UpdateCatalog_AddTwoIndenticalBooksAndUpdateURLsCheckIsAllUpdated()
        {
            string[] testContentParams = new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testContent = new Content(ContentType.Book, testContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testContent);
            currentCatalog.Add(testContent);

            string oldURL = "http://www.introprogramming.info";
            string newURL = "http://www.introprogramming.com";
            currentCatalog.UpdateContent(oldURL, newURL);

            IEnumerable<IContent> currentContent = currentCatalog.GetListContent("Intro C#", 1);
            bool isAllUpdated = true;

            foreach (IContent content in currentContent)
            {
                if (oldURL == content.URL)
                {
                    isAllUpdated = false;
                    break;
                }
            }

            Assert.IsTrue(isAllUpdated);
        }

        [TestMethod]
        [Timeout(100)]
        public void UpdateCatalog_AddFiveItemsAndUpdateAll()
        {
            string[] testContentParams = new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testContent = new Content(ContentType.Book, testContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testContent);
            currentCatalog.Add(testContent);

            string[] testMovieContentParams = new string[] { "IndenticalTitle", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://www.introprogramming.info" };
            IContent testMovieContent = new Content(ContentType.Book, testMovieContentParams);
            currentCatalog.Add(testMovieContent);

            string[] testApplicationContentParams = new string[] { "IndenticalTitle", "Mozilla", "16148072", "http://www.introprogramming.info" };
            IContent testApplicationContent = new Content(ContentType.Book, testApplicationContentParams);
            currentCatalog.Add(testApplicationContent);

            string[] testSongContentParams = new string[] { "DifferentTitle", "Metallica", "8771120", "http://www.introprogramming.info" };
            IContent testSongContent = new Content(ContentType.Book, testSongContentParams);
            currentCatalog.Add(testSongContent);

            string oldURL = "http://www.introprogramming.info";
            string newURL = "http://www.introprogramming.com";
            int updatedItems = currentCatalog.UpdateContent(oldURL, newURL);

            Assert.AreEqual(5, updatedItems);
        }

        [TestMethod]
        [Timeout(100)]
        public void UpdateCatalog_TryToUpdateMissingUrl()
        {
            string[] testContentParams = new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            IContent testContent = new Content(ContentType.Book, testContentParams);
            ICatalog currentCatalog = new Catalog();
            currentCatalog.Add(testContent);

            string oldURL = "http://www.missingURL.info";
            string newURL = "http://www.introprogramming.com";
            int updatedItems = currentCatalog.UpdateContent(oldURL, newURL);

            Assert.AreEqual(0, updatedItems);
        }
    }
}