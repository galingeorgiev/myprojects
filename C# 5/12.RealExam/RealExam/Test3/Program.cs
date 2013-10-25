using System;

namespace ConsoleApplication1
{
    static class Program
    {
        static void Main()
        {
            int[] numbers = new[]
            {
                0, 1, 2, 3, 4
            };

            Permute(numbers, Output);
            Console.WriteLine();

            string[] strings = new[]
            {
                "Red", "Orange", "Yellow", "Green", "Blue"
            };

            Permute(strings, Output);
            Console.WriteLine();

            Console.ReadLine();
        }

        private static void Output<T>(T[] permutation)
        {
            foreach (T item in permutation)
            {
                Console.Write(item);
                Console.Write(" ");
            }

            Console.WriteLine();
        }

        public static void Permute<T>(T[] items, Action<T[]> output)
        {
            Permute(items, 0, new T[items.Length], new bool[items.Length], output);
        }

        private static void Permute<T>(T[] items, int item, T[] permutation, bool[] used, Action<T[]> output)
        {
            for (int i = 0; i < items.Length; ++i)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutation[item] = items[i];

                    if (item < (items.Length - 1))
                    {
                        Permute(items, item + 1, permutation, used, output);
                    }
                    else
                    {
                        output(permutation);
                    }

                    used[i] = false;
                }
            }
        }
    }
}
