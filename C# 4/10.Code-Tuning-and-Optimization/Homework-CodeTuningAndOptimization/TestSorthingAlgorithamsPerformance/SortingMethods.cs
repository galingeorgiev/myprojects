using System;
using System.Diagnostics;

namespace TestSorthingAlgorithmsPerformance
{
    public static class SortingMethods
    {
        #region Insertion Sort
        public static void InsertionSort(int[] inputArr)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i < inputArr.Length; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (inputArr[j - 1] > inputArr[j])
                    {
                        int oldValue = inputArr[j - 1];
                        inputArr[j - 1] = inputArr[j];
                        inputArr[j] = oldValue;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            sw.Stop();
            long algorithmNeededTime = sw.ElapsedMilliseconds;
            sw.Reset();

            Console.WriteLine(
                "Insertion sort algorithm with integers needed {0} milliseconds.",
                algorithmNeededTime);
        }

        public static void InsertionSort(double[] inputArr)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i < inputArr.Length; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (inputArr[j - 1] > inputArr[j])
                    {
                        double oldValue = inputArr[j - 1];
                        inputArr[j - 1] = inputArr[j];
                        inputArr[j] = oldValue;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            sw.Stop();
            long algorithmNeededTime = sw.ElapsedMilliseconds;
            sw.Reset();

            Console.WriteLine(
                "Insertion sort algorithm with double needed {0} milliseconds.",
                algorithmNeededTime);
        }

        public static void InsertionSort(string[] inputArr)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i < inputArr.Length; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (inputArr[j - 1].CompareTo(inputArr[j]) > 0)
                    {
                        string oldValue = inputArr[j - 1];
                        inputArr[j - 1] = inputArr[j];
                        inputArr[j] = oldValue;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            sw.Stop();
            long algorithmNeededTime = sw.ElapsedMilliseconds;
            sw.Reset();

            Console.WriteLine(
                "Insertion sort algorithm with strings needed {0} milliseconds.",
                algorithmNeededTime);
        }
        #endregion

        #region QuickSort
        public static void QuickSort(int[] elements, int left, int right)
        {
            int i = left;
            int j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int oldValue = elements[i];
                    elements[i] = elements[j];
                    elements[j] = oldValue;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort(elements, left, j);
            }

            if (i < right)
            {
                QuickSort(elements, i, right);
            }
        }

        public static void QuickSort(double[] elements, int left, int right)
        {
            int i = left;
            int j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    double oldValue = elements[i];
                    elements[i] = elements[j];
                    elements[j] = oldValue;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort(elements, left, j);
            }

            if (i < right)
            {
                QuickSort(elements, i, right);
            }
        }

        public static void QuickSort(string[] elements, int left, int right)
        {
            int i = left;
            int j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    string oldValue = elements[i];
                    elements[i] = elements[j];
                    elements[j] = oldValue;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort(elements, left, j);
            }

            if (i < right)
            {
                QuickSort(elements, i, right);
            }
        }
        #endregion

        #region Selection Sort
        public static void SelectionSort(int[] inputArr)
        {
            int oldValue;
            int minValue;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < inputArr.Length - 1; i++)
            {
                minValue = i;

                for (int j = i + 1; j < inputArr.Length; j++)
                {
                    if (inputArr[j] < inputArr[minValue])
                    {
                        minValue = j;
                    }
                }

                oldValue = inputArr[minValue];
                inputArr[minValue] = inputArr[i];
                inputArr[i] = oldValue;
            }

            sw.Stop();
            long algorithmNeededTime = sw.ElapsedMilliseconds;
            sw.Reset();

            Console.WriteLine(
                "Selection sort algorithm with integers needed {0} milliseconds.",
                algorithmNeededTime);
        }

        public static void SelectionSort(double[] inputArr)
        {
            double oldValue;
            int minValue;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < inputArr.Length - 1; i++)
            {
                minValue = i;

                for (int j = i + 1; j < inputArr.Length; j++)
                {
                    if (inputArr[j] < inputArr[minValue])
                    {
                        minValue = j;
                    }
                }

                oldValue = inputArr[minValue];
                inputArr[minValue] = inputArr[i];
                inputArr[i] = oldValue;
            }

            sw.Stop();
            long algorithmNeededTime = sw.ElapsedMilliseconds;
            sw.Reset();

            Console.WriteLine(
                "Selection sort algorithm with double needed {0} milliseconds.",
                algorithmNeededTime);
        }

        public static void SelectionSort(string[] inputArr)
        {
            string oldValue;
            int minValue;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < inputArr.Length - 1; i++)
            {
                minValue = i;

                for (int j = i + 1; j < inputArr.Length; j++)
                {
                    if (inputArr[j].CompareTo(inputArr[minValue]) < 0)
                    {
                        minValue = j;
                    }
                }

                oldValue = inputArr[minValue];
                inputArr[minValue] = inputArr[i];
                inputArr[i] = oldValue;
            }

            sw.Stop();
            long algorithmNeededTime = sw.ElapsedMilliseconds;
            sw.Reset();

            Console.WriteLine(
                "Selection sort algorithm with strings needed {0} milliseconds.",
                algorithmNeededTime);
        }
        #endregion

        #region Generate array
        public static int[] GenerateIntArr()
        {
            int numberOfElements = 10000;
            int[] generatedArr = new int[numberOfElements];
            Random rnd = new Random();
            for (int i = 0; i < numberOfElements; i++)
            {
                generatedArr[i] = rnd.Next();
            }

            return generatedArr;
        }

        public static double[] GenerateDoubleArr()
        {
            int numberOfElements = 10000;
            double[] generatedArr = new double[numberOfElements];
            Random rnd = new Random();
            for (int i = 0; i < numberOfElements; i++)
            {
                generatedArr[i] = rnd.NextDouble();
            }

            return generatedArr;
        }

        public static string[] GenerateStringArr()
        {
            int numberOfElements = 10000;
            string[] generatedArr = new string[numberOfElements];
            Random rnd = new Random();
            for (int i = 0; i < numberOfElements; i++)
            {
                generatedArr[i] = rnd.NextDouble().ToString();
            }

            return generatedArr;
        }
        #endregion
    }
}
