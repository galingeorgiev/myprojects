/* Write a program to calculate the "Minimum Edit Distance" (MED)
 * between two words. MED(x, y) is the minimal sum of costs of edit 
 * operations used to transform x to y.
 * 
 * Sample costs are given below:
 * cost (replace a letter) = 1
 * cost (delete a letter) = 0.9
 * cost (insert a letter) = 0.8
 * 
 * Example: 
 * x = "developer", y = "enveloped"  cost = 2.7 
 * delete ‘d’:  "developer"  "eveloper", cost = 0.9
 * insert ‘n’:  "eveloper"  "enveloper", cost = 0.8
 * replace ‘r’  ‘d’:  "enveloper"  "enveloped", cost = 1
 */

namespace MinimumEditDistance
{
    using System;

    public class MinimumEditDistance
    {
        public static double CalcMinimumEditDistance(string sourceWord, string targetWord)
        {
            int sourceLength = sourceWord.Length;
            int targetLength = targetWord.Length;
            double[,] distances = new double[sourceLength + 1, targetLength + 1];

            if (sourceLength == 0)
            {
                return targetLength;
            }

            if (targetLength == 0)
            {
                return sourceLength;
            }

            for (int i = 0; i <= sourceLength; i++)
            {
                distances[i, 0] = i * 0.9d;
            }

            for (int j = 0; j <= targetLength; j++)
            {
                distances[0, j] = j * 0.8d;
            }

            for (int i = 1; i <= sourceLength; i++)
            {
                for (int j = 1; j <= targetLength; j++)
                {
                    if (targetWord[j - 1] == sourceWord[i - 1])
                    {
                        distances[i, j] = distances[i - 1, j - 1];
                    }
                    else
                    {
                        distances[i, j] = Math.Min(
                            Math.Min(distances[i - 1, j - 1] + 1, distances[i - 1, j] + 0.9),
                            distances[i, j - 1] + 0.8);
                    }
                }
            }

            return distances[sourceLength, targetLength];
        }

        public static void Main()
        {
            Console.WriteLine("developer -> enveloped, cost = {0}", CalcMinimumEditDistance("developer", "enveloped"));
            Console.WriteLine("developer -> eveloper, cost = {0}", CalcMinimumEditDistance("developer", "eveloper"));
            Console.WriteLine("eveloper -> enveloper, cost = {0}", CalcMinimumEditDistance("eveloper", "enveloper"));
            Console.WriteLine("eveloper -> eveloped, cost = {0}", CalcMinimumEditDistance("eveloper", "eveloped"));
        }
    }
}