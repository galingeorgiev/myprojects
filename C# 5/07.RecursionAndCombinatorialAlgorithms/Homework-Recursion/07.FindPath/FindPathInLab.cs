/* We are given a matrix of passable and non-passable cells. 
 * Write a recursive program for finding all paths between 
 * two cells in the matrix.
 */

namespace FindPath
{
    using System;
    using System.Collections.Generic;

    public class FindPathInLab
    {
        private static char[,] matrix =
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { '*', '*', ' ', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
        };

        private static List<char> path = new List<char>();

        public static void Main()
        {
            FindPath(0, 0, 'S');
        }

        private static void FindPath(int row, int col, char direction)
        {
            if (row >= matrix.GetLength(0) || row < 0 || col >= matrix.GetLength(1) || col < 0)
            {
                return;
            }

            if (matrix[row, col] == '*' || matrix[row, col] == 'V')
            {
                return;
            }

            path.Add(direction);

            if (matrix[row, col] == 'e')
            {
                Console.Write("Found path: " + string.Join(" -> ", path) + "\n");
                path.RemoveAt(path.Count - 1);
                return;
            }

            matrix[row, col] = 'V';

            // up
            FindPath(row - 1, col, 'U');

            // right
            FindPath(row, col + 1, 'R');

            // down
            FindPath(row + 1, col, 'D');

            // left
            FindPath(row, col - 1, 'L');

            matrix[row, col] = ' ';
            path.RemoveAt(path.Count - 1);
        }
    }
}