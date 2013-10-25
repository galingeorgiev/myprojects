using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.BoolBitIsZeroOrOne
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Please enter position: ");
            int bitPosition = int.Parse(Console.ReadLine());
            int mask = 1 << bitPosition;
            int numberAndMask = number & mask;
            int thirdBit = numberAndMask >> bitPosition;
            bool someBit = Convert.ToBoolean(thirdBit);
            Console.WriteLine("Is bit on position {0} is 1: {1}", bitPosition, someBit);
        }
    }
}