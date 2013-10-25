using System;
using System.Text;

class Program
{
    static char HexadecimalValue(string n)
    {
        switch (n)
        {
            case "0000": return '0'; break;
            case "0001": return '1'; break;
            case "0010": return '2'; break;
            case "0011": return '3'; break;
            case "0100": return '4'; break;
            case "0101": return '5'; break;
            case "0110": return '6'; break;
            case "0111": return '7'; break;
            case "1000": return '8'; break;
            case "1001": return '9'; break;
            case "1010": return 'A'; break;
            case "1011": return 'B'; break;
            case "1100": return 'C'; break;
            case "1101": return 'D'; break;
            case "1110": return 'E'; break;
            case "1111": return 'F'; break;
            default: return '0'; break;
        }
    }

    static string AddFirstZeros(string binaryNumber)
    {
        int misingZeros = binaryNumber.Length % 4;
        StringBuilder str = new StringBuilder();
        if (misingZeros == 0)
        {
            return binaryNumber;
        }
        else
        {
            for (int i = 0; i < 4 - misingZeros; i++)
            {
                str.Append("0");
            }
            str.Append(binaryNumber.ToString());
            return str.ToString();
        }
    }

    static string[] DivideToFour(string binariNumber)
    {
        string[] result = new string[binariNumber.Length / 4];
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < binariNumber.Length; i = i + 4)
        {
            for (int j = 0; j < 4; j++)
            {
                str.Append(binariNumber[i + j]);
            }
            result[i / 4] = str.ToString();
            str = str.Clear();
        }
        return result;
    }
    static void Main()
    {
        Console.Write("Enter hexadecimal number: ");
        string hexadecimalNumber = Console.ReadLine();
        string str = AddFirstZeros(hexadecimalNumber);
        string[] strArray = DivideToFour(str);
        StringBuilder binaryNumber = new StringBuilder();

        for (int i = 0; i < strArray.Length; i++)
        {
            binaryNumber.Append(HexadecimalValue(strArray[i]));
        }
        Console.WriteLine(binaryNumber);
    }
}