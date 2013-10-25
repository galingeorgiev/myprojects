namespace CatalogOfFreeContent.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class ICommandTests
    {
        [TestMethod]
        [Timeout(100)]
        public void Constructor_CreateNewValidCommand()
        {
            ICommand newCommand = new Command("Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");

            bool isCommandTypeCorrect = newCommand.Type == CommandType.AddApplication;
            bool isCommandNameCorrect = newCommand.Name == "Add application";
            string[] currentParameters = new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" };
            bool isCommandParametersCorrect = newCommand.Parameters.SequenceEqual(currentParameters);
            bool isOriginalFormIsCorrect = newCommand.OriginalForm == "Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org";

            bool isConstructorCorrect = isCommandTypeCorrect && isCommandNameCorrect && isCommandParametersCorrect && isOriginalFormIsCorrect;

            Assert.IsTrue(isConstructorCorrect);
        }

        [TestMethod]
        [Timeout(100)]
        [ExpectedException(typeof(FormatException))]
        public void Constructor_CreateNewInvalidCommandWithForbiddenSymbol()
        {
            // After application we have char ';'.
            ICommand newCommand = new Command("Add application;: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");
        }

        [TestMethod]
        [Timeout(100)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_CreateNewInvalidCommandWithOneParameter()
        {
            ICommand newCommand = new Command("Add application: Firefox v.11.0");
        }

        [TestMethod]
        [Timeout(100)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_CreateNewInvalidCommandWithWrongName()
        {
            ICommand newCommand = new Command("Add app: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");
        }

        [TestMethod]
        [Timeout(100)]
        public void ToString_CreateNewInvalidCommandWithWrongName()
        {
            ICommand newCommand = new Command("Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");

            string commandAsString = newCommand.ToString();
            string expectedString = "Add application Firefox v.11.0 Mozilla 16148072 http://www.mozilla.org";

            Assert.AreEqual(expectedString, commandAsString);
        }
    }
}
