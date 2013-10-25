using System;
using System.Linq;
using System.Text;

namespace _1.SubstringStringBuilder
{
    static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder stringBuilder, int start, int length)
        {
            if (start + length > stringBuilder.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (start < 0 | length <= 0)
            {
                throw new ArgumentException("Start and length must beeing bigger from zero.");
            }

            StringBuilder resultStrBuilder = new StringBuilder();
            for (int i = start; i < start + length; i++)
            {
                resultStrBuilder.Append(stringBuilder[i]);
            }
            return resultStrBuilder;
        }
    }
}
