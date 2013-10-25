using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static int GetMax(int firstNumber, int secondNumber)
    {
        if (firstNumber > secondNumber)
        {
            return firstNumber;
        }
        else
        {
            return secondNumber;
        }
    }

    static string AddLeadingZeros(string firstString, string secondString)
    {
        StringBuilder strResult = new StringBuilder();
        if (firstString.Length > secondString.Length)
        {
            strResult.Append('0', firstString.Length - secondString.Length);
            strResult.Append(secondString);
        }
        else
        {
            strResult.Append('0', secondString.Length - firstString.Length);
            strResult.Append(firstString);
        }
        return strResult.ToString();
    }

    static void SumVeryBigNumbers(string firstNumber, string secondNumber)
    {
        int endOfLoop = GetMax(firstNumber.Length, secondNumber.Length);
        int[] result = new int[endOfLoop];
        int addOne = 0;

        if (firstNumber.Length > secondNumber.Length)
        {
            secondNumber = AddLeadingZeros(firstNumber, secondNumber);
        }
        if (secondNumber.Length > firstNumber.Length)
        {
            firstNumber = AddLeadingZeros(firstNumber, secondNumber);
        }

        for (int i = 0; i < endOfLoop; i++)
        {
            int tempSum = 0;
            tempSum = int.Parse(firstNumber[firstNumber.Length - i - 1].ToString()) + int.Parse(secondNumber[secondNumber.Length - i - 1].ToString()) + addOne;
            if (tempSum >= 10)
            {
                result[result.Length - i - 1] = tempSum % 10;
                addOne = 1;
            }
            else
            {
                result[result.Length - i - 1] = tempSum;
                addOne = 0;
            }
        }
        foreach (var item in result)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Enter first number: ");
        string firstNumber = Console.ReadLine();
        Console.Write("Enter second number: ");
        string secondNumber = Console.ReadLine();

        SumVeryBigNumbers(firstNumber, secondNumber);
    }
}