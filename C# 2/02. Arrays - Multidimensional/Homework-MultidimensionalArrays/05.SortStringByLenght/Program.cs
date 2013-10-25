using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static void Main()
    {
        Console.WriteLine("Enter array lenght");
        int n = int.Parse(Console.ReadLine());
        string[] arr = new string[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter string {0}: ", i + 1);
            arr[i] = Console.ReadLine();
        }
        var result = from word in arr
                     orderby word.Length ascending
                     select word;

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}