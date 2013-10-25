using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.AddOneOrSymbolDependVarible
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter:\n1 for int\n2 for double\n3 for string\nyour choice is: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter an integer value: ");
                    int value = int.Parse(Console.ReadLine());
                    Console.WriteLine("{0}", value + 1);
                    break;
                case 2:
                    Console.Write("Enter an integer value: ");
                    double valueDouble = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0}", valueDouble + 1);
                    break;
                case 3:
                    Console.Write("Enter an integer value: ");
                    string valueString = Console.ReadLine();
                    Console.WriteLine("{0}*", valueString);
                    break;
                default:
                    Console.WriteLine("Enter value between 1-3");
                    break;
            }
        }
    }
}
