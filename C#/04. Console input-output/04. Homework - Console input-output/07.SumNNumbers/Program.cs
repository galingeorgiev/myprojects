using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumNNumbers
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
            Console.Write("Please enter number of sumed values: ");
            string stringN = Console.ReadLine();
            int n = NumberValidetion(stringN);
            int resultOfSum = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.Write("Please enter value {0}: ", i);
                string stringReadedValue = Console.ReadLine();
                int readedValue = NumberValidetion(stringReadedValue);
                resultOfSum = resultOfSum + readedValue;
            }
            Console.WriteLine("Result of sum is: {0}", resultOfSum);
        }
    }
}
