/* We are given a labyrinth of size N x N. Some of its cells are
 * empty (0) and some are full (x). We can move from an empty cell 
 * to another empty cell if they share common wall. Given a starting 
 * position (*) calculate and fill in the array the minimal distance 
 * from this position to any other cell in the array. Use "u" for all 
 * unreachable cells. */

namespace PathInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class Labyrinth
    {
        private static Queue<Tuple<int, int, int>> positionForCheck = new Queue<Tuple<int, int, int>>();
        private static bool isAddedForCheck = false; // Use this variable if we have one way next will be added in 'positionForCheck'.

        public static void FindPath(string[,] labyrint, int yPos, int xPos, int counter)
        {
            bool isXCorrect = xPos < labyrint.GetLength(0) || xPos > 0;
            bool isYCorrect = yPos < labyrint.GetLength(1) || yPos > 0;
            if (!(isXCorrect || isYCorrect))
            {
                return;
            }

            // Check is next positions are posible way.
            // If we have more from one position we go to first with recursion and add other for check later.
            // This is wave efect.
            // Up
            if (yPos >= 1 && labyrint[yPos - 1, xPos] == "0")
            {
                if (isAddedForCheck)
                {
                    Tuple<int, int, int> currCoords = new Tuple<int, int, int>(yPos, xPos, counter);
                    positionForCheck.Enqueue(currCoords);
                }
                else
                {
                    isAddedForCheck = true;
                }
            }

            // Right
            if (xPos < labyrint.GetLength(0) - 1 && labyrint[yPos, xPos + 1] == "0")
            {
                if (isAddedForCheck)
                {
                    Tuple<int, int, int> currCoords = new Tuple<int, int, int>(yPos, xPos, counter);
                    positionForCheck.Enqueue(currCoords);
                }
                else
                {
                    isAddedForCheck = true;
                }
            }

            // Down
            if (yPos < labyrint.GetLength(1) - 1 && labyrint[yPos + 1, xPos] == "0")
            {
                if (isAddedForCheck)
                {
                    Tuple<int, int, int> currCoords = new Tuple<int, int, int>(yPos, xPos, counter);
                    positionForCheck.Enqueue(currCoords);
                }
                else
                {
                    isAddedForCheck = true;
                }
            }

            // Left
            if (xPos >= 1 && labyrint[yPos, xPos - 1] == "0")
            {
                if (isAddedForCheck)
                {
                    Tuple<int, int, int> currCoords = new Tuple<int, int, int>(yPos, xPos, counter);
                    positionForCheck.Enqueue(currCoords);
                }
                else
                {
                    isAddedForCheck = true;
                }
            }

            isAddedForCheck = false;

            // Check is position free and is in matrix.
            // Up
            if (yPos >= 1 && labyrint[yPos - 1, xPos] == "0")
            {
                counter++;
                labyrint[yPos - 1, xPos] = counter.ToString();
                FindPath(labyrint, yPos - 1, xPos, counter);
                counter--;
                return;
            }

            // Right
            if (xPos < labyrint.GetLength(0) - 1 && labyrint[yPos, xPos + 1] == "0")
            {
                counter++;
                labyrint[yPos, xPos + 1] = counter.ToString();
                FindPath(labyrint, yPos, xPos + 1, counter);
                counter--;
                return;
            }
            
            // Down
            if (yPos < labyrint.GetLength(1) - 1 && labyrint[yPos + 1, xPos] == "0")
            {
                counter++;
                labyrint[yPos + 1, xPos] = counter.ToString();
                FindPath(labyrint, yPos + 1, xPos, counter);
                counter--;
                return;
            }

            // Left
            if (xPos >= 1 && labyrint[yPos, xPos - 1] == "0")
            {
                counter++;
                labyrint[yPos, xPos - 1] = counter.ToString();
                FindPath(labyrint, yPos, xPos - 1, counter);
                counter--;
                return;
            }

            // If we does not have way we get first added way and start recursion again.
            if (positionForCheck.Count > 0)
            {
                Tuple<int, int, int> currElementCoord = positionForCheck.Dequeue();
                FindPath(labyrint, currElementCoord.Item1, currElementCoord.Item2, currElementCoord.Item3);
            }
        }

        public static void Main()
        {
            string[,] lab = new string[,]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" }
            };

            FindPath(lab, 2, 1, 0);

            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    if (lab[i, j] == "0")
                    {
                        lab[i, j] = "u";
                    }

                    Console.Write("{0}", lab[i, j].PadLeft(5));
                }

                Console.WriteLine();
            }
        }
    }
}