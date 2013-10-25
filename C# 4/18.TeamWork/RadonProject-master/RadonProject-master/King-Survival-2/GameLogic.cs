namespace KingSurvival
{
    using System;

    public class GameLogic
    {
        // game objects
        // TODO: Move them to different class
        GameBoard KingSurvivalGameBoard = new GameBoard();
        PawnA firstPawn = new PawnA();
        PawnB secondPawn = new PawnB();
        PawnC thirdPawn = new PawnC();
        PawnD fourthPawn = new PawnD();

        // fileds
        private int movementsCounter = 0;
        private bool gameIsFinished = false;

        // properties
        public bool GameIsFinished
        {
            get
            {
                return this.gameIsFinished;
            }

            set
            {
                this.gameIsFinished = value;
            }
        }

        public int MovementsCounter
        {
            get
            {
                return this.movementsCounter;
            }

            set
            {
                this.movementsCounter = value;
            }
        }

        // methods
        public void InteractWithUser()
        {
            if (this.GameIsFinished)
            {
                Console.WriteLine("Game is finished!");
                return;
            }
            else
            {
                if (this.MovementsCounter % 2 == 0)
                {
                    KingSurvivalGameBoard.ShowBoard();
                    ProcessKingSide();
                }
                else
                {
                    KingSurvivalGameBoard.ShowBoard();
                    ProcessPawnSide();
                }
            }
        }

        public bool CheckPlayerInput(string checkedString)
        {
            char startLetter = checkedString[0];
            bool hasAnEqual = false;
            if (this.MovementsCounter % 2 == 0) // King turn
            {
                return this.ChechInput(checkedString, King.ValidKingInputs, ref hasAnEqual);
            }
            else // PawnsTurn
            {
                switch (startLetter)
                {
                    case 'A':
                        return ChechInput(checkedString, firstPawn.ValidPawnInputs, ref hasAnEqual);

                    case 'B':
                        return ChechInput(checkedString, secondPawn.ValidPawnInputs, ref hasAnEqual);

                    case 'C':
                        return ChechInput(checkedString, thirdPawn.ValidPawnInputs, ref hasAnEqual);

                    case 'D':
                        return ChechInput(checkedString, fourthPawn.ValidPawnInputs, ref hasAnEqual);

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command name!");
                        Console.ResetColor();
                        return false;
                }
            }
        }

        private bool ChechInput(string checkedString, string[] currentFigureValidInput, ref bool hasAnEqual)
        {
            int[] equal = new int[currentFigureValidInput.Length];
            for (int i = 0; i < currentFigureValidInput.Length; i++)
            {
                string reference = currentFigureValidInput[i];
                int result = checkedString.CompareTo(reference);
                if (result != 0)
                {
                    equal[i] = 0;
                }
                else
                {
                    equal[i] = 1;
                }
            }

            for (int i = 0; i < currentFigureValidInput.Length; i++)
            {
                if (equal[i] == 1)
                {
                    hasAnEqual = true;
                }
            }

            if (!hasAnEqual)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command name!");
                Console.ResetColor();
            }

            return hasAnEqual;
        }

        public bool CheckAndProcess(string checkedInput)
        {
            bool isCommandNameCorrect = CheckPlayerInput(checkedInput);
            if (isCommandNameCorrect)
            {
                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':
                        return MovePawn(checkedInput, 'A');

                    case 'B':
                        return MovePawn(checkedInput, 'B');

                    case 'C':
                        return MovePawn(checkedInput, 'C');

                    case 'D':
                        return MovePawn(checkedInput, 'D');

                    case 'K':
                        if (checkedInput[1] == 'U')
                        {
                            if (checkedInput[2] == 'L')
                            {
                                MoveKing('U', 'L');
                            }
                            else
                            {
                                MoveKing('U', 'R');
                            }

                            return true;
                        }
                        else
                        {
                            if (checkedInput[2] == 'L')
                            {
                                MoveKing('D', 'L');
                            }
                            else
                            {
                                MoveKing('D', 'R');
                            }

                            return true;
                        }

                    default:
                        Console.WriteLine("Sorry, there are some errors, but I can't tell you anything! You broked my program!");
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void MoveKing(char firstDirection, char secondDirection)
        {
            // ==KDR
            int[] oldCoordinates = new int[2];
            oldCoordinates[0] = King.KingPosition[0];
            oldCoordinates[1] = King.KingPosition[1];
            int[] coords = new int[2];
            coords = CheckNextKingPosition(oldCoordinates, firstDirection, secondDirection);
            if (coords != null)
            {
                King.KingPosition[0] = coords[0];
                King.KingPosition[1] = coords[1];
            }
        }

        private bool MovePawn(string checkedInput, char figure)
        {
            int pawnsPositionFirstCoord = (int)figure - (int)'A';
            if (checkedInput[2] == 'L')
            {
                int[] oldCoordinates = new int[2];

                // This is just temporarery. It will be moved to the Pawns Classes
                if (figure == 'A')
                {
                    oldCoordinates[0] = firstPawn.PawnsPosition[0, 0];
                    oldCoordinates[1] = firstPawn.PawnsPosition[0, 1];
                }
                else if (figure == 'B')
                {
                    oldCoordinates[0] = secondPawn.PawnsPosition[0, 0];
                    oldCoordinates[1] = secondPawn.PawnsPosition[0, 1];
                }
                else if (figure == 'C')
                {
                    oldCoordinates[0] = thirdPawn.PawnsPosition[0, 0];
                    oldCoordinates[1] = thirdPawn.PawnsPosition[0, 1];
                }
                else if (figure == 'D')
                {
                    oldCoordinates[0] = fourthPawn.PawnsPosition[0, 0];
                    oldCoordinates[1] = fourthPawn.PawnsPosition[0, 1];
                }

                int[] coords = new int[2];
                coords = CheckNextPownPosition(oldCoordinates, 'L', figure);
                if (coords != null)
                {
                    if (figure == 'A')
                    {
                        firstPawn.PawnsPosition[0, 0] = coords[0];
                        firstPawn.PawnsPosition[0, 1] = coords[1];
                    }
                    else if (figure == 'B')
                    {
                        secondPawn.PawnsPosition[0, 0] = coords[0];
                        secondPawn.PawnsPosition[0, 1] = coords[1];
                    }
                    else if (figure == 'C')
                    {
                        thirdPawn.PawnsPosition[0, 0] = coords[0];
                        thirdPawn.PawnsPosition[0, 1] = coords[1];
                    }
                    else if (figure == 'D')
                    {
                        fourthPawn.PawnsPosition[0, 0] = coords[0];
                        fourthPawn.PawnsPosition[0, 1] = coords[1];
                    }
                }
            }
            else
            {
                // =='R'
                int[] oldCoordinates = new int[2];
                if (figure == 'A')
                {
                    oldCoordinates[0] = firstPawn.PawnsPosition[0, 0];
                    oldCoordinates[1] = firstPawn.PawnsPosition[0, 1];
                }
                else if (figure == 'B')
                {
                    oldCoordinates[0] = secondPawn.PawnsPosition[0, 0];
                    oldCoordinates[1] = secondPawn.PawnsPosition[0, 1];
                }
                else if (figure == 'C')
                {
                    oldCoordinates[0] = thirdPawn.PawnsPosition[0, 0];
                    oldCoordinates[1] = thirdPawn.PawnsPosition[0, 1];
                }
                else if (figure == 'D')
                {
                    oldCoordinates[0] = fourthPawn.PawnsPosition[0, 0];
                    oldCoordinates[1] = fourthPawn.PawnsPosition[0, 1];
                }

                int[] coords = new int[2];
                coords = CheckNextPownPosition(oldCoordinates, 'R', figure);
                if (coords != null)
                {
                    if (figure == 'A')
                    {
                        firstPawn.PawnsPosition[0, 0] = coords[0];
                        firstPawn.PawnsPosition[0, 1] = coords[1];
                    }
                    else if (figure == 'B')
                    {
                        secondPawn.PawnsPosition[0, 0] = coords[0];
                        secondPawn.PawnsPosition[0, 1] = coords[1];
                    }
                    else if (figure == 'C')
                    {
                        thirdPawn.PawnsPosition[0, 0] = coords[0];
                        thirdPawn.PawnsPosition[0, 1] = coords[1];
                    }
                    else if (figure == 'D')
                    {
                        fourthPawn.PawnsPosition[0, 0] = coords[0];
                        fourthPawn.PawnsPosition[0, 1] = coords[1];
                    }
                }
            }

            return true;
        }

        public void ProcessKingSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("Please enter king's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
                else
                {
                    input = input.ToUpper();
                    isExecuted = CheckAndProcess(input); 
                }
            }

            InteractWithUser();
        }

        public void ProcessPawnSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("Please enter pawn's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
                else
                {
                    input = input.ToUpper();
                    isExecuted = CheckAndProcess(input);
                }
            }

            InteractWithUser();
        }

        public void CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine("King wins in {0} moves!", this.MovementsCounter / 2);
                this.GameIsFinished = true;
            }
        }

        public int[] CheckNextPownPosition(int[] currentCoordinates, char checkDirection, char currentPawn)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] newCoords = new int[2];
            if (checkDirection == 'L')
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];

                return this.CalcNextPawnPosition(newCoords, currentCoordinates, currentPawn, 0);
            }
            else
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];

                return this.CalcNextPawnPosition(newCoords, currentCoordinates, currentPawn, 1);
            }
        }

        private int[] CalcNextPawnPosition(int[] newCoords, int[] currentCoordinates, char currentPawn, int pawnSecondCoord)
        {
            if (KingSurvivalGameBoard.CheckPositionInBoard(newCoords) && KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = KingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
                KingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] = sign;
                this.MovementsCounter++;
                switch (currentPawn)
                {
                    case 'A':
                        Pawn.PawnExistingMoves[0, 0] = true;
                        Pawn.PawnExistingMoves[0, 1] = true;
                        break;
                    case 'B':
                        Pawn.PawnExistingMoves[1, 0] = true;
                        Pawn.PawnExistingMoves[1, 1] = true;
                        break;
                    case 'C':
                        Pawn.PawnExistingMoves[2, 0] = true;
                        Pawn.PawnExistingMoves[2, 1] = true;
                        break;
                    case 'D':
                        Pawn.PawnExistingMoves[3, 0] = true;
                        Pawn.PawnExistingMoves[3, 1] = true;
                        break;
                    default:
                        Console.WriteLine("ERROR!");
                        break;
                }

                return newCoords;
            }
            else
            {
                bool allAreFalse = true;
                switch (currentPawn)
                {
                    case 'A':
                        Pawn.PawnExistingMoves[0, pawnSecondCoord] = false;
                        break;
                    case 'B':
                        Pawn.PawnExistingMoves[1, pawnSecondCoord] = false;
                        break;
                    case 'C':
                        Pawn.PawnExistingMoves[2, pawnSecondCoord] = false;
                        break;
                    case 'D':
                        Pawn.PawnExistingMoves[3, pawnSecondCoord] = false;
                        break;
                    default:
                        Console.WriteLine("ERROR!");
                        break;
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (Pawn.PawnExistingMoves[i, j] == true)
                        {
                            allAreFalse = false;
                        }
                    }
                }

                if (allAreFalse)
                {
                    this.GameIsFinished = true;
                    Console.WriteLine("King wins!");
                    this.GameIsFinished = true;
                    return null;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }

        public int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displacementDownLeft = { 1, -2 };
            int[] displacementDownRight = { 1, 2 };
            int[] displacementUpLeft = { -1, -2 };
            int[] displacementUpRight = { -1, 2 };

            string direction = firstDirection.ToString() + secondDirection.ToString();
            switch (direction)
            {
                case "UL":
                    return CheckKingAvailableMove(currentCoordinates, displacementUpLeft);
                case "UR":
                    return CheckKingAvailableMove(currentCoordinates, displacementUpRight);
                case "DL":
                    return CheckKingAvailableMove(currentCoordinates, displacementDownLeft);
                case "DR":
                    return CheckKingAvailableMove(currentCoordinates, displacementDownRight);
                default:
                    return null;
            }
        }

        private int[] CheckKingAvailableMove(int[] currentCoordinates, int[] displacementDirection)
        {
            int[] newCoords = new int[2];
            newCoords[0] = currentCoordinates[0] + displacementDirection[0];
            newCoords[1] = currentCoordinates[1] + displacementDirection[1];
            if (KingSurvivalGameBoard.CheckPositionInBoard(newCoords) && KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = KingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]];
                KingSurvivalGameBoard.Board[currentCoordinates[0], currentCoordinates[1]] = ' ';
                KingSurvivalGameBoard.Board[newCoords[0], newCoords[1]] = sign;
                this.MovementsCounter++;

                for (int i = 0; i < 4; i++)
                {
                    King.KingExistingMoves[i] = true;
                }

                CheckForKingExit(newCoords[0]);
                return newCoords;
            }
            else
            {
                King.KingExistingMoves[0] = false;
                bool allAreFalse = true;
                for (int i = 0; i < 4; i++)
                {
                    if (King.KingExistingMoves[i] == true)
                    {
                        allAreFalse = false;
                    }
                }

                if (allAreFalse)
                {
                    this.GameIsFinished = true;
                    Console.WriteLine("King loses!");
                    return null;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return null;
            }
        }
    }
}