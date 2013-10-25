using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.NumbersBetween
{
    class Program
    {
        static int NumberValidetion(string n)
        {
            int firstNumber = 0;
            while (int.TryParse(n, out firstNumber) == false)
            {
                Console.WriteLine("Please enter valid value.\nYou can check you culture!");
                Console.Write("Please enter corect value = ");
                n = Console.ReadLine();
            }
            return firstNumber;
        }

        static void Main()
        {
            Console.Write("Please enter first number: ");
            string stringFirstNumber = Console.ReadLine();
            int firstNumber = NumberValidetion(stringFirstNumber);

            Console.Write("Please enter second number: ");
            string stringSecondNumber = Console.ReadLine();
            int secondNumber = NumberValidetion(stringSecondNumber);

            int divToFive = 0;

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                if (i % 5 == 0)
                {
                    divToFive++;
                }
            }
            Console.WriteLine("Between {0} and {1} {2} numbers divides to 5 without residual.", firstNumber, secondNumber, divToFive);
        }
    }
}
