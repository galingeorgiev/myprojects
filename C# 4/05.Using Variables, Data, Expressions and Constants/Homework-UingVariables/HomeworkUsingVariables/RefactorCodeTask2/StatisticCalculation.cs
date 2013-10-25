namespace RefactorCodeTask2
{
    using System;

    /// <summary>
    /// Print statistic calculation
    /// </summary>
    public class StatisticCalculation
    {
        /// <summary>
        /// Test above methods in Main method.
        /// </summary>
        public static void Main()
        {
        }

        /// <summary>
        /// Print max, min and average element from array.
        /// </summary>
        /// <param name="elements">Input elements where searching max, min and average elements.</param>
        /// <param name="count">Number of elements in array.</param>
        public void PrintStatistics(double[] elements, int count)
        {
            // To secure back compability I doesn'n delete count
            this.PrintMax(elements);

            this.PrintMin(elements);

            this.PrintAvg(elements);
        }

        /// <summary>
        /// Print the biggest element.
        /// </summary>
        /// <param name="elements">Elements where we search for the biggest.</param>
        private void PrintMax(double[] elements)
        {
            double maxValue = double.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxValue)
                {
                    maxValue = elements[i];
                }
            }

            Console.WriteLine(maxValue);
        }

        /// <summary>
        /// Print the smallest element.
        /// </summary>
        /// <param name="elements">Elements where we search for the smallest.</param>
        private void PrintMin(double[] elements)
        {
            double minValue = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] < minValue)
                {
                    minValue = elements[i];
                }
            }

            Console.WriteLine(minValue);
        }

        /// <summary>
        /// Print average of all elements.
        /// </summary>
        /// <param name="elements">Elements for that we calculate average value.</param>
        private void PrintAvg(double[] elements)
        {
            double currentSumOfElements = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                currentSumOfElements += elements[i];
            }

            Console.WriteLine(currentSumOfElements / elements.Length);
        }
    }
}