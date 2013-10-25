/* Define a class InvalidRangeException<T> that holds information
 * about an error condition related to invalid range. It should
 * hold error message and a range definition [start … end]. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.InvalidRangeException
{
    public class InvalidRangeException<T> : ApplicationException
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        private T start;
        private T end;

        public InvalidRangeException(string message, T start, T end, Exception innerException)
            : base(message, innerException)
        {
            this.start = start;
            this.end = end;
        }

        public InvalidRangeException(T start, T end)
            : this(null, start, end, null)
        {
        }

        public InvalidRangeException(string message, T start, T end)
            : this(message, start, end, null)
        {
        }
    }
}