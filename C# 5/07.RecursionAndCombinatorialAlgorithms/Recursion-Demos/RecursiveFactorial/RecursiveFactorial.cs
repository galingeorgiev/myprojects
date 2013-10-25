using System;

class RecursiveFactorial
{
    static void Main()
    {
        Console.Write("n = ");
        decimal number = decimal.Parse(Console.ReadLine());

        decimal factorial = Factorial(number);
        Console.WriteLine("{0}! = {1}", number, factorial);
    }

    static decimal Factorial(decimal n)
    {
        if (n == 0)
        {
            return 1; 
        }
        else
        {
            return n * Factorial(n - 1);
        }
    }
}
