using System;

namespace _04.PrintSomeNumbers
{
    class Program
    {
        static void Main()
        {
            short[] someNumbers = { 1, 101, 1001 };
            foreach (var number in someNumbers)
            {
                Console.WriteLine("{0}",number);
            }
        }
    }
}
