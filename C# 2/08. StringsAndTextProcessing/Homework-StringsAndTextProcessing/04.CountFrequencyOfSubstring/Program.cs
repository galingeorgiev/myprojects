using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string strLowerCase = str.ToLower();
        string searchedSubstring = "in";
        string searchedSubstringToLower = searchedSubstring.ToLower();

        int index = -1;
        int counter = 0;

        while (true)
        {
            index = str.IndexOf(searchedSubstringToLower, index + 1);
            counter++;
            if (index < 0)
            {
                break;
            }
        }

        Console.WriteLine("Result is: {0}", counter);
    }
}