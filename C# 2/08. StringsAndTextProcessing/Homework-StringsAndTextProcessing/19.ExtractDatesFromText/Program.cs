using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

class MailExtracter
{
    static void Main()
    {
        string data = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";

        ExtractDates(data);
    }

    public static void ExtractDates(string data)
    {
        Regex dateRegex = new Regex(@"([0-9]|[0-3][0-9]).([0-9]|[0-1][0-9]).([0-9][0-9][0-9][0-9])",
            RegexOptions.IgnoreCase);
        //find items that matches with pattern
        MatchCollection dates = dateRegex.Matches(data);

        StringBuilder sb = new StringBuilder();

        foreach (Match date in dates)
        {
            sb.AppendLine(date.Value);
        }

        Console.WriteLine(sb.ToString());
    }
}
