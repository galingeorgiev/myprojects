using System;

namespace _09.PrintNumbers
{
    class Program
    {
        static void Main()
        {
            for (byte numberOfSequence = 0; numberOfSequence < 10; numberOfSequence++)
            {
                if (numberOfSequence % 2 == 0)
                {
                    int positiveNumbers = (numberOfSequence + 2);
                    Console.WriteLine("{0}", positiveNumbers);
                }
                else
                {
                    int negativeNumbers =  (numberOfSequence - ((2 * numberOfSequence) + 2));
                    Console.WriteLine("{0}", negativeNumbers);
                }
            }
        }
    }
}
