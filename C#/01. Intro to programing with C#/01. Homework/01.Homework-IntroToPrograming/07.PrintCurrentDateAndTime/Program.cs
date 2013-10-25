using System;

namespace _07.PrintCurrentDateAndTime
{
    class Program
    {
        static void Main()
        {
            DateTime dateNow = DateTime.Now;
            DateTime timeNow = DateTime.Now;
            Console.WriteLine("Today is: {0:dd.MM.yyyy}\nThe time is: {1:HH:mm:ss}",dateNow,timeNow);
        }
    }
}
