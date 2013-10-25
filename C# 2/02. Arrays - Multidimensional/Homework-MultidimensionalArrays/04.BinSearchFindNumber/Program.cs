using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("N{0} = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arr);
        List<int> list = new List<int>(arr);

        List<int> index = list.FindAll(x => x <= k);

        while (true)
        {
            int place = index.BinarySearch(k);
            if (k == 0)
            {
                Console.WriteLine("Cann't find this number!");
            }
            if (place < 0)
            {
                k--;
            }
            else
            {
                Console.WriteLine(index[place]);
                break;
            }
        }
    }
}
