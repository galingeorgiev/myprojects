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
        string formatString = "d.M.yyyy h:m:ss";
        DateTime dateTimeNow = DateTime.Now;
        dateTimeNow = dateTimeNow.AddHours(6);
        dateTimeNow = dateTimeNow.AddMinutes(30);

        Console.WriteLine("After 6 hours and 30 minutes will be: {0:dddd d.M.yyyy h:m:ss} days", dateTimeNow);
        
    }
}