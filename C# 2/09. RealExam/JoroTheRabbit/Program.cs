using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string pattern = @"[-0-9]+";
        string input = Console.ReadLine();
        //string input = "1, -2, -3, 4, -5, 6, -7, -8";

        var matchedNumbers = Regex.Match(input, pattern);
        List<int> numbersList = new List<int>();

        while (matchedNumbers.Success)
        {
            numbersList.Add(int.Parse(matchedNumbers.ToString()));
            matchedNumbers = matchedNumbers.NextMatch();
        }

        //foreach (var item in numbersList)
        //{
        //    Console.WriteLine(item);
        //}

        int bestResult = 1;

        for (int i = 0; i < numbersList.Count; i++)
        {
            int step = i + 1;

            if (step >= numbersList.Count)
            {
                break;
            }

            for (int j = 0; j < numbersList.Count; j++)
            {
                int startPosition = j;
                //int currentPosition = 0;
                int tempResult = 1;
                for (int z = 0; z < numbersList.Count; z++)
                {
                    int nextJump = startPosition + step;

                    if (nextJump < numbersList.Count)
                    {
                        if (numbersList[nextJump] > numbersList[startPosition])
                        {
                            tempResult++;
                            startPosition = nextJump;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        nextJump = Math.Abs(numbersList.Count - startPosition - step);

                        if (numbersList[nextJump] > numbersList[startPosition])
                        {
                            tempResult++;
                            startPosition = nextJump;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (tempResult > bestResult)
                {
                    bestResult = tempResult;
                }
            }
        }

        Console.WriteLine(bestResult);
    }
}