namespace CalendarSystem
{
    using System;

    public class Event : IComparable<Event>
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title)
        {
            this.Date = date;
            this.Title = title;
            this.location = null;
        }

        public Event(DateTime date, string title, string location) : this(date, title)
        {
            this.Location = location;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }
        
        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }

            string eventAsString = string.Format(form, this.Date, this.title, this.Location);
            return eventAsString;
        }

        public int CompareTo(Event other)
        {
            int compareResult = DateTime.Compare(this.Date, other.Date);

            if (compareResult == 0)
            {
                compareResult = string.Compare(this.title, other.title, StringComparison.Ordinal);
            }

            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Location, other.Location, StringComparison.Ordinal);
            }

            return compareResult;
        }
    }
}