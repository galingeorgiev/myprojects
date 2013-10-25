using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.IsPrime
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter checked number: ");
            int checkedNumber = int.Parse(Console.ReadLine());
            int borderOfValues = (int)Math.Sqrt(checkedNumber);
            bool isNotPrime = false;
            for (int i = 2; i <= borderOfValues; i++)
            {
                if (checkedNumber % i == 0)
                {
                    isNotPrime = true;
                    break;
                }
            }
            if (isNotPrime)
            {
                Console.WriteLine("Number isn't prime.");
            }
            else
            {
                Console.WriteLine("Number is prime.");
            }
        }
    }
}
