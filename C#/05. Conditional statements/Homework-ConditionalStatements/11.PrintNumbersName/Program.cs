using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PrintNumbersName
{
    class Program
    {
        static string ValuesBetween0and9(int number)
        {
            string returnedValue = null;
            switch (number)
            {
                case 0: returnedValue = "Zero"; break;
                case 1: returnedValue = "One"; break;
                case 2: returnedValue = "Two"; break;
                case 3: returnedValue = "Three"; break;
                case 4: returnedValue = "Four"; break;
                case 5: returnedValue = "Five"; break;
                case 6: returnedValue = "Six"; break;
                case 7: returnedValue = "Seven"; break;
                case 8: returnedValue = "Eight"; break;
                case 9: returnedValue = "Nine"; break;
            }
            return returnedValue;
        }
        static string ValuesBetween10and19(int number)
        {
            string returnedValue = null;
            switch (number)
            {
                case 10: returnedValue = "Ten"; break;
                case 11: returnedValue = "Eleven"; break;
                case 12: returnedValue = "Twelve"; break;
                case 13: returnedValue = "Thirteen"; break;
                case 14: returnedValue = "Fourteen"; break;
                case 15: returnedValue = "Fifteen"; break;
                case 16: returnedValue = "Sixteen"; break;
                case 17: returnedValue = "Seventeen"; break;
                case 18: returnedValue = "Eighteen"; break;
                case 19: returnedValue = "Nineteen"; break;
            }
            return returnedValue;
        }
        static string DecimalValues(int number)
        {
            string returnedValue = null;
            switch (number)
            {
                case 2: returnedValue  = "Twenty"; break;
                case 3: returnedValue  = "Thirty"; break;
                case 4: returnedValue  = "Fourty"; break;
                case 5: returnedValue = "Fifty"; break;
                case 6: returnedValue = "Sixty"; break;
                case 7: returnedValue  = "Seventy"; break;
                case 8: returnedValue  = "Eighty"; break;
                case 9: returnedValue  = "Ninety"; break;
            }
            return returnedValue;
        }
        static void Main()
        {
            string valueLenghtString = Console.ReadLine();
            int valueSwitch = int.Parse(valueLenghtString);
            switch (valueLenghtString.Length)
            {
                case 1:
                    Console.WriteLine("{0}", ValuesBetween0and9(valueSwitch));
                    break;
                case 2:
                    if (valueSwitch > 9 & valueSwitch < 20)
                    {
                        Console.WriteLine(ValuesBetween10and19(valueSwitch));
                    }
                    else
                    {
                        int secondDigit = valueSwitch % 10;
                        int firstDigit = valueSwitch / 10;
                        string one = DecimalValues(firstDigit);
                        string two = ValuesBetween0and9(secondDigit);
                        Console.WriteLine("{0} {1}", one, two);
                    }
                    break;
                case 3:
                    int firstDigit3 = valueSwitch / 100;
                    int secondDigit3 = (valueSwitch / 10) % 10;
                    int thirdDigit3 = valueSwitch % 10;
                    if (secondDigit3 == 0 & thirdDigit3 == 0)
                    {
                        Console.WriteLine("{0} hundred", ValuesBetween0and9(firstDigit3));
                    }
                    else
                    {
                        if (secondDigit3 == 0 & (thirdDigit3 > 0 & thirdDigit3 < 10))
                        {
                            Console.WriteLine("{0} hundred and {1}", ValuesBetween0and9(firstDigit3), ValuesBetween0and9(thirdDigit3));
                        }
                        else
                        {
                            if (secondDigit3 == 1)
                            {
                                Console.WriteLine("{0} hundred and {1}", ValuesBetween0and9(firstDigit3), ValuesBetween10and19(valueSwitch % 100));
                            }
                            else
                            {
                                Console.WriteLine("{0} hundred {1} {2}",
                                    ValuesBetween0and9(firstDigit3), DecimalValues(secondDigit3), ValuesBetween0and9(thirdDigit3));
                            }
                        }
                    }
                    break;
                default: Console.WriteLine("You must enter value in range [0-999].");
                    break;
            }
        }
    }
}
