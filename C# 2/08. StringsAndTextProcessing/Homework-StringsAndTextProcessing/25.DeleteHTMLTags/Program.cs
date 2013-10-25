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
        string text = "<html><head><title>News</title></head> <body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";

        string newLine = Regex.Replace(text, "<[^>]*>", "\n\r");
        newLine = Regex.Replace(newLine, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
        Console.WriteLine(newLine);
    }
}