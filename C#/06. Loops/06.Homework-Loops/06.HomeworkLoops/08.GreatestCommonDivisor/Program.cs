using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.GreatestCommonDivisor
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Please enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            int tempForReplace = 0;
            if (firstNumber < secondNumber)
            {
                tempForReplace = secondNumber;
                secondNumber = firstNumber;
                firstNumber = tempForReplace;
            }
            Console.WriteLine(firstNumber);
            Console.WriteLine(secondNumber);
            int remainder = firstNumber % secondNumber;
            while (remainder != 0)
            {
                firstNumber = secondNumber;
                secondNumber = remainder;
                remainder = firstNumber % secondNumber;
            }
            Console.WriteLine("Greatest common divisor is {0}", secondNumber);
        }
    }
}
