using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NumbersPerformanceTest
{
    class Program
    {
        private const int NumberOfIteration = 10000000;

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
            double result = 0;
            for (int i = 0; i < NumberOfIteration; i++)
            {
                result = result + 10;
            }
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            AddIntTest();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
