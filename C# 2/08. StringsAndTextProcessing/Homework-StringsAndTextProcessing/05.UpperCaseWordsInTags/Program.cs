using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string str = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        char[] strToChar = str.ToCharArray();
        string openTag = "<upcase>";
        string closeTag = "</upcase>";

        int indexOpen = 0;
        int indexClose = 0;

        while (true)
        {
            indexOpen = str.IndexOf(openTag,indexOpen + 1);
            indexClose = str.IndexOf(closeTag,indexClose + 1);

            if (indexOpen < 0)
            {
                break;
            }

            for (int i = indexOpen + openTag.Length; i < indexClose; i++)
            {
                strToChar[i] = char.ToUpper(strToChar[i]);
            }

            for (int i = indexOpen; i < indexOpen + openTag.Length; i++)
            {
                strToChar[i] = ' ';
            }

            for (int i = indexClose; i < indexClose + closeTag.Length; i++)
            {
                strToChar[i] = ' ';
            }
        }

        string temp = new string(strToChar);
        string result = Regex.Replace(temp, @"\s+", " ");
        Console.WriteLine(result);
    }
}