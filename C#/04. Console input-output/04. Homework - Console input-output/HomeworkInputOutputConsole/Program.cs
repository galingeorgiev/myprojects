using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkInputOutputConsole
{
    class Program
    {
        static double NumberValidetion(string n)
        {
            double firstNumber = 0;
            while (double.TryParse(n, out firstNumber) == false)
            {
                Console.WriteLine("Please enter valid value for N.\nYou can check you culture!");
                Console.Write("Please enter corect value = ");
                n = Console.ReadLine();
            }
            return firstNumber;
        }

        static void Main()
        {
            Console.Write("Please enter first number N1 = ");
            string n1 = Console.ReadLine();
            double numberOne = NumberValidetion(n1);

            Console.Write("Please enter first number N2 = ");
            string n2 = Console.ReadLine();
            double numberTwo = NumberValidetion(n2);

            Console.Write("Please enter first number N3 = ");
            string n3 = Console.ReadLine();
            double numberThree = NumberValidetion(n3);

            double sum = numberOne + numberTwo + numberThree;
            Console.WriteLine("Result of sum is: {0}", sum);
        }
    }
}
