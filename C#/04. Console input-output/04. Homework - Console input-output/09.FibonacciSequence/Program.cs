using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _09.FibonacciSequence
{
    class Program
    {
        static BigInteger FibonacciSequenceGenerator(int n)
        {
            BigInteger firstMember = 0;
            BigInteger secondMember = 1;
            for (int i = 0; i < n; i++)
            {
                BigInteger tempMember = firstMember;
                firstMember = secondMember;
                secondMember = tempMember + firstMember;
                //Console.Write("{0}, ", firstMember);
            }
            return firstMember;
        }
        static void Main()
        {
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                //Using if statmant to generete 5 elements in every line
                if (i%5!=0)
                {
                    Console.Write("{0}, ",FibonacciSequenceGenerator(i));
                }
                else
                {
                    Console.WriteLine("{0}, ",FibonacciSequenceGenerator(i));
                }
            }
        }
    }
}
