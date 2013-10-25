/* Write a recursive program to find the largest 
 * connected area of adjacent empty cells in a matrix.
 */

namespace LargestConnectedArea
{
    using System;

    public class LargestConnectedArea
    {
        private static char[,] matrix =
        {
            { ' ', ' ', ' ', '*', '*', ' ', ' ' },
            { ' ', '*', '*', '*', '*', ' ', ' ' },
            { ' ', '*', '*', ' ', '*', '*', '*' },
            { '*', ' ', '*', ' ', ' ', ' ', '*' },
            { ' ', ' ', '*', ' ', ' ', ' ', '*' },
        };

        /*
         * |   |   |   | * | * |   |   |
         * |   | * | * | * | * |   |   |
         * |   | * | * | 1 | * | * | * |
         * | * |   | * | 2 | 4 | 6 | * |
         * |   |   | * | 3 | 5 | 7 | * |
         * 
         * If two cells have common side they are neighbors.
         */

        private static int elementsInArea = 0;
        private static int bestCountedElements = 0;

        public static void Main()
        {
            FindLargestConnectedArea();
            Console.WriteLine(bestCountedElements);
        }

        private static void FindLargestConnectedArea()
        {
            while (HasFreeCell())
            {
                if (elementsInArea > bestCountedElements)
                {
                    bestCountedElements = elementsInArea;
                }

                elementsInArea = 0;
                int[] nextFreeCellCoords = FintNextFreeCell();
                FindLargestConnectedSubArea(nextFreeCellCoords[0], nextFreeCellCoords[1]);
            }
        }

        private static void FindLargestConnectedSubArea(int row, int col)
        {
            if (row >= matrix.GetLength(0) || row < 0 || col >= matrix.GetLength(1) || col < 0)
            {
                return;
            }

            if (matrix[row, col] == '*' || matrix[row, col] == 'V')
            {
                return;
            }

            elementsInArea++;
            matrix[row, col] = 'V';

            // up
            FindLargestConnectedSubArea(row - 1, col);

            // right
            FindLargestConnectedSubArea(row, col + 1);

            // down
            FindLargestConnectedSubArea(row + 1, col);

            // left
            FindLargestConnectedSubArea(row, col - 1);
        }

        private static int[] FintNextFreeCell()
        {
            int[] nextFreeCellCoords = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ' ')
                    {
                        nextFreeCellCoords[0] = i;
                        nextFreeCellCoords[1] = j;
                    }
                }
            }

            return nextFreeCellCoords;
        }

        private static bool HasFreeCell()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ' ')
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
