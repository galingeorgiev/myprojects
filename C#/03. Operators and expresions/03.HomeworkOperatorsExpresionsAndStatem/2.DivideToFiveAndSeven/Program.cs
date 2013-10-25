using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.DivideToFiveAndSeven
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter a number: ");
            int checkedNumber = int.Parse(Console.ReadLine());

            if (checkedNumber % 5 == 0 && checkedNumber % 7 == 0)
            {
                Console.WriteLine("The number is divide to 5 and 7.");
            }
            else
            {
                Console.WriteLine("The number is don't divide to 5 and 7.");
            }
        }
    }
}
