namespace CalendarSystem
{
    using System;

    public struct Command
    {
        private CommandType commandName;
        private string[] parametars;

        public Command(CommandType commandName, string[] parametars)
        {
            this.commandName = commandName;
            this.parametars = parametars;
        }

        public CommandType CommandName
        {
            get { return this.commandName; }
            set { this.commandName = value; }
        }

        public string[] Parametars
        {
            get { return this.parametars; }
            set { this.parametars = value; }
        }
        
        public static Command Parse(string command)
        {
            if (command.Contains(Environment.NewLine))
            {
                throw new FormatException("Command cannot containes symbol for new line.");
            }

            int endOfCommandName = command.IndexOf(' ');
            if (endOfCommandName == -1)
            {
                string exceptionMessage = string.Format("Invalid command: {0}", command);
                throw new FormatException(exceptionMessage);
            }

            string commandName = command.Substring(0, endOfCommandName);
            string commandParams = command.Substring(endOfCommandName + 1);

            if (!commandParams.Contains(" | ") && (commandName == "AddEvent" || commandName == "ListEvents"))
            {
                throw new FormatException("Invalid command parametars. Parametars should be separeted with ' | '.");
            }

            var commandArguments = commandParams.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                commandParams = commandArguments[i];
                commandArguments[i] = commandParams.Trim();
            }

            CommandType currandCommandType;
            switch (commandName)
            {
                case "AddEvent":
                    currandCommandType = CommandType.AddEvent;
                    break;
                case "DeleteEvents":
                    currandCommandType = CommandType.DeleteEvents;
                    break;
                case "ListEvents":
                    currandCommandType = CommandType.ListEvents;
                    break;
                default:
                    throw new ArgumentException("Wrong command type!");
            }

            var commandFull = new Command(currandCommandType, commandArguments);

            return commandFull;
        }
    }
}
