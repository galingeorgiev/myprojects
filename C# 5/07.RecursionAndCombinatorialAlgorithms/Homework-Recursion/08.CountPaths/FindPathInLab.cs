/* Modify the above program to check whether a path exists 
 * between two cells without finding all possible paths.
 * Test it over an empty 100 x 100 matrix.
 */

namespace CountPaths
{
    using System;

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

        private static char[,] bigMatrix;

        private static int pathsCount = 0;

        public static void Main()
        {
            FindPath(0, 0, matrix);
            Console.WriteLine(pathsCount);

            // Create matrix 100x100
            // Test first with matrix 5x5
            // After that you can change to 100x100 and see that this is very very slow.
            bigMatrix = new char[5, 5];
            for (int i = 0; i < bigMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < bigMatrix.GetLength(1); j++)
                {
                    bigMatrix[i, j] = ' ';
                }
            }

            bigMatrix[bigMatrix.GetLength(0) - 1, bigMatrix.GetLength(1) - 1] = 'e';

            pathsCount = 0;
            FindPath(0, 0, bigMatrix);
            Console.WriteLine(pathsCount);
        }

        private static void FindPath(int row, int col, char[,] matrix)
        {
            if (row >= matrix.GetLength(0) || row < 0 || col >= matrix.GetLength(1) || col < 0)
            {
                return;
            }

            if (matrix[row, col] == '*' || matrix[row, col] == 'V')
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                pathsCount++;
                return;
            }

            matrix[row, col] = 'V';

            // up
            FindPath(row - 1, col, matrix);

            // right
            FindPath(row, col + 1, matrix);

            // down
            FindPath(row + 1, col, matrix);

            // left
            FindPath(row, col - 1, matrix);

            matrix[row, col] = ' ';
        }
    }
}
