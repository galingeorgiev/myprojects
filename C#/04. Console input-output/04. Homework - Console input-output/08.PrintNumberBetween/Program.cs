using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.PrintNumberBetween
{
    class Program
    {
        static int NumberValidetion(string n)
        {
            int firstNumber = 0;
            while (int.TryParse(n, out firstNumber) == false)
            {
                Console.WriteLine("Please enter valid value for N.\nYou can check you culture!");
                Console.Write("Please enter corect value = ");
                n = Console.ReadLine();
            }
            return firstNumber;
        }
        static void Main()
        {
            Console.Write("Please enter end of interval: ");
            string stringEndOfInterval = Console.ReadLine();
            int endOfInterval = NumberValidetion(stringEndOfInterval);
            for (int i = 1; i <= endOfInterval; i++)
            {
                Console.WriteLine("{0}", i);
            }
        }
    }
}
