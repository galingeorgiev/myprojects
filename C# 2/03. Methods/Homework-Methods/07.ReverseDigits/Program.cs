using System;

class Program
{
    static void ReverseDecimalNumber(decimal n)
    {
        char[] arr = n.ToString().ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0}", arr[arr.Length - i - 1]);
        }
    }
    static void Main()
    {
        Console.Write("Enter decimal nummber: ");
        decimal n = decimal.Parse(Console.ReadLine());

        ReverseDecimalNumber(n);
    }
}