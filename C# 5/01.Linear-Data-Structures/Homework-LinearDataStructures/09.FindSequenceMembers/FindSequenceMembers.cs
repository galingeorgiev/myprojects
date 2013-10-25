/*
* We are given the following sequence:
* S1 = N;
* S2 = S1 + 1;
* S3 = 2*S1 + 1;
* S4 = S1 + 2;
* S5 = S2 + 1;
* S6 = 2*S2 + 1;
* S7 = S2 + 2;
* ...
* Using the Queue<T> class write a program to print its first 50 members for given N.
* Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
*/

namespace FindSequenceMembers
{
    using System;
    using System.Collections.Generic;

    public class FindSequenceMembers
    {
        public static string FindFirstFiftySequenceMembers(int number)
        {
            Queue<int> firstMember = new Queue<int>();
            firstMember.Enqueue(number);
            List<int> sequenceNumbers = new List<int>();
            sequenceNumbers.Add(number);

            while (sequenceNumbers.Count <= 50)
            {
                int n = firstMember.Dequeue();
                int firstIteration = n + 1;
                firstMember.Enqueue(firstIteration);
                sequenceNumbers.Add(firstIteration);

                int secondIteration = 2 * n + 1;
                sequenceNumbers.Add(secondIteration);
                firstMember.Enqueue(secondIteration);

                int thirdIteration = n + 2;
                sequenceNumbers.Add(thirdIteration);
                firstMember.Enqueue(thirdIteration);
            }

            string result = string.Join(", ", sequenceNumbers);

            return result;
        }

        public static void Main()
        {
            Console.WriteLine("Enter value for n: ");
            int n = int.Parse(Console.ReadLine());
            string result = FindFirstFiftySequenceMembers(n);
            Console.WriteLine(result);
        }
    }
}
