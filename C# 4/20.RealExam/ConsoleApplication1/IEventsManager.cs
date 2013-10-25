namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Tools for add, delete and search events.
    /// </summary>
    public interface IEventsManager
    {
        /// <summary>
        /// Adding event in ICollection.
        /// Allow duplicates events to be added.
        /// </summary>
        /// <param name="currentEvent">Event that will be added.</param>
        void AddEvent(Event currentEvent);

        /// <summary>
        /// Delete all events by his title.
        /// </summary>
        /// <param name="eventTitle">Title of events that will be deleted. Case insensitive manner.</param>
        /// <returns></returns>
        int DeleteEventsByTitle(string eventTitle);

        /// <summary>
        /// Find all events after specified date and time.
        /// </summary>
        /// <param name="fromDate">Date and time after which we want events.</param>
        /// <param name="count">Number of events after specified date that will be returned.</param>
        /// <returns>Return events after specified date with given count or less if not enough events are available.</returns>
        IEnumerable<Event> ListEvents(DateTime fromDate, int count);
    }
}
