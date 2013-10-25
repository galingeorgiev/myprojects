/* Write a program based on dynamic programming to solve the 
 * "Knapsack Problem": you are given N products, each has 
 * weight Wi and costs Ci and a knapsack of capacity M and 
 * you want to put inside a subset of the products with highest
 * cost and weight ≤ M. The numbers N, M, Wi and Ci are integers
 * in the range [1..500].
 * 
 * Example: M=10 kg, N=6, products:
 * beer – weight=3, cost=2
 * vodka – weight=8, cost=12
 * cheese – weight=4, cost=5
 * nuts – weight=1, cost=4
 * ham – weight=2, cost=3
 * whiskey – weight=8, cost=13
 * 
 * Optimal solution:
 * nuts + whiskey
 * weight = 9
 * cost = 17
 */

namespace KnapsackProblem
{
    using System;

    public class KnapsackProblem
    {
        public static void Main()
        {
            int knapsackCapacity = 10;
            int numberOfProducts = 6;
            Product beer = new Product("Beer", 3, 2);
            Product vodka = new Product("Vodka", 8, 12);
            Product cheese = new Product("Cheese", 4, 5);
            Product nuts = new Product("Nuts", 1, 4);
            Product ham = new Product("Ham", 2, 3);
            Product whiskey = new Product("Whiskey", 8, 13);
            Product[] products = new Product[] { beer, vodka, cheese, nuts, ham, whiskey };

            int[,] results = new int[numberOfProducts, knapsackCapacity];
            int[,] keepProducts = new int[numberOfProducts, knapsackCapacity];

            for (int i = 1; i < numberOfProducts; i++)
            {
                for (int j = 0; j < knapsackCapacity; j++)
                {
                    if (j >= products[i].Weight)
                    {
                        results[i, j] = Math.Max(results[i - 1, j], results[i - 1, j - products[i].Weight] + products[i].Cost);
                        keepProducts[i, j] = 1;
                    }
                    else
                    {
                        results[i, j] = results[i - 1, j];
                    }
                }
            }

            int currentKnapsackCapacity = knapsackCapacity;

            for (int i = numberOfProducts  - 1; i > 0; i--)
            {
                if (keepProducts[i, currentKnapsackCapacity - 1] == 1)
                {
                    Console.WriteLine(products[i]);
                    currentKnapsackCapacity = currentKnapsackCapacity - products[i].Weight;
                }
            }
        }
    }
}
