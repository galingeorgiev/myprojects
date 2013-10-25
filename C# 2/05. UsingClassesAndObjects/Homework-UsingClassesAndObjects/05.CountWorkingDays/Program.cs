using System;

class Program
{
    static void Main()
    {
        //Public holidays for 2013
        DateTime[] publicHolidays = new DateTime[] 
        {
            new DateTime(2013,1,1),
            new DateTime(2013,5,1),
            new DateTime(2013,5,2),
            new DateTime(2013,5,3),
            new DateTime(2013,5,6),
            new DateTime(2013,5,24),
            new DateTime(2013,9,6),
            new DateTime(2013,12,24),
            new DateTime(2013,12,25),
            new DateTime(2013,12,26),
            new DateTime(2013,12,31)
        };

        DateTime today = DateTime.Now;
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Enter month: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Enter day: ");
        int day = int.Parse(Console.ReadLine());
        DateTime endDate = new DateTime(year,month,day);

        int countWorkingDays = 0;
        int addDays = 0;

        while (true)
        {
            //Include last date.
            if (today.AddDays(addDays).Year == endDate.Year &
                today.AddDays(addDays).Month == endDate.Month &
                today.AddDays(addDays).Day > endDate.Day)
            {
                break;
            }

            if (today.AddDays(addDays).DayOfWeek == DayOfWeek.Monday |
                today.AddDays(addDays).DayOfWeek == DayOfWeek.Tuesday |
                today.AddDays(addDays).DayOfWeek == DayOfWeek.Wednesday |
                today.AddDays(addDays).DayOfWeek == DayOfWeek.Thursday |
                today.AddDays(addDays).DayOfWeek == DayOfWeek.Friday)
            {
                countWorkingDays++;
            }

            for (int i = 0; i < publicHolidays.Length; i++)
            {
                if (today.AddDays(addDays).Year == publicHolidays[i].Year & today.AddDays(addDays).Month == publicHolidays[i].Month & today.AddDays(addDays).Day == publicHolidays[i].Day)
                {
                    countWorkingDays--;
                }
            }
            addDays++;
        }
        Console.WriteLine("To {1}.{2}.{3} remain {0} days.",countWorkingDays,day,month,year);
    }
}