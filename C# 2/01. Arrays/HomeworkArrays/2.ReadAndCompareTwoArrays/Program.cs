using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter values for array 1, sepaarte with comma");
        string str1 = Console.ReadLine();
        Console.WriteLine("Enter values for array 2, sepaarte with comma");
        string str2 = Console.ReadLine();
        string[] arr1 = str1.Split(',');
        string[] arr2 = str2.Split(',');
        bool isEqual = false;
        if (arr1.Length == arr2.Length)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    isEqual = true;
                }
                else
                {
                    isEqual = false;
                    break;
                }
            }
        }
        else
        {
            isEqual = false;
        }

        if (isEqual)
        {
            Console.WriteLine("Array 1 is equal to array 2.");
        }
        else
        {
            Console.WriteLine("Array 1 isn't equal to array 2.");
        }
    }
}