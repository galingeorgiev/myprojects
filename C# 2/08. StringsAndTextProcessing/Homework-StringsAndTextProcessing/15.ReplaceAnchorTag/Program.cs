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
        string text = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
        string hrefPattern = @"<\s*a\s[^>]*?\bhref\s*=\s*" +
                             @"('(?<url>[^']*)'|""(?<url>[^""]*)""|" +
                             @"(?<url>\S*))[^>]*>" +
                             @"(?<linktext>(.|\s)*?)<\s*/a\s*>";
        string newPattern = "[URL=${url}]${linktext}[/URL]";
        
        text = Regex.Replace(text, hrefPattern, newPattern);
        Console.WriteLine(text);
    }
}