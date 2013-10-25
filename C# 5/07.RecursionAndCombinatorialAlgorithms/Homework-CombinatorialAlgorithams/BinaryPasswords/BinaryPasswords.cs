/* Problem 1 from page below
 * http://academy.telerik.com/algoacademy/season-2012-2013/training-27-28-Oct-2012-combinatorics
 * You can test code in BGCODER
 * http://bgcoder.com/Contest/Practice/59
 * 01. Двоични пароли
 */

namespace BinaryPasswords
{
    using System;

    public class BinaryPasswords
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int numberOfEmptyDigits = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    numberOfEmptyDigits++;
                }
            }

            long result = (long)Math.Pow(2, numberOfEmptyDigits);
            Console.WriteLine(result);
        }
    }
}
