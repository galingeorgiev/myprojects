using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void SumOfPolynomials(List<int> firstPolinomial, List<int> secondPolinomial)
    {
        for (int i = 0; i < firstPolinomial.Count; i++)
        {
            int sum = 0;
            sum = firstPolinomial[i] + secondPolinomial[i];

            if (sum != 0 & i == 0)
            {
                Console.Write("{0}X^2", sum);
            }

            if (sum != 0 & i == 1)
            {
                if (sum > 0)
                {
                    Console.Write(" +");
                }

                Console.Write(" {0}X", sum);
            }

            if (sum != 0 & i == 2)
            {
                if (sum > 0)
                {
                    Console.Write(" +");
                }

                Console.Write(" {0}", sum);
            }
        }
        Console.WriteLine();
    }

    static void Main()
    {
        List<int> firstPolynomial = new List<int>();
        List<int> secondPolynomial = new List<int>();
        Console.WriteLine("Enter coefficients for first polynomial:");
        Console.Write("X^2 = ");
        firstPolynomial.Add(int.Parse(Console.ReadLine()));
        Console.Write("X^1 = ");
        firstPolynomial.Add(int.Parse(Console.ReadLine()));
        Console.Write("X^0 = ");
        firstPolynomial.Add(int.Parse(Console.ReadLine()));
        Console.WriteLine("Enter coefficients for second polynomial:");
        Console.Write("X^2 = ");
        secondPolynomial.Add(int.Parse(Console.ReadLine()));
        Console.Write("X^1 = ");
        secondPolynomial.Add(int.Parse(Console.ReadLine()));
        Console.Write("X^0 = ");
        secondPolynomial.Add(int.Parse(Console.ReadLine()));

        SumOfPolynomials(firstPolynomial, secondPolynomial);
    }
}
