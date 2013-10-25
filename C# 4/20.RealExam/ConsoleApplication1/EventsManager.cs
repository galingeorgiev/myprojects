namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;
    using MD = Wintellect.PowerCollections.MultiDictionary<string, Event>;

    public class EventsManager : IEventsManager
    {
        private readonly MD titleEventsDictionary = new MD(true);
        private readonly OrderedMultiDictionary<DateTime, Event> dateTimeEventsDictionary = new OrderedMultiDictionary<DateTime, Event>(true);

        public void AddEvent(Event currentEvent)
        {
            string eventTitleLowerCase = currentEvent.Title.ToLowerInvariant();
            this.titleEventsDictionary.Add(eventTitleLowerCase, currentEvent);
            this.dateTimeEventsDictionary.Add(currentEvent.Date, currentEvent);
        }

        public int DeleteEventsByTitle(string title)
        {
            string processedTitle = title.ToLowerInvariant();

            // Bottleneck is here, because we create ICollection (listOfEvents) and
            // after that we pass through every element in this collection.
            // I have no time to try to fix this problem.
            var listOfEvents = this.titleEventsDictionary[processedTitle];
            int count = listOfEvents.Count;

            foreach (var events in listOfEvents)
            {
                this.dateTimeEventsDictionary.Remove(events.Date, events);
            }

            this.titleEventsDictionary.Remove(processedTitle);

            return count;
        }

        public IEnumerable<Event> ListEvents(DateTime fromDate, int count)
        {
            var matchedEvents = from e in this.dateTimeEventsDictionary.RangeFrom(fromDate, true).Values
                                where e.Date >= fromDate
                                orderby e.Date, e.Title, e.Location
                                select e;
            var events = matchedEvents.Take(count);

            return events;
        }
    }
}