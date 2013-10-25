using System;

namespace _08.SquareOfNumber
{
    class Program
    {
        static void Main()
        {
            short numberSquare = 12345;
            int squareOfNumber = numberSquare * numberSquare;
            Console.WriteLine("12345 squared is {0:000,000,000}.", squareOfNumber);
        }
    }
}
