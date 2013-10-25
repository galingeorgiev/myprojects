using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter binary number: ");
        string binaryNumber = Console.ReadLine();
        char[] charArr = binaryNumber.ToCharArray();
        int sum = 0;
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            int temp = int.Parse((charArr[binaryNumber.Length - i - 1]).ToString());
            sum = sum + temp * (int)Math.Pow(2, i);
            if (temp != 0 & temp != 1)
            {
                Console.WriteLine("Invalid binary number!");
                sum = 0;
                break;
            }
        }
        Console.WriteLine(sum);
    }
}