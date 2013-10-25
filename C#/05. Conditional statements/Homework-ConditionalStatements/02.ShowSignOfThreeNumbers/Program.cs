using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ShowSignOfThreeNumbers
{
    class Program
    {
        static void Main()
        {

            int firstVar = int.Parse(Console.ReadLine());
            int secondVar = int.Parse(Console.ReadLine());
            int thirdVar = int.Parse(Console.ReadLine());

            bool first = firstVar > 0;
            bool second = secondVar > 0;
            bool third = thirdVar > 0;

            bool[] boolArr = { first, second, third };

            int counter = 0;

            for (int i = 0; i < 3; i++)
            {
                if (firstVar == 0 | secondVar == 0 | thirdVar == 0)
                {
                    counter = counter + 2;
                }
                else
                {
                    if (boolArr[i])
                    {
                        counter++;
                    }
                }
            }

            switch (counter)
            {
                case 0: //3-
                    Console.WriteLine("Sign is '-'");
                    break;
                case 1: // 1-
                    Console.WriteLine("Sign is '+'");
                    break;
                case 2: // 2-
                    Console.WriteLine("Sign is '-'");
                    break;
                case 3: //3+
                    Console.WriteLine("Sign is '+'");
                    break;
                default:
                    Console.WriteLine("Result is zero");
                    break;
            }
        }
    }
}
