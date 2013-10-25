namespace RiskWinsRiskLoses
{
    using System;
    using System.Collections.Generic;

    public class RiskWinsRiskLoses
    {
        private static int startPoint;
        private static int endPoint;
        private static HashSet<int> forbidenCombinations = new HashSet<int>();
        private static int result = int.MaxValue;

        public static void ReadInput()
        {
            startPoint = int.Parse(Console.ReadLine());
            endPoint = int.Parse(Console.ReadLine());
            int numberOfForbidenCombinations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfForbidenCombinations; i++)
            {
                int currentCombinations = int.Parse(Console.ReadLine());
                forbidenCombinations.Add(currentCombinations);
            }
        }

        public static void FindStepsCount()
        {
            Queue<Tuple<int, int>> pathElements = new Queue<Tuple<int, int>>();
            pathElements.Enqueue(new Tuple<int, int>(startPoint, 0));

            int[] powOf10 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                powOf10[i] = (int)Math.Pow(10d, i);
            }

            while (pathElements.Count > 0)
            {
                Tuple<int, int> currentPathElement = pathElements.Dequeue();

                if (currentPathElement.Item1 == endPoint)
                {
                    result = currentPathElement.Item2;
                    return;
                }

                for (int i = 0; i < 5; i++)
                {
                    int newPathElementUp = currentPathElement.Item1;

                    if ((newPathElementUp / powOf10[i]) % 10 != 9)
                    {
                        newPathElementUp = currentPathElement.Item1 + powOf10[i];
                    }
                    else
                    {
                        newPathElementUp = currentPathElement.Item1 - (9 * powOf10[i]);
                    }

                    if (newPathElementUp <= 99999 && newPathElementUp >= 0 && !forbidenCombinations.Contains(newPathElementUp))
                    {
                        pathElements.Enqueue(new Tuple<int, int>(newPathElementUp, currentPathElement.Item2 + 1));
                        forbidenCombinations.Add(newPathElementUp);
                    }

                    int newPathElementDown = currentPathElement.Item1;

                    if ((newPathElementDown / powOf10[i]) % 10 != 0)
                    {
                        newPathElementDown = currentPathElement.Item1 - powOf10[i];
                    }
                    else
                    {
                        newPathElementDown = currentPathElement.Item1 + (9 * powOf10[i]);
                    }

                    if (newPathElementDown <= 99999 && newPathElementDown >= 0 && !forbidenCombinations.Contains(newPathElementDown))
                    {
                        pathElements.Enqueue(new Tuple<int, int>(newPathElementDown, currentPathElement.Item2 + 1));
                        forbidenCombinations.Add(newPathElementDown);
                    }
                }
            }
        }

        public static void Main()
        {
            ReadInput();
            FindStepsCount();

            if (result == int.MaxValue)
            {
                result = -1;
            }

            Console.WriteLine(result);
        }
    }
}