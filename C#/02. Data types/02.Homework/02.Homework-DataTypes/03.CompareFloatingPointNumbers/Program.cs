using System;

namespace _03.CompareFloatingPointNumbers
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter value for A: ");
            double firstCompareNumber = double.Parse(Console.ReadLine());
            Console.Write("Please enter value for B: ");
            double SecondCompareNumber = double.Parse(Console.ReadLine());
            if (firstCompareNumber>SecondCompareNumber)
            {
                Console.WriteLine("{0} is bigger than {1}.",firstCompareNumber,SecondCompareNumber);
            }
            else if (firstCompareNumber<SecondCompareNumber)
            {
                Console.WriteLine("{0} is bigger than {1}.",SecondCompareNumber,firstCompareNumber);
            }
            else
            {
                Console.WriteLine("{0} is equal to {1}.",firstCompareNumber,SecondCompareNumber);
            }
        }
    }
}
