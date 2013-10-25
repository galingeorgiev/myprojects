/* Take the VS solution "Methods" and refactor its code to follow the guidelines of
 * high-quality methods. Ensure you handle errors correctly: when the methods cannot
 * do what their name says, throw an exception (do not return wrong result).
 * Ensure good cohesion and coupling, good naming, no side effects, etc. */

namespace Methods
{
    using System;

    internal class Methods
    {
        internal static double CalcTriangleArea(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double halfPerimetar = (firstSide + secondSide + thirdSide) / 2;
            double area = Math.Sqrt(halfPerimetar * (halfPerimetar - firstSide) * (halfPerimetar - secondSide) * (halfPerimetar - thirdSide));
            return area;
        }

        internal static string DigitToEnglishWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "Invalid number!";
            }
        }

        internal static int FindMax(params int[] elements)
        {
            if (elements.Length == 0)
            {
                throw new ArgumentException("Method FondMax() should contains one or more arguments.");
            }

            if (elements == null)
            {
                throw new NullReferenceException("Method FondMax() doesn't accept null arguments");
            }

            int maxElements = int.MinValue;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElements)
                {
                    maxElements = elements[i];
                }
            }

            return maxElements;
        }

        internal static void PrintFormatedNumber(object number, string format)
        {
            // May be we should check if number can be parsed, but I don't know with what kind of numbers method should work.
            if (format != "f" && format == "%" && format == "r")
            {
                throw new ArgumentException("Unknow format. Please enter 'f', '%', 'r'.");
            }

            switch (format)
            {
                case "f": 
                    Console.WriteLine("{0:f2}", number); 
                    break;
                case "%": 
                    Console.WriteLine("{0:p0}", number); 
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
            }
        }

        internal static double CalcDistance(double pointX1, double pointY1, double pointX2, double pointY2)
        {
            double distanceBetweenPoints = ((pointX2 - pointX1) * (pointX2 - pointX1)) + ((pointY2 - pointY1) * (pointY2 - pointY1));
            if (distanceBetweenPoints < 0)
            {
                throw new ArithmeticException("Operation SQRT must accept positive value.");
            }

            double distance = Math.Sqrt(distanceBetweenPoints);
            return distance;
        }

        internal static bool IsLineHorizontal(double pointY1, double pointY2)
        {
            bool isHorizontal = (pointY1 == pointY2);
            return isHorizontal;
        }

        internal static bool IsLineVertical(double pointX1, double pointX2)
        {
            bool isVertical = (pointX1 == pointX2);
            return isVertical;
        }

        internal static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(DigitToEnglishWord(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintFormatedNumber(1.3, "f");
            PrintFormatedNumber(0.75, "%");
            PrintFormatedNumber(2.30, "r");

            double x1 = 3;
            double y1 = -1;
            double x2 = 3;
            double y2 = 2.5;
            Console.WriteLine(CalcDistance(x1, y1, x2, y2));
            bool horizontal = IsLineHorizontal(y1, y2);
            bool vertical = IsLineVertical(x1, x2);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
