namespace Matrix.Utils
{
    using System;

    public static class MatrixUtils
    {
        // This method no need to be unit tested
        public static int ReadInput()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 1 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return n;
        }

        public static int[,] FillMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            int currentNumberInMatrix = 1;
            int positionX = 0;
            int positionY = 0;
            int dx = 1;
            int dy = 1;

            MatrixUtils.FillHalfOfMatrix(matrix, n, ref dx, ref dy, ref positionX, ref positionY, ref currentNumberInMatrix);

            MatrixUtils.FindNextFreeCell(matrix, out positionX, out positionY);

            if (positionX != 0 && positionY != 0)
            {
                dx = 1;
                dy = 1;

                MatrixUtils.FillHalfOfMatrix(matrix, n, ref dx, ref dy, ref positionX, ref positionY, ref currentNumberInMatrix);
            }

            return matrix;
        }

        // This method no need to be unit tested
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void ChangeDirection(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirection = 0;

            for (int i = 0; i < dirX.Length; i++)
            {
                if (dirX[i] == dx && dirY[i] == dy)
                {
                    currentDirection = i;
                    break;
                }
            }

            if (currentDirection == 7)
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }

            dx = dirX[currentDirection + 1];
            dy = dirY[currentDirection + 1];
        }

        private static bool CheckDirection(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < dirX.Length; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindNextFreeCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }

        private static void FillHalfOfMatrix(int[,] matrix, int n, ref int dx, ref int dy, ref int positionX, ref int positionY, ref int currentNumberInMatrix)
        {
            while (true)
            {
                matrix[positionX, positionY] = currentNumberInMatrix;

                // Break if no possible way in current half.
                if (!CheckDirection(matrix, positionX, positionY))
                {
                    currentNumberInMatrix++;
                    break;
                }

                if (positionX + dx >= n || positionX + dx < 0 || positionY + dy >= n || positionY + dy < 0 || matrix[positionX + dx, positionY + dy] != 0)
                {
                    while (positionX + dx >= n || positionX + dx < 0 || positionY + dy >= n || positionY + dy < 0 || matrix[positionX + dx, positionY + dy] != 0)
                    {
                        ChangeDirection(ref dx, ref dy);
                    }
                }

                positionX += dx;
                positionY += dy;
                currentNumberInMatrix++;
            }
        }
    }
}
