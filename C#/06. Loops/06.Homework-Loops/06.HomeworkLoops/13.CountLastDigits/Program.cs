using System;

class Program
{
    static int CalculatePower(int n)
    {
        int power = 0;
        while (n != 0)
        {
            n = n / 5;
            power++;
        }
        return power - 1;
    }
    static void Main()
    {
        Console.Write("Enter value for N: ");
        int n = int.Parse(Console.ReadLine());
        int powerOf5 = CalculatePower(n);
        int counter = 0;
        while (powerOf5 != 0)
        {
            int powOfN = (int)Math.Pow(5.0, (double)powerOf5);
            int tempVar = n / powOfN;
            counter = counter + tempVar;
            powerOf5--;
        }
        Console.WriteLine("The trailing zeros in {0}! are {1}: ", n, counter);
    }
}