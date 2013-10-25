/*
* We are given numbers N and M and the following operations:
* N = N+1
* N = N+2
* N = N*2
* Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
* Example: N = 5, M = 16
* Sequence: 5  7  8  16
*/

namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;

    public class ShortestSequenceOfOperations
    {
        public static bool IsBigger(int n, int m)
        {
            if (n >= m)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Stack<int> FindSequence(int n, int m)
        {
            Stack<int> shortSequence = new Stack<int>();
            int currentValue = m;
            shortSequence.Push(currentValue);

            if (currentValue % 2 != 0)
            {
                currentValue = currentValue - 1;
                shortSequence.Push(currentValue);
            }

            while (currentValue != n)
            {
                bool isNbiggerFromM = IsBigger(currentValue / 2, n);
                if (!isNbiggerFromM)
                {
                    currentValue = currentValue / 2;
                    shortSequence.Push(currentValue);
                    continue;
                }

                isNbiggerFromM = IsBigger(currentValue - 2, n);
                if (!isNbiggerFromM)
                {
                    currentValue = currentValue - 2;
                    shortSequence.Push(currentValue);
                    continue;
                }

                isNbiggerFromM = IsBigger(currentValue - 1, n);
                if (!isNbiggerFromM)
                {
                    currentValue = currentValue - 1;
                    shortSequence.Push(currentValue);
                    continue;
                }
            }

            return shortSequence;
        }

        public static void Main()
        {
            // My answer is 5 -> 6 -> 8 -> 16
            // I think that this is correct sequence of operations.
            // Final result as length is same.
            Stack<int> testSequence = FindSequence(5, 16);

            foreach (var item in testSequence)
            {
                Console.WriteLine(item);
            }
        }
    }
}
