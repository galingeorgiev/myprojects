using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _05.CompareTwoNumbersWithoutIF
{
    class Program
    {
        static double NumberValidetion(string n)
        {
            double firstNumber = 0;
            while (double.TryParse(n, out firstNumber) == false)
            {
                Console.WriteLine("Please enter valid value.\nYou can check you culture!");
                Console.Write("Please enter corect value = ");
                n = Console.ReadLine();
            }
            return firstNumber;
        }

        static void Main()
        {
            Console.Write("Please enter value 1: ");
            string stringFirstValue = Console.ReadLine();
            double firstValue = NumberValidetion(stringFirstValue);

            Console.Write("Please enter value 2: ");
            string stringSecondValue = Console.ReadLine();
            double secondValue = NumberValidetion(stringSecondValue);

            Console.WriteLine("Bigger from {0} and {1} is {2}.",firstValue,secondValue,Math.Max(firstValue,secondValue));
        }
    }
}
