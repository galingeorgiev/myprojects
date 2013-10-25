using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string expression = ")(a+b)/5-d)";
        int counter = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                counter++;
            }

            if (expression[i] == ')')
            {
                counter--;
            }

            if (counter < 0)
            {
                Console.WriteLine("Incorrect expression!");
                break;
            }
        }

        if (counter == 0)
        {
            Console.WriteLine("Correct expression!");
        }
    }
}