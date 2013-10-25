using System;

namespace _11.ExchangeValues
{
    class Program
    {
        static void Main()
        {
            int firstVarible = 5;
            int secondVarible = 10;
            int helpVarible = firstVarible + secondVarible;
            firstVarible = helpVarible - firstVarible;
            secondVarible = helpVarible - secondVarible;
        }
    }
}
