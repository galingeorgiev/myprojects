namespace CatalogOfFreeContent.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;

    [TestClass]
    public class ICommandExecutorTests
    {
        [TestMethod]
        [Timeout(100)]
        public void ExecuteCommand_TestOutputMessageWithAdd()
        {
            ICatalog currentCatalog = new Catalog();
            ICommand newCommand = new Command("Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org");
            StringBuilder output = new StringBuilder();

            CommandExecutor commandExecutor = new CommandExecutor();
            commandExecutor.ExecuteCommand(currentCatalog, newCommand, output);

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Application added");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

        [TestMethod]
        [Timeout(100)]
        public void ExecuteCommand_TestOutputMessageWithUpdate()
        {
            ICatalog currentCatalog = new Catalog();
            ICommand newCommand = new Command("Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");
            StringBuilder output = new StringBuilder();

            CommandExecutor commandExecutor = new CommandExecutor();
            commandExecutor.ExecuteCommand(currentCatalog, newCommand, output);

            ICommand updateCommand = new Command("Update: http://www.introprogramming.info; http://introprograming.info/en/");
            commandExecutor.ExecuteCommand(currentCatalog, updateCommand, output);

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Book added");
            expectedOutput.AppendLine("1 items updated");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

        [TestMethod]
        [Timeout(100)]
        public void ExecuteCommand_TestOutputMessageWithFind()
        {
            ICatalog currentCatalog = new Catalog();
            ICommand newCommand = new Command("Add song: One; Metallica; 8771120; http://goo.gl/dIkth7gs");
            StringBuilder output = new StringBuilder();

            CommandExecutor commandExecutor = new CommandExecutor();
            commandExecutor.ExecuteCommand(currentCatalog, newCommand, output);

            ICommand findCommand = new Command("Find: One; 1");
            commandExecutor.ExecuteCommand(currentCatalog, findCommand, output);

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Song added");
            expectedOutput.AppendLine("Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

        [TestMethod]
        [Timeout(100)]
        public void ExecuteCommand_TestOutputMessageWithFindMissingItem()
        {
            ICatalog currentCatalog = new Catalog();
            ICommand newCommand = new Command("Add movie: The Secret; Drew Heriot, Sean Byrne & others (2006); 832763834; http://t.co/dNV4d");
            StringBuilder output = new StringBuilder();

            CommandExecutor commandExecutor = new CommandExecutor();
            commandExecutor.ExecuteCommand(currentCatalog, newCommand, output);

            ICommand findCommand = new Command("Find: MissingName; 1");
            commandExecutor.ExecuteCommand(currentCatalog, findCommand, output);

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Movie added");
            expectedOutput.AppendLine("No items found");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

        [TestMethod]
        [Timeout(100)]
        [ExpectedException(typeof(ArgumentException))]
        public void ExecuteCommand_TestOutputMessageWithWrongCommandName()
        {
            ICatalog currentCatalog = new Catalog();
            ICommand newCommand = new Command("Add app: The Secret; Drew Heriot, Sean Byrne & others (2006); 832763834; http://t.co/dNV4d");
            StringBuilder output = new StringBuilder();

            CommandExecutor commandExecutor = new CommandExecutor();
            commandExecutor.ExecuteCommand(currentCatalog, newCommand, output);
        }
    }
}
