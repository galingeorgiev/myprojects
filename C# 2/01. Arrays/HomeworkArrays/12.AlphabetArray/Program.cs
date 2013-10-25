using System;

class Program
{
    static void Main()
    {
        char[] arr = new char[26];
        for (int i = 0; i < 26; i++)
        {
            arr[i] = (char)(i + 97);
        }

        Console.Write("Enter string(lowercase only): ");
        string readedStr = Console.ReadLine();
        char[] strToChar = readedStr.ToCharArray();
        //Array.Sort(strToChar);
        for (int i = 0; i < strToChar.Length; i++)
        {
            int result = Array.BinarySearch(arr, strToChar[i]);
            Console.WriteLine("{0} = {1}",strToChar[i] ,result);
        }
    }
}