using System;

namespace _04.HexadecimalInInteger
{
    class Program
    {
        static void Main()
        {
            int hexadecimalValue = 0xfe;
            Console.WriteLine("Decimal value: {0}",hexadecimalValue);
            Console.WriteLine("Hexadecimal value: {0:x}",hexadecimalValue);
        }
    }
}
