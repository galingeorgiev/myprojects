using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MoonWeight
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter your weight: ");
            double personWeight = double.Parse(Console.ReadLine());
            double personWeightInMoon = personWeight * 0.17;
            Console.WriteLine("On the moon your weight is {0}", personWeightInMoon);
        }
    }
}
