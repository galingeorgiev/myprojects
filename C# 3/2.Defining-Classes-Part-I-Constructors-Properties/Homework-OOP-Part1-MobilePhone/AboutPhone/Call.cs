/*Create a class Call to hold a call performed through
 *a GSM. It should contain date, time, dialed phone
 *number and duration (in seconds).*/

using System;

namespace AboutPhone
{
    public class Call
    {
        private DateTime date; // read only
        private DateTime time; // read only
        private string dialedNumber; // read only
        private int duration; // read only

        //Define Constructor
        public Call(DateTime date, DateTime time, string dialedNumber, int duration)
        {
            this.date = date;
            this.time = time;
            this.dialedNumber = dialedNumber;
            this.duration = duration;
        }

        //Define propreties
        public DateTime Date
        {
            get { return this.date; }
        }

        public DateTime Time
        {
            get { return this.time; }
        }

        public string DialedNumber
        {
            get { return this.dialedNumber; }
        }

        public int Duration
        {
            get { return this.duration; }
        }
    }
}
