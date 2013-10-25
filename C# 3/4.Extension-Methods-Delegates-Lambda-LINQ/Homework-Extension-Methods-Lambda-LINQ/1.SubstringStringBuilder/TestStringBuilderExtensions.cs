/*Implement an extension method Substring(int index, int length)
 *for the class StringBuilder that returns new StringBuilder
 *and has the same functionality as Substring in the class String.*/

using System;
using System.Linq;
using System.Text;

namespace _1.SubstringStringBuilder
{
    class TestStringBuilderExtensions
    {
        static void Main()
        {
            StringBuilder testSubstring = new StringBuilder("My name is ...");
            Console.WriteLine(testSubstring.Substring(3, 7));

            //Console.WriteLine(testSubstring.Substring(3,-1)); //Throw ArgumentException
            //Console.WriteLine(testSubstring.Substring(5,20)); //Throw IndexOutOfRangeException
        }
    }
}
