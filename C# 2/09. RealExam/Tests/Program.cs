using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        string tab = ">>";
        //string tabs = new string(tab,2);
        sb.Append(string.Concat(Enumerable.Repeat(tab, 2)));
        Console.WriteLine(sb);

        int n = 3 % 10;
        Console.WriteLine(n);
    }
}