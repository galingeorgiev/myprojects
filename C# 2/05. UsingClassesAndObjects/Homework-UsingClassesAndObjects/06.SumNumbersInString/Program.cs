using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter positive integer values separated by spaces: ");
        string valuesString = Console.ReadLine();
        string[] valuesArray = valuesString.Split(' ');
        int sumOfValues = 0;
        for (int i = 0; i < valuesArray.Length; i++)
        {
            sumOfValues = sumOfValues + int.Parse(valuesArray[i]);
        }
        Console.WriteLine("Result is {0}",sumOfValues);
    }
}