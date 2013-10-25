namespace RefactorCodeIfStat
{
    using System;

    public class Program
    {
        public static void Main()
        {
            const int SpecialValue = 666;
            int expectedValue = 100;
            int[] array = new int[100];
            int searchedValue = 0;
            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        i = SpecialValue;
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                }

                searchedValue = i;
            }

            // More code here
            if (searchedValue == SpecialValue)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
