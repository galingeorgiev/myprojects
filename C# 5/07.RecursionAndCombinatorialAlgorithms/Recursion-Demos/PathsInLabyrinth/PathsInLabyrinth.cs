using System;
using System.Collections.Generic;

class PathsInLabyrinth
{
    static char[,] lab = 
    {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
    };

	static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

    static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < lab.GetLength(0);
        bool colInRange = col >= 0 && col < lab.GetLength(1);
        return rowInRange && colInRange;
    }

    static void FindPathToExit(int row, int col)
    {
        if (!InRange(row, col))
        {
            // We are out of the labyrinth -> can't find a path
            return;
        }

        // Check if we have found the exit
        if (lab[row,col] == 'e')
        {
			PrintPath(row, col);
        }

        if (lab[row,col] != ' ')
        {
            // The current cell is not free -> can't find a path
            return;
        }

        // Temporary mark the current cell as visited to avoid cycles
        lab[row,col] = 's';
		path.Add(new Tuple<int, int>(row, col));

        // Invoke recursion the explore all possible directions
        FindPathToExit(row, col - 1); // left
        FindPathToExit(row - 1, col); // up
        FindPathToExit(row, col + 1); // right
        FindPathToExit(row + 1, col); // down

        // Mark back the current cell as free
        // Comment the below line to visit each cell at most once
        lab[row,col] = ' ';
		path.RemoveAt(path.Count - 1);
	}

	private static void PrintPath(int finalRow, int finalCol)
	{
		Console.Write("Found the exit: ");
		foreach (var cell in path)
		{
			Console.Write("({0},{1}) -> ", cell.Item1, cell.Item2);
		}
		Console.WriteLine("({0},{1})", finalRow, finalCol);
        Console.WriteLine();
	}

    static void Main()
    {
        // Uncomment the code below to create larger labirinth
        // Test with size = 10 and size = 100

        //int size = 10;
        //lab = new char[size, size];
        //for (int row = 0; row < size; row++)
        //{
        //    for (int col = 0; col < size; col++)
        //    {
        //        lab[row, col] = ' ';
        //    }
        //}
        //lab[size - 1, size - 1] = 'e';

        FindPathToExit(0, 0);
    }
}
