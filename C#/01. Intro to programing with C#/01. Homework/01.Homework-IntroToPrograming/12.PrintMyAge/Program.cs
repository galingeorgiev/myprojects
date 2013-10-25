using System;

namespace _12.PrintMyAge
{
    class Program
    {
        static void Main()
        {
            Console.Write("My age is: ");
            byte myAgeNow = byte.Parse(Console.ReadLine());
            byte myAgeAfter10Years = (byte)(myAgeNow + 10);
            Console.WriteLine("My age after 10 years will be {0}.", myAgeAfter10Years);
        }
    }
}
