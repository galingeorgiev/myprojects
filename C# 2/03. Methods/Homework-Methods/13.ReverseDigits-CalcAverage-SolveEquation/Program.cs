using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void ReverseDigits(decimal number)
    {
        char[] charNumber = number.ToString().ToCharArray();

        for (int i = 0; i < charNumber.Length; i++)
        {
            Console.Write(charNumber[charNumber.Length - i - 1]);
        }
        Console.WriteLine();
    }

    static void CalcAverage(List<int> list)
    {
        int sum = 0;

        for (int i = 0; i < list.Count; i++)
        {
            sum = sum + list[i];
        }
        Console.WriteLine("Average is: {0:F2}", sum / list.Count);
    }

    static void SolveLinearEquation(double a, double b)
    {
        Console.WriteLine("X = {0:F2}", (-(b) / a));
    }

    static void Main()
    {
        Console.Write("Select option:\nPress 1 for reverse digits\nPress 2 for calculate average\nPress 3 for solving linear equation (a * x + b = 0)\nYour choice is: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter number for reverse: ");
                decimal number = decimal.Parse(Console.ReadLine());

                if (number >= 0)
                {
                    ReverseDigits(number);
                }
                else
                {
                    Console.WriteLine("You should enter non-negative value!");
                }
                break;
            case 2:
                List<int> list = new List<int>();
                Console.WriteLine("Enter array elements: \nFor end enter 'n'");
                while (true)
                {
                    string numberStr = Console.ReadLine();
                    int value;
                    bool isNum = int.TryParse(numberStr, out value);
                    if (isNum)
                    {
                        list.Add(value);
                    }
                    else
                    {
                        break;
                    }
                }

                if (list.Count > 0)
                {
                    CalcAverage(list);
                }
                else
                {
                    Console.WriteLine("Your sequence is empty!");
                }
                break;
            case 3:
                Console.Write("Enter value for a: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Enter value for b: ");
                double b = double.Parse(Console.ReadLine());
                if (a == 0)
                {
                    Console.WriteLine("a should not be equal to 0.");
                }
                else
                {
                    SolveLinearEquation(a, b);
                }
                break;
            default:
                Console.WriteLine("Enter value between 1-3");
                break;
        }
    }
}