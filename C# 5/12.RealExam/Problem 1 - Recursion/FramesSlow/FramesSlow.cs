using System;
using System.Collections.Generic;

class Frames
{
    static Tuple<int, int>[] frames;
    static bool[] used;
    static Tuple<int, int>[] generated;
    static SortedSet<string> allPermutations = new SortedSet<string>();

    static void Main()
    {
        ReadFrames();
        used = new bool[frames.Length];
        generated = new Tuple<int, int>[frames.Length];
        GeneratePermutations(0);
        PrintPermutations();
    }

    private static void ReadFrames()
    {
        int n = int.Parse(Console.ReadLine());
        frames = new Tuple<int, int>[n];
        for (int i = 0; i < n; i++)
        {
            string frameSizes = Console.ReadLine();
            string[] sizes = frameSizes.Split(' ');
            int width = int.Parse(sizes[0]);
            int heigth = int.Parse(sizes[1]);
            frames[i] = new Tuple<int, int>(width, heigth);
        }
    }

    static void GeneratePermutations(int k)
    {
        if (k == frames.Length)
        {
            string permutation = String.Join(" | ", (object[])generated);
            allPermutations.Add(permutation);
        }
        else
        {
            for (int i = 0; i < frames.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    generated[k] = frames[i];
                    GeneratePermutations(k + 1);
                    generated[k] = new Tuple<int, int>(frames[i].Item2, frames[i].Item1);
                    GeneratePermutations(k + 1);
                    used[i] = false;
                }
            }
        }
    }

    static void PrintPermutations()
    {
        Console.WriteLine(allPermutations.Count);
        foreach (var perm in allPermutations)
        {
            Console.WriteLine(perm);
        }
    }
}
