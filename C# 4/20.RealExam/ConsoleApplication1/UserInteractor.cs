namespace CalendarSystem
{
    using System;

    public static class UserInteractor
    {
        public static void StartIteraction()
        {
            var eventManager = new EventsManager();
            var commandExecutor = new CommandExecutor(eventManager);

            while (true)
            {
                string currentLineCommand = Console.ReadLine();
                if (currentLineCommand == "End" || currentLineCommand == null)
                {
                    break;
                }

                try
                {
                    Console.WriteLine(commandExecutor.ProcessCommand(Command.Parse(currentLineCommand)));
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException("Command cannot be executed.\n{0}", ex);
                }
            }
        }
    }
}
