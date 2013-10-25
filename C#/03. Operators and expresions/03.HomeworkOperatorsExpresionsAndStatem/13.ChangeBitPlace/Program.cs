using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.ChangeBitPlace
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter number n= ");
            int number = int.Parse(Console.ReadLine());

            int bitPosition3 = 3;
            int bitPosition4 = 4;
            int bitPosition5 = 5;
            int bitPosition24 = 24;
            int bitPosition25 = 25;
            int bitPosition26 = 26;

            int mask3 = 1 << bitPosition3;
            int numberAndMask3 = number & mask3;
            int bitOnPosition3 = numberAndMask3 >> bitPosition3;

            int mask4 = 1 << bitPosition4;
            int numberAndMask4 = number & mask4;
            int bitOnPosition4 = numberAndMask4 >> bitPosition4;

            int mask5 = 1 << bitPosition5;
            int numberAndMask5 = number & mask5;
            int bitOnPosition5 = numberAndMask5 >> bitPosition5;

            int mask24 = 1 << bitPosition24;
            int numberAndMask24 = number & mask24;
            int bitOnPosition24 = numberAndMask24 >> bitPosition24;

            int mask25 = 1 << bitPosition25;
            int numberAndMask25 = number & mask25;
            int bitOnPosition25 = numberAndMask25 >> bitPosition25;

            int mask26 = 1 << bitPosition26;
            int numberAndMask26 = number & mask26;
            int bitOnPosition26 = numberAndMask26 >> bitPosition26;

            if (bitOnPosition3 != bitOnPosition24)
            {
                if (bitOnPosition3 == 0)
                {
                    int maskChangeValue1 = 1 << bitPosition3;
                    number = number | maskChangeValue1;
                    int maskChangeValue2 = ~(1 << bitPosition24);
                    number = number & maskChangeValue2;
                }
                else
                {
                    int maskChangeValue1 = ~(1 << bitPosition3);
                    number = number & maskChangeValue1;
                    int maskChangeValue2 = 1 << bitPosition24;
                    number = number | maskChangeValue2;
                }
            }

            if (bitOnPosition4 != bitOnPosition25)
            {
                if (bitOnPosition4 == 0)
                {
                    int maskChangeValue1 = 1 << bitPosition4;
                    number = number | maskChangeValue1;
                    int maskChangeValue2 = ~(1 << bitPosition25);
                    number = number & maskChangeValue2;
                }
                else
                {
                    int maskChangeValue1 = ~(1 << bitPosition4);
                    number = number & maskChangeValue1;
                    int maskChangeValue2 = 1 << bitPosition25;
                    number = number | maskChangeValue2;
                }
            }

            if (bitOnPosition5 != bitOnPosition26)
            {
                if (bitOnPosition5 == 0)
                {
                    int maskChangeValue1 = 1 << bitPosition5;
                    number = number | maskChangeValue1;
                    int maskChangeValue2 = ~(1 << bitPosition26);
                    number = number & maskChangeValue2;
                }
                else
                {
                    int maskChangeValue1 = ~(1 << bitPosition5);
                    number = number & maskChangeValue1;
                    int maskChangeValue2 = 1 << bitPosition26;
                    number = number | maskChangeValue2;
                }
            }
            Console.WriteLine(number);
        }
    }
}
