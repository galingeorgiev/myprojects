using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ExchangeNumbersValue
{
    class Program
    {
        static void Main()
        {
            int firstVar = int.Parse(Console.ReadLine());
            int secondVar = int.Parse(Console.ReadLine());

            if (firstVar > secondVar)
            {
                int temp = 0;
                temp = secondVar;
                secondVar = firstVar;
                firstVar = temp;
            }
            Console.WriteLine("First varible is: {0}\nSecond varible is: {1}", firstVar, secondVar);
        }
    }
}
