
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _05.CalculatesFactorielOtherExercise
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter value for N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter value for K: ");
            int k = int.Parse(Console.ReadLine());
            BigInteger resultK = 1;
            BigInteger resultNK = 1;
            BigInteger resultDenominator = 1;
            BigInteger finalResult = 0;
            for (int i = 1; i <= k; i++)
            {
                resultK = resultK * i;
            }
            for (int i = 1; i <= n; i++)
            {
                resultNK = resultNK * i;
            }
            for (int i = 1; i <= (k - n); i++)
            {
                resultDenominator = resultDenominator * i;
            }
            finalResult = (resultK * resultNK) / resultDenominator;
            Console.WriteLine(finalResult);
        }
    }
}
