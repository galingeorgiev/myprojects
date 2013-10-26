namespace WcfServiceDateTimeUtils
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Threading;

    [DataContract]
    public class ServiceDateTimeUtil : IServiceDateTimeUtil
    {
        public string GetDayOfWeek(DateTime date)
        {
            CultureInfo bg = new CultureInfo("bg-BG");
            string dayOfWeek = bg.DateTimeFormat.DayNames[(int)date.DayOfWeek];

            return dayOfWeek;
        }
    }
}
