namespace Command.Tests
{
    using CalendarSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ParseTests
    {
        [TestMethod]
        [Timeout(300)]
        public void Parse_ValidCommand()
        {
            string commandStr = "AddEvent 2012-01-21T20:00:00 | party Viki | home";
            Command command = new Command();

            command = Command.Parse(commandStr);

            bool isCommandNameValid = command.CommandName == CommandType.AddEvent;
            string[] parametars = command.Parametars;
            string date = parametars[0];
            string title = parametars[1];
            string location = parametars[2];
            bool isDateAndTimeCorrect = date == "2012-01-21T20:00:00";
            bool isTitleCorrect = title == "party Viki";
            bool isLocationCorrect = location == "home";

            bool isParseValid = isCommandNameValid && isDateAndTimeCorrect && isTitleCorrect && isLocationCorrect;

            Assert.IsTrue(isParseValid, "Parse with valid input does not work correct.");
        }

        [TestMethod]
        [Timeout(300)]
        [ExpectedException(typeof(FormatException))]
        public void Parse_InvalidCommandWithoutSpace()
        {
            string commandStr = "AddEvent2012-01-21T20:00:00|party|home";
            Command command = new Command();

            command = Command.Parse(commandStr);
        }

        [TestMethod]
        [Timeout(300)]
        [ExpectedException(typeof(FormatException))]
        public void Parse_InvalidCommandWithoutVerticalLineBetweenParams()
        {
            string commandStr = "AddEvent 2012-01-21T20:00:00 party Viki home";
            Command command = new Command();

            command = Command.Parse(commandStr);
        }

        [TestMethod]
        [Timeout(300)]
        [ExpectedException(typeof(FormatException))]
        public void Parse_InvalidCommandWithNewLineIn()
        {
            string commandStr = "AddEvent 2012-01-21T20:00:00" + Environment.NewLine + " | party Viki | home";
            Command command = new Command();

            command = Command.Parse(commandStr);
        }

        [TestMethod]
        [Timeout(300)]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_InvalidCommandType()
        {
            string commandStr = "Add 2012-01-21T20:00:00 | party Viki | home";
            Command command = new Command();

            command = Command.Parse(commandStr);
        }

        [TestMethod]
        [Timeout(300)]
        public void Parse_ValidCommandDeleteEvents()
        {
            string commandDeleteStr = "DeleteEvents c# exam";
            Command command = new Command();

            command = Command.Parse(commandDeleteStr);

            bool isCommandNameValid = command.CommandName == CommandType.DeleteEvents;
            string[] parametars = command.Parametars;
            string title = parametars[0];
            bool isTitleCorrect = title == "c# exam";

            bool isParseValid = isCommandNameValid && isTitleCorrect;

            Assert.IsTrue(isParseValid, "Parse with valid input does not work correct.");
        }

        [TestMethod]
        public void Parse_ValidCommandListEvents()
        {
            string commandDeleteStr = "ListEvents 2013-11-27T08:30:25 | 25";
            Command command = new Command();

            command = Command.Parse(commandDeleteStr);

            bool isCommandNameValid = command.CommandName == CommandType.ListEvents;
            string[] parametars = command.Parametars;
            string date = parametars[0];
            bool isDateCorrect = date == "2013-11-27T08:30:25";
            string count = parametars[1];
            bool isCountCorrect = count == "25";

            bool isParseValid = isCommandNameValid && isDateCorrect && isCountCorrect;

            Assert.IsTrue(isParseValid, "Parse with valid input does not work correct.");
        }
    }
}