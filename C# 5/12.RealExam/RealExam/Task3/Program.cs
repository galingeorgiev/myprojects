namespace Task3
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        public static List<char[,]> matrix;
        public static int numberOfFllors;
        public static int numberOfRows;
        public static int numberOfCols;
        public static long bestSteps = long.MaxValue;

        private static void FindPath(int floor, int row, int col, long steps)
        {
            if (row >= matrix[floor].GetLength(0) || row < 0 || col >= matrix[floor].GetLength(1) || col < 0)
            {
                return;
            }

            if (matrix[floor][row, col] == '#' || matrix[floor][row, col] == 'V')
            {
                return;
            }

            steps++;

            if (matrix[floor][row, col] == 'U')
            {
                floor++;
                steps++;
                if (floor == numberOfFllors)
                {
                    if (bestSteps > steps)
                    {
                        bestSteps = steps;
                    }

                    return;
                }
            }

            if (matrix[floor][row, col] == 'D')
            {
                floor--;
                steps++;
                if (floor == -1)
                {
                    if (bestSteps > steps)
                    {
                        bestSteps = steps;
                    }

                    return;
                }
            }

            matrix[floor][row, col] = 'V';

            // up
            FindPath(floor, row - 1, col, steps);
            
            // right
            FindPath(floor, row, col + 1, steps);

            // down
            FindPath(floor, row + 1, col, steps);

            // left
            FindPath(floor, row, col - 1, steps);

            matrix[floor][row, col] = '.';
        }

        static void Main()
        {
            string[] fLine = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            int statFloor = int.Parse(fLine[0]);
            int statRow = int.Parse(fLine[1]);
            int statCol = int.Parse(fLine[2]);

            string[] sLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            numberOfFllors = int.Parse(sLine[0]);
            numberOfRows = int.Parse(sLine[1]);
            numberOfCols = int.Parse(sLine[2]);

            matrix = new List<char[,]>();

            for (int i = 0; i < numberOfFllors; i++)
            {
                char[,] currFloor = new char[numberOfRows, numberOfCols];
                for (int j = 0; j < numberOfRows; j++)
                {
                    string currLine = Console.ReadLine();
                    for (int z = 0; z < numberOfCols; z++)
                    {
                        currFloor[j, z] = currLine[z];
                    }
                }

                matrix.Add(currFloor);
            }

            FindPath(statFloor, statRow, statCol, -1);
            Console.WriteLine(bestSteps);
        }
    }
}