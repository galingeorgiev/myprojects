using System;

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
    static void Main()
    {
        Console.Write("Enter first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("The biggest number is {0}", GetMax(GetMax(firstNumber, secondNumber), thirdNumber));
    }
}