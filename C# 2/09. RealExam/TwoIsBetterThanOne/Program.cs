using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    static void FirstTask(string input)
    {
        string[] numbers = input.Split(' ');
        ulong leftBorder = ulong.Parse(numbers[0]);
        ulong rightBorder = ulong.Parse(numbers[1]);
        int lukyNumbers = 0;
        bool isLuckyNumber = true;

        for (ulong i = leftBorder; i < rightBorder; i++)
        {
            if (i % 10 == 3 | i % 10 == 5)
            {
                isLuckyNumber = true;
                char[] numbersChars = i.ToString().ToCharArray();
                for (int j = 0; j < numbersChars.Length; j++)
                {
                    if (numbersChars[j] == '3' | numbersChars[j] == '5')
                    {
                        //continue;
                    }
                    else
                    {
                        isLuckyNumber = false;
                        break;
                    }
                }

                for (int j = 0; j < (numbersChars.Length / 2); j++)
                {
                    if (numbersChars[j] == numbersChars[numbersChars.Length - j - 1])
                    {
                        
                    }
                    else
                    {
                        isLuckyNumber = false;
                        break;
                    }
                }

                if (numbersChars.Length == 1 & (numbersChars[0] == '3' | numbersChars[0] == '5'))
                {
                    isLuckyNumber = true;
                }

                if (isLuckyNumber)
                {
                    lukyNumbers++;
                }
            }
        }
        Console.WriteLine(lukyNumbers);
    }

    static void SecondTask(string input, double p)
    {
        var dig = Regex.Match(input,@"[-0-9]+");
        List<string> digits = new List<string>();
        while (dig.Success)
        {
            digits.Add(dig.ToString());
            dig = dig.NextMatch();
        }

        digits.Sort();
        double digitsPlace = (p / 100) * digits.Count;
        int place = (int)digitsPlace;
        Console.WriteLine(digits[place]);
    }

    static void Main()
    {
        string inputFirstTask = Console.ReadLine();
        string inputSecondTask = Console.ReadLine();
        double p = int.Parse(Console.ReadLine());

        FirstTask(inputFirstTask);
        SecondTask(inputSecondTask, p);
    }
}