using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quicksort
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter array lenght: ");
            int arrayLenght = int.Parse(Console.ReadLine());
            string[] unsortedStringArray = new string[arrayLenght];

            for (int i = 0; i < unsortedStringArray.Length; i++)
            {
                unsortedStringArray[i] = Console.ReadLine();
            }

            for (int i = 0; i < unsortedStringArray.Length; i++)
            {
                Console.Write(unsortedStringArray[i] + " ");
            }

            Console.WriteLine();

            Quicksort(unsortedStringArray, 0, unsortedStringArray.Length - 1);

            for (int i = 0; i < unsortedStringArray.Length; i++)
            {
                Console.Write(unsortedStringArray[i] + " ");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        public static void Quicksort(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
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
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }

    }
}