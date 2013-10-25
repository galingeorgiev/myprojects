using System;

namespace VirtualShop
{
    public struct ExpirationDate
    {
        private int year;
        private byte month;
        private byte day;

        //Must check if date is incorect throw exception
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }

        public byte Month
        {
            get { return this.month; }
            set { this.month = value; }
        }

        public byte Day
        {
            get { return this.day; }
            set { this.day = value; }
        }
    }
}
