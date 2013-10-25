using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static string[,] matrix = { { "ha", "fifi", "ho", "hi" }, { "fo", "ha", "hi", "xx" }, { "xxx", "ho", "ha", "xx" } };
    //static string[,] matrix = { { "s", "qq", "s" }, { "pp", "pp", "s" }, { "pp", "qq", "s" } };
    //static string[,] matrix = { { "v", "a", "b", "c", "d", "e", "f" }, { "g", "v", "h", "i", "j", "k", "l" }, { "m", "n", "v", "o", "v", "p", "q" }, { "r", "s", "t", "v", "u", "v", "w" }, { "x", "y", "z", "a", "b", "v", "c" }, { "d", "e", "f", "g", "h", "v", "i" }, { "j", "k", "l", "m", "o", "v", "p" } };
    static List<string> list = new List<string>();

    static void LongSequence(int row, int col, string word)
    {
        if (row < 0 | col < 0 | row >= matrix.GetLength(0) | col >= matrix.GetLength(1))
        {
            return;
        }

        if (matrix[row, col] == "visited")
        {
            return;
        }

        if (matrix[row, col] != word)
        {
            return;
        }

        list.Add(word);
        matrix[row, col] = "visited";

        LongSequence(row + 1, col + 1, word);
        LongSequence(row + 1, col, word);
        LongSequence(row + 1, col - 1, word);
        LongSequence(row, col - 1, word);
        LongSequence(row - 1, col - 1, word);
        LongSequence(row - 1, col, word);
        LongSequence(row - 1, col + 1, word);
        LongSequence(row, col + 1, word);
    }

    static void Main()
    {
        List<string> bestList = new List<string>();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] != "visited")
                {
                    LongSequence(i, j, matrix[i, j]);

                    if (list.Count > bestList.Count)
                    {
                        bestList.Clear();
                        for (int z = 0; z < list.Count; z++)
                        {
                            bestList.Add(list[z]);
                        }
                    }

                    //foreach (var item in list)
                    //{
                    //    Console.Write("{0} ", item);
                    //}
                    //Console.WriteLine();
                    list.Clear();
                }
            }
        }

        foreach (var item in bestList)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}