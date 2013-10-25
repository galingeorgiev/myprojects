using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinAndMaxNumbersFromSequence
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter lenght of array: ");
            int n = int.Parse(Console.ReadLine());

            int[] quantity = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter {0} value: ", i + 1);
                quantity[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(quantity);
            Console.WriteLine("Smaller value is {0}\nBigger value is {1}", quantity[0], quantity[n - 1]);
        }
    }
}
