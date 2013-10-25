/* Define a class BitArray64 to hold 64 bit values inside an ulong value.
 * Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=. */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong bitArray;

        public BitArray64(ulong value)
        {
            this.bitArray = value;
        }

        public IEnumerator<int> GetEnumerator()
        {
            string bitArrayString = ULongToBinary(this.bitArray);
            for (int i = 0; i < bitArrayString.Length; i++)
            {
                yield return int.Parse(bitArrayString[i].ToString());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object bitArray)
        {
            BitArray64 bitArray64 = bitArray as BitArray64;
            /*if (bitArray64 == null)
            {
                throw new InvalidCastException("This element can not be casted to BitArray64");
            }*/

            bool isEquals = true;
            string bitArrayString = ULongToBinary(this.bitArray);
            int i = 0;
            foreach (var item in bitArray64)
            {
                if (item != int.Parse(bitArrayString[i].ToString()))
                {
                    isEquals = false;
                    break;
                }
                i++;
            }

            return isEquals;
        }

        public override int GetHashCode()
        {
            string bitArrayString = ULongToBinary(this.bitArray);
            int hashCode = 0;
            int i = 1;
            foreach (var item in bitArrayString)
            {
                hashCode = hashCode * i + (int)item * i;
                i = i + 10;
            }
            return hashCode;
        }

        public int this[int i]
        {
            get 
            {
                string bitArrayString = ULongToBinary(this.bitArray);
                return int.Parse(bitArrayString[i].ToString()); 
            }
        }

        public static bool operator ==(BitArray64 firstBitArray, BitArray64 secondBitArray)
        {
            return firstBitArray.Equals(secondBitArray);
        }

        public static bool operator !=(BitArray64 firstBitArray, BitArray64 secondBitArray)
        {
            return !(firstBitArray.Equals(secondBitArray));
        }

        private string ULongToBinary(ulong number)
        {
            ulong remainder;
            string result = string.Empty;
            while (number > 0)
            {
                remainder = number % 2;
                number /= 2;
                result = remainder.ToString() + result;
            }
            return result;
        }
    }
}
