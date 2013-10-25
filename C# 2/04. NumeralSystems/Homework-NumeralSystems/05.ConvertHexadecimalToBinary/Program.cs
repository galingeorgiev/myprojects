using System;
using System.Text;

class Program
{
    static int HexadecimalValue(char n)
    {
        switch (n)
        {
            case '0': return 0000; break;
            case '1': return 0001; break;
            case '2': return 0010; break;
            case '3': return 0011; break;
            case '4': return 0100; break;
            case '5': return 0101; break;
            case '6': return 0110; break;
            case '7': return 0111; break;
            case '8': return 1000; break;
            case '9': return 1001; break;
            case 'A': return 1010; break;
            case 'B': return 1011; break;
            case 'C': return 1100; break;
            case 'D': return 1101; break;
            case 'E': return 1110; break;
            case 'F': return 1111; break;
            case 'a': return 1010; break;
            case 'b': return 1011; break;
            case 'c': return 1100; break;
            case 'd': return 1101; break;
            case 'e': return 1110; break;
            case 'f': return 1111; break;
            default: return '0'; break;
        }
    }
    static void Main()
    {
        Console.Write("Enter hexadecimal number: ");
        string hexadecimalNumber = Console.ReadLine();
        char[] hexadecimalNumberChars = hexadecimalNumber.ToCharArray();
        StringBuilder binaryValue = new StringBuilder();

        for (int i = 0; i < hexadecimalNumber.Length; i++)
        {
            binaryValue.Append(HexadecimalValue(hexadecimalNumberChars[i]).ToString());
        }

        Console.WriteLine(binaryValue);
    }
}