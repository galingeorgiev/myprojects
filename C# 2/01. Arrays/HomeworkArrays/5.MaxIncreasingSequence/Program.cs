using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter array, values sepaartet with comma");
        string str1 = Console.ReadLine();
        string[] strArr = str1.Split(',');
        int bestLenght = 0;
        int lastIndex = 0;
        int counter = 0;
        for (int i = 0; i < strArr.Length - 1; i++)
        {
            int n1 = int.Parse(strArr[i]);
            int n2 = int.Parse(strArr[i + 1]);
            if (n1 + 1 == n2)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
            if (counter > bestLenght)
            {
                lastIndex = i + 1;
                bestLenght = counter;
            }
        }
        for (int i = lastIndex - bestLenght; i <= lastIndex; i++)
        {
            Console.Write("{0} ", strArr[i]);
        }
    }
}