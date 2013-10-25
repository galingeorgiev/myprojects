using System;
using System.Diagnostics;
using System.Threading;

/*Write a program to compare the performance of add, subtract, increment, multiply, divide for int, long, float, double and decimal values. */

namespace NumbersPerformanceTest
{
    class NumbersPerformanceTest
    {
        private const int NumberOfIteration = 10000000;

        #region AddTestMethods
        private static void AddIntTest()
        {
            int result = 0;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result + 10;
            }
        }

        private static void AddLongTest()
        {
            long result = 0L;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result + 10L;
            }
        }

        private static void AddFloatTest()
        {
            float result = 0F;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result + 10F;
            }
        }

        private static void AddDoubleTest()
        {
            double result = 0D;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result + 10D;
            }
        }

        private static void AddDecimalTest()
        {
            decimal result = 0M;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result + 10M;
            }
        }
        #endregion

        #region SubtractTestMethods
        private static void SubtractIntTest()
        {
            int result = int.MaxValue;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result - 10;
            }
        }

        private static void SubtractLongTest()
        {
            long result = long.MaxValue;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result - 10L;
            }
        }

        private static void SubtractFloatTest()
        {
            float result = float.MaxValue;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result - 10F;
            }
        }

        private static void SubtractDoubleTest()
        {
            double result = double.MaxValue;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result - 10D;
            }
        }

        private static void SubtractDecimalTest()
        {
            decimal result = decimal.MaxValue;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result - 10M;
            }
        }
        #endregion

        #region IncrementTestMethods
        private static void IncrementIntTest()
        {
            int result = 0;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result++;
            }
        }

        private static void IncrementLongTest()
        {
            long result = 0L;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result++;
            }
        }

        private static void IncrementFloatTest()
        {
            float result = 0F;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result++;
            }
        }

        private static void IncrementDoubleTest()
        {
            double result = 0D;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result++;
            }
        }

        private static void IncrementDecimalTest()
        {
            decimal result = 0M;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result++;
            }
        }
        #endregion

        #region MultiplyTestMethods
        private static void MultiplyIntTest()
        {
            int result = 0;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result * 1;
            }
        }

        private static void MultiplyLongTest()
        {
            long result = 0L;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result * 1L;
            }
        }

        private static void MultiplyFloatTest()
        {
            float result = 0F;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result * 1F;
            }
        }

        private static void MultiplyDoubleTest()
        {
            double result = 0D;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result * 1D;
            }
        }

        private static void MultiplyDecimalTest()
        {
            decimal result = 0M;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result * 1M;
            }
        }
        #endregion

        #region DivideTestMethods
        private static void DivideIntTest()
        {
            int result = 0;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result / 1;
            }
        }

        private static void DivideLongTest()
        {
            long result = 0L;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result / 1L;
            }
        }

        private static void DivideFloatTest()
        {
            float result = 0F;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result / 1F;
            }
        }

        private static void DivideDoubleTest()
        {
            double result = 0D;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result / 1D;
            }
        }

        private static void DivideDecimalTest()
        {
            decimal result = 0M;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result / 1M;
            }
        }
        #endregion

        static void Main()
        {
            // Test add methods with different types.
            Stopwatch sw = new Stopwatch();
            sw.Start();
            AddIntTest();
            sw.Stop();
            Console.WriteLine("Test add with int. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            AddLongTest();
            sw.Stop();
            Console.WriteLine("Test add with long. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            AddFloatTest();
            sw.Stop();
            Console.WriteLine("Test add with float. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            AddDoubleTest();
            sw.Stop();
            Console.WriteLine("Test add with Double. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            AddDecimalTest();
            sw.Stop();
            Console.WriteLine("Test add with decimal. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
            Console.WriteLine();

            // Test subtract methods with different types.
            sw.Start();
            SubtractIntTest();
            sw.Stop();
            Console.WriteLine("Test subtract with int. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            SubtractLongTest();
            sw.Stop();
            Console.WriteLine("Test subtract with long. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            SubtractFloatTest();
            sw.Stop();
            Console.WriteLine("Test subtract with float. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            SubtractDoubleTest();
            sw.Stop();
            Console.WriteLine("Test subtract with Double. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            SubtractDecimalTest();
            sw.Stop();
            Console.WriteLine("Test subtract with decimal. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
            Console.WriteLine();

            // Test increment methods with different types.
            sw.Start();
            IncrementIntTest();
            sw.Stop();
            Console.WriteLine("Test increment with int. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            IncrementLongTest();
            sw.Stop();
            Console.WriteLine("Test increment with long. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            IncrementFloatTest();
            sw.Stop();
            Console.WriteLine("Test increment with float. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            IncrementDoubleTest();
            sw.Stop();
            Console.WriteLine("Test increment with Double. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            IncrementDecimalTest();
            sw.Stop();
            Console.WriteLine("Test increment with decimal. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
            Console.WriteLine();

            // Test multiply methods with different types.
            sw.Start();
            MultiplyIntTest();
            sw.Stop();
            Console.WriteLine("Test multiply with int. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            MultiplyLongTest();
            sw.Stop();
            Console.WriteLine("Test multiply with long. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            MultiplyFloatTest();
            sw.Stop();
            Console.WriteLine("Test multiply with float. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            MultiplyDoubleTest();
            sw.Stop();
            Console.WriteLine("Test multiply with Double. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            MultiplyDecimalTest();
            sw.Stop();
            Console.WriteLine("Test multiply with decimal. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
            Console.WriteLine();

            // Test divide methods with different types.
            sw.Start();
            DivideIntTest();
            sw.Stop();
            Console.WriteLine("Test divide with int. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            DivideLongTest();
            sw.Stop();
            Console.WriteLine("Test divide with long. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            DivideFloatTest();
            sw.Stop();
            Console.WriteLine("Test divide with float. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            DivideDoubleTest();
            sw.Stop();
            Console.WriteLine("Test divide with Double. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            DivideDecimalTest();
            sw.Stop();
            Console.WriteLine("Test divide with decimal. Execution time: {0} milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
            Console.WriteLine();
        }
    }
}
