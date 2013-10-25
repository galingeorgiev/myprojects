using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Minesweeper
    {
        public static void Main(string[] args)
        {
            const int MAX = 35;
            string command = string.Empty;
            char[,] playfield = CreatePlayfield();
            char[,] bombs = PutBombs();
            int countResult = 0;
            bool explosionGameOver = false;
            List<Points> champions = new List<Points>(6);
            int row = 0;
            int col = 0;
            bool isGameOver = true;
            bool isPlayfieldCleared = false;

            do
            {
                if (isGameOver)
                {
                    Console.WriteLine("Lets play game 'Minesweeper'. Try your luck to find all fields without mine." +
                                      "Command 'top' show ranking, 'restart' start new game, 'exit' close application");
                    DrawPlayField(playfield);
                    isGameOver = false;
                }

                Console.Write("Write row and col separeted with space: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= playfield.GetLength(0) &&
                        col <= playfield.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                
                switch (command)
                {
                    case "top":
                        ShowRankList(champions);
                        break;
                    case "restart":
                        playfield = CreatePlayfield();
                        bombs = PutBombs();
                        DrawPlayField(playfield);
                        explosionGameOver = false;
                        isGameOver = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                YourTurn(playfield, bombs, row, col);
                                countResult++;
                            }

                            if (MAX == countResult)
                            {
                                isPlayfieldCleared = true;
                            }
                            else
                            {
                                DrawPlayField(playfield);
                            }
                        }
                        else
                        {
                            explosionGameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command.\n");
                        break;
                }

                if (explosionGameOver)
                {
                    DrawPlayField(bombs);
                    Console.Write("\nBooooom! Game over! Result: {0} points.\nEnter your name: ", countResult);
                    string playerName = Console.ReadLine();
                    Points points = new Points(playerName, countResult);
                    if (champions.Count < 5)
                    {
                        champions.Add(points);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Point < points.Point)
                            {
                                champions.Insert(i, points);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Points r1, Points r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Points r1, Points r2) => r2.Point.CompareTo(r1.Point));
                    ShowRankList(champions);

                    playfield = CreatePlayfield();
                    bombs = PutBombs();
                    countResult = 0;
                    explosionGameOver = false;
                    isGameOver = true;
                }

                if (isPlayfieldCleared)
                {
                    Console.WriteLine("\nWell done! Find 35 cells without blood.");
                    DrawPlayField(bombs);
                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    Points currentPlayerPoints = new Points(name, countResult);
                    champions.Add(currentPlayerPoints);
                    ShowRankList(champions);
                    playfield = CreatePlayfield();
                    bombs = PutBombs();
                    countResult = 0;
                    isPlayfieldCleared = false;
                    isGameOver = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria!\nBye.");
            Console.Read();
        }

        private static void ShowRankList(List<Points> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, points[i].Name, points[i].Point);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty rank list!\n");
            }
        }

        private static void YourTurn(char[,] playField, char[,] bombs, int row, int col)
        {
            char numberOfBombs = NumberOfBombsArround(bombs, row, col);
            bombs[row, col] = numberOfBombs;
            playField[row, col] = numberOfBombs;
        }

        private static void DrawPlayField(char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayfield()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PutBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] playField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> listOfBombs = new List<int>();
            while (listOfBombs.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!listOfBombs.Contains(randomNumber))
                {
                    listOfBombs.Add(randomNumber);
                }
            }

            // Put bombs in playfield
            foreach (int bombsPosition in listOfBombs)
            {
                int col = bombsPosition / cols;
                int row = bombsPosition % cols;
                if (row == 0 && bombsPosition != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playField[col, row - 1] = '*';
            }

            return playField;
        }

        private static char NumberOfBombsArround(char[,] playField, int row, int col)
        {
            int numberOfMines = 0;
            int palyFieldsRows = playField.GetLength(0);
            int playFieldsCols = playField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playField[row - 1, col] == '*')
                { 
                    numberOfMines++; 
                }
            }

            if (row + 1 < palyFieldsRows)
            {
                if (playField[row + 1, col] == '*')
                { 
                    numberOfMines++; 
                }
            }

            if (col - 1 >= 0)
            {
                if (playField[row, col - 1] == '*')
                { 
                    numberOfMines++;
                }
            }

            if (col + 1 < playFieldsCols)
            {
                if (playField[row, col + 1] == '*')
                { 
                    numberOfMines++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (playField[row - 1, col - 1] == '*')
                { 
                    numberOfMines++; 
                }
            }

            if ((row - 1 >= 0) && (col + 1 < playFieldsCols))
            {
                if (playField[row - 1, col + 1] == '*')
                { 
                    numberOfMines++; 
                }
            }

            if ((row + 1 < palyFieldsRows) && (col - 1 >= 0))
            {
                if (playField[row + 1, col - 1] == '*')
                { 
                    numberOfMines++; 
                }
            }

            if ((row + 1 < palyFieldsRows) && (col + 1 < playFieldsCols))
            {
                if (playField[row + 1, col + 1] == '*')
                { 
                    numberOfMines++; 
                }
            }

            return char.Parse(numberOfMines.ToString());
        }
    }
}