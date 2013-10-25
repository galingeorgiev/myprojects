using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.GreatestVarible
{
    class Program
    {
        static void Main()
        {
            int n0 = int.Parse(Console.ReadLine());
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            int n4 = int.Parse(Console.ReadLine());

            int temp01 = Math.Max(n0, n1);
            int temp23 = Math.Max(n2, n3);
            int temp0123 = Math.Max(temp01, temp23);
            int result = Math.Max(temp0123, n4);
            Console.WriteLine("Greatest number is {0}", result);
        }
    }
}
