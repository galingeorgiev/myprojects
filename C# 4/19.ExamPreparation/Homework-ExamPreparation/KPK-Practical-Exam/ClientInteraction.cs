namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ClientInteraction
    {
        public static void StartInteraction()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor command = new CommandExecutor();
            IList<ICommand> commandForExecution = ReadCommands();

            foreach (ICommand item in commandForExecution)
            {
                command.ExecuteCommand(catalog, item, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadCommands()
        {
            List<ICommand> commands = new List<ICommand>();
            bool isCommandEnd = false;

            do
            {
                string cyrrentLineCommand = Console.ReadLine();
                isCommandEnd = (cyrrentLineCommand.Trim() == "End");
                if (!isCommandEnd)
                {
                    ICommand currentCommand = new Command(cyrrentLineCommand);
                    commands.Add(currentCommand);
                }
            }
            while (!isCommandEnd);

            return commands;
        }
    }
}
