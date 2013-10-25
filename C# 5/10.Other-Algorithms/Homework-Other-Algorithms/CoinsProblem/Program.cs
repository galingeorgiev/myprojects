/* You are given a set of infinite number of coins (1, 2 and 5)
 * and end value – N. Write an algorithm that gives the number 
 * of coins needed so that the sum of the coins equals N. 
 * Example:
 * N = 33 => 6 coins x 5 + 1 coin x 2 + 1 coin x 1
 */

namespace CoinsProblem
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // Set of coins must be sorted by size to work algorithm correct.
            int[] setOfCoins = new int[] { 1, 2, 5 };
            int[] coinsCount = new int[setOfCoins[setOfCoins.Length - 1]];

            int n = 33;

            for (int i = 0; i < setOfCoins.Length; i++)
            {
                if (n / setOfCoins[setOfCoins.Length - i - 1] >= 1)
                {
                    coinsCount[setOfCoins[setOfCoins.Length - i - 1] - 1] = n / setOfCoins[setOfCoins.Length - i - 1];
                    n = n % setOfCoins[setOfCoins.Length - i - 1];
                }
            }

            for (int i = coinsCount.Length - 1; i >= 0; i--)
            {
                if (coinsCount[i] != 0)
                {
                    Console.WriteLine("{0} coins x {1}", coinsCount[i], i + 1);
                }
            }
        }
    }
}
