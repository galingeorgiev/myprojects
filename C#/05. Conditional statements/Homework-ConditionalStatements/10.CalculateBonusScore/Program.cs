using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CalculateBonusScore
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter value in range [1-9]: ");
            int var = int.Parse(Console.ReadLine());
            int switchVar = 0;
            if (var >= 1 & var <= 3)
            {
                switchVar = 1;
            }
            else
            {
                if (var >= 4 & var <= 6)
                {
                    switchVar = 2;
                }
                else
                {
                    if (var >= 7 & var <= 9)
                    {
                        switchVar = 3;
                    }
                }
            }
            switch (switchVar)
            {
                case 1:
                    Console.WriteLine("{0}", var * 10);
                    break;
                case 2:
                    Console.WriteLine("{0}", var * 100);
                    break;
                case 3:
                    Console.WriteLine("{0}", var * 1000);
                    break;
                default:
                    Console.WriteLine("Please enter value between 1-9");
                    break;
            }
        }
    }
}
