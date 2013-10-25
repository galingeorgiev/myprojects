/*Write a program that prints from given array of integers
 *all numbers that are divisible by 7 and 3. Use the built-in
 *extension methods and lambda expressions. Rewrite the same with LINQ.*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.DivisibleBy3and7
{
    class LINQDivisibleBy3and7
    {
        static void Main()
        {
            int[] numbers = new int[] { 84, 3, 7, 21, 42, 33, 2, 43, 54, 65, 63 };

            var resultLambda = numbers.ToList().FindAll(x => x % 3 == 0 && x % 7 == 0);
            Console.WriteLine("----------Lambda expresion result----------");
            foreach (var item in resultLambda)
            {
                Console.WriteLine(item);
            }

            var resultLINQ = from number in numbers
                             where number % 3 == 0 && number % 7 == 0
                             select number;

            Console.WriteLine("\n----------LINQ result----------");
            foreach (var item in resultLINQ)
            {
                Console.WriteLine(item);
            }
        }
    }
}
