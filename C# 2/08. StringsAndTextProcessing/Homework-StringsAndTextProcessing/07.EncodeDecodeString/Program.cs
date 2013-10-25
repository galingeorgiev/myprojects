using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static string Encoder(string text, string key)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < key.Length; j++)
            {
                if (i >= text.Length)
                {
                    break;
                }
                sb.Append((char)(text[i] ^ key[j]));
                i++;
            }
            i--;
        }
        return sb.ToString();
    }

    static string Decoder(string text, string key)
    {
        return Encoder(text, key);
    }

    static void Main()
    {
        Console.Write("Enetr text: ");
        string text = Console.ReadLine();
        Console.Write("Enetr key: ");
        string key = Console.ReadLine();

        string encodedText = Encoder(text,key);
        Console.WriteLine("Encoded text is: {0}", encodedText);

        string decodedText = Decoder(encodedText,key);
        Console.WriteLine("Decoded text is: {0}", decodedText);
    }
}