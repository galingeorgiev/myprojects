/* Write a sample application that demonstrates the InvalidRangeException<int>
* and InvalidRangeException<DateTime> by entering numbers in the range [1..100]
* and dates in the range [1.1.1980 … 31.12.2013]. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.InvalidRangeException
{
    class TestInvalidRangeException
    {
        static void Main()
        {
            Console.WriteLine("----- Test InvalidRangeException<int> -----");
            int start = 0;
            int end = 100;
            Console.Write("Enter number between {0} and {1}: ", start, end);
            int number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end)
            {
                throw new InvalidRangeException<int>("Wrong number", start, end);
            }
            else
            {
                Console.WriteLine("You enter from console number: {0}", number);
            }

            Console.WriteLine("\n----- Test InvalidRangeException<DateTime> -----");
            DateTime startDate = new DateTime(1980,1,1);
            DateTime endDate = new DateTime(2013,12,31);

            Console.WriteLine("Enter new date in range [{0:dd.MM.yyyy} - {1:dd.MM.yyyy}]", startDate, endDate);
            Console.Write("day: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("year: ");
            int year = int.Parse(Console.ReadLine());
            DateTime readedFromConsoleDate = new DateTime(year, month, day);

            if (readedFromConsoleDate <= startDate || readedFromConsoleDate >= endDate)
            {
                string exceptionMessage = string.Format("Date is out of range [{0:dd.MM.yyyy} - {1:dd.MM.yyyy}]", startDate, endDate);
                throw new InvalidRangeException<DateTime>(exceptionMessage, startDate, endDate);
            }
            else
            {
                Console.WriteLine("You enter from console date: {0:dd.MM.yyyy}", readedFromConsoleDate);
            }
        }
    }
}