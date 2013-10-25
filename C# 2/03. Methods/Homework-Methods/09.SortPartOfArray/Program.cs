using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static int[] FindBiggestNumberInSubArray(int startIndex, List<int> list)
    {
        int[] bestNumber = new int[] { int.MinValue, 0 };
        for (int i = startIndex; i < list.Count; i++)
        {
            if (list[i] > bestNumber[0])
            {
                bestNumber[0] = list[i];
                bestNumber[1] = i;
            }
        }
        return bestNumber;
    }

    static void DescendingSort(int startIndex, List<int> list)
    {
        List<int> descendingList = new List<int>();

        for (int i = startIndex; i < list.Count; i++)
        {
            int[] arrTempResult = FindBiggestNumberInSubArray(i, list);
            descendingList.Add(arrTempResult[0]);
            int temp = list[i];
            list[i] = list[arrTempResult[1]];
            list[arrTempResult[1]] = temp;
        }

        foreach (var item in descendingList)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }

    static void AscendingSort(int startIndex, List<int> list)
    {
        List<int> ascendingList = new List<int>();

        for (int i = startIndex; i < list.Count; i++)
        {
            int[] arrTempResult = FindBiggestNumberInSubArray(i, list);
            ascendingList.Add(arrTempResult[0]);
            int temp = list[i];
            list[i] = list[arrTempResult[1]];
            list[arrTempResult[1]] = temp;
        }

        for (int i = 0; i < ascendingList.Count; i++)
        {
            Console.Write("{0} ", ascendingList[ascendingList.Count - i - 1]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Enter start index: ");
        int n = int.Parse(Console.ReadLine());

        List<int> list = new List<int>();
        Console.WriteLine("Enter array elements: \nFor end enter 'n'");
        while (true)
        {
            string number = Console.ReadLine();
            int value;
            bool isNum = int.TryParse(number, out value);
            if (isNum)
            {
                list.Add(value);
            }
            else
            {
                break;
            }
        }

        Console.Write("Biggest number in subarray is: ");
        Console.WriteLine(FindBiggestNumberInSubArray(n, list)[0]);
        DescendingSort(n, list);
        AscendingSort(n,list);
    }
}
