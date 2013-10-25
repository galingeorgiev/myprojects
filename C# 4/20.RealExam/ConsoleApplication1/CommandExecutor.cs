namespace CalendarSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class CommandExecutor
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        private readonly IEventsManager eventManager;

        public CommandExecutor(IEventsManager eventManager)
        {
            this.eventManager = eventManager;
        }

        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventManager;
            }
        }

        public string ProcessCommand(Command currentCommand)
        {
            switch (currentCommand.CommandName)
            {
                case CommandType.AddEvent:
                    return this.AddEvent(currentCommand);

                case CommandType.DeleteEvents:
                    return this.DeleteEvents(currentCommand);

                case CommandType.ListEvents:
                    return this.ListEvents(currentCommand);

                default:
                    throw new ArgumentException("Wrong command name!");
            }
        }
  
        private string AddEvent(Command currentCommand)
        {
            string eventDate = currentCommand.Parametars[0];
            var date = DateTime.ParseExact(eventDate, DateTimeFormat, CultureInfo.InvariantCulture);
            var title = currentCommand.Parametars[1];
            
            if (currentCommand.Parametars.Length == 2)
            {
                var currentEvent = new Event(date, title);
                this.eventManager.AddEvent(currentEvent);
            }
            else if (currentCommand.Parametars.Length == 3)
            {
                var location = currentCommand.Parametars[2];
                var currentEvent = new Event(date, title, location);
                this.eventManager.AddEvent(currentEvent);
            }

            string output = "Event added";
            return output;
        }

        private string DeleteEvents(Command currentCommand)
        {
            string dateForDalete = currentCommand.Parametars[0];
            int count = this.eventManager.DeleteEventsByTitle(dateForDalete);

            string output;
            if (count == 0)
            {
                output = "No events found";
            }
            else
            {
                output = count + " events deleted";
            }

            return output;
        }
  
        private string ListEvents(Command currentCommand)
        {
            string dateForSearch = currentCommand.Parametars[0];
            var parsedDate = DateTime.ParseExact(dateForSearch, DateTimeFormat, CultureInfo.InvariantCulture);
            string countStr = currentCommand.Parametars[1];
            var count = int.Parse(countStr);
            var events = this.eventManager.ListEvents(parsedDate, count).ToList();
            var output = new StringBuilder();

            if (events.Any())
            {
                foreach (var e in events)
                {
                    output.AppendLine(e.ToString());
                }
            }
            else
            {
                output.AppendLine("No events found");
            }

            string processedOutput = output.ToString().Trim();
            return processedOutput;
        }
    }
}
