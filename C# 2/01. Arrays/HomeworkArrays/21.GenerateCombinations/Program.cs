using System;

class Program
{
    static int kLoop = 0;
    static int nIteration = 0;
    static int[] loop;

    static void GenerateCombinationsRecursive(int curentLoop)
    {
        if (curentLoop == kLoop)
        {
            PrintLoop(loop);
            return;
        }

        for (int i = 1; i <= nIteration; i++)
        {
            loop[curentLoop] = i;
            GenerateCombinationsRecursive(curentLoop + 1);
        }
    }

    static void PrintLoop(int[] loop)
    {
        bool isPrint = true;

        for (int i = 0; i < loop.Length - 1; i++)
        {
            if (loop[i] >= loop[i + 1])
            {
                isPrint = false;
                break;
            }
        }
        if (isPrint)
        {
            for (int i = 0; i < loop.Length; i++)
            {
                Console.Write("{0,3}", loop[i]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.Write("N = ");
        nIteration = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        kLoop = int.Parse(Console.ReadLine());
        loop = new int[kLoop];

        GenerateCombinationsRecursive(0);
    }
}