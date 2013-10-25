using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter first string");
        string str1 = Console.ReadLine();
        Console.WriteLine("Enter second string");
        string str2 = Console.ReadLine();
        bool isFirstBigger = false;
        if (str1.Length >= str2.Length)
        {
            for (int i = 0; i < str2.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    if ((int)str1[i] < (int)str2[i])
                    {
                        isFirstBigger = true;
                        break;
                    }
                }
                else
                {
                    isFirstBigger = false;
                }
            }
        }

        if (str1.Length < str2.Length)
        {
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    if ((int)str1[i] < (int)str2[i])
                    {
                        isFirstBigger = true;
                        break;
                    }
                }
                else
                {
                    isFirstBigger = true;
                }
            }
        }

        if (str1 == str2)
        {
            Console.WriteLine("First string is equal to second");
        }
        if (isFirstBigger & (str1 != str2))
        {
            Console.WriteLine("First string is smaler");
        }
        if ((!isFirstBigger) & (str1 != str2))
        {
            Console.WriteLine("Second string is smaler");
        }
    }
}