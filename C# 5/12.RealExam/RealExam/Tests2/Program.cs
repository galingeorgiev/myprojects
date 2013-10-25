using System;

namespace ConsoleApplication1
{
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
            int compareResult = this.x.CompareTo(other.y);
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

    static class Program
    {
        public static Twins[] setOfElements;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            setOfElements = new Twins[n];

            for (int i = 0; i < n; i++)
            {
                string[] currentLineTwins = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                setOfElements[i] = new Twins(int.Parse(currentLineTwins[0]), int.Parse(currentLineTwins[1]));
            }

            Array.Sort(setOfElements);

            for (int i = 0; i < n; i++)
            {
                Permute(setOfElements, Output, i);
            }
            //Permute(setOfElements, Output);
            Console.WriteLine();

            Console.ReadLine();
        }

        private static void Output<Twins>(Twins[] permutation)
        {
            foreach (var item in permutation)
            {
                Console.Write(item);
                Console.Write(" ");
            }

            Console.WriteLine();
        }

        public static void Permute<Twins>(Twins[] items, Action<Twins[]> output, int i)
        {
            Twins[] currOut = new Twins[items.Length];
            //currOut[0] = setOfElements[i];
            Permute(items, 0, currOut, new bool[items.Length], output, i);
        }

        private static void Permute<Twins>(Twins[] items, int item, Twins[] permutation, bool[] used, Action<Twins[]> output, int ii)
        {
            for (int i = 0; i < items.Length; ++i)
            {
                //if (!used[i])
                //{
                    used[i] = true;
                    
                    permutation[item] = items[i];

                    if (item < (items.Length - 1))
                    {
                        Permute(items, item + 1, permutation, used, output, ii);
                    }
                    else
                    {
                        output(permutation);
                    }

                    used[i] = false;
                //}
            }
        }
    }
}