using System;
using System.Diagnostics;

/*Write a program to compare the performance of square root, natural logarithm, sinus for float, double and decimal values. */

namespace MathematicOperationsPerformanceTest
{
    class MathematicOperationsPerformanceTest
    {
        private const int NumberOfIteration = 10000000;

        #region TestSqrtMethods
        static void SqrtFloatPerformanceTest()
        {
            float result = 0F;
            for (float i = 1; i < NumberOfIteration; i++)
            {
                result = (float)Math.Sqrt(i);
            }
        }

        static void SqrtDoublePerformanceTest()
        {
            double result = 0;
            for (double i = 1; i < NumberOfIteration; i++)
            {
                result = Math.Sqrt(i);
            }
        }

        static void SqrtDecimalPerformanceTest()
        {
            decimal result = 0M;
            for (decimal i = 1; i < NumberOfIteration; i++)
            {
                result = (decimal)Math.Sqrt((double)i);
            }
        }
        #endregion

        #region TestLog10Methods
        static void Log10FloatPerformanceTest()
        {
            float result = 0F;
            for (float i = 1; i < NumberOfIteration; i++)
            {
                result = (float)Math.Log10(i);
            }
        }

        static void Log10DoublePerformanceTest()
        {
            double result = 0;
            for (double i = 1; i < NumberOfIteration; i++)
            {
                result = Math.Log10(i);
            }
        }

        static void Log10DecimalPerformanceTest()
        {
            decimal result = 0M;
            for (decimal i = 1; i < NumberOfIteration; i++)
            {
                result = (decimal)Math.Log10((double)i);
            }
        }
        #endregion

        #region TestSinMethods
        static void SinFloatPerformanceTest()
        {
            float result = 0F;
            for (float i = 1; i < NumberOfIteration; i++)
            {
                result = (float)Math.Sin(i);
            }
        }

        static void SinDoublePerformanceTest()
        {
            double result = 0;
            for (double i = 1; i < NumberOfIteration; i++)
            {
                result = Math.Sin(i);
            }
        }

        static void SinDecimalPerformanceTest()
        {
            decimal result = 0M;
            for (decimal i = 1; i < NumberOfIteration; i++)
            {
                result = (decimal)Math.Sin((double)i);
            }
        }
        #endregion

        static void Main()
        {
            // Test sqrt methods with different types.
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SqrtFloatPerformanceTest();
            sw.Stop();
            Console.WriteLine("Test sqrt with float. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            SqrtDoublePerformanceTest();
            sw.Stop();
            Console.WriteLine("Test sqrt with double. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            SqrtDecimalPerformanceTest();
            sw.Stop();
            Console.WriteLine("Test sqrt with decimal. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
            Console.WriteLine();

            // Test log10 methods with different types.
            sw.Start();
            Log10FloatPerformanceTest();
            sw.Stop();
            Console.WriteLine("Test log10 with float. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            Log10DoublePerformanceTest();
            sw.Stop();
            Console.WriteLine("Test log10 with double. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            Log10DecimalPerformanceTest();
            sw.Stop();
            Console.WriteLine("Test log10 with decimal. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
            Console.WriteLine();

            // Test sin methods with different types.
            sw.Start();
            SinFloatPerformanceTest();
            sw.Stop();
            Console.WriteLine("Test sin with float. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            SinDoublePerformanceTest();
            sw.Stop();
            Console.WriteLine("Test sin with double. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            SinDecimalPerformanceTest();
            sw.Stop();
            Console.WriteLine("Test sin with decimal. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
            Console.WriteLine();
        }
    }
}
