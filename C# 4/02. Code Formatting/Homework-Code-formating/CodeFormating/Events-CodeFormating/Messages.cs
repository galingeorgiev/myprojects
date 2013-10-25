using System;
using System.Text;

namespace EventsCodeFormating
{
    internal static class Messages
    {
        private static StringBuilder output = new StringBuilder();

        public static StringBuilder POutput
        {
            get
            {
                return output;
            }

            set
            {
                output = value;
            }
        }

        public static void EventAdded()
        {
            output.Append("Event added" + Environment.NewLine);
        }

        public static void EventDeleted(int quantity)
        {
            if (quantity == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted", quantity);
                output.Append(Environment.NewLine);
            }
        }

        public static void NoEventsFound()
        {
            output.Append("No events found" + Environment.NewLine);
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + Environment.NewLine);
            }
        }

        // Added new method to return output. Heretofore is used global variable, but this is wrong.
        public static string GetEventOutput()
        {
            return output.ToString();
        }
    }
}