using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ChangeBitOnPosition
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter number n= ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Please enter position p= ");
            int bitPosition = int.Parse(Console.ReadLine());
            Console.Write("Please enter value on position v= ");
            int bitValueOnPosition = int.Parse(Console.ReadLine());
            int mask = 1 << bitPosition;
            int numberAndMask = number | mask;
            int someBit = number >> bitPosition;
            if (someBit == bitValueOnPosition)
            {
                Console.WriteLine("Bit on position {0} is equal to v.", bitPosition);
            }
            else
            {
                if (someBit == 1)
                {
                    int updatedValue = (number & (~mask));
                    Console.WriteLine(updatedValue);
                }
                else
                {
                    int updatedValue = number | mask;
                    Console.WriteLine(updatedValue);
                }
            }
        }
    }
}
