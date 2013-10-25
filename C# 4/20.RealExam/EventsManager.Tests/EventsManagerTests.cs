namespace EventsManager.Tests
{
    using CalendarSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    [TestClass]
    public class EventsManagerTests
    {
        // Invalid event is not posible.
        [TestMethod]
        [Timeout(300)]
        public void AddEvent_ValidInput()
        {
            string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
            string date = "2012-01-21T20:00:00";
            DateTime eventDate = DateTime.ParseExact(date, dateTimeFormat, CultureInfo.InvariantCulture);
            string eventTitle = "party Viki";
            Event currentEvent = new Event(eventDate, eventTitle);

            EventsManager currentEventManager = new EventsManager();
            currentEventManager.AddEvent(currentEvent);

            IEnumerable<Event> actualOutputList = currentEventManager.ListEvents(eventDate, 5);
            int numberOfAddedEvents = actualOutputList.Count();
            bool isCountValid = numberOfAddedEvents == 1;

            bool isOutputEventValid = actualOutputList.First() == currentEvent;

            bool isAddCorrect = isCountValid && isOutputEventValid;

            Assert.IsTrue(isAddCorrect, "Adding valid event is incorect.");
        }

        [TestMethod]
        [Timeout(300)]
        public void DeleteEventsByTitle_ValidInputAndValidDeleting()
        {
            string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
            int numberOfAddedEvents = 50;
            int numberOfOtherEvents = 20;

            string date = "2012-01-21T20:00:00";
            DateTime eventDate = DateTime.ParseExact(date, dateTimeFormat, CultureInfo.InvariantCulture);
            string eventTitle = "party Viki";
            Event currentEvent = new Event(eventDate, eventTitle);

            EventsManager currentEventManager = new EventsManager();
            for (int i = 0; i < numberOfAddedEvents; i++)
            {
                currentEventManager.AddEvent(currentEvent);
            }

            string otherDate = "2015-01-21T20:00:00";
            DateTime otherEventDate = DateTime.ParseExact(otherDate, dateTimeFormat, CultureInfo.InvariantCulture);
            string otherEventTitle = "C# exam";
            Event otherEvent = new Event(otherEventDate, otherEventTitle);
            for (int i = 0; i < numberOfOtherEvents; i++)
            {
                currentEventManager.AddEvent(otherEvent);
            }

            int deletedEvents = currentEventManager.DeleteEventsByTitle(eventTitle);
            bool isNumberOfDeletedEventsCorrect = deletedEvents == numberOfAddedEvents;

            Assert.IsTrue(isNumberOfDeletedEventsCorrect, "Number of deleted events is incorect!");
        }

        [TestMethod]
        [Timeout(300)]
        public void ListEvents_CountIsBigger()
        {
            string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
            int numberOfAddedEvents = 50;
            int numberOfOtherEvents = 20;

            string date = "2012-01-21T20:00:00";
            DateTime eventDate = DateTime.ParseExact(date, dateTimeFormat, CultureInfo.InvariantCulture);
            string eventTitle = "party Viki";
            Event currentEvent = new Event(eventDate, eventTitle);

            EventsManager currentEventManager = new EventsManager();
            for (int i = 0; i < numberOfAddedEvents; i++)
            {
                currentEventManager.AddEvent(currentEvent);
            }

            string otherDate = "2015-01-21T20:00:00";
            DateTime otherEventDate = DateTime.ParseExact(otherDate, dateTimeFormat, CultureInfo.InvariantCulture);
            string otherEventTitle = "C# exam";
            Event otherEvent = new Event(otherEventDate, otherEventTitle);
            for (int i = 0; i < numberOfOtherEvents; i++)
            {
                currentEventManager.AddEvent(otherEvent);
            }

            IEnumerable<Event> foundEvents = currentEventManager.ListEvents(eventDate, 20);
            bool isNumberOfFoundEventsCorrect = foundEvents.Count() == 20;

            Assert.IsTrue(isNumberOfFoundEventsCorrect, "Number of found events is incorect!");
        }

        [TestMethod]
        [Timeout(300)]
        public void ListEvents_CountIsLess()
        {
            string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
            int numberOfAddedEvents = 50;
            int numberOfOtherEvents = 20;

            string date = "2012-01-21T20:00:00";
            DateTime eventDate = DateTime.ParseExact(date, dateTimeFormat, CultureInfo.InvariantCulture);
            string eventTitle = "party Viki";
            Event currentEvent = new Event(eventDate, eventTitle);

            EventsManager currentEventManager = new EventsManager();
            for (int i = 0; i < numberOfAddedEvents; i++)
            {
                currentEventManager.AddEvent(currentEvent);
            }

            string otherDate = "2015-01-21T20:00:00";
            DateTime otherEventDate = DateTime.ParseExact(otherDate, dateTimeFormat, CultureInfo.InvariantCulture);
            string otherEventTitle = "C# exam";
            Event otherEvent = new Event(otherEventDate, otherEventTitle);
            for (int i = 0; i < numberOfOtherEvents; i++)
            {
                currentEventManager.AddEvent(otherEvent);
            }

            IEnumerable<Event> foundEvents = currentEventManager.ListEvents(eventDate, 100);
            bool isNumberOfFoundEventsCorrect = foundEvents.Count() == (numberOfAddedEvents + numberOfOtherEvents);

            Assert.IsTrue(isNumberOfFoundEventsCorrect, "Number of found events is incorect!");
        }

        [TestMethod]
        [Timeout(300)]
        public void DeleteEventsByTitle_NonexistentTitle()
        {
            string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
            int numberOfAddedEvents = 50;
            int numberOfOtherEvents = 20;

            string date = "2012-01-21T20:00:00";
            DateTime eventDate = DateTime.ParseExact(date, dateTimeFormat, CultureInfo.InvariantCulture);
            string eventTitle = "party Viki";
            Event currentEvent = new Event(eventDate, eventTitle);

            EventsManager currentEventManager = new EventsManager();
            for (int i = 0; i < numberOfAddedEvents; i++)
            {
                currentEventManager.AddEvent(currentEvent);
            }

            string otherDate = "2015-01-21T20:00:00";
            DateTime otherEventDate = DateTime.ParseExact(otherDate, dateTimeFormat, CultureInfo.InvariantCulture);
            string otherEventTitle = "C# exam";
            Event otherEvent = new Event(otherEventDate, otherEventTitle);
            for (int i = 0; i < numberOfOtherEvents; i++)
            {
                currentEventManager.AddEvent(otherEvent);
            }

            int deletedEvents = currentEventManager.DeleteEventsByTitle("WrongTitle");
            bool isNumberOfDeletedEventsCorrect = deletedEvents == 0;

            Assert.IsTrue(isNumberOfDeletedEventsCorrect, "Number of deleted events is incorect!");
        }

        [TestMethod]
        [Timeout(300)]
        public void ListEvents_NoEventsAfterThisDate()
        {
            string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
            int numberOfAddedEvents = 50;

            string date = "2012-01-21T20:00:00";
            DateTime eventDate = DateTime.ParseExact(date, dateTimeFormat, CultureInfo.InvariantCulture);
            string eventTitle = "party Viki";
            Event currentEvent = new Event(eventDate, eventTitle);

            EventsManager currentEventManager = new EventsManager();
            for (int i = 0; i < numberOfAddedEvents; i++)
            {
                currentEventManager.AddEvent(currentEvent);
            }

            // This date is after 'eventDate'.
            string otherDate = "2015-01-21T20:00:00";
            DateTime otherEventDate = DateTime.ParseExact(otherDate, dateTimeFormat, CultureInfo.InvariantCulture);

            IEnumerable<Event> foundEvents = currentEventManager.ListEvents(otherEventDate, 100);
            bool isNumberOfFoundEventsCorrect = foundEvents.Count() == 0;

            Assert.IsTrue(isNumberOfFoundEventsCorrect, "Number of found events is incorect!");
        }

        [TestMethod]
        [Timeout(300)]
        public void ListEvents_GetZeroEvents()
        {
            string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
            int numberOfAddedEvents = 50;

            string date = "2012-01-21T20:00:00";
            DateTime eventDate = DateTime.ParseExact(date, dateTimeFormat, CultureInfo.InvariantCulture);
            string eventTitle = "party Viki";
            Event currentEvent = new Event(eventDate, eventTitle);

            EventsManager currentEventManager = new EventsManager();
            for (int i = 0; i < numberOfAddedEvents; i++)
            {
                currentEventManager.AddEvent(currentEvent);
            }

            IEnumerable<Event> foundEvents = currentEventManager.ListEvents(eventDate, 0);
            bool isNumberOfFoundEventsCorrect = foundEvents.Count() == 0;

            Assert.IsTrue(isNumberOfFoundEventsCorrect, "Number of found events is incorect!");
        }

        [TestMethod]
        [Timeout(300)]
        public void ListEvents_HaveFiftyAndGetFifty()
        {
            string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
            int numberOfAddedEvents = 50;
            int numberOfOtherEvents = 20;

            string date = "2012-01-21T20:00:00";
            DateTime eventDate = DateTime.ParseExact(date, dateTimeFormat, CultureInfo.InvariantCulture);
            string eventTitle = "party Viki";
            Event currentEvent = new Event(eventDate, eventTitle);

            EventsManager currentEventManager = new EventsManager();
            for (int i = 0; i < numberOfAddedEvents; i++)
            {
                currentEventManager.AddEvent(currentEvent);
            }

            string otherDate = "2015-01-21T20:00:00";
            DateTime otherEventDate = DateTime.ParseExact(otherDate, dateTimeFormat, CultureInfo.InvariantCulture);
            string otherEventTitle = "C# exam";
            Event otherEvent = new Event(otherEventDate, otherEventTitle);
            for (int i = 0; i < numberOfOtherEvents; i++)
            {
                currentEventManager.AddEvent(otherEvent);
            }

            IEnumerable<Event> foundEvents = currentEventManager.ListEvents(eventDate, numberOfAddedEvents);
            bool isNumberOfFoundEventsCorrect = foundEvents.Count() == numberOfAddedEvents;

            Assert.IsTrue(isNumberOfFoundEventsCorrect, "Number of found events is incorect!");
        }
    }
}