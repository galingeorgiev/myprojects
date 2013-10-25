namespace Task5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class GenerateAllSubsets
    {
        private static Twins[] currentLine;
        private static Twins[] setOfElements;
        private static bool[] isUsedAsStart;
        public static StringBuilder resultStr = new StringBuilder();
        public static int forbidenElement;

        public class Twins : IComparable<Twins>
        {
            private int x;
            private int y;

            public Twins(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int Y
            {
                get { return this.y; }
                set { this.y = value; }
            }


            public int X
            {
                get { return this.x; }
                set { this.x = value; }
            }


            public int CompareTo(Twins other)
            {
                int compareResult = this.x.CompareTo(other.x);
                if (compareResult == 0)
                {
                    compareResult = this.y.CompareTo(other.y);
                }

                return compareResult;
            }

            public override string ToString()
            {
                return string.Format("({0}, {1})", this.x, this.y);
            }
        }



        public static void GenerateCombinationsFrom1toN(int size, int startElement, Twins[] currentValue)
        {
            if (size == currentLine.Length)
            {
                for (int i = 0; i < currentLine.Length - 1; i++)
                {
                    resultStr.Append(currentLine[i]);
                    resultStr.Append(" | ");
                }

                resultStr.AppendLine(currentLine[currentLine.Length - 1].ToString());

                return;
            }
            else
            {
                for (int i = startElement; i < currentLine.Length; i++)
                {
                    if (!isUsedAsStart[i])
                    {
                        currentLine[size] = setOfElements[i];
                        GenerateCombinationsFrom1toN(size + 1, i, currentLine);
                    }
                }
            }
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            currentLine = new Twins[n];
            setOfElements = new Twins[n];
            

            for (int i = 0; i < n; i++)
            {
                string[] currentLineTwins = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                setOfElements[i] = new Twins(int.Parse(currentLineTwins[0]), int.Parse(currentLineTwins[1]));
            }

            Array.Sort(setOfElements);

            for (int i = 0; i < n; i++)
            {
                isUsedAsStart = new bool[n];
                isUsedAsStart[i] = true;
                currentLine[i] = setOfElements[i];
                GenerateCombinationsFrom1toN(1, 0, currentLine);
            }

            Console.WriteLine(resultStr);
        }
    }
}