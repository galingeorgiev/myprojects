using System;

namespace RefactorCSharpCode
{
    public class BoolPrinter
    {
        public void PrintBoolVarible(bool variable)
        {
            string varibleToString = variable.ToString();
            Console.WriteLine(varibleToString);
        }
    }
}
