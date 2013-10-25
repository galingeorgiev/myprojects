/*Implement a set of extension methods for IEnumerable<T> that implement
 *the following group functions: sum, product, min, max, average.*/

using System;
using System.Collections.Generic;

namespace _2.IEnumerableExtensions
{
    class TestIEnumerableExtensions
    {
        static void Main()
        {
            List<string> stringList = new List<string>()
            {
                "Academy", "Telerik", "Nakov", "Svetlin", "Kostov", "Kolev"
            };

            List<int> intList = new List<int>()
            {
                1, 2, 3, 4, 5
            };

            //Sum tests
            int sumOfIntElements = intList.Sum();
            Console.WriteLine("-----Sum of ints-----");
            Console.WriteLine(sumOfIntElements);

            string sumOfStrings = stringList.Sum();
            Console.WriteLine("\n-----Sum of strings-----");
            Console.WriteLine(sumOfStrings);

            //Product test
            int productOfIntElements = intList.Product();
            Console.WriteLine("\n-----Product of ints-----");
            Console.WriteLine(productOfIntElements);

            //string productOfStrings = stringList.Product(); // Compile time error because i have constraints. 
            Console.WriteLine("\n-----Product of strings-----");
            Console.WriteLine("Compile time error!");

            //Min test
            int minOfIntElements = intList.Min();
            Console.WriteLine("\n-----Min of ints-----");
            Console.WriteLine(minOfIntElements);

            string minOfStrings = stringList.Min();
            Console.WriteLine("\n-----Min of strings-----");
            Console.WriteLine(minOfStrings);

            //Max test
            int maxOfIntElements = intList.Max();
            Console.WriteLine("\n-----Max of ints-----");
            Console.WriteLine(maxOfIntElements);

            string maxOfStrings = stringList.Max();
            Console.WriteLine("\n-----Max of strings-----");
            Console.WriteLine(maxOfStrings);

            //Average test
            int averageOfIntElements = intList.Average();
            Console.WriteLine("\n-----Average of ints-----");
            Console.WriteLine(averageOfIntElements);

            //string averageOfStrings = stringList.Average(); // Compile time error because i have constraints. 
            Console.WriteLine("\n-----Average of strings-----");
            Console.WriteLine("Compile time error!");
            Console.WriteLine();
        }
    }
}