using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CheckThirdDigit
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter a number: ");
            int checkedNumber = int.Parse(Console.ReadLine());
            int tempValue = checkedNumber / 100;
            int thirdDigitIs = tempValue % 10;
            Console.WriteLine("Third digit from right to left in number {0} is {1}.", checkedNumber, thirdDigitIs);
        }
    }
}
