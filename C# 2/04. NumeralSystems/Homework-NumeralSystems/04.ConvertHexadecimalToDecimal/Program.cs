using System;


class Program
{
    static int HexadecimalValue(char n)
    {
        switch (n)
        {
            case '0':
                return 0;
                break;
            case '1':
                return 1;
                break;
            case '2':
                return 2;
                break;
            case '3':
                return 3;
                break;
            case '4':
                return 4;
                break;
            case '5':
                return 5;
                break;
            case '6':
                return 6;
                break;
            case '7':
                return 7;
                break;
            case '8':
                return 8;
                break;
            case '9':
                return 9;
                break;
            case 'A':
                return 10;
                break;
            case 'B':
                return 11;
                break;
            case 'C':
                return 12;
                break;
            case 'D':
                return 13;
                break;
            case 'E':
                return 14;
                break;
            case 'F':
                return 15;
                break;
            case 'a':
                return 10;
                break;
            case 'b':
                return 11;
                break;
            case 'c':
                return 12;
                break;
            case 'd':
                return 13;
                break;
            case 'e':
                return 14;
                break;
            case 'f':
                return 15;
                break;
            default:
                return '0';
                break;
        }
    }

    static void Main()
    {
        Console.Write("Enter hexadecimal number: ");
        string hexadecimalNumber = Console.ReadLine();
        char[] hexadecimalNumberChars = hexadecimalNumber.ToCharArray();
        int sum = 0;

        for (int i = 0; i < hexadecimalNumber.Length; i++)
        {
            sum = sum + HexadecimalValue(hexadecimalNumberChars[hexadecimalNumberChars.Length - i - 1]) * (int)Math.Pow(16, i);
        }

        Console.WriteLine(sum);
    }
}