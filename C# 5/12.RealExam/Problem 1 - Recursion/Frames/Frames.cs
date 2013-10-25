using System;
using System.Collections.Generic;

class Frames
{
    static Tuple<int, int>[] frames;
    static SortedSet<string> allPermutations = new SortedSet<string>();

    static void Main()
    {
        ReadFrames();
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
            string permutation = String.Join(" | ", (object[])frames);
            allPermutations.Add(permutation);
        }
        else
        {
            for (int i = k; i < frames.Length; i++)
            {
                SwapFrames(k, i);
                GeneratePermutations(k + 1);
                FlipFrame(k);
                GeneratePermutations(k + 1);
                FlipFrame(k);
                SwapFrames(k, i);
            }
        }
    }

    static void FlipFrame(int k)
    {
        frames[k] = new Tuple<int, int>(frames[k].Item2, frames[k].Item1);
    }

    static void SwapFrames(int k, int i)
    {
        var oldFrame = frames[i];
        frames[i] = frames[k];
        frames[k] = oldFrame;
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
