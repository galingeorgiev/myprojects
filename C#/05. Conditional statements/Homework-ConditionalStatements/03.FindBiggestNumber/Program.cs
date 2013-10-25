using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FindBiggestNumber
{
    class Program
    {
        static void Main()
        {
            int firstVar = int.Parse(Console.ReadLine());
            int secondVar = int.Parse(Console.ReadLine());
            int thirdVar = int.Parse(Console.ReadLine());

            int temp = Math.Max(firstVar, secondVar);
            if (temp > thirdVar)
            {
                Console.WriteLine("Biggest value is {0}", temp);
            }
            else
            {
                if (temp < thirdVar)
                {
                    Console.WriteLine("Biggest value is {0}", thirdVar);
                }
                else
                {
                    if (firstVar == secondVar & secondVar == thirdVar)
                    {
                        Console.WriteLine("Varible are equals.");
                    }
                }
            }
        }
    }
}
