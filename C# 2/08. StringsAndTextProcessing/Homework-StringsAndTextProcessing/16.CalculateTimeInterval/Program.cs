using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string formatString = "d.M.yyyy";
        Console.Write("Enter the first date: ");
        string firstDate = Console.ReadLine();
        DateTime firstDateTime = DateTime.ParseExact(firstDate,formatString,CultureInfo.InvariantCulture);
        Console.Write("Enter the second date: ");
        string secondDate = Console.ReadLine();
        DateTime secondDateTime = DateTime.ParseExact(secondDate, formatString, CultureInfo.InvariantCulture);

        int result = (secondDateTime - firstDateTime).Days;
        if (result < 0)
        {
            Console.WriteLine("Second date is before first!");
        }
        else
        {
            Console.WriteLine("Distance: {0} days", result);
        }
    }
}