/* Define a class BitArray64 to hold 64 bit values inside an ulong value.
 * Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=. */

using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.BitArray64
{
    class TestBitArray64
    {
        static void Main()
        {
            Console.WriteLine("----- Show foreach result -----");
            BitArray64 testBitArray = new BitArray64(8);
            foreach (var item in testBitArray)
            {
                Console.Write(item);
            }

            Console.WriteLine("\n----- Show Equals result -----");
            BitArray64 firstBitArray = new BitArray64(10);
            BitArray64 secondBitArray = new BitArray64(11);
            BitArray64 thirdBitArray = new BitArray64(10);
            Console.WriteLine("firstBitArray.Equals(secondBitArray): {0}",firstBitArray.Equals(secondBitArray));
            Console.WriteLine("firstBitArray.Equals(thirdBitArray): {0}", firstBitArray.Equals(thirdBitArray));
            Console.WriteLine("secondBitArray.Equals(thirdBitArray): {0}", secondBitArray.Equals(thirdBitArray));

            Console.WriteLine("\n----- Show hash code -----");
            Console.WriteLine("Hash code of firstBitArray is: {0}", firstBitArray.GetHashCode());
            Console.WriteLine("Hash code of secondBitArray is: {0}", secondBitArray.GetHashCode());

            Console.WriteLine("\n----- Show operator [] -----");
            for (int i = 0; i < testBitArray.Count(); i++)
            {
                Console.Write(testBitArray[i]);
            }

            Console.WriteLine("\n----- Show operators == and != -----");
            Console.WriteLine("firstBitArray == secondBitArray : {0}", firstBitArray == secondBitArray);
            Console.WriteLine("firstBitArray == thirdBitArray : {0}", firstBitArray == thirdBitArray);
            Console.WriteLine("firstBitArray != secondBitArray : {0}", firstBitArray != secondBitArray);
            Console.WriteLine("firstBitArray != thirdBitArray : {0}", firstBitArray != thirdBitArray);
        }
    }
}
