using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _09.CatalanNumbers
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            while (n < 0)
            {
                Console.Write("Please enter corect value for n: ");
                n = int.Parse(Console.ReadLine());
            }
            BigInteger twoMultipliedNFactoriel = 1;
            for (int i = 1; i <= 2*n; i++)
            {
                twoMultipliedNFactoriel = twoMultipliedNFactoriel * i;
            }
            BigInteger nFactoriel = 1;
            for (int i = 1; i <= n; i++)
            {
                nFactoriel = nFactoriel * i;
            }
            BigInteger nPlusOneFactoriel = 1;
            for (int i = 1; i <= n + 1; i++)
            {
                nPlusOneFactoriel = nPlusOneFactoriel * i;
            }
            int catalanNumber = (int)(twoMultipliedNFactoriel / (nPlusOneFactoriel*nFactoriel));
            Console.WriteLine(catalanNumber);
        }
    }
}
